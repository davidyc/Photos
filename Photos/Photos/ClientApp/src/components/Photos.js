import React, { Component } from 'react';
import axios  from 'axios';


export class Photos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Images: [],
            selectedFile: null
        };     
    } 

    fileSelectedHandler = event => {        
        this.selectedFile = event.target.files[0];        
    };

    fileUploadHandler = () => {
        const fd = new FormData();          
        fd.append('body', this.selectedFile,  this.selectedFile.name)
        axios.post("photos", fd);
    }

    componentDidMount() {
        this.getAllPhotos();
    }

    render() {       
        return (   
            <div>
                <div>
                    <input type="file" onChange={this.fileSelectedHandler} />
                    <button onClick={this.fileUploadHandler }>Upload</button>
                </div>

                <h1>All photos</h1>  
                {this.state.Images.map(i => (<img src={"data:image/png;base64," + i} />))}        
            </div>
        );
    }  

    async getAllPhotos() {
        const response = await fetch('Photos');
        const data = await response.json();        
        this.setState({ Images: data });        
     
    }
}


