import httpClient from '@/services/httpClient';
import { Feature } from '@/api/feature';
import { PlatformAndPrice } from '@/api/platformAndPrice';
import { Language } from '@/api/language';
import { da } from 'vuetify/locale';

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

export type priceAndPlatformId = {
  platformId: string;
  price: number;
};

export type GameCreationData = {
  name: string;
  platforms: priceAndPlatformId[];
  usk: USK;
  releaseDate: Date;
  description: string;
  features: string[];
  languages: string[];
};

export const fetchGames = async (): Promise<Game[]> => httpClient.get('/api/game');
export const fetchGame = async (id: string): Promise<Game> => httpClient.get(`/api/game/${id}`);
export const createGame = async (data: GameCreationData): Promise<Game> =>
  httpClient.post(`/api/game`, data);
