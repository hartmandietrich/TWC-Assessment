<template>
  <v-row justify="center">
    <v-col cols="12">
      <v-tabs v-model="tab">
        <v-tab value="login">Log In</v-tab>
        <v-tab value="register">Register</v-tab>
      </v-tabs>
    </v-col>
    <v-col cols="12" align-self="center">
      <v-tabs-window v-model="tab">
        <v-tabs-window-item value="login">
          <LoginForm />
        </v-tabs-window-item>
        <v-tabs-window-item value="register">
          <LoginForm />
        </v-tabs-window-item>
      </v-tabs-window>
    </v-col>
  </v-row>
</template>

<script setup>
import LoginForm from "@/components/Forms/LoginForm.vue";
import {ref} from "vue";

var tab = ref();
</script>
