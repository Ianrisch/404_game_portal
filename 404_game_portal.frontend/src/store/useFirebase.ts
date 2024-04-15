import { defineStore } from 'pinia';
import { initializeApp } from 'firebase/app';
import { getStorage, getDownloadURL, ref } from 'firebase/storage';

export const useFirebase = defineStore('firebase', () => {
  const firebaseConfig = {
    apiKey: 'AIzaSyDbSP6FfcAARRU7Qn71Rdi8R-cWCRfBAhs',
    authDomain: 'gameportal-9d72f.firebaseapp.com',
    projectId: 'gameportal-9d72f',
    storageBucket: 'gameportal-9d72f.appspot.com',
    messagingSenderId: '280772725717',
    appId: '1:280772725717:web:cf856c465ff00cedd5cb5c',
  };

  const firebaseApp = initializeApp(firebaseConfig);
  const storage = getStorage(firebaseApp);

  const getUrlForFile = async (filePath: string): Promise<string | undefined> => {
    try {
      const storageRef = ref(storage, filePath);
      const url = await getDownloadURL(storageRef);
      console.log('url: ' + url);
      return url;
    } catch (e) {
      console.warn(e);
      return undefined;
    }
  };
  return {
    getUrlForFile,
  };
});
