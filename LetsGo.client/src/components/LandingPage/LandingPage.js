import React from 'react'
import './LandingPage.css'
import { DebounceInput } from 'react-debounce-input';
import SearchService from '../../services/SearchService'


class LandingPage extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            searchTerm: "",
            searchArr: []
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

    onClick = props => {
        console.log("clicked")
        // sends the search term to the axios call using the NPS API
        SearchService.search(this.state.searchTerm, this.onClickSuccess, this.onClickError)
    }

    onClickSuccess = resp => {
        // on click of submit the user is redirected to the listAll component where the state of this page is passed
        // and the results are listed    
        console.log(resp.data.data)
        this.setState({
            searchArr: resp.data.data
        }, () => this.props.history.push({ pathname: '/ListAll', state: { ...this.state } }))
    }

    onClickError = err => {
        console.log(err)
    }

    render() {
        return (
            <React.Fragment >
                <div className="container">
                    <div className="wrapper">
                        <div className="header-text">
                            <DebounceInput
                                // this is used to send the input value to the state one second after the user stops typing
                                minLength={0}
                                debounceTimeout={100}
                                className="searchInput"
                                name="searchTerm"
                                input type='textarea'
                                placeholder="search campsite, or location"
                                value={this.state.searchTerm}
                                onChange={this.onChange}
                            />
                            {/* button that sends the information to the NPS API */}
                            <div className="btn btn-primary btn-lg" onClick={this.onClick}>Let's Go!</div>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

export default LandingPage