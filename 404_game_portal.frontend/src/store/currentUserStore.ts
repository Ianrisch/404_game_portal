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
    } else {
      user.value = undefined;
    }
  });
  const logout = usePromise(api.logOut, () => {
    useIsLoggedIn.createPromise();
  });
  const login = usePromise(api.logIn, () => {
    useIsLoggedIn.createPromise();
  });

  return {
    fetchUser: () => currentUser.createPromise(),
    user,
    isLoggedIn: useIsLoggedIn.result,
    fetchLogin: useIsLoggedIn.createPromise,
    logout: logout.createPromise,
    login: login.createPromise,
  };
});
