import React from 'react';
import PropTypes from 'prop-types';
import './HeaderBar.css';

function HeaderBar(props) {

    return (
        <div   className={'rd-headerbar'}>
            <div>
                <div>
                    {props.headerbarTitle}
                </div>
            </div>
        </div>
    );
}

HeaderBar.propTypes = {
    headerbarTitle: PropTypes.string.isRequired,
};

export default HeaderBar;
