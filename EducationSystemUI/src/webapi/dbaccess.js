const host = "http://localhost:58530/";

export function register(user) {
    var url = `${host}api/account/register`;
    var data = user;
    console.log(JSON.stringify(data))
    fetch(url, {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(data),
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then(response => console.log('Success:', response));
}

export function login(user) {
    var url = `${host}token`;
    var data = user;
    return fetch(url, {
        method: 'POST',
        body: data,
        headers: new Headers({
            'Content-Type': 'text/plain'
        }),
        xhrFields: {
            withCredentials: true
        }
    }).then(res => { return res.json() });
}

export function getCreatedProjectsByUser(username) {
    var url = `${host}api/project/GetAllCreatedByUser?username=${username}`;

    fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then(response => console.log('Success:', response));
}

export function getRequestedProjectsByUser(username) {
    var url = `${host}api/project/GetAllRequestedByUser?username=${username}`;

    fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then(response => console.log('Success:', response));
}

export function getAcceptedProjectsByUser(username) {
    var url = `${host}api/project/GetAllAcceptedByUser?username=${username}`;

    fetch(url, {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then(response => console.log('Success:', response));
}

export function getAllProjects(userEmail) {
    const search = userEmail ? userEmail : "";
    var url = `${host}api/project/getAllNotOwnedByUser?email=${search}`;
    var data = userEmail;
    console.log(data);
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
        body: data,
        headers: new Headers({
            'Content-Type': 'text/plain'
        })
    }).then(res => { return res.json() });
}