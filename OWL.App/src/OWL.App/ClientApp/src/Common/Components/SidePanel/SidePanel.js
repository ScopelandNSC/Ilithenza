import React from 'react';
import PropTypes from 'prop-types';
import ArrowLeftIcon from '../../Icons/ArrowLeft'
import { Button } from 'reactstrap';
import './SidePanel.css';

function SidePanel(props) {

    function closeSidepanel(event) {
    }

    return (
        <div  data-testid="rd-sidepanel" className={props.sidepanelOpen ? 'rd-sidepanel' : 'rd-sidepanel rd-sidepanel--hide'}>
            <div>
                {props.showCloseButton && (
                    <Button
                        onClick={() => props.closeSidepanel()}
                    >
                        <ArrowLeftIcon fill="#474547" width="32px" height="32px" />
                    </Button>
                )}
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
    closeSidepanel: PropTypes.func.isRequired,
    sidepanelTitle: PropTypes.string.isRequired,
    sidepanelStaticContent: PropTypes.node,
    sidepanelScrollableContent: PropTypes.node,
    sidepanelFooter: PropTypes.node,
    headerChildren: PropTypes.node,
    showCloseButton: PropTypes.bool
};

export default SidePanel;
