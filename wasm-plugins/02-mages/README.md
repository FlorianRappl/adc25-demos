# Details

Zuerst das Projekt initialisieren:

```sh
dotnet new web -o FlexibleApi
cd FlexibleApi
```

Die Abhängigkeiten installieren:

```sh
dotnet add package Mages
```

HTTPS einrichten, falls noch nicht geschehen:

```sh
dotnet dev-certs https --trust
```

Um das Projekt laufen zu lassen:

```sh
dotnet run
```

Im Browser ausführen:

```js
fetch('/', {
    method: 'POST',
    body: JSON.stringify({
        code: "2+3",
    }),
    headers: {
        'content-type': 'application/json',
    },
})
```

Komplexeres Beispiel:

```js
fetch('/', { method: 'POST', body: JSON.stringify({ code: "db.products.count" }), headers: { 'content-type': 'application/json' } })
fetch('/', { method: 'POST', body: JSON.stringify({ code: 'db.addProduct("Example", 42.69)' }), headers: { 'content-type': 'application/json' } })
fetch('/', { method: 'POST', body: JSON.stringify({ code: 'db.products | json' }), headers: { 'content-type': 'application/json' } })
```
