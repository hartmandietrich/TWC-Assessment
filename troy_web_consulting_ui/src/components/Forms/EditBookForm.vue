<template>
<v-container>
  <v-card class="pa-8">
    Edit Book
    <v-text-field v-model="book.title" label="Title"></v-text-field>
    <v-text-field v-model="book.author" label="Author"></v-text-field>
    <v-textarea v-model="book.description" label="Description"></v-textarea>
    <v-text-field v-model="book.publisher" label="Publisher"></v-text-field>
    <v-text-field v-model="book.category" label="Category"></v-text-field>
    <v-text-field v-model="book.pageCount" label="Page Count"></v-text-field>

    <v-card-actions>
      <div class="d-flex">
        <v-btn class="text-white" color = "primary" variant="flat" @click="saveBook">Save</v-btn>
        <v-btn class="text-white" color = "primary" variant="flat" @click="exitEdit">Cancel</v-btn>
      </div>
    </v-card-actions>
  </v-card>
</v-container>
</template>

<script setup>
import {defineProps, onMounted, ref,} from "vue";
import {useStore} from "vuex";

const store = useStore();
const emit = defineEmits(["exitedit"]);

const book = ref({
  id: null,
  author:"",
  category:"",
  description:"",
  pageCount:null,
  publisher:"",
  title:"",

})

const props = defineProps({
  book: {}
})

onMounted(() => {
  book.value = props.book;
})

const saveBook = async () => {
  if(book.value.id === null){
    return;                         //Handle for this case
  }
  await store.dispatch("books/editBook", book.value);
  exitEdit();
}

const exitEdit = () => {
  emit("exitedit");
}

</script>
