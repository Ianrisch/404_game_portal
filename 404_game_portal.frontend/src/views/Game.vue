<script setup lang="ts">
import { USK } from '@/api/game';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { watch } from 'vue';
const props = defineProps<{
  id: string;
}>();

const { loading, result, createPromise } = usePromise(api.fetchGame);

watch(
  () => props.id,
  () => {
    createPromise(props.id);
  },
  { immediate: true },
);
createPromise(props.id);
</script>

<template>
  <v-card v-if="!loading && result">
    <v-card-title>
      {{ result.name }}
    </v-card-title>
    <v-card-text>
      {{ result.description }}
      {{ USK[result.usk] }}
    </v-card-text>
  </v-card>
  <div v-else>A Problem Occurred</div>
</template>

<style scoped></style>
