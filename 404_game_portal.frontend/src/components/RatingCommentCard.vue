<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import StarBar from '@/components/StarBar.vue';
import api from '@/api';
import { Rating } from '@/api/rating';
import { ref, watch } from 'vue';
import CommentSection from '@/components/CommentSection.vue';
import { SubmitEventPromise } from 'vuetify';
import { useCurrentUserStore } from '@/store/currentUserStore';
import { Role } from '@/api/auth';
import rules from '@/util/roules';

const props = defineProps<{
  gameId: string;
}>();
const currentUserStore = useCurrentUserStore();
const shouldReload = ref(true);
const rating = ref<Rating>();

const createRating = usePromise(api.createRating, (result) => {
  rating.value = result;
});
const getRating = usePromise(api.fetchRating, (result) => {
  rating.value = result;
});
watch(
  () => currentUserStore.isLoggedIn,
  () => {
    getRating.createPromise(props.gameId);
    shouldReload.value = true;
  },
  { immediate: true },
);

const commentText = ref<string>('');
const createComment = usePromise(api.createComment, () => {
  shouldReload.value = true;
});
const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid) {
    await createComment.createPromise({
      comment: commentText.value,
      gameId: props.gameId,
    });
  }
  commentText.value = '';
};
</script>

<template>
  <v-card :loading="getRating.loading.value">
    <h2>Comments</h2>
    <v-row
      v-if="
        currentUserStore.isLoggedIn &&
        currentUserStore.user &&
        currentUserStore.user.role >= Role.User
      "
    >
      <v-col cols="12" md="8">
        <v-form @submit.prevent="submit">
          <v-textarea label="Comment" v-model="commentText" :rules="rules" />
          <v-btn type="submit">Submit comment</v-btn>
        </v-form>
      </v-col>
      <v-col cols="12" md="4" v-if="rating">
        <star-bar click-enabled v-model:rating="rating.rating" />
        <v-btn
          @click="createRating.createPromise({ rating: rating.rating, gameId: gameId })"
          :loading="createRating.loading.value"
        >
          Submit rating
        </v-btn>
      </v-col>
    </v-row>
    <comment-section v-model:should-reload="shouldReload" :game-id="gameId" />
  </v-card>
</template>

<style scoped lang="scss"></style>
