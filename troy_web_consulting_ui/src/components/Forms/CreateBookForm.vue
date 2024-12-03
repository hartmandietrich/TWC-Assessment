<template>
  <v-container>
    <v-card class="pa-8">
      Add New Book
      <v-text-field v-model="book.title" label="Title"></v-text-field>
      <v-text-field v-model="book.author" label="Author"></v-text-field>
      <v-textarea v-model="book.description" label="Description"></v-textarea>
      <v-text-field v-model="book.publisher" label="Publisher"></v-text-field>
      <v-text-field v-model="book.category" label="Category"></v-text-field>
      <v-text-field v-model="book.pageCount" label="Page Count"></v-text-field>

      <v-card-actions>
        <div class="d-flex">
          <v-btn class="text-white mr-2" color = "primary" variant="flat" @click="saveBook">Save</v-btn>
          <v-btn class="text-white" color = "primary" variant="flat" @click="exitCreate">Cancel</v-btn>
        </div>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup>

import {ref} from "vue";
import {useStore} from "vuex";

const store = useStore();
const emit = defineEmits(["exitcreate"]);

const book = ref({
  author:"",
  category:"",
  description:"",
  pageCount:null,
  publicationDate: "2024-01-01",
  publisher:"",
  title:"",
  isCheckedOut: false,

})

const saveBook = async () => {
  await store.dispatch("books/createBook", book.value);
  exitCreate();
}

const exitCreate = () => {
  emit("exitcreate");
}

</script>

<style scoped>

</style>