import React, { Component } from 'react';

export class QRCode extends Component {

    constructor(props) {
        super(props);
        this.state = { QR: null, loading: true };
    }

    componentDidMount() {
        this.testData("XXXXX")
    }

    //var base64Image;

    render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <img src={"data:image/png;base64," + this.state.QR.qrCode} alt={"data:image/png;base64," + this.state.QR.qrCode} />

        return (
            <div>             
                <p>{contents}</p>
            </div>
        );
    }

    async testData(text) {
        const response = await fetch('QRCode/?text=' + text);
        const data = await response.json();
        this.setState({ QR: data, loading: false });
    }
}
