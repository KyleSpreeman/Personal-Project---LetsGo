import React from 'react'
import './Login.css'
import LoginForm from './LoginForm'
import UserService from '../../services/UserService';

class Login extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            email: "",
            password: ""
        }
    }

    onChange = evt => {
        // Takes the name and value from the input components and sets the state 
        let key = evt.target.name;
        let val = evt.target.value;
        this.setState({
            [key]: val
        })
    }

    login = param => {
        //on click the login function fires to the user service and on success the user will be directed to the home page
        let data = {
            email: this.state.email,
            password: this.state.password
        }
        UserService.login(data, this.onLoginSuccess, this.onLoginError)
    }

    onLoginSuccess = resp => {
        console.log(resp)
        this.props.history.push({ pathname: '/Home' })
    }

    onLoginError = err => {
        console.log(err)
    }


    render() {
        return (
            <div className="loginForm">
                <LoginForm
                    // passing functions to registration form
                    onChange={this.onChange}
                    onClick={this.login}
                />
            </div>
        )
    }
}

export default Login