<script setup lang="ts">
import { useCurrentUserStore } from '@/store/currentUserStore';
import { ref } from 'vue';
import { SubmitEventPromise } from 'vuetify';

const currentUserStore = useCurrentUserStore();

const rules = ref([(value: any) => !!value || 'Required']);
const emailOrUsername = ref<string>('');
const password = ref<string>('');

const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid) {
    currentUserStore.login({ emailOrUsername: emailOrUsername.value, password: password.value });
  }
};
</script>

<template>
  <div class="profileBlock">
    <v-avatar icon="mdi-login" />
    <div class="text">Login</div>

    <v-menu activator="parent" :close-on-content-click="false" location="bottom">
      <v-card width="300px">
        <v-form @submit.prevent="submit">
          <v-text-field
            hide-details="auto"
            label="Email or username"
            placeholder="johndoe@gmail.com"
            type="email"
            :rules="rules"
            v-model="emailOrUsername"
          />
          <v-text-field
            class="passwordInput"
            label="Password"
            type="password"
            hint="Enter your password"
            hide-details="auto"
            :rules="rules"
            v-model="password"
          />
          <div class="loginButtons">
            <v-btn variant="plain">No account?</v-btn>
            <v-btn type="submit">Login</v-btn>
          </div>
        </v-form>
      </v-card>
    </v-menu>
  </div>
</template>

<style scoped lang="scss">
@import '@/scss/mixin.scss';

.v-card {
  padding: 10px;

  .v-input.passwordInput {
    margin-top: 15px;
  }
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

.loginButtons {
  display: flex;
  justify-content: space-between;
}
</style>
