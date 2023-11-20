import httpClient from '@/services/httpClient';
import { PriceOnPlatform } from '@/api/priceOnPlatform';
import { Feature } from '@/api/feature';
import { Platform } from '@/api/platform';

export enum USK {
  USK0,
  USK6,
  USK12,
  USK16,
  USK18,
}
export type Game = {
  id: number;
  name: string;
  description: string;
  usk: USK;
  image: string;
  rating: number;
  prices: PriceOnPlatform[];
  releaseDate: Date;
  platforms: Platform[];
  features: Feature[];
};

export const fetchGames = async (): Promise<Game[]> => httpClient.get('/api/game');
export const fetchGame = async (id: string): Promise<Game> => httpClient.get(`/api/game/${id}`);
