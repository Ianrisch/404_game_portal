<script setup lang="ts">
import Default from '@/layouts/default/Default.vue';
import { useDarkModeStore } from '@/store/darkModeStore';
useDarkModeStore().initDarkMode();
</script>

<template>
  <Default />
</template>

<style lang="scss"></style>
