<script setup lang="ts">
import { ref, watch } from 'vue';
import rules from '@/util/rules';
import { IdAndPrice, Price } from '@/types/IdAndPrice';

const props = defineProps<{
  items: any[];
  itemTitle: (item: any) => string;
  itemId?: (item: any) => string;
  loading?: boolean;
  disabled?: boolean;
}>();
const emit = defineEmits<{
  (e: 'update', value: IdAndPrice[]): void;
}>();

const selectedItems = ref<IdAndPrice[]>([]);

watch(selectedItems, (newValue) => {
  emit('update', newValue);
});

watch(
  () => props.items,
  () => {
    selectedItems.value = selectedItems.value.filter((item) => {
      return props.items.some((p) => getId(p) === item.id);
    });
  },
  { immediate: true },
);

const getId = (item: any) => {
  if (props.itemId) return props.itemId(item);
  return item.id;
};
</script>

<template>
  <v-list v-if="items.length > 0">
    <v-list-item v-for="item in items" :key="getId(item)">
      <v-label :ripple="false">
        {{ itemTitle(item) }}
      </v-label>
      <v-text-field
        :loading="loading"
        :disabled="disabled"
        label="Price"
        type="number"
        suffix="€"
        :rules="[rules.required]"
        @update:modelValue="
          (newValue) => {
            const id = getId(item);
            const index = selectedItems.findIndex((i) => i.id === id);
            if (index === -1) {
              selectedItems.push({ id: id, price: Number(newValue) });
            } else {
              selectedItems[index].price = Number(newValue);
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
