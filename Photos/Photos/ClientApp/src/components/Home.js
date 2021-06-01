import React, { Component } from 'react';
import { Davidyc } from './Davidyc';
import { FetchData } from './FetchData';
import { Counter } from './Counter';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
      <hr/>
      <Davidyc />
      <hr/>
      <FetchData/>
      <hr/>
      <Counter/>
      </div>
    );
  }
}
