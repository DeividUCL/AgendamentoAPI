export default defineAppConfig({
  ui: {
    primary: 'green',
    gray: 'gray'
  },
  content: {
    files: [
      './src/**/*.html',
      './src/**/*.vue',
      './src/**/*.jsx',
    ],
    safelist: [
      /text-red-400/,
      /text-red-500/,
      /ring-red-400/,
      /ring-red-500/,
      /bg-red-400/,
      /bg-red-500/,
    ],
  },
})
