const userReducerDefaultState = {
  isLogged: false
};

export default (state = userReducerDefaultState, action) => {
  switch (action.type) {
    case 'SET_IS_LOGGED':
      return [
        ...state,
        action.isLogged
      ];
    default:
      return state;
  }
};
