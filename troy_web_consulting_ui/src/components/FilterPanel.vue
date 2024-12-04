<template>
<v-container>
  <v-card class="pa-6">
    Filter
    <v-text-field v-model="filterAuthor" label="Author"></v-text-field>
    <v-select v-model="availability" label="Availability" :items="availabilityOptions"></v-select>
    <v-card-actions>
      <div class="d-flex">
        <v-btn class="text-white mr-2" color = "primary" variant="flat" @click="filter">Filter</v-btn>
        <v-btn class="text-white" color = "primary" variant="flat" @click="exitFilter">Cancel</v-btn>
      </div>
    </v-card-actions>
  </v-card>
</v-container>
</template>

<script setup>
import {ref} from "vue";

const availabilityOptions = ["Available", "Unavailable", "All"];

const filterAuthor = ref("");
const availability = ref("All")

const emit = defineEmits(["filter", "exitfilter"]);

const filter = () => {
  let isAvailable = null;
  if(availability.value === "Available") {
    isAvailable = true;
  }
  if(availability.value === "Unavailable") {
    isAvailable = false;
  }
  const filterOptions = {
    author: filterAuthor.value,
    availability: isAvailable,
  }
  console.log("filter", filterOptions);
  emit("filter", filterOptions);
  exitFilter();
}

const exitFilter = () => {
  emit("exitfilter");
}

</script>
