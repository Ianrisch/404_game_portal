import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type PriceOnPlatform = {
  id: string;
  price: Number;
  game: Game;
  platform: PriceOnPlatform;
};
