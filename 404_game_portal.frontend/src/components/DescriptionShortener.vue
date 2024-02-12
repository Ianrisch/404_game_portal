<template>
  <p v-if="descriptionLengthExceeded">
    {{ description.substring(0, props.maxLength ?? defaultMaxLength).trim() + '...' }}
    <a :href="tag ?? '#description'">more</a>
  </p>
  <p v-else>
    {{ description }}
  </p>
</template>
<script setup lang="ts">
import { watch } from 'vue';

const props = defineProps<{
  description: string;
  maxLength?: number;
  tag?: string;
}>();
const descriptionLengthExceeded = defineModel<boolean>('descriptionLengthExceeded');

const defaultMaxLength = 100;

watch(
  () => props.description,
  () =>
    (descriptionLengthExceeded.value =
      props.description.length > (props.maxLength ?? defaultMaxLength)),
  { immediate: true },
);
</script>
<style scoped>
h1 {
  margin-left: auto;
  margin-right: auto;
  padding-top: 10px;
}

:deep(.v-chip) {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
}

img {
  height: 300px;
  object-fit: cover;
}
</style>
