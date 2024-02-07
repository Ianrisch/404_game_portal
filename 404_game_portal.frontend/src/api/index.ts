import { fetchGames, fetchGame } from '@/api/game';
import { changePassword, getUser, isLoggedIn, logIn, logOut, register } from '@/api/auth';

const api = {
  fetchGames,
  fetchGame,
  logIn,
  logOut,
  register,
  changePassword,
  getUser,
  isLoggedIn,
};

export default api;
