import React from 'react';
import { Link } from 'react-router-dom';
import './HeaderNavigation.css';

const HeaderNavigation = () => (
  <div className='header-navigation'>
    <ul>
        <li><Link to="#"><i className="ion-ionic"></i></Link></li>
        <li><Link to="#">Dashboard</Link></li>
        <li><Link to="#">Profile</Link></li>
        <li><Link to="#">Browse</Link></li>
    </ul>
    <ul>
        <li><Link to="#">Login</Link></li>
        <li><Link to="#">Register</Link></li>
    </ul>
  </div>
);

export default HeaderNavigation;