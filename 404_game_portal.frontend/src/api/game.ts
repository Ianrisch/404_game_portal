import httpClient from '@/services/httpClient';
import { PriceOnPlatform } from '@/api/priceOnPlatform';
import { Feature } from '@/api/feature';
import { PlatformAndPrice } from '@/api/platformAndPrice';
import { Language } from '@/api/language';

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
  releaseDate: Date;
  platformAndPrices: PlatformAndPrice[];
  features: Feature[];
  languages: Language[];
};

export const fetchGames = async (): Promise<Game[]> => httpClient.get('/api/game');
export const fetchGame = async (id: string): Promise<Game> => httpClient.get(`/api/game/${id}`);
