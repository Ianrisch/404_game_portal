<script setup lang="ts">
import { USK } from '@/api/game';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { ref, watch } from 'vue';
import DescriptionShortener from '@/components/DescriptionShortener.vue';
import StarBar from '@/components/StarBar.vue';
import RatingCommentCard from '@/components/RatingCommentCard.vue';
import CustomImage from '@/components/CustomImage.vue';

const props = defineProps<{
  id: string;
}>();
const descriptionLengthExceeded = ref<boolean>();

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
  <div class="background" v-if="result">
    <v-card class="game">
      <v-row>
        <h1>{{ result.name }}</h1>
      </v-row>
      <v-row>
        <v-col cols="12" md="8">
          <CustomImage
            :filePath="result.image"
            :alternativePath="'https://picsum.photos/1000?random=' + result.id"
            height="432px"
            cover
          />
        </v-col>
        <v-col cols="12" md="4">
          <description-shortener
            :description="result.description"
            v-model:description-length-exceeded="descriptionLengthExceeded"
          />

          <v-list>
            <v-list-item>
              <star-bar v-if="result.totalRatings > 0" v-model:rating="result.ratingAverage" />
              <div v-else>No Ratings yet</div>
            </v-list-item>
            <v-list-item> {{ USK[result.usk] }}</v-list-item>
            <v-list-item>Release Date: {{ result.releaseDate.toLocaleString() }}</v-list-item>
          </v-list>
          <v-chip-group>
            <v-chip
              v-for="platformAndPrice in result.platformAndPrices"
              :key="platformAndPrice.id"
              :ripple="false"
            >
              <div v-if="platformAndPrice.price != 0">
                {{ platformAndPrice.price.toFixed(2).replace('.', ',') }}-€ -
                {{ platformAndPrice.platformName + ' ' + platformAndPrice.platformVersion }}
              </div>
              <div v-else>
                Free on {{ platformAndPrice.platformName + ' ' + platformAndPrice.platformVersion }}
              </div>
            </v-chip>
          </v-chip-group>
          <v-chip-group>
            <v-chip v-for="feature in result.features" :key="feature.featureName" :ripple="false">
              {{ feature.featureName }}
              <v-tooltip activator="parent" location="top">
                {{ feature.featureDescription }}
              </v-tooltip>
            </v-chip>
          </v-chip-group>
          <v-chip-group>
            <v-chip v-for="language in result.languages" :key="language.id" :ripple="false">
              {{ language.languageName }}
            </v-chip>
          </v-chip-group>
        </v-col>
      </v-row>
    </v-card>
    <v-card v-if="descriptionLengthExceeded" id="description">
      <h2>More information</h2>
      <v-spacer />
      <pre>{{ result.description }}</pre>
    </v-card>
    <rating-comment-card :game-id="result.id" />
  </div>
</template>

<style scoped>
h1 {
  margin-left: auto;
  margin-right: auto;
  padding-top: 10px;
}
.background {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.v-card {
  margin-top: 15px;
  padding: 10px;
  width: 60%;

  @media only screen and (max-width: 600px) {
    width: 95%;
  }

  &:first-of-type {
    margin-top: 2%;
  }

  &:last-of-type {
    margin-bottom: 20px;
  }

  &#description {
    pre {
      overflow: auto;
      white-space: pre-wrap;
      font-family: 'Roboto', sans-serif;
    }
  }
}
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
