<script setup lang="ts">
import { computed, ref } from 'vue';
import { useFirebase } from '@/store/useFirebase';

const props = defineProps<{
  filePath: string;
  width?: string;
  height?: string;
  cover?: boolean;
  alternativePath?: string;
  alt?: string;
}>();

const firebase = useFirebase();

const imageSrc = ref<string>();
firebase.getUrlForFile(props.filePath).then((url) => {
  console.log(url + 'dsfgsg');
  imageSrc.value = url;
});

const actualWidth = computed(() => {
  return props.width ?? '100%';
});
const actualHeight = computed(() => {
  return props.height ?? '100%';
});
const actualObjectFit = computed(() => {
  return props.cover ? 'cover' : 'contain';
});
</script>

<template>
  <div v-if="imageSrc || alternativePath">
    <img :src="imageSrc ?? alternativePath" :alt="alt ?? filePath" />
  </div>
</template>

<style scoped lang="scss">
img {
  width: v-bind(actualWidth);
  height: v-bind(actualHeight);
  object-fit: v-bind(actualObjectFit);
}
</style>
