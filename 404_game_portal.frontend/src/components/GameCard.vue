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
  <v-card class="mx-auto" max-width="500">
    <v-img v-if="showImage" :src="game.image" height="200px" cover />

    <v-card-title> {{ game.name }} </v-card-title>

    <v-card-actions>
      <VBtn color="purple" @click="$router.push(`/game/${game.id}`)">Mehr</VBtn>

      <v-spacer />

      <v-btn :icon="show ? 'mdi-chevron-up' : 'mdi-chevron-down'" @click="show = !show" />
    </v-card-actions>

    <v-expand-transition>
      <div v-show="show">
        <v-divider />

        <v-card-text>
          <div>
            {{ USK[game.usk] }}
          </div>
          <div>Release Date: {{ game.releaseDate.toLocaleString() }}</div>
          <v-chip-group>
            <v-chip
              v-for="priceOnPlatform in game.prices"
              :key="priceOnPlatform.id"
              :ripple="false"
            >
              {{ priceOnPlatform.price.toFixed(2).replace('.', ',') }}-€ -
              {{ priceOnPlatform.platform.platformName }}
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
      </div>
    </v-expand-transition>
  </v-card>
</template>

<style scoped>
.v-card {
  margin-bottom: 15px;
}
</style>
