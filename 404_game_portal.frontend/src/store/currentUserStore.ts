import { defineStore } from 'pinia';
import { ref } from 'vue';
import { User } from '@/api/auth';
import usePromise from '@/composables/usePromise';
import api from '@/api';

export const useCurrentUserStore = defineStore('currentUser', () => {
  const user = ref<User>();

  const currentUser = usePromise(api.getUser, (u) => (user.value = u));
  const useIsLoggedIn = usePromise(api.isLoggedIn, (loggedIn) => {
    if (loggedIn) {
      currentUser.createPromise();
    }
  });

  return { fetch: () => currentUser.createPromise(), user };
});
