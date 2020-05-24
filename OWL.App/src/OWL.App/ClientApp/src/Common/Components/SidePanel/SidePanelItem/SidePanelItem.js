import React from 'react';
import PropTypes from 'prop-types';

import './SidePanelItem.css';

function SidePanelItem(props) {
    return (
        <div>
            {
                props.category === props.type &&
                <div data-testid="sidepanelitem" className="sidepanel-item sidepanel-item--category">
                        {props.type}
                    </div>
            }
            {
                props.category !== props.type &&
                <div data-testid="sidepanelitem" className="sidepanel-item sidepanel-item--sub">
                    {props.type}
                </div>
            }
        </div>
    );
}

SidePanelItem.propTypes = {
    category: PropTypes.string,
    type: PropTypes.string
};

export default SidePanelItem;
