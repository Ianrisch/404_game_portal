import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type Feature = {
  id: string;
  games: Game[];
  featureName: string;
  featureDescription: string;
};

export type FeatureCreationData = {
  gameIds: string[];
  featureName: string;
  featureDescription: string;
};

export const fetchFeatures = async (): Promise<Feature[]> => httpClient.get('/api/feature');
export const fetchFeature = async (id: string): Promise<Feature> =>
  httpClient.get('/api/feature/' + id);
export const createFeature = async (data: FeatureCreationData): Promise<Feature> =>
  httpClient.post('/api/feature', data);
