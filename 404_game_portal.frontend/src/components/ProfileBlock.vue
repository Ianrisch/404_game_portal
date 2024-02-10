<script setup lang="ts">
import { useCurrentUserStore } from '@/store/currentUserStore';
import { ref } from 'vue';

const showMenu = ref(false);
const currentUserStore = useCurrentUserStore();
currentUserStore.fetchLogin();
</script>

<template>
  <div v-if="currentUserStore.isLoggedIn && currentUserStore.user">
    <div class="userprofile">
      <div>
        <v-avatar
          :image="'https://picsum.photos/1000?random' + currentUserStore.user.username"
        ></v-avatar>
      </div>

      <div>
        {{ currentUserStore.user.username }}
      </div>
      <v-menu
        activator="parent"
        v-model:model-value="showMenu"
        :close-on-content-click="false"
        location="bottom"
      >
        <v-card> asd </v-card>
      </v-menu>
    </div>
  </div>
  <div v-else>logged out</div>
</template>

<style scoped lang="scss">
@import '@/scss/mixin.scss';

.userprofile {
  display: flex;
  align-items: center;
  justify-content: stretch;
  margin: 0 5px;

  :first-child {
    width: 40px;
    height: 40px;
  }
  :last-child {
    margin-left: 5px;
  }
  @include noSelect;
}
</style>
