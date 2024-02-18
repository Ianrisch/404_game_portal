<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import api from '@/api';

const props = defineProps<{
  gameId: string;
}>();

const { loading, result, createPromise } = usePromise(api.fetchComments);
createPromise(props.gameId);
</script>

<template v-if="result">
  <v-row>
    <v-col>
      <v-card class="commentCard" v-for="comment in result" :key="comment.id" :loading="loading">
        <p>{{ comment.comment }}</p>
        <p class="commentBy">
          Commented by <span class="user">{{ comment.userName }}</span>
        </p>
      </v-card>
    </v-col>
  </v-row>
</template>

<style scoped lang="scss">
.commentCard {
  width: 100%;
  margin: 5px;
  padding: 10px;
}

.commentBy {
  font-style: italic;
  font-size: 0.9em;
  color: #555;

  .user {
    text-decoration: underline;
  }
}
</style>
