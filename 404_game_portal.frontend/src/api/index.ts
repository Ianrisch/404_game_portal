import { fetchGames, fetchGame } from '@/api/game';
import { changePassword, getUser, logIn, logOut, register } from '@/api/auth';

const api = {
  fetchGames,
  fetchGame,
  logIn,
  logOut,
  register,
  changePassword,
  getUser,
};

export default api;
