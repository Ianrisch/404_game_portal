import { fetchGames, fetchGame, createGame } from '@/api/game';
import {
  changePassword,
  getUser,
  isLoggedIn,
  isUsernameOrEmailTaken,
  logIn,
  logOut,
  register,
} from '@/api/auth';
import { createFeature, fetchFeature, fetchFeatures } from '@/api/feature';
import { createLanguage, fetchLanguage, fetchLanguages } from '@/api/language';
import { createPlatform, fetchPlatform, fetchPlatforms } from '@/api/platformAndPrice';
import { createRating, fetchRating, fetchRatingsForGame, fetchRatingsForUser } from '@/api/rating';
import { createComment, fetchComments, updateComment } from '@/api/comment';

const api = {
  fetchGames,
  fetchGame,
  createGame,
  fetchFeatures,
  fetchFeature,
  createFeature,
  fetchLanguages,
  fetchLanguage,
  createLanguage,
  fetchPlatforms,
  fetchPlatform,
  createPlatform,
  fetchRatingsForGame,
  fetchRatingsForUser,
  fetchRating,
  createRating,
  fetchComments,
  createComment,
  updateComment,
  logIn,
  logOut,
  register,
  changePassword,
  getUser,
  isLoggedIn,
  isUsernameOrEmailTaken,
};

export default api;
