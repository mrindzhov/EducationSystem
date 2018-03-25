import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import './HeaderNavigation.css';
import LoginModal from './modals/LoginModal';
import RegisterModal from './modals/RegisterModal';
import { register, login } from '../../webapi/dbaccess';
import { connect } from 'react-redux';
import { setIsLogged, setUserToken } from '../../actions/user';

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
        this.onLogin = this.onLogin.bind(this);
        this.onLogout = this.onLogout.bind(this);
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
        this.setState({ register: false });
    }

    onLogin() {
        const user = `username=${this.state.email}&password=${this.state.password}&grant_type=password`;
        login(user).then(json => {
            const token = json.access_token;
            console.log(token);
            this.props.dispatch(setIsLogged(true));
            this.props.dispatch(setUserToken(token));
        });

        this.setState({ login: false });
    }

    onLogout() {
        this.props.dispatch(setIsLogged());
        this.props.dispatch(setUserToken());
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
                    onLogin={this.onLogin}
                    onChange={this.onChange} />
                <RegisterModal 
                    email={this.state.email} 
                    password={this.state.password} 
                    isOpen={this.state.register} 
                    closeModal={this.closeModal}
                    onRegister={this.onRegister}
                    onChange={this.onChange} />
                <ul>
                    <li><Link to="/"><i className="ion-android-globe"></i></Link></li>
                    {this.props.user.isLogged &&  <li><NavLink to="/dashboard" activeClassName="active">Dashboard</NavLink></li>}
                    {this.props.user.isLogged && <li><NavLink to="/projects">Projects</NavLink></li>}
                </ul>
                <ul>
                    {this.props.user.isLogged && <li><NavLink to="/profile">Profile</NavLink></li>}
                    {this.props.user.isLogged && <li><Link to="/" onClick={() => this.onLogout()}>Logout</Link></li>}
                    {!this.props.user.isLogged && <li><NavLink to="#" onClick={() => this.openModal("login")}>Login</NavLink></li>}
                    {!this.props.user.isLogged && <li><NavLink to="#" onClick={() => this.openModal("register")}>Register</NavLink></li>}
                </ul>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        user: state.user
    };
};

export default connect(mapStateToProps)(HeaderNavigation);