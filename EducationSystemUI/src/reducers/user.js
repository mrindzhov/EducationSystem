const userReducerDefaultState = {
  isLogged: true,
  userToken: ''
};

export default (state = userReducerDefaultState, action) => {
  
  console.log(action)
  switch (action.type) {
    case 'SET_IS_LOGGED':
      return {
        ...state,
        isLogged: action.isLogged,
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
