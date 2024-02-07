<template>
  <VList :loading="loading">
    <template v-if="result">
      <GameCard v-for="game in result" :key="game.id" :game="game" show-image />
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

<style lang="scss" scoped>
.v-list {
  padding: 15px 20px 0 20px;
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 10px;
  justify-items: center;
}
</style>
