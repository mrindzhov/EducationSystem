import React from 'react';
import './ModalButton.css';

const ModalButton = (props) => (
  <button className="btn-modal" {...props}>
    {props.children}
  </button>
);

export default ModalButton;
