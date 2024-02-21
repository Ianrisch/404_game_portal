<script setup lang="ts">
import { ref } from 'vue';
import { LanguageCreationData } from '@/api/language';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import rules from '@/util/roules';
const creationData = ref<LanguageCreationData>({
  languageName: '',
  gameIds: [],
});

const { createPromise, loading } = usePromise(api.createLanguage);
const getGames = usePromise(api.fetchGames);
const games = getGames.result;
getGames.createPromise({});
</script>

<template>
  <v-card width="50%" v-if="games">
    <v-form @submit.prevent="createPromise(creationData)">
      <v-text-field
        label="Language Name"
        v-model="creationData.languageName"
        hide-details="auto"
        :rules="rules"
        :loading="loading"
        :disabled="loading"
      />
      <v-select
        label="Games"
        :items="games"
        v-model="creationData.gameIds"
        :item-value="(game: any) => game.id"
        :item-title="(game: any) => game.name"
        :loading="loading"
        hide-details="auto"
        :disabled="loading"
        multiple
      >
      </v-select>
      <v-btn type="submit" :loading="loading" :disabled="loading">Create</v-btn>
    </v-form>
  </v-card>
</template>

<style scoped lang="scss"></style>
