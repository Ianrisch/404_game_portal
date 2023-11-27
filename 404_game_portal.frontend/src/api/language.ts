import { Game } from '@/api/game';

export type Language = {
  id: string;
  languageName: string;
  games: Game[];
};
