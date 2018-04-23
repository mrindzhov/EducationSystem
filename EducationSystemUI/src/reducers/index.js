import { combineReducers } from 'redux';
import UserReducer from './user';

const rootReducer = combineReducers({
  user: UserReducer
});

export default rootReducer;