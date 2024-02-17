<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import StarBar from '@/components/StarBar.vue';
import api from '@/api';
import { Rating } from '@/api/rating';
import { ref } from 'vue';

const props = defineProps<{
  gameId: string;
}>();

const createRating = usePromise(api.createRating, (result) => {
  rating.value = result;
});
const getRating = usePromise(api.fetchRating, (result) => {
  rating.value = result;
});
const rating = ref<Rating>();

getRating.createPromise(props.gameId);
</script>

<template>
  <v-card :loading="getRating.loading.value">
    <div v-if="rating">
      <star-bar click-enabled v-model:rating="rating.rating" />
      <v-btn
        @click="createRating.createPromise({ rating: rating.rating, gameId: gameId })"
        :loading="createRating.loading.value"
      >
        submit
      </v-btn>
    </div>
  </v-card>
</template>

<style scoped lang="scss"></style>
