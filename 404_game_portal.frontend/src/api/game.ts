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
  ratingAverage: number;
  totalRatings: number;
  releaseDate: Date;
  platformAndPrices: PlatformAndPrice[];
  features: Feature[];
  languages: Language[];
};

export type priceAndPlatformId = {
  platformId: string;
  price: number;
};
export type FilterOptions = {
  usk?: USK;
  gameName?: string;
  maximumPrice?: number;
  platformId?: string;
  featureId?: string;
  languageId?: string;
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

export const fetchGames = async (options: FilterOptions): Promise<Game[]> =>
  httpClient.get(
    '/api/game?' +
      (options.usk ? `usk=${options.usk}` : '') +
      (options.gameName ? `&gameName=${options.gameName}` : '') +
      (options.maximumPrice ? `&maximumPrice=${options.maximumPrice}` : '') +
      (options.platformId ? `&platformId=${options.platformId}` : '') +
      (options.featureId ? `&featureId=${options.featureId}` : '') +
      (options.languageId ? `&languageId=${options.languageId}` : ''),
  );
export const fetchGame = async (id: string): Promise<Game> => httpClient.get(`/api/game/${id}`);
export const createGame = async (data: GameCreationData): Promise<Game> =>
  httpClient.post(`/api/game`, data);
