import React from 'react';
import './Projects.css';
import Project from './Project';
import { connect } from 'react-redux';

import { getAllProjects } from '../../webapi/dbaccess';

class Projects extends React.Component {
  constructor(props) {
    super(props);

    this.state = {}
  }

  componentDidMount() {
    this.getProjects();
  }

  // componentWillUpdate() {
  //   this.getProjects();
  // }

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