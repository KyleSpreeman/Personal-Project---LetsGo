import axios from 'axios'

class UserService {
    static register(data, onSuccess, onError) {
        axios.post('api/account/register', data, { withCredentials: true })

            .then(onSuccess)
            .catch(onError)
    }

    static login(data, onSuccess, onError) {
        axios.post('api/account/login', data, { withCredentials: true })

            .then(onSuccess)
            .catch(onError)
    }
}

export default UserService