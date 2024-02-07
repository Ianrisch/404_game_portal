<script setup lang="ts">
import { defineProps } from 'vue';
defineProps<{
  title: string;
  tooltip?: string;
}>();
</script>

<template>
  <v-card-title>
    {{ title }}
    <v-tooltip activator="parent" location="top">
      {{ tooltip ?? title }}
    </v-tooltip>
  </v-card-title>
</template>
