import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../navbar/HeaderNavigation';
import './Dashboard.css';

import LinkButton from '../button/LinkButton';

const projects = [
  {
      "Id": 1,
      "Name": null,
      "CreateDate": "2018-03-25T10:44:46.613",
      "GitHubUrl": null,
      "StartDate": null,
      "EndDate": null,
      "EstimationDate": null,
      "Description": null,
      "Requirements": null,
      "IsTeamFormed": false,
      "ProductOwnerId": null,
      "ProductOwner": null,
      "Feedbacks": [],
      "Resources": [],
      "SkillsNeeded": [],
      "AcceptedDevelopers": [],
      "RequestedDevelopers": [],
      "ReceivedRequests": []
  },
  {
      "Id": 2,
      "Name": null,
      "CreateDate": "2018-03-25T10:45:31.76",
      "GitHubUrl": null,
      "StartDate": null,
      "EndDate": null,
      "EstimationDate": null,
      "Description": null,
      "Requirements": null,
      "IsTeamFormed": false,
      "ProductOwnerId": null,
      "ProductOwner": null,
      "Feedbacks": [],
      "Resources": [],
      "SkillsNeeded": [],
      "AcceptedDevelopers": [],
      "RequestedDevelopers": [],
      "ReceivedRequests": []
  }
]

const Dashboard = () => (
  <section className="section-dashboard">
    <h2>Dashboard</h2>
    <div className="row">
      <LinkButton to="/dashboard/create">Create New</LinkButton>
    </div>
  </section>
);

export default Dashboard;
