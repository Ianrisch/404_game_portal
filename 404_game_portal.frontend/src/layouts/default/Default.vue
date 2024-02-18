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
        <v-btn variant="text" class="mx-2 footer-btn" rounded="xl">
          About
          <v-dialog activator="parent" width="600px">
            <v-card>
              <v-card-text>
                Das 404 GamePortal ist ein Projekt von Ian Risch & Julius Lange für das Pflichtfach
                Dynamische Webseiten der Carl Benz Berufschule
              </v-card-text>
              <v-img src="@/assets/background.jpg" alt="test" width="100%"></v-img>
            </v-card> </v-dialog
        ></v-btn>
        <v-btn
          variant="text"
          class="mx-2 footer-btn"
          rounded="xl"
          href="mailto:noreply@404gameportal.com"
        >
          Contact us
        </v-btn>
        <v-col class="text-center mt-4" cols="12">
          {{ new Date().getFullYear() }} — <strong>404 GamePortal</strong>
        </v-col>
      </v-row>
    </v-footer>
  </v-app>
</template>

<style scoped lang="scss">
@import '@/scss/mixin.scss';
.v-app-bar {
  position: fixed !important;
  top: 0 !important;
}

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
  @include noDrag;
  @include noSelect;
}

.v-footer {
  max-height: 15%;
}
</style>
