import { createRouter, createWebHistory } from 'vue-router'
import LoginView from "@/Views/LoginView.vue";
import FeaturedView from "@/Views/FeaturedView.vue";
import BookDetailsView from "@/Views/BookDetailsView.vue";

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: LoginView,
        },
        {
            path: '/featured',
            component: FeaturedView,
        },
        {
            path: '/bookdetails/:id',
            component: BookDetailsView
        }
    ]
})