import React from 'react'
import InputComponent from '../../common/InputComponent'
import RegisterForm from './RegisterForm'
import UserService from '../../services/UserService'


class Register extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            firstName: "",
            lastName: "",
            email: "",
            password: "",
            confirmPassword: ""
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
    // Asd#123
    submit = param => {
        let data = {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            email: this.state.email,
            password: this.state.password,
            confirmPassword: this.state.confirmPassword
        }
        UserService.register(data, this.onRegisterSuccess, this.onRegisterError)
    }

    onRegisterSuccess = resp => {
        console.log(resp)
        this.props.history.push("/Login")
    }

    onRegisterError = err => {
        console.log(err)
    }

    render() {
        return (
            <div className="registrationForm">
                <RegisterForm
                    // passing functions to registration form
                    onChange={this.onChange}
                    onClick={this.submit} />
            </div>
        )
    }
}

export default Register