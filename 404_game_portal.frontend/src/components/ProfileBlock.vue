<script setup lang="ts">
import { useCurrentUserStore } from '@/store/currentUserStore';

const currentUserStore = useCurrentUserStore();
</script>

<template>
  <div class="profileBlock">
    <v-avatar :image="'https://picsum.photos/1000?random=' + currentUserStore.user.username" />

    <div class="text">{{ currentUserStore.user.username }}</div>

    <v-menu activator="parent" :close-on-content-click="false" location="bottom">
      <v-card>
        <v-btn variant="text" @click="currentUserStore.logout">Logout</v-btn>
      </v-card>
    </v-menu>
  </div>
</template>

<style scoped lang="scss">
@import '@/scss/mixin.scss';

.v-card {
  padding: 10px;
}

.profileBlock {
  display: flex;
  align-items: center;
  justify-content: stretch;
  margin: 0 5px;

  .text {
    margin: 0 0 0 5px;
  }

  @include noSelect;
}
</style>
