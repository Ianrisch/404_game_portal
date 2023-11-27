import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';
import { Platform } from '@/api/platform';

export type PriceOnPlatform = {
  id: string;
  price: Number;
  game: Game;
  platform: Platform;
};
