import React, { Component, Fragment, useState } from 'react';
import { Button } from 'reactstrap';
import PlayerService from '../../Players/Services/PlayerService'

function PageBody(props) {

    const [player, setPlayer] = useState({}); 

    return (
      <Fragment>
            <Button onClick={
                async () => {
                    const playerService = new PlayerService();
                    setPlayer(await playerService.getPlayer(8747));
                }
            } />
            <div>
                {player.username}
            </div>
      </Fragment>
    );

}

export default PageBody;
