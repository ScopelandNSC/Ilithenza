import React from 'react';
import PropTypes from 'prop-types';
import ArrowLeftIcon from '../../Icons/ArrowLeft';
import useBooleanToggle from '../../Hooks/UseBooleanToggle'
import { Button } from 'reactstrap';
import './SidePanel.css';

function SidePanel(props) {

    const showPanel = useBooleanToggle(true);

    return (
        <div  data-testid="sidepanel" className={showPanel.value ? 'sidepanel' : 'sidepanel sidepanel--hide'}>
            <div>
                <Button className="sidepanel-toggle-btn"
                    onClick={() => showPanel.onToggle()}
                >
                    <ArrowLeftIcon fill="#474547" width="32px" height="32px" />
                </Button>
                
            <div>
                {props.sidepanelTitle}
            </div>
                {props.headerChildren}
            </div>
            <div>

            </div>

        </div>

    );
}

SidePanel.propTypes = {
    sidepanelOpen: PropTypes.bool.isRequired,
    sidepanelTitle: PropTypes.string.isRequired,
    sidepanelStaticContent: PropTypes.node,
    sidepanelScrollableContent: PropTypes.node,
    sidepanelFooter: PropTypes.node,
    headerChildren: PropTypes.node
};

export default SidePanel;
