import React, { Component } from 'react';

export class Photos extends Component {
    constructor(props) {
        super(props);
        this.state = { Images: []};      
    }


    componentDidMount() {
        this.getAllPhotos();
    }



    render() {       
        return (
            <div>
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
