const host = "http://localhost:58530/";

const RequestMethod = {
    GET: 0,
    POST: 1,
    DELETE: 2
};

function getHeaders(headers = null) {
    headers = headers || {};
    return headers;
}

async function sendRequest(endpoint, method, postObj = null, captchaToken = null, headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Captcha': captchaToken
}) {
    let allHeaders = getHeaders(headers);

    let getParams = {
        headers: getHeaders()
    };

    let postParams = {
        headers: allHeaders,
        method: 'POST',
        body: JSON.stringify(postObj)
    };

    let deleteParams = {
        headers: getHeaders(),
        method: 'DELETE'
    };

    let requestHeaders = {};

    switch (method) {
    case RequestMethod.GET:
        requestHeaders = getParams;
        break;
    case RequestMethod.POST:
        requestHeaders = postParams;
        break;
    case RequestMethod.DELETE:
        requestHeaders = deleteParams;
        break;
    default:
        break;
    }

    return fetch(endpoint, requestHeaders)
        .then(res => {
            if (!res.ok) {
                return {
                    response: res.json().then(r => {
                        return r;
                    }),
                    success: res.ok
                };
            } else {
                return {
                    response: res,
                    success: res.ok
                };
            }
        });
}

export function get() {
    return sendRequest(`${host}api/projects/getbyid?id=1`, RequestMethod.GET).then(res => {
        return res.response.json();
    });
}

export function register(user) {
    return sendRequest(`${host}api/account/register`, RequestMethod.POST, user).then(res => {
        return res;
    });
}