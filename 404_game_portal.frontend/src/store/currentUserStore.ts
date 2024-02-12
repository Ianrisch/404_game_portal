import { defineStore } from 'pinia';
import { ref } from 'vue';
import { User } from '@/api/auth';
import usePromise from '@/composables/usePromise';
import api from '@/api';

export const useCurrentUserStore = defineStore('currentUser', () => {
  const user = ref<User>();

  const currentUser = usePromise(api.getUser, (u) => (user.value = u));
  const useIsLoggedIn = usePromise(api.isLoggedIn, async (loggedIn) => {
    if (loggedIn) {
      await currentUser.createPromise();
    } else {
      user.value = undefined;
    }
  });
  const logout = usePromise(api.logOut, async () => await useIsLoggedIn.createPromise());
  const login = usePromise(api.logIn, async () => await useIsLoggedIn.createPromise());

  return {
    fetchUser: async () => await currentUser.createPromise(),
    user,
    isLoggedIn: useIsLoggedIn.result,
    fetchLogin: useIsLoggedIn.createPromise,
    logout: logout.createPromise,
    login: login.createPromise,
  };
});
