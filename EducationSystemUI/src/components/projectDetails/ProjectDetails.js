import React from 'react';
import { withRouter } from 'react-router-dom';
import { getProjectDetailsById } from '../../webapi/dbaccess';
import './ProjectDetails.css';

class ProjectDetails extends React.Component {
    constructor(props) {
      super(props);
      
      this.state = {}
    }

    componentDidMount() {
        this.getProjectDetails();
    }

    getProjectDetails() {
        const id = this.props.match.params.id;
        getProjectDetailsById(id).then(json => {
            this.setState({ project: json });
        })
    }

    render() {
        if (!this.state.project) {
            return null;
        }
        
        return (
          <section className="section-create">
            <h2>Project name: {this.state.project.Name}</h2>
            <p className="project-description">Project description: {this.state.project.Description}</p>
            <h3>Team Members:</h3>
            <div>
                {this.state.project.AcceptedDevelopers && this.state.project.AcceptedDevelopers.map(developer => {
                    return (
                        <div>developer</div>
                    );
                })}
            </div>
        </section>
        )
    }
}

export default withRouter(ProjectDetails);