<template>
  <v-card>
    <v-form v-model="valid">
      <v-text-field v-model="username" label="Username" :rules="usernameRules" required></v-text-field>
      <v-text-field v-model="password" label="Password" :rules="passwordRules" required></v-text-field>
    </v-form>
    <v-card-actions>
      <v-btn :disabled="!valid" class="text-white" color = "primary" variant="flat" @click="login">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup>
import {ref} from "vue";
import { useStore } from "vuex";
import { defineEmits } from "vue";

const store = useStore();
const emit = defineEmits(["login"]);

const valid = ref(false);
const username = ref();
const password = ref();

const usernameRules = [value => {
  if (value) return true
  return 'Username is required.'
}]
const passwordRules = [value => {
  if (value) return true
  return 'Password is required.'
}]

const login = async () => {
  const loginInfo = {
    username: username.value,
    password: password.value,
  }
  await store.dispatch('authentication/login', loginInfo);

  emit("login");
}
</script>
