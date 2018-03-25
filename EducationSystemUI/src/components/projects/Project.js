import React from 'react';
import './Project.css';
import Button from '../button/Button';
import LinkButton from '../button/LinkButton';

const Project = (props) => (
  <div className="project">
      <h3>{props.project.Name}</h3>
      <p className="description">{props.project.Description}</p>
      <Button>Apply</Button>
      <LinkButton to={`/projects/id=${props.project.Id}`}>View</LinkButton>
  </div>
);

export default Project;