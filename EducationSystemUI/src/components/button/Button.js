import React from 'react';
import { Link } from 'react-router-dom';
import './Button.css';

const Button = (props) => (
  <button href="#" className="btn btn-full">
    {props.children}
  </button>
);

export default Button;
