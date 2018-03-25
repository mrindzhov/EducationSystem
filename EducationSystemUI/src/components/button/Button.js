import React from 'react';
import './Button.css';

const Button = (props) => (
  <button className="btn btn-full" {...props}>
    {props.children}
  </button>
);

export default Button;
