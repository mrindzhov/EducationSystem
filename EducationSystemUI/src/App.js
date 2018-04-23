import React, { Component } from 'react';
import { Provider } from 'react-redux';
import configureStore from './store/configureStore';
import AppRouter from './routers/AppRouter';
import { createStore, applyMiddleware } from 'redux';
import reducers from './reducers/index';
import promise from 'redux-promise';
import './App.css';
import 'react-notifications/lib/notifications.css';

const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

const jsx = (
  <Provider store={createStoreWithMiddleware(reducers)}>
    <AppRouter />
  </Provider>
);

class App extends Component {
  render() {
    return (
      <div className="App">{jsx}</div>
    );
  }
}

export default App;
