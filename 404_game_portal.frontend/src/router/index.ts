// Composables
import { createRouter, createWebHistory, RouteLocationNormalized } from 'vue-router';
import { useCurrentUserStore } from '@/store/currentUserStore';
import { Role } from '@/api/auth';

const authorize = async (
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  role: Role,
) => {
  const useCurrenUser = useCurrentUserStore();
  await useCurrenUser.fetchLogin();
  if (!useCurrenUser.isLoggedIn) return from;

  await useCurrenUser.fetchUser();

  if (useCurrenUser.user!.role >= role) return true;
  return from;
};

function authorizeAdmin() {
  return async (to: RouteLocationNormalized, from: RouteLocationNormalized) =>
    await authorize(to, from, Role.Admin);
}
function authorizeUser() {
  return async (to: RouteLocationNormalized, from: RouteLocationNormalized) =>
    await authorize(to, from, Role.User);
}

const routes = [
  {
    path: '',
    name: 'Home',
    component: () => import('@/views/Home.vue'),
  },
  {
    path: '/game/:id',
    name: 'Game',
    props: true,
    component: () => import('@/views/Game.vue'),
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('@/views/Register.vue'),
  },
  {
    path: '/admin',
    name: 'Admin',
    component: () => import('@/views/Admin.vue'),
    beforeEnter: [authorizeAdmin()],
    children: [
      {
        path: '',
        name: 'AdminHome',
        component: () => import('@/views/AdminHome.vue'),
      },
      {
        path: 'create/game',
        name: 'CreateGame',
        component: () => import('@/views/CreateGame.vue'),
      },
      {
        path: 'create/language',
        name: 'CreateLanguage',

        component: () => import('@/views/CreateLanguage.vue'),
      },
      {
        path: 'create/platform',
        name: 'CreatePlatform',

        component: () => import('@/views/CreatePlatform.vue'),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
