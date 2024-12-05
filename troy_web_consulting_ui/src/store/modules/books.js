import axios from "axios";
import {baseUrl} from "@/store/baseApiUrl.js";

const state = () => ({
    books: [],
    searchedBooks: []
})

const getters = {
    allBooks: state => state.books,
}

const actions = {
    async getBooks({state}) {
        return axios.get(`${baseUrl}/Book/getall`, {withCredentials: true})
            .then((response) => {
                state.books = response.data;
            })
    },

    async editBook({},book) {
        return axios.put(`${baseUrl}/Book/update`, book, {withCredentials: true})
    },

    async createBook({},book) {
        return axios.post(`${baseUrl}/Book/create`, book, {withCredentials: true})
    },

    async deleteBook({}, bookId) {
        return axios.delete(`${baseUrl}/Book/delete/${bookId}`, {withCredentials: true})
    },

    async checkoutBook({}, book) {
        return axios.post(`${baseUrl}/Book/checkout`, book, {withCredentials: true})
    },

    async makeBookAvailable({}, book) {
        return axios.post(`${baseUrl}/Book/makeavailable`, book, {withCredentials: true})
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions
}