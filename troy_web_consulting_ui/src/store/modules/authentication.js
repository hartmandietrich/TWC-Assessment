import axios from "axios";

const actions = {
    async login({},loginInfo) {
        return axios.post('https://localhost:44346/Authorization/user/login', loginInfo)
    },

    async registerUser({}, registerInfo) {
        return axios.post('https://localhost:44346/Authorization/user/register', registerInfo)
    }
}

export default {
    namespaced: true,
    actions
}
