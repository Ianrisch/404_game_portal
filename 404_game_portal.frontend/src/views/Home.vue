<template>
  <VList :loading="loading">
    <template v-if="result">
      <GameCard v-for="game in result" :key="game.id" :game="game" />
    </template>
  </VList>
</template>

<script lang="ts" setup>
import usePromise from '@/composables/usePromise';
import api from '@/api';
import GameCard from '@/components/GameCard.vue';

const { loading, result, createPromise } = usePromise(api.fetchGames);
createPromise();
</script>
