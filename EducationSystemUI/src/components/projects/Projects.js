import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../navbar/HeaderNavigation';
import './Projects.css';
import Project from './Project';

const projects = [
  {
      "Id": 1,
      "Name": "First",
      "CreateDate": "2018-03-25T10:44:46.613",
      "GitHubUrl": null,
      "StartDate": null,
      "EndDate": null,
      "EstimationDate": null,
      "Description": "First Description",
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
    "Id": 1,
    "Name": "First",
    "CreateDate": "2018-03-25T10:44:46.613",
    "GitHubUrl": null,
    "StartDate": null,
    "EndDate": null,
    "EstimationDate": null,
    "Description": "First Description",
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
  "Id": 1,
  "Name": "First",
  "CreateDate": "2018-03-25T10:44:46.613",
  "GitHubUrl": null,
  "StartDate": null,
  "EndDate": null,
  "EstimationDate": null,
  "Description": "First Description",
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
      "Name": "Second",
      "CreateDate": "2018-03-25T10:45:31.76",
      "GitHubUrl": null,
      "StartDate": null,
      "EndDate": null,
      "EstimationDate": null,
      "Description": "Second Description",
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

const Projects = () => (
  <section className="section-projects">
    <h2>Projects</h2>
    <div className="projects-container">
      
      {projects && projects.map(project => {
        return (
          <Project />
        );
      })}
    </div>
  </section>
);

export default Projects;