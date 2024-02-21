<script setup lang="ts">
import { ref } from 'vue';
import { PlatformCreationData } from '@/api/platformAndPrice';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { Game } from '@/api/game';
import PriceCombiner from '@/components/PriceCombiner.vue';

const { createPromise, loading } = usePromise(api.createPlatform);
const creationData = ref<PlatformCreationData>({
  platformName: '',
  platformVersion: '',
  platformType: '',
  gamesAndPrices: [],
});
const getGames = usePromise(api.fetchGames);
const games = getGames.result;
const selectedGames = ref<string[]>([]);
getGames.createPromise({});
</script>

<template>
  <v-card v-if="games" width="50%">
    <v-form>
      <v-text-field
        label="Platform Name"
        v-model="creationData.platformName"
        hide-details="auto"
        :loading="loading"
        :disabled="loading"
      />
      <v-text-field
        label="Platform Version"
        v-model="creationData.platformVersion"
        hide-details="auto"
        :loading="loading"
        :disabled="loading"
      />
      <v-text-field
        label="Platform Type"
        v-model="creationData.platformType"
        hide-details="auto"
        :loading="loading"
        :disabled="loading"
      />
      <v-select
        label="Games"
        :items="games"
        v-model="selectedGames"
        :item-value="(game: any) => game"
        :item-title="(game: any) => game.name"
        :loading="loading"
        hide-details="auto"
        :disabled="loading"
        multiple
      />
      <price-combiner
        :items="selectedGames"
        :item-title="(item: Game) => item.name"
        :loading="loading"
        :disabled="loading"
        @update="(data) => (creationData.gamesAndPrices = data)"
      />
      <v-btn @click="createPromise(creationData)" :loading="loading" :disabled="loading"
        >Create</v-btn
      >
    </v-form>
  </v-card>
</template>

<style scoped lang="scss"></style>
