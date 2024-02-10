<script setup lang="ts">
import { useCurrentUserStore } from '@/store/currentUserStore';
import LoginBlock from '@/components/LoginBlock.vue';
import ProfileBlock from '@/components/ProfileBlock.vue';

const currentUserStore = useCurrentUserStore();
currentUserStore.fetchLogin();
</script>

<template>
  <profile-block v-if="currentUserStore.isLoggedIn && currentUserStore.user" />
  <login-block v-else />
</template>
