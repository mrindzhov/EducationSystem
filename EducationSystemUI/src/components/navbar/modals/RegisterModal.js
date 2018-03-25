import React from 'react';
import Modal from 'react-modal';
import ModalButton from './ModalButton';
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
      <input type="text" className="input-credentials" name="email" placeholder="email" value={props.email} onChange={props.onChange}></input>
      <input type="password" className="input-credentials" name="password" placeholder="password" value={props.password} onChange={props.onChange}></input>
    </div>
    <ModalButton onClick={props.onRegister}>Register</ModalButton>
  </Modal>
);

export default RegisterModal;