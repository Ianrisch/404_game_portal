<script setup lang="ts">
import { ref } from 'vue';
import { SubmitEventPromise } from 'vuetify';
import usePromise from '@/composables/usePromise';
import api from '@/api';
import { useRouter } from 'vue-router';

const router = useRouter();

const register = usePromise(api.register, () => {
  router.replace('/');
});

const rules = ref([(value: any) => !!value || 'Required']);
const emailRule = (value: any) => {
  const pattern = new RegExp('[a-z0-9]+@[a-z]+.[a-z]{2,3}');
  return pattern.test(value) || 'Invalid e-mail.';
};
const confirmedPasswordRule = (value: any) => {
  return value === password.value || 'Passwords do not match';
};
const usernameTakenRule = async (value: any) => {
  return !(await api.isUsernameOrEmailTaken(value)) || 'This username is already taken';
};
const emailTaken = async (value: any) => {
  return (
    !(await api.isUsernameOrEmailTaken(undefined, value)) ||
    'An account already exists for this email address'
  );
};

const email = ref<string>('');
const username = ref<string>('');
const password = ref<string>('');
const confirmedPassword = ref<string>('');

const submit = async (event: SubmitEventPromise) => {
  if ((await event).valid) {
    register.createPromise({
      email: email.value,
      username: username.value,
      password: confirmedPassword.value,
    });
  }
};
</script>

<template>
  <div class="background">
    <v-card>
      <h1>Register</h1>
      <v-form @submit.prevent="submit">
        <v-text-field
          hide-details="auto"
          label="Email address"
          placeholder="johndoe@gmail.com"
          type="email"
          :rules="[...rules, emailRule, emailTaken]"
          v-model="email"
        />
        <v-text-field
          hide-details="auto"
          label="Username"
          :rules="[...rules, usernameTakenRule]"
          v-model="username"
        />
        <v-text-field
          class="passwordInput"
          label="Password"
          type="password"
          hide-details="auto"
          :rules="rules"
          v-model="password"
        />
        <v-text-field
          class="passwordInput"
          label="Confirm your Password"
          type="password"
          hide-details="auto"
          :rules="[...rules, confirmedPasswordRule]"
          v-model="confirmedPassword"
        />
        <div class="loginButtons">
          <v-btn type="submit">Register</v-btn>
        </div>
      </v-form>
    </v-card>
  </div>
</template>

<style scoped lang="scss">
.background {
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;

  background-image: url('@/assets/register.jpg');
  background-size: cover;
}
.v-card {
  width: 25%;
  padding: 15px;

  h1 {
    margin-bottom: 5px;
  }
  .v-input {
    margin-bottom: 10px;
  }
}
</style>
