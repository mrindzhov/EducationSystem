import React from 'react';
import './Dashboard.css';
import Project from '../projects/Project'
import { getCreatedProjectsByUser, getRequestedProjectsByUser, getAcceptedProjectsByUser } from '../../webapi/dbaccess'

import LinkButton from '../button/LinkButton';

const createdProjects = getCreatedProjectsByUser("kukamunga@kuka.munga")
const involvedProjects = getAcceptedProjectsByUser("kukamunga@kuka.munga")
const requestedProjects = getRequestedProjectsByUser("kukamunga@kuka.munga")

const Dashboard = () => (
  <section className="section-dashboard">
    <h2>Dashboard</h2>
    <section>
      <div>
        <h3>Created Projects</h3>
        <div className="row">
          <LinkButton to="/dashboard/create">Create New</LinkButton>
        </div>
        {createdProjects ? createdProjects.map(project => {
          return (
            <Project />
          );
        }) : <div>(empty)</div>
        }
      </div>
      <div>
        <h3>Involved Projects</h3>
        {involvedProjects ? involvedProjects.map(project => {
          return (
            <Project />
          );
        }) : <div>(empty)</div>
        }
      </div>
      <div>
        <h3>Requested Projects</h3>
        {requestedProjects ? requestedProjects.map(project => {
          return (
            <Project />
          );
        }) : <div>(empty)</div>
        }
      </div>

    </section >
  </section>
);

export default Dashboard;
