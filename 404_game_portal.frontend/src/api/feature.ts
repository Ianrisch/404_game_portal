import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type Feature = {
  id: String;
  games: Game[];
  featureName: String;
  featureDescription: String;
};

export const fetchFeatures = async (): Promise<Feature[]> => httpClient.get('/api/feature');
export const fetchFeature = async (id: String): Promise<Feature> =>
  httpClient.get('/api/feature/' + id);
