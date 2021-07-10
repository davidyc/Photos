import React, { Component } from 'react';
import axios from 'axios';

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
        axios.post("/api/photos", fd)
            .then((res) => {
                this.setState({ loading: false, button: true }); 
                window.location.reload();
            });     
    }

    fileDeleteHandler = (InFileName) => {        
        axios.delete("/api/photos/"+ InFileName )
            .then((res) => {
                window.location.reload();
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
                {this.state.Images.map((i) => {
                    return (
                        <div class="card" >
                            <button onClick={()=> this.fileDeleteHandler(i.name)} >Delete</button>
                            <img class="card-img-top" src={"data:image/png;base64," + i.bytesArray} alt={i.name} />
                            <div class="card-body">
                                <p class="card-text">{i.name}</p>
                            </div>
                        </div>
                    )
                })}                  
            </div>
        );
    }  

    async getAllPhotos() {
        const response = await fetch('/api/Photos');
        const data = await response.json();        
        this.setState({ Images: data });        
    }
}


