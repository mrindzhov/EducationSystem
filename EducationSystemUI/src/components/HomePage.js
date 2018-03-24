import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from './header/HeaderNavigation';

import { get } from '../webapi/dbaccess';

const getData = () => {
  get().then((json) => {
    console.log(json);    
  })
}

const HomePage = () => (
  <div>
    <HeaderNavigation />
    <button onClick={getData}>Get Data</button>
  </div>
);

export default HomePage;
