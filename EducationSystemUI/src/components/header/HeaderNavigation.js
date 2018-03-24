import React from 'react';
import { Link } from 'react-router-dom';
import './HeaderNavigation.css';
import LoginModal from './modals/LoginModal';
import RegisterModal from './modals/RegisterModal';

class HeaderNavigation extends React.Component {
    constructor(props) {
        super(props);

        this.state = {

        };

        this.openModal = this.openModal.bind(this);
        this.closeModal = this.closeModal.bind(this);
    }

    openModal(modal, e) {
        if (e) {
            e.preventDefault();
        }

        console.log(modal, e)

        this.setState({ [modal]: true });
    }

    closeModal(modal, e) {
        if (e) {
            e.preventDefault();
        }

        console.log(modal, e)

        this.setState({ [modal]: false });
    }

    render() {
        return (
            <div className='header-navigation'>
                <LoginModal isOpen={this.state.login} closeModal={this.closeModal} />
                <RegisterModal isOpen={this.state.register} closeModal={this.closeModal} />
                <ul>
                    {/* <li><Link to="#"><i className="ion-ionic"></i></Link></li> */}
                    <li><Link to="#"><i className="ion-android-globe"></i></Link></li>
                    <li><Link to="#">Dashboard</Link></li>
                    <li><Link to="#">Profile</Link></li>
                    <li><Link to="#">Projects</Link></li>
                </ul>
                <ul>
                    <li><Link to="#" onClick={() => this.openModal("login")}>Login</Link></li>
                    <li><Link to="#" onClick={() => this.openModal("register")}>Register</Link></li>
                </ul>
            </div>
        );
    }
}

export default HeaderNavigation;