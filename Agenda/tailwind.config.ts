import type { Config } from 'tailwindcss'
import { excludeColors, generateSafelist, customSafelistExtractor } from './colors';

console.log('customSafelistExtractor importado:', customSafelistExtractor);

const myColors = {
  transparent: 'transparent',
  primary: {
    DEFAULT: '#ef4444',
    50: '#fef2f2',
    100: '#fee2e2',
    200: '#fecaca',
    300: '#fca5a5',
    400: '#f87171',
    500: '#ef4444',
    600: '#dc2626',
    700: '#b91c1c',
    800: '#991b1b',
    900: '#7f1d1d',
  },
  gray: {
    50: '#f8fafc',
    100: '#f1f5f9',
    200: '#e2e8f0',
    300: '#cbd5e1',
    400: '#94a3b8',
    500: '#64748b',
    600: '#475569',
    700: '#334155',
    800: '#1e293b',
    900: '#0f172a',
  },
  red: {
    50: '#FDEDED',
    100: '#FCDADA',
    200: '#F9B5B5',
    300: '#F58F8F',
    400: '#F26A6A',
    500: '#EF4444',
    600: '#E71414',
    700: '#B30F0F',
    800: '#800B0B',
    900: '#4C0707',
    950: '#320404'
  },
};
const myGlobalColors = 'primary';
const excluirCores = excludeColors(myColors);

const coresEmUso = excluirCores.reduce((obj: Record<string, any>, color) => {
  obj[color] = myColors[color as keyof typeof myColors];
  return obj;
}, {})

export default <Partial<Config>>{
  content: {
    files: [
      './src/**/*.{js,ts,jsx,tsx,vue}',
    ],
    safelist: generateSafelist(Object.keys(myColors), myGlobalColors),
    // {
    //   standard: generateSafelist(Object.keys(myColors), myGlobalColors),
    //   extractors: [
    //     {
    //       extractor: customSafelistExtractor,
    //       extensions: ['js', 'ts', 'jsx', 'tsx'],
    //     },
    //   ],
    // },
  },
  theme: {
    screens: {
      sm: '480px',
      md: '768px',
      lg: '976px',
      xl: '1440px',
      // '2xl': '1536px',
    },
    colors: coresEmUso,
    extend: {
      spacing: {
        '128': '32rem',
        '144': '36rem',
      },
      borderRadius: {
        '4xl': '2rem',
      },
      aspectRatio: {
        auto: 'auto',
        square: '1 / 1',
        video: '16 / 9'
      }
    },
  }
}
