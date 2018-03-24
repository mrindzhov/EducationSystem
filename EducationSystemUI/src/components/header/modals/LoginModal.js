import React from 'react';
import Modal from 'react-modal';
import LinkButton from '../../button/LinkButton';
import './LoginModal.css';

const LoginModal = (props) => (
  <Modal
    isOpen={props.isOpen}
    onRequestClose={() => props.closeModal("login")}
    contentLabel="Login"
    className="modal"
    shouldCloseOnEsc={true}
    shouldCloseOnOverlayClick={true}
  >
    <h3 className="modal__title">Login</h3>
    <div className=".modal__body">
      <input type="text" className="input-credentials" placeholder="email"></input>
      <input type="password" className="input-credentials" placeholder="password"></input>
    </div>
    <LinkButton>Login</LinkButton>
  </Modal>
);

export default LoginModal;