import React, { Component } from 'react';
import { Davidyc } from './Davidyc';
import { FetchData } from './FetchData';
import { Counter } from './Counter';
import { QRCode } from './QRCode';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
      <hr/>
      <Davidyc />
      <hr/>
      <QRCode />
      <hr />
      <FetchData/>
      <hr/>
      <Counter/>
      </div>
    );
  }
}
