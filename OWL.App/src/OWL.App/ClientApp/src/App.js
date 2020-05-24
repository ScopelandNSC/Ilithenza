import React, { Fragment, useState} from 'react';
import { Route } from 'react-router';
import { Layout } from './Common/Components/Layout/Layout';
import { Home } from './Common/Components/Home';

export default function App() {
    return (
      <Fragment>
          <Layout>
            <Route exact path='/' component={Home} />
          </Layout>
      </Fragment>
    );
}