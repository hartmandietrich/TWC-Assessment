<template>
<v-btn class="text-white" color = "primary" variant="flat" @click="logout">Log Out</v-btn>
</template>

<script setup>

import {useStore} from "vuex";

const store = useStore();

const logout = async () => {
  await store.dispatch("authentication/logout");
}
</script>