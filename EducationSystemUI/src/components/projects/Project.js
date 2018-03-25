import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../navbar/HeaderNavigation';
import './Project.css';
import Button from '../button/Button';

const Project = (props) => (
  <div className="project">
      <h3>Project</h3>
      <div className="description"></div>
      <Button>Apply</Button>
      <Button>View</Button>
  </div>
);

export default Project;