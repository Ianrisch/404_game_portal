<script setup lang="ts">
import type { Game } from '@/api/game';
import { USK } from '@/api/game';
import { ref } from 'vue';
import CardTitleTooltip from '@/components/CardTitleTooltip.vue';
import StarBar from '@/components/StarBar.vue';

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
        <div>
          <div class="shadow">
            <v-img
              v-if="showImage"
              :src="game.image ?? 'https://picsum.photos/1000?random=' + game.id"
              height="200px"
              cover
            />
          </div>
          <star-bar
            class="star-bar"
            v-if="game.totalRatings > 0"
            v-model:rating="game.ratingAverage"
          />
        </div>

        <card-title-tooltip :title="game.name" />
      </v-window-item>

      <v-window-item :value="true">
        <card-title-tooltip :title="game.name" />

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
      <VBtn color="purple" :to="`/game/${game.id}`">More</VBtn>

      <v-spacer />

      <v-btn :icon="show ? 'mdi-chevron-left' : 'mdi-chevron-right'" @click="show = !show" />
    </v-card-actions>
  </v-card>
</template>

<style scoped lang="scss">
@import '@/scss/mixin.scss';

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

.star-bar {
  position: absolute;
  right: 0;
  bottom: 20%;
  color: darkorange;
}

.shadow {
  content: '';
  z-index: 1;
  background: -webkit-linear-gradient(rgba(0, 0, 0, 0), rgb(var(--v-theme-surface)));
  @include noDrag;
}

:deep(.v-img) {
  z-index: -1;

  img {
    @include noSelect;
    @include noDrag;
  }
}
</style>
