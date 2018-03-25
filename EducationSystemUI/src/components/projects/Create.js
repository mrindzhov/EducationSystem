import React from 'react';
import './Create.css';

class Create extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = {}

    this.onChange = this.onChange.bind(this);
    this.handleCreateProject = this.handleCreateProject.bind(this);
  }

  onChange(e) {
    console.log(e);
    this.setState({ [e.target.name]: e.target.value })
  }

  handleCreateProject(e) {
    if (e) {
      e.preventDefault();
    }


  }

  render() {
    return (
      <section className="section-create">
        <h2>Create New Project</h2>
        <form>
          <div className="form-row">
            <label htmlFor="name">Name:</label>
            <input type="text" name="name" value={this.state.name} onChange={this.onChange} />
          </div>
          <div className="form-row">
            <label htmlFor="description">Description:</label>
            <input type="text" name="description" value={this.state.description} onChange={this.onChange} />
          </div>
          <input type="submit" onClick={this.handleCreateProject}/>
        </form>
      </section>
    )
  }
}

export default Create;