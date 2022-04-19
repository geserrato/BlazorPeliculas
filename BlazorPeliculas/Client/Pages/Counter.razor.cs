using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MathNet.Numerics.Statistics;

namespace BlazorPeliculas.Client.Pages;

public partial class Counter
{
    
    [Inject] IJSRuntime JS { get; set; }
    IJSObjectReference modulo;
    
    protected int currentCount = 0;
    static int currentCountStatic = 0;
    
    async Task IncrementCountJavaScript()
    {
        await JS.InvokeVoidAsync("pruebaPuntoNetInstancia", DotNetObjectReference.Create(this));
    }

    [JSInvokable]
    public async Task IncrementCount()
    {
        var arreglo = new double[] { 1, 2, 3, 4, 5, 6 };
        var max = arreglo.Maximum();
        var min = arreglo.Minimum();

        modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
        await modulo.InvokeVoidAsync("mostrarAlerta", $"El max es {max} y el min es {min}");

        currentCount++;
        currentCountStatic = currentCount;
        await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
    }

    [JSInvokable]
    public static Task<int> ObtenerCurrentCount()
    {
        return Task.FromResult(currentCountStatic);
    }
}