<script lang="ts" setup>
import { useDarkModeStore } from '@/store/darkModeStore';
import BlockChooser from '@/components/BlockChooser.vue';

const darkModeStore = useDarkModeStore();
</script>

<template>
  <v-app>
    <v-layout>
      <v-app-bar>
        <template #prepend>
          <router-link to="/" class="logo-container">
            <div>404 Game</div>
            <v-img class="logo" to="home" src="@/assets/logo.png" />
          </router-link>
        </template>
        <template #append>
          <block-chooser />

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

<style lang="scss">
.logo {
  width: 176px;
  height: 64px;
  margin-left: 5px;
}
.logo-container {
  display: flex;
  align-items: center;
  font-size: 32px;
  text-decoration: none;
  font-weight: bold;
  &:visited,
  &:active {
    text-decoration: none;
    color: rgba(var(--v-theme-on-background), var(--v-high-emphasis-opacity));
  }
}
</style>
