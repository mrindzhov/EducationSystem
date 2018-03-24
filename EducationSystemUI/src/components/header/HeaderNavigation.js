import React from 'react';
import { Link } from 'react-router-dom';
import './HeaderNavigation.css';

const HeaderNavigation = () => (
  <div className='header-navigation'>
    <ul>
        <li><Link to="#">Logo</Link></li>
        <li><Link to="#">Dashboard</Link></li>
        <li><Link to="#">Profile</Link></li>
        <li><Link to="#">Browse Projects</Link></li>
    </ul>
  </div>
);

export default HeaderNavigation;