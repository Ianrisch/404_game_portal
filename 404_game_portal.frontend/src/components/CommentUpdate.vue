<script setup lang="ts">
import rules from '@/util/roules';
import { ref } from 'vue';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { SubmitEventPromise } from 'vuetify';
import { Comment } from '@/api/comment';

const props = defineProps<{
  comment: Comment;
}>();
const showDialog = ref<boolean>(false);

const updatedCommentText = ref<string>('');
const commentId = ref<string>('');

const emit = defineEmits<{
  (e: 'updateComments'): void;
}>();

const updateComment = usePromise(api.updateComment, () => emit('updateComments'));
const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid) {
    await updateComment.createPromise({
      comment: updatedCommentText.value,
      id: commentId.value,
    });
  }
};
</script>

<template>
  <v-btn
    variant="flat"
    @click="
      updatedCommentText = comment.comment;
      commentId = comment.id;
    "
  >
    <v-avatar icon="mdi-pencil" />
    <v-dialog v-model="showDialog" activator="parent">
      <v-card>
        <v-form @submit.prevent="submit">
          <v-textarea label="Comment" v-model="updatedCommentText" :rules="rules" />
          <v-btn @click="showDialog = false" type="submit">Save changes</v-btn>
        </v-form>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<style scoped lang="scss">
.v-dialog {
  width: 600px;
  .v-card {
    padding: 10px;
    background-color: #222;
  }
}
</style>
