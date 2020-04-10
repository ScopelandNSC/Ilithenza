import React, { Fragment, useState} from 'react';
import { Route } from 'react-router';
import { Layout } from './Common/Components/Layout/Layout';
import { Home } from './Common/Components/Home';
import { Button } from 'reactstrap';
import PlayerService from './Players/Services/PlayerService'

export default function App() {

    return (
      <Fragment>
          <Layout>
            <Route exact path='/' component={Home} />
          </Layout>
          <Button onClick={
            async () => {
                const playerService = new PlayerService();
                var player = await playerService.getPlayer(8747);
            }
          }/>
      </Fragment>
    );
}