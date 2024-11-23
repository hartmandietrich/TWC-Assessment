<template>
<v-container>
  <v-row>
    <v-col cols="12">
      Featured Books
    </v-col>
    <v-col :cols="books.length/numFeatured" v-for="(book, id) in featuredBooks">
      <v-card>
        {{ book.title }}
      </v-card>
    </v-col>
    <v-col cols="12">
      All Books
      <v-text-field v-model="search" label="Search" variant="outlined"></v-text-field>
    </v-col>
    <v-col cols="12" v-for="(book, id) in searchedBooks">
      <BookInfo :book="book"></BookInfo>
    </v-col>
  </v-row>
</v-container>
</template>

<script setup>
import {computed, onMounted, ref} from "vue";
import {useStore} from "vuex";
import BookInfo from "@/components/Books/BookInfo.vue";

const store = useStore();
const numFeatured = 4;

const books = ref([]);
const search = ref("");

onMounted(async () => {
  await store.dispatch("books/getBooks");
  books.value = store.state.books.books;
})

const featuredBooks = computed(() => {
  if (numFeatured >= books.value.length) {
    return books.value;
  }
  let featuredBooksArray = []
  while (featuredBooksArray.length < numFeatured) {
    let bookChosen = books.value[Math.floor(Math.random() * books.value.length)];
    if(featuredBooksArray.indexOf(bookChosen) === -1) {
      featuredBooksArray.push(bookChosen);
    }
  }
  return featuredBooksArray;
})

const searchedBooks = computed(() => {
  return books.value.filter(book => book.title.toLowerCase().includes(search.value.toLowerCase()));
})
</script>