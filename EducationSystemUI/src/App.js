import React, { Component } from 'react';
import { Provider } from 'react-redux';
import configureStore from './store/configureStore';
import AppRouter from './routers/AppRouter';
import './App.css';

const store = configureStore();

const jsx = (
  <Provider store={store}>
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
