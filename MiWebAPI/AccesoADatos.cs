using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class AccesoADatos
{
    private readonly string rutaArchivo = "tareas.json"; // Nombre del archivo JSON

    public async Task<List<Tarea>> ObtenerTareasAsync()
    {
        List<Tarea> tareas = new List<Tarea>();

        try
        {
            if (File.Exists(rutaArchivo))
            {
                string json = await File.ReadAllTextAsync(rutaArchivo);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
            }
        }
        catch (Exception ex)
        {
            // Manejar errores aquí si es necesario
            Console.WriteLine($"Error al obtener tareas: {ex.Message}");
        }

        return tareas;
    }

    public async Task GuardarTareasAsync(List<Tarea> tareas)
    {
        try
        {
            string json = JsonSerializer.Serialize(tareas, new JsonSerializerOptions
            {
                WriteIndented = true // Formato JSON con sangría
            });
            await File.WriteAllTextAsync(rutaArchivo, json);
        }
        catch (Exception ex)
        {
            // Manejar errores aquí si es necesario
            Console.WriteLine($"Error al guardar tareas: {ex.Message}");
        }
    }
}


/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoADatos
{
    //private string archivoJson;
    private readonly string archivoJson = "tareas.json"; // Nombre del archivo JSON

    //coloco la ruta al archivo json cuando llamo a la funcion
    public AccesoADatos(string archivoJson)
    {
        this.archivoJson = archivoJson;
    }

    public List<Tarea> LeerTareas()
    {
        try{
            // Verificar si el archivo JSON existe
            if (File.Exists(archivoJson))
            {
                //Leer el contenido del archivo JSON
                string json = File.ReadAllText(archivoJson);

                //Deserializar el JSON en una lista de tareas
                List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(json);

                return tareas;
            }
            else{
                // Si el archivo no existe, retornar una lista vacía
                return new List<Tarea>();
            }
        }
        catch (Exception ex){
            Console.WriteLine($"Error al leer tareas desde el archivo JSON: {ex.Message}");
            return new List<Tarea>();
        }
    }

    public void GuardarTareas(List<Tarea> tareas)
    {
        try
        {
            // Serializar la lista de tareas a formato JSON
            string json = JsonSerializer.Serialize(tareas, new JsonSerializerOptions
            {
                WriteIndented = true // Formatear el JSON para que sea legible
            });

            // Escribir el JSON en el archivo
            File.WriteAllText(archivoJson, json);

            Console.WriteLine("Tareas guardadas correctamente en el archivo JSON.");
        }
        catch (Exception ex){
            Console.WriteLine($"Error al guardar tareas en el archivo JSON: {ex.Message}");
        }
    }
}
*/