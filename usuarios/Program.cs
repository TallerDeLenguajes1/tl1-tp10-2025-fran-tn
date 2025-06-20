using EspacioUsuarios;
using System.IO;
using System.Text.Json;

string rutaArchivo = "../lista.csv";

// Crear una Instancia de HttpClient:
HttpClient client = new HttpClient();

// Enviar Solicitud GET: Se envía una solicitud GET a la URL especificada y se verifica que la
// respuesta sea exitosa.

string url = "https://jsonplaceholder.typicode.com/users";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

// Leer y Deserializar la Respuesta:
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuarios> listUsuarios = JsonSerializer.Deserialize<List<Usuarios>>(responseBody);

int contador=0; 

foreach (Usuarios usuario in listUsuarios)
{
    if (contador < 5)
    {
        Console.WriteLine($"Nombre: {usuario.name}");
        Console.WriteLine($"Correo electronico: {usuario.email}");
        Console.WriteLine($"Domicilio: {usuario.address.street}");
    }
    contador++;
}

if(!File.Exists(rutaArchivo))
{
    File.Create(rutaArchivo);
}

using(StreamWriter writer = new StreamWriter(rutaArchivo, true))
{
    writer.WriteLine("Nombre, Correo Electronico");

    foreach(Usuarios elementos in listUsuarios)
    {
        string escribirNombre = elementos.name;
        string escribirCorreo = elementos.email;

        string linea = $"{escribirNombre}, {escribirCorreo}";
        writer.WriteLine(linea);
    }

    Console.WriteLine("Archivo cargado");
}