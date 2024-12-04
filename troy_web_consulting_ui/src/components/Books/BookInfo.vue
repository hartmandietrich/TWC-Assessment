<template>
  <v-card class="pa-2" @click="routeToDetails">{{props.book.title}}</v-card>
</template>

<script setup>
import {defineProps} from "vue"
import {useRouter} from "vue-router";

const router = useRouter();

const props = defineProps({
  book: {}
})

const routeToDetails = () => {
  router.push(`/bookdetails/${props.book.id}`)
}
</script>