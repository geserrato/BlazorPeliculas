function pruebaPuntoNetStatic() {
    DotNet.invokeMethodAsync("BlazorPeliculas.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log(`Conteo desde Js ${resultado}`);
        })
}

function pruebaPuntoNetInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}