<script setup lang="ts">
import { FilterOptions, USK } from '@/api/game';
import { ref, watch } from 'vue';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { Feature } from '@/api/feature';
import { Language } from '@/api/language';
import { Platform } from '@/api/platformAndPrice';

const emit = defineEmits<{
  (e: 'filter', value: FilterOptions): void;
}>();
defineProps<{
  loading?: boolean;
}>();

const filterOptions = ref<FilterOptions>({
  gameName: undefined,
  usk: undefined,
  maximumPrice: undefined,
  platformId: undefined,
  featureId: undefined,
  languageId: undefined,
});

const platforms = usePromise(api.fetchPlatforms);
const features = usePromise(api.fetchFeatures);
const languages = usePromise(api.fetchLanguages);

platforms.createPromise();
features.createPromise();
languages.createPromise();

const platformArray = platforms.result;
const featureArray = features.result;
const languageArray = languages.result;

const selectedPlatform = ref<Platform>();
const selectedFeature = ref<Feature>();
const selectedLanguage = ref<Language>();

const show = ref(false);
const form = ref();
</script>

<template>
  <v-form
    ref="form"
    @submit.prevent="$emit('filter', filterOptions)"
    :disabled="loading"
    :loading="loading"
  >
    <v-expand-transition>
      <v-card class="filter-bar" v-if="show">
        <v-row>
          <v-col cols="3">
            <v-text-field
              label="Game Name"
              v-model="filterOptions.gameName"
              hide-details="auto"
              :clearable="true"
            />
          </v-col>
          <v-col cols="2">
            <v-combobox
              v-model="filterOptions.usk"
              :items="Object.values(USK).filter((u) => typeof u == 'number')"
              :item-title="(i: any) => USK[i].toString()"
              :item-value="(i: any) => i"
              label="USK"
              hide-details="auto"
              :clearable="true"
            />
          </v-col>
          <v-col cols="3">
            <div>Maximum Price</div>
            <v-slider v-model="filterOptions.maximumPrice" :max="300" :step="1" hide-details="auto">
              <template #append>
                <v-text-field
                  v-model="filterOptions.maximumPrice"
                  type="number"
                  style="width: 110px"
                  density="compact"
                  variant="outlined"
                  hide-details="auto"
                  :clearable="true"
                />
              </template>
            </v-slider>
          </v-col>
          <v-col cols="2">
            <v-combobox
              v-model="selectedPlatform"
              @update:modelValue="(value: any) => (filterOptions.platformId = value?.id)"
              :items="platformArray"
              :item-title="(i: Platform | null) => i?.platformName"
              label="Platform"
              hide-details="auto"
              :clearable="true"
            />
          </v-col>

          <v-col cols="2">
            <v-combobox
              v-model="selectedFeature"
              @update:modelValue="(value: any) => (filterOptions.featureId = value?.id)"
              :items="featureArray"
              :item-title="(i: Feature | null) => i?.featureName"
              label="Feature"
              hide-details="auto"
              :clearable="true"
            />
          </v-col>
          <v-col cols="2">
            <v-combobox
              v-model="selectedLanguage"
              @update:modelValue="(value: any) => (filterOptions.languageId = value?.id)"
              :items="languageArray"
              :item-title="(i: Language | null) => i?.languageName"
              label="Language"
              hide-details="auto"
              :clearable="true"
            />
          </v-col>
        </v-row>
      </v-card>
    </v-expand-transition>
    <v-btn
      @click="show = !show"
      prepend-icon="mdi-filter"
      :text="show ? 'Hide Filters' : 'Show Filters'"
    />
    <v-btn v-if="show" text="Submit" type="submit" :disabled="loading" :loading="loading" />
    <v-btn
      :disabled="loading"
      :loading="loading"
      v-if="show"
      @click="
        () => {
          filterOptions.gameName = undefined;
          filterOptions.usk = undefined;
          filterOptions.maximumPrice = undefined;

          filterOptions.platformId = undefined;
          filterOptions.featureId = undefined;
          filterOptions.languageId = undefined;
          selectedLanguage = undefined;
          selectedFeature = undefined;
          selectedPlatform = undefined;
        }
      "
      text="Clear"
    />
  </v-form>
</template>

<style scoped lang="scss">
.filter-bar {
  padding: 15px 20px;
}
</style>
