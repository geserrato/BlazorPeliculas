using BlazorPeliculas.Shared.Entidades;
using System.Text;
using System.Text.Json;

namespace BlazorPeliculas.Client.Repositorios;

public class Repositorio : IRepositorio
{
    private readonly HttpClient _httpClient;
    public Repositorio(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
    {
        var json = JsonSerializer.Serialize(enviar);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
    }

    public List<Pelicula> ObtenerPeliculas()
    {
        return new List<Pelicula>()
        {
            new Pelicula()
            {
                Titulo = "Spider-Man: Far From Home",
                Lanzamiento = new DateTime(2019, 7, 2),
                Poster = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"
            },
            new Pelicula()
            {
                Titulo = "Moana",
                Lanzamiento = new DateTime(2016, 11, 23),
                Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"
            },
            new Pelicula()
            {
                Titulo = "Inception", Lanzamiento = new DateTime(2010, 7, 16),
                Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"
            }
        };
    }
}