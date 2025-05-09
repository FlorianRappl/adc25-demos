import * as React from "react";
import { createRoot } from "react-dom/client";
import { createInstance, Piral } from "piral-core";
import { createMenuApi } from "piral-menu";
import { home, layout, errors } from "./layout";

const instance = createInstance({
  state: {
    components: layout,
    errorComponents: errors,
    routes: {
      "/": home,
    },
  },
  plugins: [createMenuApi()],
  requestPilets() {
    return fetch("https://feed.piral.cloud/api/v1/pilet/netflix-demo")
      .then((res) => res.json())
      .then((res) => res.items);
  },
});

const root = createRoot(document.querySelector("#app"));
root.render(<Piral instance={instance} />);
