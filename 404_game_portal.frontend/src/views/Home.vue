<script lang="ts" setup>
import usePromise from '@/composables/usePromise';
import api from '@/api';
import GameCard from '@/components/GameCard.vue';
import FilterBar from '@/components/FilterBar.vue';
import { FilterOptions } from '@/api/game';

const { loading, result, createPromise } = usePromise(api.fetchGames);
createPromise({});
</script>

<template>
  <div class="background">
    <filter-bar :loading="loading" @filter="(value: FilterOptions) => createPromise(value)" />
    <VList>
      <template v-if="result && !loading">
        <GameCard
          v-for="game in result"
          :key="game.id"
          :game="game"
          show-image
          :loading="loading"
          :disabled="loading"
        />
      </template>
      <template v-else>
        <v-skeleton-loader
          v-for="a in 10"
          :elevation="24"
          width="300"
          :loading="true"
          class="mx-auto"
          max-width="300"
          height="312"
          type="image, article"
          style="margin-bottom: 15px"
        />
      </template>
    </VList>
  </div>
</template>

<style lang="scss" scoped>
.v-list {
  padding: 15px 20px 0 20px;
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 10px;
  justify-items: center;
  background: transparent;
}
</style>
