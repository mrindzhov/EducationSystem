import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../header/HeaderNavigation';
import './HomePage.css';

import { get } from '../../webapi/dbaccess';
import Button from '../button/Button';

const getData = () => {
  get().then((json) => {
    console.log(json);    
  })
}

const HomePage = () => (
  <div>
    <header className="home-header">
      <HeaderNavigation />
      <div class="hero-box">
        <h1>Teamwork Education</h1>
        {/* <Button>Login</Button>
        <Button>Register</Button> */}
      </div>
    </header>
  </div>
);

export default HomePage;
