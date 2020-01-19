import React, { Component , Fragment} from 'react';
import { Route } from 'react-router';
import { Layout } from './Common/Components/Layout';
import { Home } from './Common/Components/Home';
import { Button } from 'reactstrap';
import PlayerService from './Players/Services/PlayerService'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
      <Fragment>
      <Layout>
        <Route exact path='/' component={Home} />
      </Layout>
        <Button onClick={
            () => {
                const playerService = new PlayerService();
                var test = playerService.getPlayer(8747);
            }
        }

              />
      </Fragment>

    );
  }
}
