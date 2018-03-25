import React from 'react';
import { BrowserRouter, Route, Switch, Link, NavLink, Redirect } from 'react-router-dom';
import HomePage from '../components/home/HomePage';
import Dashboard from '../components/dashboard/Dashboard';
import Profile from '../components/profile/Profile';
import Projects from '../components/projects/Projects';
import ReduxTest from '../components/ReduxTest';
import NotFoundPage from '../components/NotFoundPage';
import HeaderNavigation from '../components/navbar/HeaderNavigation';
import { connect } from 'react-redux';

const AppRouter = (props) => (
  <BrowserRouter>
    <div>
      <HeaderNavigation />
      {!props.user.isLogged && <Redirect to="/"></Redirect>}
      <Switch>
        <Route exact path="/" component={HomePage} exact={true} />
        <Route exact path="/dashboard" component={Dashboard} exact={true} />
        <Route exact path="/profile" component={Profile} exact={true} />
        <Route exact path="/projects" component={Projects} exact={true} />
        <Route component={NotFoundPage} />
      </Switch>
    </div>
  </BrowserRouter>
);

const mapStateToProps = (state) => {
  return {
      user: state.user
  };
};

export default connect(mapStateToProps)(AppRouter);
