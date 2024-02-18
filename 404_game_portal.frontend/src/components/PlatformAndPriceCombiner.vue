<script setup lang="ts">
import { PriceAndPlatformId } from '@/api/game';
import { Platform } from '@/api/platformAndPrice';
import { ref, watch } from 'vue';
import rules from '@/util/roules';

const props = defineProps<{
  platforms: Platform[];
  loading?: boolean;
  disabled?: boolean;
}>();
const emit = defineEmits<{
  (e: 'update', value: PriceAndPlatformId[]): void;
}>();

const selectedPlatforms = ref<PriceAndPlatformId[]>([]);

watch(selectedPlatforms, (newValue) => {
  emit('update', newValue);
});

watch(
  () => props.platforms,
  () => {
    selectedPlatforms.value = selectedPlatforms.value.filter((platform) => {
      return props.platforms.some((p) => p.id === platform.platformId);
    });
  },
  { immediate: true },
);
</script>

<template>
  <v-list v-if="platforms.length > 0">
    <v-list-item v-for="platform in platforms" :key="platform.id">
      <v-label :ripple="false">
        {{ platform.platformName + ' ' + platform.platformVersion + ' - ' + platform.platformType }}
      </v-label>
      <v-text-field
        :loading="loading"
        :disabled="disabled"
        label="Price"
        type="number"
        suffix="€"
        :rules="rules"
        @update:modelValue="
          (newValue) => {
            const index = selectedPlatforms.findIndex((i) => i.platformId === platform.id);
            if (index === -1) {
              selectedPlatforms.push({ platformId: platform.id, price: Number(newValue) });
            } else {
              selectedPlatforms[index].price = Number(newValue);
            }
          }
        "
        hide-details="auto"
      />
    </v-list-item>
  </v-list>
</template>

<style scoped lang="scss">
.v-list-item {
  display: flex;
  flex-direction: row;
  gap: 10px;
}
</style>
