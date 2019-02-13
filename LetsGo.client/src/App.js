import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Toolbar from './components/Toolbar/Toolbar'
import SideDrawer from './components/SideDrawer/SideDrawer'
import Backdrop from './components/Backdrop/Backdrop'
import Navigation from './Navigation'


class App extends Component {
  state = {
    SideDrawerOpen: false
  }
  drawerToggleClickHandler = () => {
    this.setState((prevState) => {
      return { SideDrawerOpen: !prevState.SideDrawerOpen }
    });
  };

  backdropClickHandler = () => {
    this.setState({
      SideDrawerOpen: false
    })
  };



  render() {
    let backdrop;

    if (this.state.SideDrawerOpen) {
      backdrop = <Backdrop click={this.backdropClickHandler} />
    }
    return (
      <div>
        <Toolbar
          drawerClickHandler={this.drawerToggleClickHandler}
        />
        <SideDrawer show={this.state.SideDrawerOpen} />
        {backdrop}
        <main style={{ marginTop: '64px' }}>
          <div className="content-container">
            <Navigation />
          </div>
        </main>
      </div>
    );
  }
}

export default App;
