<script setup lang="ts">
import type { Game } from '@/api/game';
import { USK } from '@/api/game';
import { ref } from 'vue';
defineProps<{
  game: Game;
}>();

const show = ref(false);
const featureDescription = (description: String) => alert(description);
</script>

<template>
  <!--  <v-card>-->
  <!--    <v-card-title> </v-card-title>-->
  <!--    <v-card-text> </v-card-text>-->
  <!--    <VCardActions> </VCardActions>-->
  <!--  </v-card>-->

  <v-card class="mx-auto" max-width="344">
    <v-img src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg" height="200px" cover></v-img>

    <v-card-title> {{ game.name }} </v-card-title>

    <v-card-subtitle> {{ game.description }} </v-card-subtitle>

    <v-card-actions>
      <!--      <v-btn color="orange-lighten-2" variant="text"> Explore </v-btn>-->
      <VBtn @click="$router.push(`/game/${game.id}`)">Mehr</VBtn>

      <v-spacer></v-spacer>

      <v-btn :icon="show ? 'mdi-chevron-up' : 'mdi-chevron-down'" @click="show = !show"></v-btn>
    </v-card-actions>

    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
          <div>
            {{ USK[game.usk] }}
          </div>
          <div>Release Date: {{ game.releaseDate.toLocaleString() }}</div>
          <v-chip-group>
            <v-chip v-for="priceOnPlatform in game.prices"> {{ priceOnPlatform.price }},-€ </v-chip>
          </v-chip-group>
          <v-chip-group>
            <v-chip
              v-for="feature in game.features"
              @click="featureDescription(feature.featureDescription)"
            >
              {{ feature.featureName }}
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
