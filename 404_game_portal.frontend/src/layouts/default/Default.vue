<template>
  <v-app>
    <v-layout>
      <v-app-bar>
        <template #append>
          <v-switch
            v-model:model-value="isDarkMode"
            :label="isDarkMode ? 'Change to Lightmode' : 'Change to Darkmode'"
          />
        </template>
      </v-app-bar>

      <v-main>
        <router-view />
      </v-main>
    </v-layout>
  </v-app>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue';
const theme = useTheme();
import { useTheme } from 'vuetify';
const isDarkMode = ref<boolean>(theme.global.current.value.dark);
watch(isDarkMode, (isDark) => {
  theme.global.name.value = isDark ? 'dark' : 'light';
});
</script>
