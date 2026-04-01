import { createI18n } from "vue-i18n";

const i18nLocal = createI18n({
  locale: "es-MX",
  numberFormats: {
    "es-MX": {
      currency: {
        style: "currency",
        currency: "MXN",
        minimumFractionDigits: 2,
      },
    },
    "en-US": {
      currency: {
        style: "currency",
        currency: "USD",
        minimumFractionDigits: 2,
      },
    },
  }
});

export default i18nLocal