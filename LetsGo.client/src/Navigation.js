import React from 'react'
import { withRouter } from 'react-router-dom';
import { BrowserRouter as Router, Route, Switch, Link, Redirect } from 'react-router-dom';
import LandingPage from './components/LandingPage/LandingPage'
import MyParks from './components/MyParks/MyParks'
import Login from './components/Login/Login'
import ListAll from './components/ListAll/ListAll';
import Register from './components/Register/Register'
import PackingEssentials from './components/PackingEssentials/PackingEssentials';


const Navigation = props => {
    return (
        <Router>
            <Switch>
                {/* <Link to="/"></Link>
                <Link to="/Home"></Link> */}
                <Route exact path="/" component={LandingPage} />
                <Route path="/MyParks" component={MyParks} />
                <Route path="/Login" component={Login} />
                <Route path="/ListAll" component={ListAll} />
                <Route path="/Register" component={Register} />
                <Route path="/PackingEssentials" component={PackingEssentials} />
            </Switch>
        </Router>
    );
}
export default Navigation