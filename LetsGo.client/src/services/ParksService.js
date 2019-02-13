import axios from 'axios'

class ParksService {
    static savePark(data, onSuccess, onError) {
        axios.post('api/parks', data, { withCredentials: true })

            .then(onSuccess)
            .catch(onError)
    }

    static listSavedParks(onSuccess, onErrror) {
        axios.get('api/parks', { withCredentials: true })

            .then(onSuccess)
            .catch(onErrror)
    }

    static deleteSavedPark(ParkCode, onSuccess, onError) {
        axios.delete(`api/parks/${ParkCode}`, { withCredentials: true })

            .then(onSuccess)
            .catch(onError)
    }

    static scrape(onSuccess, onError) {
        axios.get('api/parks/scrape', { withCredentials: true })

            .then(onSuccess)
            .catch(onError)
    }
}

export default ParksService