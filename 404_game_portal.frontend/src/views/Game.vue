<script setup lang="ts">
import { USK } from '@/api/game';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { watch } from 'vue';
const props = defineProps<{
  id: string;
}>();

const { loading, result, createPromise } = usePromise(api.fetchGame);

watch(
  () => props.id,
  () => {
    createPromise(props.id);
  },
  { immediate: true },
);
</script>

<template>
  <VCard v-if="result">
    <VCardItem>
      <v-btn icon @click="$router.go(-1)" variant="tonal">
        <v-icon icon="mdi-arrow-left" />
      </v-btn>
    </VCardItem>
    <VCardItem>
      <img :src="result!.image ?? 'https://picsum.photos/1000/?random=' + result.id" alt="test" />
    </VCardItem>
    <div>
      <VCardTitle>{{ result!.name }}</VCardTitle>
      <VCardText>{{ result!.description }}</VCardText>
      <VCardItem>
        <div>{{ USK[result!.usk] }}</div>
        <div>Release Date: {{ result!.releaseDate.toLocaleString() }}</div>
        <v-chip-group>
          <v-chip
            v-for="platformAndPrice in result!.platformAndPrices"
            :key="platformAndPrice.id"
            :ripple="false"
          >
            {{ platformAndPrice.price.toFixed(2).replace('.', ',') }}-€ -
            {{ platformAndPrice.platformName }}
          </v-chip>
        </v-chip-group>
        <v-chip-group>
          <v-chip v-for="feature in result!.features" :key="feature.featureName" :ripple="false">
            {{ feature.featureName }}
            <v-tooltip activator="parent" location="top">
              {{ feature.featureDescription }}
            </v-tooltip>
          </v-chip>
        </v-chip-group>
        <v-chip-group>
          <v-chip v-for="language in result!.languages" :key="language.id" :ripple="false">
            {{ language.languageName }}
          </v-chip>
        </v-chip-group>
      </VCardItem>
    </div>
  </VCard>
</template>

<style scoped>
:deep(.v-chip) {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
}
img {
  height: 300px;
  object-fit: cover;
}
</style>
