<script setup lang="ts">
import { computed, ref, watch } from 'vue';
import { useFirebase } from '@/store/useFirebase';

const props = defineProps<{
  filePath: string;
  width?: string | number;
  height?: string | number;
  cover?: boolean;
  alternativePath?: string;
  alt?: string;
}>();

const firebase = useFirebase();

const imageSrc = ref<string>();
const loading = ref(true);

watch(
  () => props.filePath,
  () => {
    loading.value = true;
    firebase
      .getUrlForFile(props.filePath)
      .then((url) => {
        imageSrc.value = url;
      })
      .finally(() => {
        loading.value = false;
      });
  },
  { immediate: true },
);

const actualWidth = computed(() => {
  return props.width ?? '100%';
});
const actualHeight = computed(() => {
  return props.height ?? '100%';
});
</script>

<template>
  <div class="custom-img" v-if="!loading && (imageSrc || alternativePath)">
    <v-img
      :src="imageSrc ?? alternativePath"
      :alt="alt ?? filePath"
      :width="actualWidth"
      :height="actualHeight"
      cover
    />
  </div>
  <v-skeleton-loader
    v-else
    :elevation="24"
    class="mx-auto"
    :loading="loading"
    type="image"
    :width="actualWidth"
    :height="actualHeight"
  />
</template>

<style scoped lang="scss">
.custom-img {
  width: v-bind(actualWidth);
  height: v-bind(actualHeight);
}
:deep(.v-skeleton-loader__image) {
  width: v-bind(actualWidth);
  height: v-bind(actualHeight);
}
</style>
