export default [
  {
    languageOptions: {
      globals: {
        angular: "readonly",
        statusText: "writable",
        start: "writable",
        end: "writable",
        FormData: "readonly",
        document: "readonly",
        window: "readonly",
        module: "readonly",
        require: "readonly",
        exports: "readonly",
        __dirname: "readonly",
        __filename: "readonly",
        process: "readonly",
      },
    },
    rules: {
      "no-undef": "error",
      "no-unused-vars": ["error", { args: "none" }],
    },
  },
];
