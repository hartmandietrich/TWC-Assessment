import './assets/main.css'

import { createApp } from 'vue'
import store from "@/store/index.js";
import App from './App.vue'
import router from "@/router.js";
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
    components,
    directives,
})

createApp(App)
    .use(router)
    .use(vuetify)
    .use(store)
    .mount('#app')
