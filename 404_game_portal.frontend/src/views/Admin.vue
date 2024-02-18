<script setup lang="ts"></script>

<template>
  <div class="background">
    <div class="sticky">
      <v-btn to="/admin" prepend-icon="mdi-home" :size="35" />
      <v-btn to="/admin/create/game">Create Game</v-btn>
      <v-btn to="/admin/create/language">Create Language</v-btn>
      <v-btn to="/admin/create/platform">Create Platform</v-btn>
    </div>
    <div class="router-view">
      <router-view />
    </div>
  </div>
</template>

<style scoped lang="scss">
div.sticky {
  position: fixed;
  top: 69px;
  z-index: 200;
  display: flex;
  gap: 10px;
}
.router-view {
  padding-top: 41px;
}
</style>
