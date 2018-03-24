import React from 'react';
import { Link } from 'react-router-dom';

const HomePage = () => (
  <div>
    Home <Link to='/isLogged'>Check User</Link>
  </div>
);

export default HomePage;
