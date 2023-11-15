/* eslint-disable no-console */
enum HttpMethod {
  POST = 'POST',
  GET = 'GET',
  PUT = 'PUT',
  DELETE = 'DELETE',
}
const sendXML = async <T>(
  url: string,
  method: HttpMethod,
  form: FormData,
  ignoreRedirect: boolean,
) => {
  try {
    const xhr = new XMLHttpRequest();
    xhr.open(method, url);

    xhr.onload = () => {
      if (xhr.readyState === xhr.DONE) {
        canContinue = true;
      }
    };
    xhr.onerror = () => {
      throw new Error(xhr.statusText.toString());
    };

    xhr.send(form);
    let canContinue: boolean = false;

    while (!canContinue) {
      await new Promise((r) => setTimeout(r, 200));
    }

    if (xhr.status === 0 && !ignoreRedirect) {
      // do nothing
    }

    return JSON.parse(xhr.response) as Promise<T>;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

const send = async <T>(
  url: string,
  method: HttpMethod,
  payload: Record<string, unknown> | null,
  ignoreRedirect = false,
): Promise<T> => {
  const headers: Record<string, string> = {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  };

  const options: RequestInit = {
    method,
    headers,
    redirect: 'manual',
  };
  if (payload) {
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
      // do nothing for now
    }

    if (!response.ok) {
      throw new Error(response.status.toString());
    }

    return response.json() as Promise<T>;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

const httpClient = {
  async get<T>(url: string, ignoreRedirect = false): Promise<T> {
    return send(url, HttpMethod.GET, null, ignoreRedirect);
  },
  async post<T>(url: string, payload: Record<string, unknown>, ignoreRedirect = false): Promise<T> {
    return send(url, HttpMethod.POST, payload, ignoreRedirect);
  },
  async postFileInModel<T>(url: string, form: FormData, ignoreRedirect = false): Promise<T> {
    return sendXML(url, HttpMethod.POST, form, ignoreRedirect);
  },
  async putFileInModel<T>(url: string, form: FormData, ignoreRedirect = false): Promise<T> {
    return sendXML(url, HttpMethod.PUT, form, ignoreRedirect);
  },
  async put<T>(
    url: string,
    payload: Record<string, unknown> | null,
    ignoreRedirect = false,
  ): Promise<T> {
    return send(url, HttpMethod.PUT, payload, ignoreRedirect);
  },
  async delete<T>(url: string, ignoreRedirect = false): Promise<T> {
    return send(url, HttpMethod.DELETE, null, ignoreRedirect);
  },
};

export default httpClient;
