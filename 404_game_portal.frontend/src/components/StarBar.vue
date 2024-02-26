<script setup lang="ts">
import { computed, ref } from 'vue';
import usePromise from '@/composables/usePromise';

const rating = defineModel<number>('rating', { default: 0 });
const tempRating = ref<number>();
const props = defineProps<{
  clickEnabled?: boolean;
}>();

const cursor = computed(() => (props.clickEnabled ? 'pointer' : 'default'));
const determineIcon = (rating: number, starPosition: number) => {
  return rating - starPosition >= 0
    ? 'mdi-star'
    : rating - starPosition >= -0.5
      ? 'mdi-star-half-full'
      : 'mdi-star-outline';
};
</script>

<template>
  <div>
    <v-btn
      v-for="a in 5"
      :v-key="a"
      variant="plain"
      :ripple="false"
      size="40px"
      :icon="tempRating ? determineIcon(tempRating, a) : determineIcon(rating, a)"
      @click="rating = a"
      @mouseover="tempRating = a"
      @mouseleave="tempRating = undefined"
      :disabled="!clickEnabled"
    />
  </div>
</template>

<style scoped lang="scss">
.v-btn {
  width: 29px !important;
  opacity: 100%;

  &:hover {
    cursor: v-bind(cursor);
  }
}
</style>
