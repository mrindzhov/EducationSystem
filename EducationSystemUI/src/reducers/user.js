const userReducerDefaultState = {
  isLogged: false,
  userToken: ''
};

export default (state = userReducerDefaultState, action) => {
  
  console.log(action)
  switch (action.type) {
    case 'SET_IS_LOGGED':
      return {
        ...state,
        isLogged: action.isLogged,
        email: action.email
      };
    case 'SET_USER_TOKEN':
      return {
        ...state,
        userToken: action.userToken,
      };
    default:
      return state;
  }
};
