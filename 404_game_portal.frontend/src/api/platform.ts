import httpClient from '@/services/httpClient';
import { PriceOnPlatform } from '@/api/priceOnPlatform';
import { Game } from '@/api/game';

export type Platform = {
  id: string;
  games: Game[];
  priceOnPlatforms: PriceOnPlatform;
  platformName: string;
  platformVersion: string;
  platformType: string;
};
