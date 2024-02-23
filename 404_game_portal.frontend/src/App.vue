<script setup lang="ts">
import Default from '@/layouts/default/Default.vue';
import { useDarkModeStore } from '@/store/darkModeStore';
import { computed } from 'vue';
const darkModeStore = useDarkModeStore();
darkModeStore.initDarkMode();
const background = computed(
  () => `var(--background-${darkModeStore.isDarkMode ? 'dark' : 'light'})`,
);
</script>

<template>
  <Default />
</template>

<style lang="scss">
:root div {
  --background: v-bind(background);
}
</style>
