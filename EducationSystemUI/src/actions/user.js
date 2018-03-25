export const setIsLogged = (isLogged = false) => ({
    type: 'SET_IS_LOGGED',
    isLogged
});

export const setUserToken = (userToken = '') => ({
    type: 'SET_USER_TOKEN',
    userToken
});