import React, { Component } from 'react';

export class Davidyc extends Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.test();
    }

    render() {
       
        return (
            <div>
                <h1>Davidyc</h1>      
            </div>
        );
    }  



    async test() {
        const response = await fetch('Test');
        const data = await response.json();
        this.setState({ Images: data });
        console.log(this.state.Images)
    }
    
}
