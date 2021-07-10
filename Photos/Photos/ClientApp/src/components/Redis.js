import React, { Component } from 'react';

export class Redis extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Table : []
        }
    }

    componentDidMount() {
        this.GetAllEvents();
    }

    render() {
       
        return (
            <div>
                <h1>Data from Redis</h1>  
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Event</th>
                            <th>Date</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.Table.map(row =>
                            <tr>
                                <td>{row.id}</td>
                                <td>{row.nameEvent}</td>
                                <td>{row.dateEvent}</td>
                                <td>{row.descriptionEvent}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }  



    async GetAllEvents() {        
        const response = await fetch('/api/Redis');
        const data = await response.json();
        this.setState({ Table : data });
    }
    
}
