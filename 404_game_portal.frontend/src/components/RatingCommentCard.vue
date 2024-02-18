<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import StarBar from '@/components/StarBar.vue';
import api from '@/api';
import { Rating } from '@/api/rating';
import { ref } from 'vue';
import CommentSection from '@/components/CommentSection.vue';
import { SubmitEventPromise } from 'vuetify';

const props = defineProps<{
  gameId: string;
}>();
const rating = ref<Rating>();

const createRating = usePromise(api.createRating, (result) => {
  rating.value = result;
});
const getRating = usePromise(api.fetchRating, (result) => {
  rating.value = result;
});

getRating.createPromise(props.gameId);

const rules = ref([(value: any) => !!value || 'Required']);
const commentText = ref<string>('');
const createComment = usePromise(api.createComment);
const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid) {
    createComment.createPromise({
      comment: commentText.value,
      gameId: props.gameId,
    });
  }
  commentText.value = '';
};
</script>

<template>
  <v-card :loading="getRating.loading.value">
    <v-row>
      <v-col cols="8">
        <v-form @submit.prevent="submit">
          <v-textarea label="Comment" v-model="commentText" :rules="rules" />
          <v-btn type="submit">Submit comment</v-btn>
        </v-form>
      </v-col>
      <v-col cols="4" v-if="rating">
        <star-bar click-enabled v-model:rating="rating.rating" />
        <v-btn
          @click="createRating.createPromise({ rating: rating.rating, gameId: gameId })"
          :loading="createRating.loading.value"
        >
          Submit rating
        </v-btn>
      </v-col>
    </v-row>
    <comment-section :game-id="gameId" />
  </v-card>
</template>

<style scoped lang="scss"></style>
