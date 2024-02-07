<script setup lang="ts">
import type { Game } from '@/api/game';
import { USK } from '@/api/game';
import { ref } from 'vue';

defineProps<{
  game: Game;
  showImage?: boolean;
}>();

const show = ref(false);
</script>

<template>
  <v-card class="mx-auto" width="300px">
    <v-window v-model="show" class="">
      <v-window-item :value="false">
        <v-img
          v-if="showImage"
          :src="game.image ?? 'https://picsum.photos/1000?random=' + game.id"
          height="200px"
          cover
        />
        <v-card-title> {{ game.name }}</v-card-title>
      </v-window-item>

      <v-window-item :value="true">
        <v-card-title> {{ game.name }}</v-card-title>

        <v-card-text>
          <div>
            {{ USK[game.usk] }}
          </div>
          <div>Release Date: {{ game.releaseDate.toLocaleString() }}</div>
          <v-chip-group>
            <v-chip
              v-for="platformAndPrice in game.platformAndPrices"
              :key="platformAndPrice.id"
              :ripple="false"
            >
              {{ platformAndPrice.price.toFixed(2).replace('.', ',') }}-€ -
              {{ platformAndPrice.platformName }}
            </v-chip>
          </v-chip-group>
          <v-chip-group>
            <v-chip v-for="feature in game.features" :key="feature.featureName" :ripple="false">
              {{ feature.featureName }}
              <v-tooltip activator="parent" location="top">
                {{ feature.featureDescription }}
              </v-tooltip>
            </v-chip>
          </v-chip-group>
          <v-chip-group>
            <v-chip v-for="language in game.languages" :key="language.id" :ripple="false">
              {{ language.languageName }}
            </v-chip>
          </v-chip-group>
        </v-card-text>
      </v-window-item>
    </v-window>

    <v-card-actions>
      <VBtn color="purple" @click="$router.push(`/game/${game.id}`)">Mehr</VBtn>

      <v-spacer />

      <v-btn :icon="show ? 'mdi-chevron-left' : 'mdi-chevron-right'" @click="show = !show" />
    </v-card-actions>
  </v-card>
</template>

<style scoped>
.v-card {
  margin-left: 5px !important;
  margin-right: 5px !important;
  margin-bottom: 15px;
  display: flex;
  flex-direction: column;

  .v-window {
    width: 100%;
    height: 100%;
  }
}
</style>
