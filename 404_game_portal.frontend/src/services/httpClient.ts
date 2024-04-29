/* eslint-disable no-console */
enum HttpMethod {
  POST = 'POST',
  GET = 'GET',
  PUT = 'PUT',
  DELETE = 'DELETE',
}

export interface HttpError extends Error {
  statusCode?: number;
}

const send = async <T>(
  url: string,
  method: HttpMethod,
  payload: Record<string, unknown> | FormData | null,
  ignoreRedirect = false,
  download = false,
  downloadFileName?: string,
): Promise<T> => {
  const headers: Record<string, string> = {
    Accept: 'application/json',
  };

  const options: RequestInit = {
    method,
    headers,
    redirect: 'manual',
  };

  if (payload instanceof FormData) {
    options.body = payload;
  } else if (payload) {
    headers['Content-Type'] = 'application/json';
    options.body = JSON.stringify(payload);
  }

  try {
    const startTime = new Date().getMilliseconds();
    console.debug(options.method + ' ' + url);
    const response = await fetch(url, options);
    console.debug(
      options.method +
        ' ' +
        url +
        ': ' +
        response.status +
        ' - ' +
        (new Date().getMilliseconds() - startTime) +
        'ms',
    );

    if (response.status === 0 && !ignoreRedirect) {
      window.location.href = 'Login?ReturnUrl=' + window.location;
    }

    if (!response.ok) {
      const errorData = await response.json();
      const error: HttpError = new Error(errorData.message || 'Network Error');
      error.statusCode = response.status;
      throw error;
    }

    if (download) {
      const url = window.URL.createObjectURL(await response.blob());
      const a = document.createElement('a');
      a.href = url;
      a.download = downloadFileName!;
      document.body.appendChild(a);
      a.click();
      a.remove();

      return undefined as unknown as Promise<T>;
    }

    return response.json() as Promise<T>;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

const httpClient = {
  async get<T>(url: string, ignoreRedirect = false): Promise<T> {
    return send(url, HttpMethod.GET, null, ignoreRedirect);
  },
  async post<T>(
    url: string,
    payload: Record<string, unknown> | FormData,
    ignoreRedirect = false,
  ): Promise<T> {
    return send(url, HttpMethod.POST, payload, ignoreRedirect);
  },
  async put<T>(
    url: string,
    payload: Record<string, unknown> | FormData | null,
    ignoreRedirect = false,
  ): Promise<T> {
    return send(url, HttpMethod.PUT, payload, ignoreRedirect);
  },
  async delete<T>(url: string, ignoreRedirect = false): Promise<T> {
    return send(url, HttpMethod.DELETE, null, ignoreRedirect);
  },
  async download(url: string, fileName: string): Promise<void> {
    return send(url, HttpMethod.GET, null, false, true, fileName);
  },
};

export default httpClient;
