import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';

const ReduxTest = (props) => (
  <div>
    User is logged: {props.user.isLogged.toString()}
  </div>
);

const mapStateToProps = (state) => {
    return {
      user: state.user
    };
  };

export default connect(mapStateToProps)(ReduxTest);
