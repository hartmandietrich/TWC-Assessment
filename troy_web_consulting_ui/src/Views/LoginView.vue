<template>
  <v-row justify="center">
    <v-col cols="12">
      <v-tabs v-model="tab" color="primary">
        <v-tab value="login">Log In</v-tab>
        <v-tab value="register">Register</v-tab>
      </v-tabs>
    </v-col>
    <v-col cols="12" align-self="center">
      <v-tabs-window v-model="tab">
        <v-tabs-window-item value="login">
          <LoginForm @login="routeToFeatured"/>
        </v-tabs-window-item>
        <v-tabs-window-item value="register">
          <RegisterForm @register="tab = 'login'"/>
        </v-tabs-window-item>
      </v-tabs-window>
    </v-col>
  </v-row>
</template>

<script setup>
import {ref} from "vue";
import {useRouter} from "vue-router";
import LoginForm from "@/components/Forms/LoginForm.vue";
import RegisterForm from "@/components/Forms/RegisterForm.vue";

const tab = ref();
const router = useRouter();

const routeToFeatured = () => {
  router.push("/featured");
}
</script>
