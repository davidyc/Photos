import React, { Component } from 'react';

export class QRCode extends Component {

    constructor(props) {
        super(props);
        this.state = { QR: '', loading: false, Text: 'It is test text, please add here your text and click generate button' };

        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event) {
        this.setState({Text: event.target.value});
    }


    render() {
        return (
            <div>    
                <div className="input-group">
                    <div className="input-group-prepend">
                        <span className="input-group-text" id="basic-addon">
                            <i className="fas fa-pencil-alt prefix"></i>
                        </span>
                    </div>
                    <textarea className="form-control" id="exampleFormControlTextarea1" 
                    value={this.state.Text} onChange={this.handleChange}
                    rows="10" />
                </div>

                <div style={{ marginTop: "60px" }}>
                    {this.state.Text && (
                   
                        <button className="button" onClick={this.fetchData} disabled={this.state.loading}>
                            {this.state.loading && (
                                <i
                                    className="fa fa-refresh fa-spin"
                                    style={{ marginRight: "5px" }}
                                />
                            )}
                            {this.state.loading && <span>QR Code is generating</span>}
                            {!this.state.loading && <span>Generate QR Code</span>}
                        </button>
                        )
                    }
                </div>
                {this.state.QR && (
                    <img src={"data:image/png;base64," + this.state.QR.qrCode} />
                    )               
                }                
            </div>
        );
    }

    fetchData = () => {
        this.setState({ loading: true });
        this.testData(this.state.Text)       
        setTimeout(() => {
            this.setState({ loading: false });
        }, 2000);
    };

    async testData(text) {
        const response = await fetch('/api/QRCode/?text=' + text);
        const data = await response.json();
        this.setState({ QR: data});
    }

}
