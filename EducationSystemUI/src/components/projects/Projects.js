import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../navbar/HeaderNavigation';
import './Projects.css';
import Project from './Project';
import { connect } from 'react-redux';

import { getAllProjects } from '../../webapi/dbaccess';

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
  "Id": 3,
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
      "Id": 4,
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

class Projects extends React.Component {
  constructor(props) {
    super(props);

    this.state = {}
  }

  componentDidMount() {
    this.getProjects();
  }

  getProjects() {
    const email = this.props.user.email;
    getAllProjects(email).then(projects => {
      this.setState({ projects: projects });
    })
  }

  render () {
    return (
      <section className="section-projects">
        <h2>Projects</h2>
        <div className="projects-container">
          
          {this.state.projects && this.state.projects.map(project => {
            return (
              <Project project={project}/>
            );
          })}
        </div>
      </section>
    );
  }
}

const mapStateToProps = (state) => {
  return {
      user: state.user
  };
};

export default connect(mapStateToProps)(Projects);