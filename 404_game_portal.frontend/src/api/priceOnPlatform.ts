import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type PriceOnPlatform = {
  id: String;
  price: Number;
  game: Game;
  platform: PriceOnPlatform;
};
