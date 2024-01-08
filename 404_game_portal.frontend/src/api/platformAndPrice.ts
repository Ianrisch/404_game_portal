import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type PlatformAndPrice = {
  id: string;
  games: Game[];
  price: number;
  platformName: string;
  platformVersion: string;
  platformType: string;
};
