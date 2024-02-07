import httpClient from '@/services/httpClient';
import { Game } from '@/api/game';

export type User = {
  email: string;
  username: string;
  role: Role;
};

export enum Role {
  User,
  Admin,
}

export type RegisterData = {
  email: string;
  username: string;
  password: string;
};

export type LoginData = {
  email: string;
  password: string;
};

export type ChangePasswordData = {
  oldPassword: string;
  newPassword: string;
};

export const logOut = async (): Promise<string> => httpClient.get('/api/auth/logout');
export const logIn = async (loginData: LoginData): Promise<string> =>
  httpClient.post('/api/auth/login', loginData);

export const getUser = async (usernameOrEmail?: string): Promise<User> =>
  httpClient.get('/api/auth/user' + (usernameOrEmail ? `?usernameOrEmail=${usernameOrEmail}` : ''));

export const register = async (registerData: RegisterData): Promise<string> =>
  httpClient.post('/api/auth/register', registerData);

export const changePassword = async (changePasswordData: ChangePasswordData): Promise<string> =>
  httpClient.put('/api/auth/changePassword', changePasswordData);
