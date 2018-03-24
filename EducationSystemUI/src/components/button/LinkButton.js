import React from 'react';
import { Link } from 'react-router-dom';
import './LinkButton.css';

const LinkButton = (props) => (
  <a href="#" className="btn btn-full">
    {props.children}
  </a>
);

export default LinkButton;
