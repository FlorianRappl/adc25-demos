# Details

Zuerst das Projekt initialisieren:

```sh
mkdir example
cd example
npm init -y
npm install --save-dev assemblyscript
npx asinit .
```

Um das Projekt bauen zu lassen:

```sh
npm run asbuild
```

Um das Projekt im Browser laufen zu lassen:

```sh
npm start
```

Anschließend die generierte WASM im [Playground](https://webassembly.github.io/wabt/demo/wasm2wat/) anschauen.

Die Artefakte beinhalten auch Node.js-kompatible Quellen:

```js
import('./build/release.js').then(res => res.add(2, 3)).then(res => console.log('Result %s', res))
```
