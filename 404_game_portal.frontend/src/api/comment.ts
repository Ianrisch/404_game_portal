import { User } from '@/api/auth';
import { Game } from '@/api/game';
import httpClient from '@/services/httpClient';

export type Comment = {
  id: number;
  comment: string;
  userName: string;
  userId: string;
};

export type CommentUpdateData = {
  comment: string;
  id: string;
};

export type CommentCreationData = {
  comment: string;
  gameId: string;
};

export const fetchComments = async (gameId: string): Promise<Comment[]> =>
  httpClient.get(`/api/comment/${gameId}`);

export const createComment = async (data: CommentCreationData): Promise<Comment> =>
  httpClient.post('api/comment', data);

export const updateComment = async (data: CommentUpdateData): Promise<Comment> =>
  httpClient.put('api/comment/', data);
