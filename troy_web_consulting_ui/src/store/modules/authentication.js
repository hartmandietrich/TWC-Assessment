import axios from "axios";
import {baseUrl} from "@/store/baseApiUrl.js";

const actions = {
    async login({},loginInfo) {
        return axios.post(`${baseUrl}/Authorization/user/login`, loginInfo, {withCredentials: true})
    },

    async registerUser({}, registerInfo) {
        return axios.post(`${baseUrl}/Authorization/user/register`, registerInfo, {withCredentials: true})
    },

    async logout (){
        return axios.post(`${baseUrl}/Authorization/user/logout`, {}, {withCredentials: true})
    }
}

export default {
    namespaced: true,
    actions
}
