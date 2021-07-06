import React, { Component } from 'react';
import { Davidyc } from './Davidyc';
import { Counter } from './Counter';
import { QRCode } from './QRCode';
import { Photos } from './Photos';

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
          <Photos />
          <hr/>
          <Counter />
         
      </div>
    );
  }
}
