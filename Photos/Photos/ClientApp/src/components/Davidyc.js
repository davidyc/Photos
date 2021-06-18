import React, { Component } from 'react';

export class Davidyc extends Component {
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
        alert(data)
        //this.setState({ forecasts: data, loading: false });
    }
}
