import React from 'react';
import { Link } from 'react-router-dom';
import './HeaderNavigation.css';
import LoginModal from './modals/LoginModal';
import RegisterModal from './modals/RegisterModal';
import { register } from '../../webapi/dbaccess';

class HeaderNavigation extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            password: '',
        };

        this.openModal = this.openModal.bind(this);
        this.closeModal = this.closeModal.bind(this);
        this.onChange = this.onChange.bind(this);
        this.onRegister = this.onRegister.bind(this);
    }

    onChange(e) {
        console.log(e.target.name)
        this.setState({ [e.target.name]: e.target.value});
    }

    onRegister() {
        console.log("reg")
        const user = {
            "Email": this.state.email,
            "Password": this.state.password
        }

        register(user);
    }

    openModal(modal, e) {
        if (e) {
            e.preventDefault();
        }

        this.setState({ [modal]: true });
    }

    closeModal(modal, e) {
        if (e) {
            e.preventDefault();
        }

        this.setState({ [modal]: false });
    }

    render() {
        return (
            <div className='header-navigation'>
                <LoginModal 
                    email={this.state.email} 
                    password={this.state.password} 
                    isOpen={this.state.login} 
                    closeModal={this.closeModal}
                    onChange={this.onChange} />
                <RegisterModal 
                    email={this.state.email} 
                    password={this.state.password} 
                    isOpen={this.state.register} 
                    closeModal={this.closeModal}
                    onRegister={this.onRegister}
                    onChange={this.onChange} />
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