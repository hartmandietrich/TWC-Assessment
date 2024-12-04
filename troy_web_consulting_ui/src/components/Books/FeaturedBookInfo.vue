<template>
  <v-card @click="routeToDetails" color="secondary" class="pa-3">
    <div class="d-flex flex-column">
      <div class="text-subtitle-1 font-weight-medium">
        {{ book.title }}
      </div>
      <div>
        Author: {{ book.author }}
      </div>
      <div>
        Description: {{ book.description }}
      </div>
    </div>
  </v-card>
</template>

<script setup>
import {defineProps} from "vue";
import {useRouter} from "vue-router";

const router = useRouter();

const props = defineProps({
  book: {}
})

const routeToDetails = () => {
  router.push(`/bookdetails/${props.book.id}`)
}
</script>
