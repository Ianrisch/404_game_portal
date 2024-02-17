<script setup lang="ts">
import { computed } from 'vue';
import usePromise from '@/composables/usePromise';

const rating = defineModel<number>('rating', { default: 0 });
const props = defineProps<{
  clickEnabled?: boolean;
}>();

const cursor = computed(() => (props.clickEnabled ? 'pointer' : 'default'));
</script>

<template>
  <div>
    <v-btn
      v-for="a in 5"
      :v-key="a"
      variant="plain"
      :ripple="false"
      size="40px"
      :icon="
        rating - a >= 0
          ? 'mdi-star'
          : rating - a >= -0.5
            ? 'mdi-star-half-full'
            : 'mdi-star-outline'
      "
      @click="rating = a"
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
