<script lang="ts" setup>
import BlockChooser from '@/components/BlockChooser.vue';
import Settings from '@/layouts/default/Settings.vue';
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

          <settings />
        </template>
      </v-app-bar>

      <v-main>
        <router-view />
      </v-main>
    </v-layout>
    <v-footer>
      <v-row justify="center" no-gutters>
        <v-btn variant="text" class="mx-2 footer-btn" rounded="xl" to="/about"> About </v-btn>
        <v-btn variant="text" class="mx-2 footer-btn" rounded="xl" to="/contact">
          Contact us
        </v-btn>
        <v-col class="text-center mt-4" cols="12">
          {{ new Date().getFullYear() }} — <strong>404 Game Portal</strong>
        </v-col>
      </v-row>
    </v-footer>
  </v-app>
</template>

<style lang="scss">
@import '@/scss/mixin.scss';
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
    @include themeColor;
  }
}
</style>
