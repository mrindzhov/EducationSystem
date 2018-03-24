import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../header/HeaderNavigation';
import './HomePage.css';

import { get } from '../../webapi/dbaccess';
import LinkButton from '../button/LinkButton';

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
        <LinkButton>Login</LinkButton>
        <LinkButton>Register</LinkButton>
      </div>
    </header>
  </div>
);

export default HomePage;
