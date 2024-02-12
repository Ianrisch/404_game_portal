import { User } from '@/api/auth';
import { Game } from '@/api/game';
import httpClient from '@/services/httpClient';

export type Rating = {
  rating: number;
  user: User;
  Game: Game;
};

export type RatingUpdateData = {
  rating: number;
  gameId: string;
};

export const fetchRating = async (gameId: string): Promise<Rating> =>
  httpClient.get(`/api/rating/${gameId}`);

export const fetchRatingsForUser = async (username: string): Promise<Rating[]> =>
  httpClient.get(`/api/rating/user/${username}`);

export const fetchRatingsForGame = async (gameId: string): Promise<Rating[]> =>
  httpClient.get(`/api/rating/game/${gameId}`);
export const createRating = async (data: RatingUpdateData): Promise<Rating> =>
  httpClient.post(`/api/platform`, data);
