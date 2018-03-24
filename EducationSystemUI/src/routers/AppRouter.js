import React from 'react';
import { BrowserRouter, Route, Switch, Link, NavLink } from 'react-router-dom';
import HomePage from '../components/HomePage';
import ReduxTest from '../components/ReduxTest';
import NotFoundPage from '../components/NotFoundPage';

const AppRouter = () => (
  <BrowserRouter>
    <div>
      <Switch>
        <Route path="/" component={HomePage} exact={true} />
        <Route path="/isLogged" component={ReduxTest} exact={true} />
        <Route component={NotFoundPage} />
      </Switch>
    </div>
  </BrowserRouter>
);

export default AppRouter;
