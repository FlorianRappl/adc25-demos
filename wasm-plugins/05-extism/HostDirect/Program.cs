using System;

using Extism.Sdk;

var manifest = new Manifest(new UrlWasmSource("https://github.com/extism/plugins/releases/latest/download/count_vowels.wasm"));
using var plugin = new Plugin(manifest, new HostFunction[] { }, withWasi: true);

var output = plugin.Call("count_vowels", "Hello, World!");
Console.WriteLine(output);
