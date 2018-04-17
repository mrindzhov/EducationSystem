import React from 'react';
import './Dashboard.css';
import Project from '../projects/Project'
import { getCreatedProjectsByUser, getRequestedProjectsByUser, getAcceptedProjectsByUser } from '../../webapi/dbaccess'
import { connect } from 'react-redux';

import LinkButton from '../button/LinkButton';

class Dashboard extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = {
      createdProjects: [],
      involvedProjects: [],
      requestedProjects: [],
    }

    this.getCreatedProjectsByUser = this.getCreatedProjectsByUser.bind(this);
    this.getAcceptedProjectsByUser = this.getAcceptedProjectsByUser.bind(this);
    this.getRequestedProjectsByUser = this.getRequestedProjectsByUser.bind(this);
  }

  componentDidMount() {
    this.getCreatedProjectsByUser();
    this.getAcceptedProjectsByUser();
    this.getRequestedProjectsByUser();
  }

  getCreatedProjectsByUser() {
    getCreatedProjectsByUser(this.props.user.email).then(json => {
      this.setState({ createdProjects: json });
    })
  }

  getAcceptedProjectsByUser() {
    getAcceptedProjectsByUser(this.props.user.email).then(json => {
      this.setState({ involvedProjects: json });
    })
  }

  getRequestedProjectsByUser() {
    getRequestedProjectsByUser(this.props.user.email).then(json => {
      this.setState({ requestedProjects: json });
    })
  }


  render() {
    return (
      <section className="section-dashboard">
      <h2>Dashboard</h2>
        <div>
          <h2>Created Projects</h2>
          <div className="projects-container">
            {this.state.createdProjects ? this.state.createdProjects.map((project, index) => {
              return (
                <Project key={index} project={project} />
              );
            }) : <div>(empty)</div>
            }
          </div>
        </div>
        <div>
          <h2>Involved Projects</h2>
          <div className="projects-container">
            {this.state.involvedProjects ? this.state.involvedProjects.map((project, index) => {
              return (
                <Project key={index} project={project} />
              );
            }) : <div>(empty)</div>
            }
          </div>
        </div>
        <div>
          <h2>Requested Projects</h2>
          <div className="projects-container">
            {this.state.requestedProjects ? this.state.requestedProjects.map((project, index) => {
              return (
                <Project key={index} project={project} />
              );
            }) : <div>(empty)</div>
            }
          </div>
        </div>

        <div className="row">
          <LinkButton to="/dashboard/create">Create New</LinkButton>
        </div>
    </section>
    )
  }
}

const mapStateToProps = (state) => {
  return {
      user: state.user
  };
};

export default connect(mapStateToProps)(Dashboard);
