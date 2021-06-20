import React, { Component } from 'react';

export class Davidyc extends Component {
    constructor(props) {
        super(props);
        this.state = { QR: '', loading: false, Text: 'It is test text, please add here your text and click generate button' };

       
    }



    componentDidMount() {
        this.test();
    }



    render() {
       
        return (
            <div>
                <h1>Davidyc</h1>  
                <img src={"data:image/png;base64," + this.state.QR.qrCode} />
            </div>
        );
    }  

    async test() {
        const response = await fetch('Test');
        const data = await response.json();
       
        
        this.setState({ QR: data });
    }
}
