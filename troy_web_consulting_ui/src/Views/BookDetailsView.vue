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
             :disabled="isUnavailable"
             @click="checkoutBook">Checkout
      </v-btn>
      <v-btn class="text-white"
             color="primary"
             variant="flat"
              @click="editBookDialog=true">Edit
      </v-btn>
      <v-btn class="text-white"
             color="red"
             variant="flat"
             @click="deleteBook">Delete

      </v-btn>
    </v-card-actions>
  </v-card>
  <v-dialog v-model="editBookDialog">
    <EditBookForm :book="detailBook" @exitedit="editBookDialog=false"/>
  </v-dialog>
</v-container>
</template>

<script setup>
import {useRoute} from "vue-router";
import {useStore} from "vuex";
import {computed, ref} from "vue";
import EditBookForm from "@/components/Forms/EditBookForm.vue";

const route = useRoute();
const store = useStore();

const editBookDialog = ref(false);

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

const isUnavailable = computed(() => {
  if (detailBook.value) {
    return detailBook.value.isCheckedOut
  }
  return true;
})

const checkoutBook = () => {
  store.dispatch('books/checkoutBook', detailBook.value);
}

const deleteBook = () => {
  store.dispatch('books/deleteBook', detailBook.value);
}
</script>