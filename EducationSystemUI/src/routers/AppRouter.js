import React from 'react';
import { BrowserRouter, Route, Switch, Link, NavLink } from 'react-router-dom';
import HomePage from '../components/home/HomePage';
import Dashboard from '../components/dashboard/Dashboard';
import Profile from '../components/profile/Profile';
import Projects from '../components/projects/Projects';
import ReduxTest from '../components/ReduxTest';
import NotFoundPage from '../components/NotFoundPage';
import HeaderNavigation from '../components/navbar/HeaderNavigation';

const AppRouter = () => (
  <BrowserRouter>
    <body>
      <HeaderNavigation />
      <Switch>
        <Route exact path="/" component={HomePage} exact={true} />
        <Route exact path="/dashboard" component={Dashboard} exact={true} />
        <Route exact path="/profile" component={Profile} exact={true} />
        <Route exact path="/projects" component={Projects} exact={true} />
        <Route component={NotFoundPage} />
      </Switch>
    </body>
  </BrowserRouter>
);

export default AppRouter;
