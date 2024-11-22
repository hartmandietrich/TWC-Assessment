<template>
  <v-card>
    <v-form v-model="valid">
      <v-text-field v-model="username" label="Username" :rules="usernameRules" required></v-text-field>
      <v-text-field v-model="password" label="Password" :rules="passwordRules" required></v-text-field>
    </v-form>
    <v-card-actions>
      <v-btn :disabled="!valid">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup>
import {ref} from "vue";

var valid = ref(false);
var username = ref();
var password = ref();

var usernameRules = [value => {
  if (value) return true
  return 'Username is required.'
}]
var passwordRules = [value => {
  if (value) return true
  return 'Password is required.'
}]
</script>
