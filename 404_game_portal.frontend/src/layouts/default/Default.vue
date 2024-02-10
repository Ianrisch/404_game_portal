<script lang="ts" setup>
import { useDarkModeStore } from '@/store/darkModeStore';
import ProfileBlock from '@/components/ProfileBlock.vue';

const darkModeStore = useDarkModeStore();
</script>

<template>
  <v-app>
    <v-layout>
      <v-app-bar>
        <template #append>
          <profile-block> </profile-block>

          <v-switch
            v-model:model-value="darkModeStore.isDarkMode"
            :label="darkModeStore.isDarkMode ? 'Change to Light mode' : 'Change to Dark mode'"
          />
        </template>
      </v-app-bar>

      <v-main>
        <router-view />
      </v-main>
    </v-layout>
  </v-app>
</template>
