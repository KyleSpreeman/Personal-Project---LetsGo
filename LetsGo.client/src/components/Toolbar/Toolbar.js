import React from 'react'
import './Toolbar.css'
import DrawerToggleButton from '../SideDrawer/DrawerToggleButton'
import { red } from 'ansi-colors';
import Navigation from '../../Navigation'
import ToolBarLinks from './ToolBarLinks'


const toolbar = props => (
    <header className="toolbar">
        <nav className="toolbar_navigation">
            <div className="toolbar_toggleButton">
                {/* this is the button that will open the side drawer */}
                <DrawerToggleButton click={props.drawerClickHandler} />
            </div>
            {/* logo of the toolbar */}
            <div className="toolbar_logo" ><a href="/">Lets Go</a></div>
            <div className="spacer" />
            <div className="toolbar_navigation_items">
                <ul>
                    {/* links at the top left that allow navigation around the site */}
                    <ToolBarLinks />
                </ul>
            </div>
        </nav >
    </header>

);

export default toolbar