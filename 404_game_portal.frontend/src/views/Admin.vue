<script setup lang="ts"></script>

<template>
  <div class="background">
    <v-btn to="/admin" prepend-icon="mdi-home" :size="35" />
    <v-btn to="/admin/create/game">Create Game</v-btn>
    <v-btn to="/admin/create/language">Create Language</v-btn>
    <v-btn to="/admin/create/platform">Create Platform</v-btn>

    <router-view />
  </div>
</template>

<style scoped lang="scss"></style>
