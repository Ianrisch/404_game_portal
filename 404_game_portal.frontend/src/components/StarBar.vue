<script setup lang="ts">
import { computed } from 'vue';

const rating = defineModel<number>('rating', { default: 0 });
const props = defineProps<{
  clickEnabled?: boolean;
}>();

const cursor = computed(() => (props.clickEnabled ? 'pointer' : 'default'));
</script>

<template>
  <div>
    <v-btn
      variant="plain"
      :ripple="false"
      v-for="a in 5"
      size="40px"
      :icon="a <= rating ? 'mdi-star' : 'mdi-star-outline'"
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
