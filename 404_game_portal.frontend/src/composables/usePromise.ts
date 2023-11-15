import { ref } from 'vue';

export default function usePromise<T, R extends unknown[]>(
  fn: (...args: R) => Promise<T>,
  onSuccess?: (result: T) => void,
  onFailure?: (error: unknown) => void,
) {
  const result = ref<T>();
  const initialLoading = ref(false);
  const loading = ref(false);
  const error = ref();

  const createPromise = async (...args: R): Promise<void> => {
    loading.value = true;
    error.value = undefined;

    if (!result.value) {
      initialLoading.value = true;
    }

    try {
      result.value = await fn(...args);
      onSuccess?.(result.value);
    } catch (err) {
      // eslint-disable-next-line no-console
      console.error(err);
      error.value = err;
      onFailure?.(err);
    } finally {
      loading.value = false;
      initialLoading.value = false;
    }
  };

  return {
    createPromise,
    error,
    initialLoading,
    loading,
    result,
  };
}
