import httpClient from '@/services/httpClient';
import { Feature } from '@/api/feature';
import { PlatformAndPrice } from '@/api/platformAndPrice';
import { Language } from '@/api/language';
import { IdAndPrice } from '@/types/IdAndPrice';

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

export type FilterOptions = {
  usk?: USK;
  gameName?: string;
  maximumPrice?: number;
  platformId?: string;
  featureId?: string;
  languageId?: string;
  minRating?: number;
};

export type GameCreationData = {
  name: string;
  platforms: IdAndPrice[];
  usk: USK;
  releaseDate: Date;
  description: string;
  features: string[];
  languages: string[];
  image: string;
};

export const fetchGames = async (options: FilterOptions): Promise<Game[]> =>
  httpClient.get(
    '/api/game?' +
      (options.usk != undefined ? `usk=${options.usk}` : '') +
      (options.gameName ? `&gameName=${options.gameName}` : '') +
      (options.maximumPrice != undefined ? `&maximumPrice=${options.maximumPrice}` : '') +
      (options.platformId ? `&platformId=${options.platformId}` : '') +
      (options.featureId ? `&featureId=${options.featureId}` : '') +
      (options.languageId ? `&languageId=${options.languageId}` : '') +
      (options.minRating != undefined ? `&minRating=${options.minRating}` : ''),
  );
export const fetchGame = async (id: string): Promise<Game> => httpClient.get(`/api/game/${id}`);
export const createGame = async (data: GameCreationData): Promise<Game> =>
  httpClient.post(`/api/game`, data);
