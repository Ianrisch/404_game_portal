<script setup lang="ts">
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { computed, ref } from 'vue';
import { type GameCreationData, GameCreationDataWithImage, USK } from '@/api/game';
import rules from '@/util/rules';
import { Platform } from '@/api/platformAndPrice';
import PriceCombiner from '@/components/PriceCombiner.vue';
import { SubmitEventPromise } from 'vuetify';
import { da } from 'vuetify/locale';

const useCreateGame = usePromise(api.createGame, () => {
  files.value = [];
  creationModel.value = {
    name: '',
    description: '',
    usk: 0,
    releaseDate: undefined,
    platforms: [],
    features: [],
    languages: [],
  };
});

const createLoading = useCreateGame.loading;

const platforms = usePromise(api.fetchPlatforms);
const features = usePromise(api.fetchFeatures);
const languages = usePromise(api.fetchLanguages);

const creationModel = ref<GameCreationData>({
  name: '',
  description: '',
  usk: 0,
  releaseDate: undefined,
  platforms: [],
  features: [],
  languages: [],
});
const files = ref<File[]>([]);

platforms.createPromise();
features.createPromise();
languages.createPromise();

const loading = computed(() => {
  return platforms.loading.value || features.loading.value || languages.loading.value;
});

const platformsArray = platforms.result;
const featuresArray = features.result;
const languagesArray = languages.result;

const chosenPlatforms = ref<Platform[]>([]);

const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid && files.value) {
    await useCreateGame.createPromise({
      gameCreationData: creationModel.value,
      image: files.value[0],
    });
  }
};
</script>

<template>
  <v-card width="50%">
    <v-form @submit.prevent="submit">
      <div v-if="!loading || !platformsArray || !featuresArray || !languagesArray">
        <v-text-field
          label="Game Name"
          hide-details="auto"
          v-model="creationModel.name"
          :rules="[rules.required]"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-textarea
          label="Description"
          hide-details="auto"
          v-model="creationModel.description"
          :rules="[rules.required]"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-text-field
          type="date"
          label="Release Date"
          hide-details="auto"
          v-model="creationModel.releaseDate"
          :rules="[rules.required]"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-select
          label="USK"
          :items="Object.values(USK).filter((value) => typeof value === 'number')"
          v-model="creationModel.usk"
          :item-value="(i: any) => i"
          :item-title="(i: any) => USK[i].toString()"
          hide-details="auto"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-select
          label="Platforms"
          :items="platformsArray"
          v-model="chosenPlatforms"
          :item-title="(i: any) => i.platformName"
          :item-value="(i: any) => i"
          multiple
          hide-details="auto"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <price-combiner
          :items="chosenPlatforms"
          :item-title="
            (i: Platform) => i.platformName + ' ' + i.platformVersion + ' - ' + i.platformType
          "
          :loading="createLoading"
          :disabled="createLoading"
          @update="(data) => (creationModel.platforms = data)"
        />
        <v-select
          label="Features"
          :items="featuresArray"
          v-model="creationModel.features"
          :item-title="(i: any) => i.featureName"
          :item-value="(i: any) => i.id"
          multiple
          hide-details="auto"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-select
          label="Languages"
          :items="languagesArray"
          v-model="creationModel.languages"
          :item-title="(i: any) => i.languageName"
          :item-value="(i: any) => i.id"
          multiple
          hide-details="auto"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-file-input
          label="Image"
          accept="image/*"
          hide-details="auto"
          v-model="files"
          :rules="[rules.fileRequired]"
          :loading="createLoading"
          :disabled="createLoading"
        />
        <v-btn type="submit" variant="outlined" :loading="createLoading" :disabled="createLoading"
          >Create Game</v-btn
        >
      </div>
    </v-form>
  </v-card>
</template>

<style scoped lang="scss"></style>
