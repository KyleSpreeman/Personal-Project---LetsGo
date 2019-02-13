import React from 'react'
import './SideDrawer.css'

const SideDrawer = props => {
    let drawerClasses = 'side_drawer';
    if (props.show) {
        drawerClasses = 'side_drawer open'
    }


    return (
        <nav className={drawerClasses}>
            <ul>
                {/*This creates the side aspect of the navigation bar with links to the components*/}
                <li><a href="/Login">Login</a></li>
                <li><a href="/MyParks">MyParks</a></li>
                <li><a href="/PackingEssentials">Packing</a></li>
            </ul>
        </nav>
    );
}

export default SideDrawer