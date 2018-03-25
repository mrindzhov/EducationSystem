import React from 'react';
import { Link } from 'react-router-dom';
import HeaderNavigation from '../navbar/HeaderNavigation';

import LinkButton from '../button/LinkButton';

const project =  {
    "Id": 4,
    "Name": "Second Project",
    "CreateDate": "2018-03-25T10:45:31.76",
    "GitHubUrl": null,
    "StartDate": null,
    "EndDate": null,
    "EstimationDate": null,
    "Description": "Second Description",
    "Requirements": null,
    "IsTeamFormed": false,
    "ProductOwnerId": null,
    "ProductOwner": "Owner",
    "Feedbacks": [],
    "Resources": [],
    "SkillsNeeded": [],
    "AcceptedDevelopers": [ "Pesho", "Asen" ],
    "RequestedDevelopers": [],
    "ReceivedRequests": []
}

const ProjectDetails = () => (
  <section className="section-create">
    <h2>{project.Name} ({project.ProductOwner})</h2>
    <p>{project.Description}</p>
    <h3>Team</h3>
    <div>
        {project.AcceptedDevelopers && project.AcceptedDevelopers.map(developer => {
            return (
                <div>developer</div>
            );
        })}
    </div>
  </section>
);

export default ProjectDetails;