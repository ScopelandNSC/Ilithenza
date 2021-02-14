import React, { Component, Fragment, useState } from 'react';
import PageBody from './PageBody'

export class Home extends Component {
  static displayName = Home.name;

    render() {
    return (
      <Fragment>
            <h1>Hello, Ilithenza.App!</h1>
            <PageBody/>
      </Fragment>
    );
  }
}
