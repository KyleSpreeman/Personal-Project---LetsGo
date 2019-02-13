import React from 'react'
import ParksService from '../../services/ParksService';
import PackingEssentialCard from './PackingEssentialCard';

class PackingEssentials extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            Packing: ""
        }
    }

    componentDidMount = evt => {
        ParksService.scrape(this.onScrapeSuccess, this.onScrapeError)
    }

    onScrapeSuccess = resp => {
        console.log(resp.data)
        this.setState({
            Packing: resp.data
        })
    }

    onScrapeError = err => {
        console.log(err)
    }


    render() {
        return (
            <React.Fragment>
                <PackingEssentialCard
                    packing={this.state.Packing} />
            </React.Fragment>
        )
    }
}
export default PackingEssentials