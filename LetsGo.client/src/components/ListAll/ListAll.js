import React from 'react'
import ListAllCard from './ListAllCard'
import './ListAll.css'
import ParksService from '../../services/ParksService'

class ListAll extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            listArr: []

        }
    }

    componentDidMount() {
        // sets the background on component load
        document.body.style.backgroundImage = "url('https://cdn-image.travelandleisure.com/sites/default/files/styles/1600x1000/public/1491585429/yosemite-national-park-PARKBROS0417.jpg?itok=0JYlsmHR')"
        // sets the state of the listArr to the information passed from the landing page
        this.setState({
            listArr: this.props.location.state.searchArr
        })
    }

    saveToAccount = props => {
        let data = {
            ParkCode: props
        }
        ParksService.savePark(data, this.onSaveSuccess, this.onSaveError)
    }

    onSaveSuccess = resp => {
        console.log(resp)
    }

    render() {
        console.log(this.state.listArr)
        return (
            <React.Fragment>
                <div className="listContainer">
                    <div className="card-deck">
                        {this.state.listArr.map(props => {
                            // maps through the information from the landing page and passes them to the cards 
                            return (
                                <ListAllCard
                                    name={props.name}
                                    description={props.description}
                                    url={props.url}
                                    weather={props.weatherInfo}
                                    state={props.states}
                                    parkCode={props.parkCode}
                                    save={this.saveToAccount}
                                />
                            )
                        })}
                    </div>
                </div>
            </React.Fragment>

        )
    }
}

export default ListAll