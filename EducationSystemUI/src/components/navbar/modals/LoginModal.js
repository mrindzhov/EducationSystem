import React from 'react';
import Modal from 'react-modal';
import Button from '../../button/Button';
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
      <input 
        type="text" 
        className="input-credentials" 
        name="email" 
        placeholder="email" 
        value={props.email}
        onChange={props.onChange}></input>
      <input 
        type="password" 
        className="input-credentials" 
        name="password" 
        placeholder="password" 
        value={props.password}
        onChange={props.onChange}></input>
    </div>
    <Button onClick={props.onLogin}>Login</Button>
  </Modal>
);

export default LoginModal;