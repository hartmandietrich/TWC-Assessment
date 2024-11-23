<template>
  <v-card @click="routeToDetails">
    <div class="d-flex flex-column">
      <div>
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
