<template>
<v-container>
  <v-card>
    <div class="d-flex flex-column">
      <div>{{detailBook?.title}}</div>
      <div>Author: {{detailBook?.author}}</div>
      <div>Publisher: {{detailBook?.publisher}}</div>
      <div>Publication Date: {{detailBook?.publicationDate}}</div>
      <div>Category: {{detailBook?.category}}</div>
      <div>Page Count: {{detailBook?.pageCount}}</div>
    </div>
    <v-card-actions>
      <v-btn class="text-white"
             color="primary"
             variant="flat"
             @click="checkoutBook">Checkout
      </v-btn>
      <v-btn class="text-white"
             color="primary"
             variant="flat">Edit
      </v-btn>
    </v-card-actions>
  </v-card>
</v-container>
</template>

<script setup>
import {useRoute} from "vue-router";
import {useStore} from "vuex";
import {computed} from "vue";

const route = useRoute();
const store = useStore();

const allBooks = computed(() => {
  return store.getters['books/allBooks'];
})

const detailBook = computed(() => {
  let index =  allBooks.value?.findIndex((book) => {
    return route.params.id == book.id;
  });
  if (index === -1) {
    return null
  }
  return allBooks.value[index];
})

const checkoutBook = () => {
  store.dispatch('books/checkoutBook', detailBook.value);
}
</script>

<style scoped>

</style>