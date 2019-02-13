import React from 'react'
import InputComponent from '../../common/InputComponent'
import './Login.css'

const LoginForm = props => {
    return (
        <div className="card">
            <div className="card-body">
                <h3>Login</h3>
                <label>Login email:</label>
                <InputComponent
                    name='email'
                    type='email'
                    value={props.email}
                    placeholder='email'
                    onChange={props.onChange} />
                <label>Password</label>
                <InputComponent
                    name='password'
                    type='password'
                    value={props.password}
                    placeholder='password'
                    onChange={props.onChange} />
                <br />
                <div className="loginButton">
                    <a href="/Register" className="card-link" style={{ textAlign: "left" }}>Don't have an account?</a><span> </span>
                    <button type="button" className="btn btn-info btn-sm" onClick={props.onClick}>Login</button>
                </div>
            </div>
        </div>
    )
}

export default LoginForm