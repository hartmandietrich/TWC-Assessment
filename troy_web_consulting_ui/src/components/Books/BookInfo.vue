<template>
  <v-card>{{props.book.title}}</v-card>
</template>

<script setup>
import {defineProps} from "vue"

const props = defineProps({
  book: {}
})
</script>