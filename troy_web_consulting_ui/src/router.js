import { createRouter, createWebHistory } from 'vue-router'
import LoginView from "@/Views/LoginView.vue";

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: LoginView,
        }
    ]
})