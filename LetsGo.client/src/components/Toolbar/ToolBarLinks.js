import React from 'react'
import UserService from '../../services/UserService'

const ToolBarLinks = props => {
    return (
        <ul>
            <li><a href="/MyParks">MyParks</a></li>
            <li><a href="/Login">Login</a></li>
            <li><a href="/PackingEssentials">Packing</a></li>
        </ul>
    )
}

export default ToolBarLinks