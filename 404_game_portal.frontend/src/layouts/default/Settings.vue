<script lang="ts" setup>
import { useDarkModeStore } from '@/store/darkModeStore';
const darkModeStore = useDarkModeStore();
</script>

<template>
  <div class="settings">
    <v-btn :icon="'mdi-cog-outline'" />

    <v-menu activator="parent" :close-on-content-click="false" location="bottom">
      <v-card>
        <v-switch
          v-model:model-value="darkModeStore.isDarkMode"
          :label="darkModeStore.isDarkMode ? 'Change to Light mode' : 'Change to Dark mode'"
          hide-details="auto"
        />
      </v-card>
    </v-menu>
  </div>
</template>

<style scoped lang="scss">
.settings {
  margin-left: 10px;
}
.v-card {
  padding: 10px;
}
</style>
