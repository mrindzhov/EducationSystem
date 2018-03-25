export const setIsLogged = (isLogged = false, email = '') => ({
    type: 'SET_IS_LOGGED',
    isLogged,
    email
});

export const setUserToken = (userToken = '') => ({
    type: 'SET_USER_TOKEN',
    userToken
});