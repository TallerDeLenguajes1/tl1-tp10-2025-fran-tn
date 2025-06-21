using System;
using System.Text.Json;
using EspacioFacts;

HttpClient client = new HttpClient();
//Se crea la instania httpclient

string url = "https://catfact.ninja/fact";
//url de la API

string guardarDatos = "../datosEjercicio3.csv";
//Ubicacion donde se creara el archivo csv

HttpResponseMessage response = await client.GetAsync(url);
//Envia una solicitud GET a la url asignada

response.EnsureSuccessStatusCode();
//Indica si la conexion fue exitosa

string responseBody = await response.Content.ReadAsStringAsync();
//Lee la respuesta

Facts descerealizado = JsonSerializer.Deserialize<Facts>(responseBody);
//Deserealiza la respuesta
//La API contiene un solo elemento, por lo tanto no es necesario crear una lista

Console.WriteLine($"dato1: {descerealizado.fact}, dato2: {descerealizado.length}");

if (!File.Exists(guardarDatos))
//Si no existe el archivo csv se lo crea
{
    File.Create(guardarDatos);
}

using (StreamWriter writer = new StreamWriter(guardarDatos, true))
//True hace que se escriba al final del archivo

{
    writer.WriteLine("Fact, Longitud");
    //Escribo un encabezado para la lista

    string linea = $"{descerealizado.fact}, {descerealizado.length}";
    //Creo el texto que se escribira en el archivo

    writer.WriteLine(linea);
    //Escribo el texto en el archivo
    

    Console.WriteLine("Operacion realizada");
}
//using cierra el archivo 