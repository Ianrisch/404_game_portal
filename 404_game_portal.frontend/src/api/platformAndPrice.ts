import httpClient from '@/services/httpClient';
import { Game, GameCreationData } from '@/api/game';

export type PlatformAndPrice = {
  id: string;
  games: Game[];
  price: number;
  platformName: string;
  platformVersion: string;
  platformType: string;
};
export type Platform = {
  id: string;
  price: number;
  platformName: string;
  platformVersion: string;
  platformType: string;
};

export type GameAndPrice = {
  gameId: string;
  price: number;
};

export type PlatformCreationData = {
  gamesAndPrices: GameAndPrice[];
  platformName: string;
  platformVersion: string;
  platformType: string;
};

export const createPlatform = async (data: PlatformCreationData): Promise<Platform> =>
  httpClient.post(`/api/platform`, data);

export const fetchPlatform = async (id: string): Promise<Platform> =>
  httpClient.get(`/api/platform/${id}`);
export const fetchPlatforms = async (): Promise<Platform[]> => httpClient.get(`/api/platform`);
