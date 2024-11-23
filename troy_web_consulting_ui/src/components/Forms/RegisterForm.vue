<template>
  <v-card>
    <v-form v-model="valid">
      <v-text-field v-model="username" label="Username" :rules="usernameRules" required></v-text-field>
      <v-text-field v-model="password" label="Password" :rules="passwordRules" required></v-text-field>
      <v-select v-model="role" label="Role" :items="roles" :rules="roleRules" required></v-select>
    </v-form>
    <v-card-actions>
      <v-btn :disabled="!valid" class="text-white" color = "primary" variant="flat" @click="registerUser">Register</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup>
import {ref} from "vue";
import { useStore } from "vuex";

const store = useStore();

const valid = ref(false);
const username = ref();
const password = ref();
const role = ref();

const roles = ["Customer", "Librarian"]
const usernameRules = [value => {
  if (value) return true
  return 'Username is required.'
}]
const passwordRules = [value => {
  if (value) return true
  return 'Password is required.'
}]
const roleRules = [value => {
  if (value) return true
  return 'Must chose a role.'
}]

const registerUser = () => {
  const registerInfo = {
    username: username.value,
    password: password.value,
    rolename: role.value
  }
  store.dispatch("authentication/registerUser", registerInfo)
}
</script>
