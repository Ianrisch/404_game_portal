<template>
  <Default />
</template>

<script setup lang="ts">
import Default from '@/layouts/default/Default.vue';
import { useDarkModeStore } from '@/store/darkModeStore';
useDarkModeStore().initDarkMode();
</script>

<style lang="scss">
@import '@/scss/main.scss';
</style>
