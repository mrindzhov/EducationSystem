import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from './header/HeaderNavigation';

const HomePage = () => (
  <div>
    <HeaderNavigation />
    Home <Link to='/isLogged'>Check User</Link>
  </div>
);

export default HomePage;
