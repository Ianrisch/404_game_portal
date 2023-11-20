import httpClient from '@/services/httpClient';
import { PriceOnPlatform } from '@/api/priceOnPlatform';
import { Game } from '@/api/game';

export type Platform = {
  id: String;
  games: Game[];
  priceOnPlatforms: PriceOnPlatform;
  platformName: String;
  platformVersion: String;
  platformType: String;
};
