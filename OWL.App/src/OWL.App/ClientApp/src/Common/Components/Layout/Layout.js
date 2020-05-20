import React, { Component } from 'react';
import { Container } from 'reactstrap';
import HeaderBar from '../HeaderBar/HeaderBar'
import SidePanel from '../SidePanel/SidePanel'
import './Layout.css'

export class Layout extends Component {
    static displayName = Layout.name;

    render () {
        return (
            <div>
                <HeaderBar
                    headerbarTitle="HeaderBar Test"
                />
                <SidePanel
                    sidepanelTitle="SidePanel Test"
                    sidepanelOpen={true}
                />
                <Container className={true ? 'rd-container' : 'rd-container rd-container--sidepanel-hidden'}>
                    {this.props.children}
                </Container>
            </div>
        );
    }
}
