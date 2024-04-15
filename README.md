
# MauiPeliculasApp

Aplicación .NET 7 MAUI en la cual se podrán visualizar las peliculas populares y mejor valoradas. Se utiliza SQLite como base de datos y patrón de diseño MVVVM


## API Reference
https://developers.themoviedb.org/3/movies/get-popular-movies
#### Get peliculas populares

```http
  GET https://api.themoviedb.org/3/movie/popular
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Requerido**. Api key |
| `language` | `string` | **Opcional**. es-ES (español) |
| `page` | `string` | **Opcional**. 1 página |

#### Get peliculas mejor valoradas

```http
  GET https://api.themoviedb.org/3/movie/top_rated
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Requerido**. Api key |
| `language` | `string` | **Opcional**. es-ES (español) |
| `page` | `string` | **Opcional**. 1 página |




## Paquetes y versiones

- CommunityToolkit.Mvvm **v. 8.2.1**
- Microsoft.EntityFrameworkCore.Sqlite **v. 7.0.18**
- Newtonsoft.Json **v. 13.0.3**
- Microsoft.Data.Sqlite.Core **v. 7.0.18**
- Microsoft.EntityFrameworkCore.Sqlite **v.7.0.18**


### Tencnología
- .NET 7 MAUI
### Base de datos
- SQLite
### Patrón de diseño

- MVVM

