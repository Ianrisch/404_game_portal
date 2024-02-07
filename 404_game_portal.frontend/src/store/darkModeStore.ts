import { defineStore } from 'pinia';
import { ref, watch } from 'vue';
import { useTheme } from 'vuetify';

export const useDarkModeStore = defineStore('darkMode', () => {
  const theme = useTheme();

  const isDarkMode = ref<boolean>(theme.global.current.value.dark);

  watch(isDarkMode, (isDark) => {
    theme.global.name.value = isDark ? 'dark' : 'light';
    localStorage.setItem('darkMode', isDark.toString());
  });

  const initDarkMode = () => {
    const darkMode = localStorage.getItem('darkMode');
    if (darkMode !== null) {
      isDarkMode.value = darkMode === 'true';
    }
  };

  return { isDarkMode, initDarkMode };
});
