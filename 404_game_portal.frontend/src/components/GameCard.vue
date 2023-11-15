<script setup lang="ts">
import type { Game } from '@/api/game';
import { USK } from '@/api/game';
defineProps<{
  game: Game;
}>();
</script>

<template>
  <v-card>
    <v-card-title>
      {{ game.name }}
    </v-card-title>
    <v-card-text>
      {{ game.description }}
      {{ USK[game.usk] }}
    </v-card-text>
    <VCardActions>
      <VBtn @click="$router.push(`/game/${game.id}`)">Mehr</VBtn>
    </VCardActions>
  </v-card>
</template>

<style scoped></style>
