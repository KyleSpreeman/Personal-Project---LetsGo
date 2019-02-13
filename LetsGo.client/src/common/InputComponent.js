import React from 'react'
// this is deconstructing what is being passed into the function
const InputComponent = props => {//({ name, type, value, placeholder, onChange }) => {
    return (
        <div>
            <input className="input"
                name={props.name}
                type={props.type}
                value={props.value}
                placeholder={props.placeholder}
                onChange={props.onChange}
            />
        </div>
    )
}

export default InputComponent