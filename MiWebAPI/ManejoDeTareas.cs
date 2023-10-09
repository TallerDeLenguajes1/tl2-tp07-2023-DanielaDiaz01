
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tareas
{
    public class ManejoDeTareas
    {
        private AccesoADatos accesoADatos; // Instancia de la clase de persistencia de datos JSON

        public ManejoDeTareas()
        {
            accesoADatos = new AccesoADatos(); // Inicializa la instancia de AccesoADatos
        }

        public async Task<List<Tarea>> ObtenerTodasLasTareasAsync()
        {
            return await accesoADatos.ObtenerTareasAsync();
        }

        public async Task GuardarTareaAsync(Tarea tarea)
        {
            List<Tarea> tareas = await accesoADatos.ObtenerTareasAsync();
            tareas.Add(tarea);
            await accesoADatos.GuardarTareasAsync(tareas);
        }

        public async Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            List<Tarea> tareas = await accesoADatos.ObtenerTareasAsync();
            return tareas.FirstOrDefault(t => t.IdTarea == id);
        }

        public async Task ActualizarTareaAsync(Tarea tareaActualizada)
        {
            List<Tarea> tareas = await accesoADatos.ObtenerTareasAsync();
            int index = tareas.FindIndex(t => t.IdTarea == tareaActualizada.IdTarea);
            if (index >= 0)
            {
                tareas[index] = tareaActualizada;
                await accesoADatos.GuardarTareasAsync(tareas);
            }
        }

        public async Task EliminarTareaAsync(int id)
        {
            List<Tarea> tareas = await accesoADatos.ObtenerTareasAsync();
            tareas.RemoveAll(t => t.IdTarea == id);
            await accesoADatos.GuardarTareasAsync(tareas);
        }

        public async Task<List<Tarea>> ObtenerTodasLasTareasCompletadasAsync()
        {
            List<Tarea> tareas = await accesoADatos.ObtenerTareasAsync();
            return tareas.Where(t => t.Estado == "Completada").ToList();
        }
    }
}

/*
using System;
using System.Collections.Generic;

public class ManejoDeTareas
{
    private AccesoADatos accesoDatos;

    public ManejoDeTareas(string rutaArchivoJson)
    {
        // Crea una instancia de AccesoADatos con la ruta del archivo JSON
        accesoDatos = new AccesoADatos(rutaArchivoJson);
    }

    public void AgregarTarea(Tarea tarea)
    {
        // Obtén la lista actual de tareas desde el archivo JSON
        List<Tarea> tareas = accesoDatos.LeerTareas();

        // Asigna un ID único a la nueva tarea
        tarea.IdTarea = GenerarNuevoId(tareas);

        // Agrega la nueva tarea a la lista de tareas
        tareas.Add(tarea);

        // Guarda la lista actualizada de tareas en el archivo JSON
        accesoDatos.GuardarTareas(tareas);
    }

    public List<Tarea> ObtenerTodasLasTareas()
    {
        // Obtiene la lista actual de tareas desde el archivo JSON
        return accesoDatos.LeerTareas();
    }

    public Tarea ObtenerTareaPorId(int idTarea)
    {
        // Obtiene la lista actual de tareas desde el archivo JSON
        List<Tarea> tareas = accesoDatos.LeerTareas();

        // Busca la tarea por su ID
        return tareas.Find(t => t.IdTarea == idTarea);
    }

    public void ActualizarTarea(Tarea tareaActualizada)
    {
        // Obtiene la lista actual de tareas desde el archivo JSON
        List<Tarea> tareas = accesoDatos.LeerTareas();

        // Busca la tarea por su ID
        Tarea tareaExistente = tareas.Find(t => t.IdTarea == tareaActualizada.IdTarea);

        if (tareaExistente != null)
        {
            // Actualiza la tarea existente con los datos de la tarea actualizada
            tareaExistente.Titulo = tareaActualizada.Titulo;
            tareaExistente.Descripcion = tareaActualizada.Descripcion;
            tareaExistente.Estado = tareaActualizada.Estado;

            // Guarda la lista actualizada de tareas en el archivo JSON
            accesoDatos.GuardarTareas(tareas);
        }
    }

    public void EliminarTarea(int idTarea)
    {
        // Obtiene la lista actual de tareas desde el archivo JSON
        List<Tarea> tareas = accesoDatos.LeerTareas();

        // Busca la tarea por su ID
        Tarea tareaAEliminar = tareas.Find(t => t.IdTarea == idTarea);

        if (tareaAEliminar != null)
        {
            // Elimina la tarea de la lista
            tareas.Remove(tareaAEliminar);

            // Guarda la lista actualizada de tareas en el archivo JSON
            accesoDatos.GuardarTareas(tareas);
        }
    }

    // Método auxiliar para generar un nuevo ID único para una tarea
    private int GenerarNuevoId(List<Tarea> tareas)
    {
        int nuevoId = 1; // Valor inicial para el ID

        if (tareas.Count > 0)
        {
            // Si hay tareas en la lista, obtén el ID más alto y suma 1
            nuevoId = tareas.Max(t => t.IdTarea) + 1;
        }

        return nuevoId;
    }
}
*/