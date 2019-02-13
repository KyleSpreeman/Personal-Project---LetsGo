import React from 'react'
import InputComponent from '../../common/InputComponent'
import './Register.css'

const RegisterForm = props => {
    return (
        <div className="card">
            <div className="card-body">
                <h3>Register</h3>
                <label>First Name: </label>
                <InputComponent
                    name='firstName'
                    type='text'
                    value={props.firstName}
                    placeholder='First Name'
                    onChange={props.onChange} />
                <label>Last Name: </label>
                <InputComponent
                    name='lastName'
                    type='text'
                    value={props.lastName}
                    placeholder='Last Name'
                    onChange={props.onChange} />
                <label>Email: </label>
                <InputComponent
                    name='email'
                    type='email'
                    value={props.email}
                    placeholder='Email'
                    onChange={props.onChange} />
                <label>Password:</label>
                <InputComponent
                    name='password'
                    type='password'
                    value={props.password}
                    placeholder='password'
                    onChange={props.onChange} />
                <label>Confirm password:</label>
                <InputComponent
                    name='confirmPassword'
                    type='password'
                    value={props.confirmPassword}
                    placeholder='Confirm Password'
                    onChange={props.onChange} />
                <br />
                <div className="loginButton">
                    <a href="/Login" className="card-link" style={{ textAlign: "left" }}>Already have an account?</a><span> </span>
                    <button type="button" className="btn btn-info btn-sm" onClick={props.onClick}>Submit</button>
                </div>
            </div>
        </div>
    )
}

export default RegisterForm