import axios from 'axios'


class SearchService {
    static search(searchTerm, onSuccess, onError) {
        axios.get(`https://developer.nps.gov/api/v1/parks?q=${searchTerm}&api_key=GyzhcPODYbOrZ3qR2M1fyPmZPPZf6eVYl9oHqJy7`)

            .then(onSuccess)
            .catch(onError)
    }

    static searchByParkCode(parkCode, onSuccess, onError) {
        axios.get(`https://api.nps.gov/api/v1/parks?parkCode=${parkCode}&api_key=GyzhcPODYbOrZ3qR2M1fyPmZPPZf6eVYl9oHqJy7`)

            .then(onSuccess)
            .catch(onError)
    }
}
export default SearchService