import React from 'react';
import PropTypes from 'prop-types';
import './MinimisedSidePanelItem.css';

function MinimisedSidePanelItem(props) {
    return (
        <div  data-testid="minisidepanelitem" className="mini-side-panel-item">
            { props.icon }
        </div>

    );
}

MinimisedSidePanelItem.propTypes = {
    icon: PropTypes.node,
    type: PropTypes.string
};

export default MinimisedSidePanelItem;
