import React from 'react';
import './SvgIcons.scss';

const EditIcon = (props) => (
    <svg version="1.1" fill={props.fill} xmlns="http://www.w3.org/2000/svg" width={props.width} height={props.height} viewBox="0 0 24 24">
        <title>Icon-Edit</title>
        <desc>Created with Sketch.</desc>
        <g id="Icon-Edit">
	       <path id="Shape" className="icon-edit" d="M19,4H5C4.4,4,4,4.4,4,5v14c0,0.6,0.4,1,1,1h14c0.6,0,1-0.4,1-1V5C20,4.4,19.6,4,19,4L19,4z M18,18
	    	    H6V6h12V18L18,18z"/>
	            <polygon className="icon-edit" points="15,11 13,9 8,14 8,16 10,16 	"/>
	        <path className="icon-edit" d="M16.7,9.3c0.4-0.4,0.4-1,0-1.4l-0.6-0.6c-0.4-0.4-1-0.4-1.4,0L14,8l2,2L16.7,9.3L16.7,9.3z"/>
        </g>
    </svg>
);

export default EditIcon;