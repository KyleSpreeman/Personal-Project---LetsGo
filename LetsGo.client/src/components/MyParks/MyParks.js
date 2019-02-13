import React from 'react'
import MyParksCards from './MyParksCards'
import './MyParks.css'
import { Card, CardImg, CardText, CardBody, CardTitle, Row, Col } from 'reactstrap'
import ParksService from '../../services/ParksService';
import SearchService from '../../services/SearchService';

class MyParks extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            logedIn: "",
            whereIveBeen: [],
            FirstName: "",
        }
    }

    componentDidMount = evt => {
        this.setState({ whereIveBeen: [] })
        ParksService.listSavedParks(this.onListSuccess, this.onListError)
        document.body.style.backgroundImage = "url('https://thumbor-static.factorymedia.com/6sB1NoMr_iWLS6L1PcRnWH2Llrc=/2000x1300/smart/http%3A%2F%2Fcoresites-cdn.factorymedia.com%2Fmpora_new%2Fwp-content%2Fuploads%2F2017%2F06%2FWild-Camping-In-Scotland.jpg')"
    }

    onListSuccess = resp => {
        this.setState({
            FirstName: resp.data.items[0].firstName
        })
        resp.data.items.map(props => {
            SearchService.searchByParkCode(props.parkCode, this.onSearchSuccess, this.onSearchError)
        })
    }

    onListError = err => {
        console.log(err)
    }

    onSearchSuccess = resp => {
        console.log(resp.data)
        let newArr = this.state.whereIveBeen
        newArr.push(resp.data.data)
        this.setState({
            whereIveBeen: newArr
        })
    }

    onSearchError = err => {
        console.log(err)
    }

    deletSavedPark = props => {
        ParksService.deleteSavedPark(props, this.onDeleteSuccess, this.onDeleteError)
    }
    onDeleteSuccess = resp => {
        console.log(resp)
        window.location.reload();
    }
    onDeleteError = err => {
        console.log(err)
    }
    render() {
        console.log(this.state.FirstName)
        return (
            < React.Fragment >
                <div className="home-container" >
                    <h1> Welcome Back {this.state.FirstName},</h1>
                    <h3>Where I've been: </h3>
                </div>
                <div className="cards-container">
                    <div className="card-deck">
                        {this.state.whereIveBeen.map(para => {
                            return (
                                <MyParksCards
                                    description={para[0].description}
                                    image={para[0].image}
                                    name={para[0].name}
                                    website={para[0].url}
                                    parkCode={para[0].parkCode}
                                    delete={this.deletSavedPark}
                                />
                            )
                            // })
                        })}
                    </div>
                </div>
            </React.Fragment >
        )
    }
}

export default MyParks