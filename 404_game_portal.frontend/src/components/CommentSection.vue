<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { watch } from 'vue';
import { useCurrentUserStore } from '@/store/currentUserStore';
import CommentUpdate from '@/components/CommentUpdate.vue';

const props = defineProps<{
  gameId: string;
}>();
const shouldReload = defineModel<boolean>('shouldReload', { default: true });

const { loading, result, createPromise } = usePromise(api.fetchComments, () => {
  shouldReload.value = false;
});

const currentUserStore = useCurrentUserStore();

watch(
  shouldReload,
  (newValue) => {
    if (newValue) createPromise(props.gameId);
  },
  { immediate: true },
);
</script>

<template v-if="result">
  <v-row>
    <v-col>
      <v-card class="commentCard" v-for="comment in result" :key="comment.id" :loading="loading">
        <p>{{ comment.comment }}</p>
        <div class="controls">
          <p class="commentBy">
            Commented by <span class="user">{{ comment.userName }}</span>
          </p>
          <comment-update
            v-if="
              currentUserStore.isLoggedIn &&
              currentUserStore.user &&
              comment.userName === currentUserStore.user?.username
            "
            :comment="comment"
          />
        </div>
      </v-card>
    </v-col>
  </v-row>
</template>

<style scoped lang="scss">
.commentCard {
  width: 100%;
  margin: 5px;
  padding: 10px;

  .controls {
    display: flex;
    align-items: center;
    justify-content: space-between;
    .commentBy {
      font-style: italic;
      font-size: 0.9em;
      color: #555;

      .user {
        text-decoration: underline;
      }
    }
  }
}
</style>
