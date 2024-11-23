import {createStore} from "vuex";
import authentication from "./modules/authentication";
import books from "./modules/books.js";

export default createStore({
    modules: {
        authentication,
        books,
    }
})