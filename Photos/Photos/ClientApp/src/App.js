import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { Davidyc } from './components/Davidyc';
import { QRCode } from './components/QRCode';
import { Photos } from './components/Photos';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/davidyc' component={Davidyc} />
            <Route path='/qrcode' component={QRCode} />
            <Route path='/photos' component={Photos} />
      </Layout>
    );
  }
}
