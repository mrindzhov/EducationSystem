import { NotificationManager } from "react-notifications";

const host = "http://localhost:58530/";

export function register(user) {
    var url = `${host}api/account/register`;
    var data = user;
    fetch(url, {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(data),
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    })
    .then(res => {
        if (res.ok) {
            return res.json();
        } else {
            res.json().then(json => {
                NotificationManager.error(json.Message);
            })
        }
     })
     .catch(error => console.error('Error:', error));
}

export function login(user) {
    var url = `${host}token`;
    var data = user;
    return fetch(url, {
        method: 'POST',
        body: data,
        mode: 'cors',
        headers: new Headers({
            'Content-Type': 'text/plain'
        })
    })
    .then(res => {
        if (res.ok) {
            return res.json();
        } else {
            res.json().then(json => {
                NotificationManager.error(json.error_description);
            })
        }
     })
     .catch(error => console.error('Error:', error));
}

export function getCreatedProjectsByUser(username) {
    var url = `${host}api/project/GetAllCreatedByUser?username=${username}`;

    return fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error));
}

export function getRequestedProjectsByUser(username) {
    var url = `${host}api/project/GetAllRequestedByUser?username=${username}`;

    return fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error));
}

export function getAcceptedProjectsByUser(username) {
    var url = `${host}api/project/GetAllAcceptedByUser?username=${username}`;

    return fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error));
}

export function getAllProjects(userEmail) {
    const search = userEmail ? userEmail : "";
    var url = `${host}api/project/getAllNotOwnedByUser?email=${search}`;
    return fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => { return res.json() });
}

export function createProject(project) {
    var url = `${host}api/project/create`;
    var data = project;
    return fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res);
}

export function getProjectDetailsById(id) {
    var url = `${host}api/project/getById?id=${id}`;
    return fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => { return res.json() });
}