import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Game } from './components/Game';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route component={Game} />
      </Layout>
    );
  }
}
