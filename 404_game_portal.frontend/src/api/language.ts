import { Game } from '@/api/game';
import httpClient from '@/services/httpClient';

export type Language = {
  id: string;
  languageName: string;
  games: Game[];
};

export type LanguageCreationData = {
  languageName: string;
  gameIds: string[];
};
export const fetchLanguage = async (id: string): Promise<Language> =>
  httpClient.get(`/api/language/${id}`);
export const fetchLanguages = async (): Promise<Language[]> => httpClient.get(`/api/language`);
export const createLanguage = async (data: LanguageCreationData): Promise<Language> =>
  httpClient.post(`/api/language`, data);
