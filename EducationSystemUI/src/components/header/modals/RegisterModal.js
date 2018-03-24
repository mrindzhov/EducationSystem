import React from 'react';
import Modal from 'react-modal';
import LinkButton from '../../button/LinkButton';
import './RegisterModal.css';

const RegisterModal = (props) => (
  <Modal
    isOpen={props.isOpen}
    onRequestClose={() => props.closeModal("register")}
    contentLabel="Register"
    className="modal"
    shouldCloseOnEsc={true}
    shouldCloseOnOverlayClick={true}
  >
    <h3 className="modal__title">Register</h3>
    <div className=".modal__body">
      <input type="text" className="input-credentials" placeholder="email"></input>
      <input type="password" className="input-credentials" placeholder="password"></input>
    </div>
    <LinkButton>Register</LinkButton>
  </Modal>
);

export default RegisterModal;