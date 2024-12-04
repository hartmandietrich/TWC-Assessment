<template>
<v-container class="d-flex flex-column justify-end">
  <v-row>
    <v-col cols="10">
      <div class="text-h5"> Featured Books </div>
    </v-col>
    <v-col cols="2">
      <LogOutButton @click="routeToLogin"/>
    </v-col>
    <v-col :cols="books.length/numFeatured" v-for="(book, id) in featuredBooks">
      <FeaturedBookInfo :book="book" />
    </v-col>
    <v-col cols="10">
      <div class="text-h6">All Books</div>
    </v-col>
    <v-col cols="2">
      <v-btn class="text-white"
             color="primary"
             variant="flat"
             @click="filterDialog=true">Filter
      </v-btn>
    </v-col>
    <v-col cols="12">
      <v-text-field v-model="search" label="Search" variant="outlined"></v-text-field>
    </v-col>
    <v-col cols="12" v-for="(book, id) in searchAndFilteredBooks">
      <BookInfo :book="book"></BookInfo>
    </v-col>
  </v-row>
  <v-fab color="primary" icon class="mt-12" @click="createBookDialog = true">+</v-fab>
  <v-dialog v-model="createBookDialog">
    <CreateBookForm @exitcreate="createBookDialog = false"/>
  </v-dialog>
  <v-dialog v-model="filterDialog">
    <FilterPanel @exitfilter="filterDialog=false" @filter="updateFilterOptions"/>
  </v-dialog>
</v-container>
</template>

<script setup>
import {computed, onMounted, ref} from "vue";
import {useRouter} from "vue-router";
import {useStore} from "vuex";
import BookInfo from "@/components/Books/BookInfo.vue";
import FeaturedBookInfo from "@/components/Books/FeaturedBookInfo.vue";
import LogOutButton from "@/components/LogOutButton.vue";
import CreateBookForm from "@/components/Forms/CreateBookForm.vue";
import FilterPanel from "@/components/FilterPanel.vue";

const store = useStore();
const router = useRouter();
const numFeatured = 4;

const books = ref([]);
const search = ref("");
const createBookDialog = ref(false);
const filterDialog = ref(false);
const filterOptions = ref({
  author: "",
  availability: "All"
});

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
const searchAndFilteredBooks = computed(() => {
  return searchedBooks.value.filter((book) => {
    return (!filterOptions.value.author || book.author.toLowerCase().includes(filterOptions.value.author.toLowerCase())) &&
        (filterOptions.value.availability === null || book.isCheckedOut !== filterOptions.value.availability);
  })
})

const updateFilterOptions = (newOptions) => {
  filterOptions.value = newOptions
}

const routeToLogin = () => {
  router.push("/");
}
</script>