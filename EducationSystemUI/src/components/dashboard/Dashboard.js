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
      console.log(json);
      this.setState({ createdProjects: json });
    })
  }

  getAcceptedProjectsByUser() {
    getAcceptedProjectsByUser(this.props.user.email).then(json => {
      console.log(json);
      this.setState({ involvedProjects: json });
    })
  }

  getRequestedProjectsByUser() {
    getRequestedProjectsByUser(this.props.user.email).then(json => {
      console.log(json);
      this.setState({ requestedProjects: json });
    })
  }


  render() {
    return (
      <section className="section-dashboard">
    <h2>Dashboard</h2>
    <section>
      <div>
        <h3>Created Projects</h3>
        <div className="row">
          <LinkButton to="/dashboard/create">Create New</LinkButton>
        </div>
        {this.state.createdProjects ? this.state.createdProjects.map(project => {
          return (
            <Project project={project} />
          );
        }) : <div>(empty)</div>
        }
      </div>
      <div>
        <h3>Involved Projects</h3>
        {this.state.involvedProjects ? this.state.involvedProjects.map(project => {
          return (
            <Project project={project} />
          );
        }) : <div>(empty)</div>
        }
      </div>
      <div>
        <h3>Requested Projects</h3>
        {this.state.requestedProjects ? this.state.requestedProjects.map(project => {
          return (
            <Project project={project} />
          );
        }) : <div>(empty)</div>
        }
      </div>

    </section >
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
