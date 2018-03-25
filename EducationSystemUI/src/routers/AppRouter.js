import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import HomePage from '../components/home/HomePage';
import Dashboard from '../components/dashboard/Dashboard';
import Profile from '../components/profile/Profile';
import Projects from '../components/projects/Projects';
import ProjectDetails from '../components/projectDetails/ProjectDetails';
import Create from '../components/projects/Create';
import NotFoundPage from '../components/NotFoundPage';
import HeaderNavigation from '../components/navbar/HeaderNavigation';
import { connect } from 'react-redux';

const AppRouter = (props) => (
  <BrowserRouter>
    <div>
      <HeaderNavigation />
      {/* {!props.user.isLogged && <Redirect to="/"></Redirect>} */}
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route exact path="/dashboard" component={Dashboard} />
        <Route exact path="/profile" component={Profile} />
        <Route exact path="/projects" component={Projects} />
        <Route exact path="/projects/:id" component={ProjectDetails} />
        <Route exact path="/dashboard/create" component={Create} />
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
