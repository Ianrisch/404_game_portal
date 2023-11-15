import httpClient from '@/services/httpClient';

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
  released: string;
  prices: [];
  releaseDate: Date;
};

export const fetchGames = async (): Promise<Game[]> => httpClient.get('/api/game');
export const fetchGame = async (id: string): Promise<Game> => httpClient.get('/api/game/' + id);
