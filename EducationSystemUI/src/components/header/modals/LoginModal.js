import React from 'react';
import Modal from 'react-modal';
import './LoginModal.css';

const LoginModal = (props) => (
  <Modal
    isOpen={!!props.isOpen}
    onRequestClose={props.closeModal}
    contentLabel="Login"
  >
    <h3>Login</h3>
    <button onClick={props.handleLogin}>Login</button>
  </Modal>
);

export default LoginModal;