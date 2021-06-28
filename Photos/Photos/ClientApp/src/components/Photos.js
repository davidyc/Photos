import React, { Component } from 'react';
import axios from 'axios';
import { Container, Row, Col } from 'reactstrap';

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

    fileDeleteHandler = (fileName) => {    
        axios.delete("photos", fileName)
            .then((res) => {
                alert("!");
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
                <Container>
                    <Row>                                     
                            {this.state.Images.map((i) => {
                                return(
                                    <Col xs="3">  
                                    <img
                                        src={"data:image/png;base64," + i.bytesArray}
                                        style={{ height: 400, width: 400 }}                      
                                        />
                                        <button onClick={this.fileDeleteHandler}>Delete</button>
                                    </Col>
                             )
                            })}                           
                    </Row>
                </Container>
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


