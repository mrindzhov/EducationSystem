import React from 'react';
import Modal from 'react-modal';
import ModalButton from './ModalButton';
import './LoginModal.css';

Modal.setAppElement('#root');

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
        onChange={props.onChange}>
      </input>
      <input 
        type="password" 
        className="input-credentials" 
        name="password" 
        placeholder="password" 
        value={props.password}
        onChange={props.onChange}>
      </input>
    </div>
    <ModalButton onClick={props.onLogin}>Login</ModalButton>
  </Modal>
);

export default LoginModal;