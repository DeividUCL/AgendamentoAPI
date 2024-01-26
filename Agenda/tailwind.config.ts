import type { Config } from 'tailwindcss'

export default <Partial<Config>>{
  content: {
    files: [
      './src/**/*.html',
      './src/**/*.vue',
      './src/**/*.jsx',
    ],
    // safelist: [
    //   /text-red-400/,
    //   /text-red-500/,
    //   /ring-red-400/,
    //   /ring-red-500/,
    //   /bg-red-400/,
    //   /bg-red-500/,
    // ],
  },
  theme: {
    screens: {
      sm: '480px',
      md: '768px',
      lg: '976px',
      xl: '1440px',
      // '2xl': '1536px',
    },
    colors: {
      transparent: 'transparent',
      green: {
        DEFAULT: '#22c554',
        50: '#f0fdf4',
        100: '#dcfce6',
        200: '#bbf7cd',
        300: '#86efa6',
        400: '#4ade78',
        500: '#22c554',
        600: '#16a341',
        700: '#158036',
        800: '#16652e',
        900: '#145327',
        950: '#052e12',
      },
      gray: {
        DEFAULT: '#859bab',
        50: '#f9fafb',
        100: '#eceff2',
        200: '#d5dde2',
        300: '#b0bfc9',
        400: '#859bab',
        500: '#668091',
        600: '#516778',
        700: '#425462',
        800: '#394753',
        900: '#333e47',
        950: '#22292f',
      },
    },
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
