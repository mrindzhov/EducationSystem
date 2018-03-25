import React from 'react';
import { Link } from 'react-router-dom';
import './LinkButton.css';

const LinkButton = (props) => (
  <Link to={props.to} className="btn btn-full">
    {props.children}
  </Link>
);

export default LinkButton;
