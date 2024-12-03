import axios from "axios";

const state = () => ({
    books: [],
    searchedBooks: []
})

const getters = {
    allBooks: state => state.books,
}

const actions = {
    async getBooks({state}) {
        return axios.get('https://localhost:44346/api/Book/getall', {withCredentials: true})
            .then((response) => {
                state.books = response.data;
            })
    },

    async editBook({},book) {
        return axios.put('https://localhost:44346/api/Book/update', book, {withCredentials: true})
    },

    async createBook({},book) {
        return axios.post('https://localhost:44346/api/Book/create', book)
    },

    async deleteBook({}, book) {
        return axios.delete('https://localhost:44346/api/Book/delete', {
            headers: {
                withCredentials: true
            },
            data: book
        })
    },

    async checkoutBook({}, book) {
        return axios.post('https://localhost:44346/api/Book/checkout', book, {withCredentials: true})
    },

    async makeBookAvailable({}, book) {
        return axios.post('https://localhost:44346/api/Book/makeavailable', book)
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions
}