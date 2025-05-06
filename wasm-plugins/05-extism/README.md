# Details

Ein Plugin bspw. über folgende *package.json* veröffentlichen (PluginCs/bin/Debug/net8.0/wasi-wasm/AppBundle):

```json
{
  "name": "csharp",
  "version": "1.0.0",
  "main": "Plugin.wasm",
  "scripts": {
    "deploy": "npx publish-microfrontend --url https://extism-demo.my.dev.piral.cloud/api/v1/pilet --interactive"
  },
  "files": [
    "Plugin.wasm",
    "Plugin.runtimeconfig.json"
  ],
  "keywords": [],
  "author": "Florian Rappl",
  "license": "MIT",
  "description": "Example plugin using C# as language."
}
```

Oder für Rust (PluginRust/target/wasm32-unknown-unknown/debug):

```json
{
  "name": "rust",
  "version": "1.0.0",
  "main": "rust_pdk_template.wasm",
  "scripts": {
    "deploy": "npx publish-microfrontend --url https://extism-demo.my.dev.piral.cloud/api/v1/pilet --interactive"
  },
  "files": [
    "rust_pdk_template.wasm"
  ],
  "keywords": [],
  "author": "Florian Rappl",
  "license": "MIT",
  "description": "Example plugin using Rust as language."
}
```

Um eine Funktion wie bspw. `add` mit Hilfe von JSON als Eingabe laufen zu lassen:

```sh
dotnet run add '{"left":2,"right":3}'
```

Nur eins der zwei Plugins definiert das JSON so - bspw. braucht das andere Plugin `a` und `b` als Parameter.

```sh
dotnet run add '{"a":2,"b":3}'
```

Um die `greet` Funktion aufzurufen:

```sh
dotnet run greet Flo
```
