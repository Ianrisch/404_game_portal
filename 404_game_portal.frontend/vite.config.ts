// Plugins
import vue from '@vitejs/plugin-vue'
import vuetify, { transformAssetUrls } from 'vite-plugin-vuetify'

// Utilities
import { defineConfig } from 'vite'
import { fileURLToPath, URL } from 'node:url'

// https://vitejs.dev/config/
export default defineConfig(({ command, mode, ssrBuild }) => {
  if (command === 'serve') {
    return {
      plugins: [
        vue({
          template: { transformAssetUrls }
        }),
        // https://github.com/vuetifyjs/vuetify-loader/tree/next/packages/vite-plugin
        vuetify({
          autoImport: true,
        }),
      ],
      define: { 'process.env': {} },
      resolve: {
        alias: {
          '@': fileURLToPath(new URL('./src', import.meta.url))
        },

        extensions: [
          '.js',
          '.json',
          '.jsx',
          '.mjs',
          '.ts',
          '.tsx',
          '.vue',
        ],
      },
      server: {
        port: 3000,
        proxy: {
          '/api': {
            target: 'https://localhost:7016',
            changeOrigin: true,
            secure: false,
          },
        },
      },
    }
  } else {
    // command === 'build'
    return {
      build: {
        outDir: '../404_game_portal.backend/wwwroot'
      },
      plugins: [
        vue({
          template: { transformAssetUrls }
        }),
        // https://github.com/vuetifyjs/vuetify-loader/tree/next/packages/vite-plugin
        vuetify({
          autoImport: true,
        }),
      ],
        define: { 'process.env': {} },
      resolve: {
        alias: {
          '@': fileURLToPath(new URL('./src', import.meta.url))
        },

        extensions: [
          '.js',
          '.json',
          '.jsx',
          '.mjs',
          '.ts',
          '.tsx',
          '.vue',
        ],
      },
      server: {
        port: 3000,
      },
    }

  }
}
)
