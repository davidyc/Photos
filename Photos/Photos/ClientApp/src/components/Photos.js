import React, { Component } from 'react';
import axios  from 'axios';

const imgType = "image/jpeg";

export class Photos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Images: [],
            selectedFile: null,
            loading: false,
            imageinput: true,
            uploadButton: true
        };     
    } 

    fileSelectedHandler = event => {        
        this.selectedFile = event.target.files[0];
        if (this.selectedFile.type == imgType) {
            this.setState({ uploadButton: false })
        }
        else {
            alert("Only "+imgType)
        }        
    };

    fileUploadHandler = () => {
        const fd = new FormData();          
        fd.append('body', this.selectedFile, this.selectedFile.name);
        this.setState({ loading: true, button: false, uploadButton: true });
        axios.post("photos", fd)
            .then((res) => {
                this.setState({ loading: false, button: true });                
            });     
    }

    componentDidMount() {
        this.getAllPhotos();
    }

    render() {       
        return (   
            <div>
                <div>
                    <input type="file" onChange={this.fileSelectedHandler} disabled={this.state.loading}/>
                    <button className="button" onClick={this.fileUploadHandler} disabled={this.state.uploadButton}>
                            {this.state.loading && (
                                <i
                                    className="fa fa-refresh fa-spin"
                                    style={{ marginRight: "5px" }}
                                />
                            )}
                            {!this.state.loading && <span>Upload image</span>}
                            {this.state.loading && <span>Image is uploading</span>}
                    </button>                        
                </div>

                <h1>All photos</h1>  
                {this.state.Images.map(i => (
                    <img                       
                        src={"data:image/png;base64," + i}
                        style={{ height: 400, width: 400 }}
                    />
                    ))}        
            </div>
        );
    }  

    async getAllPhotos() {
        const response = await fetch('Photos');
        const data = await response.json();        
        this.setState({ Images: data });   
        console.log(this.state.Images)
     
    }
}


