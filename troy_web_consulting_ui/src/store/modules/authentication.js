import axios from "axios";

const actions = {
    async login({},loginInfo) {
        console.log(loginInfo);
        return axios.post('https://localhost:44346/Authorization/user/login', loginInfo, {withCredentials: true})
    },

    async registerUser({}, registerInfo) {
        return axios.post('https://localhost:44346/Authorization/user/register', registerInfo, {withCredentials: true})
    },

    async logout (){
        return axios.post('https://localhost:44346/Authorization/user/logout', {}, {withCredentials: true})
    }
}

export default {
    namespaced: true,
    actions
}
