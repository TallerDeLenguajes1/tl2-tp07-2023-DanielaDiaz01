public class Tarea
{
    public int IdTarea { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }

    //Constructor
    public Tarea(int id, string titulo, string descripcion, string estado)
    {
        IdTarea = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Estado = estado;
    }


    public Tarea()
    {
        //Inicializa las propiedades requeridas
        IdTarea = 0;
        Titulo = string.Empty;
        Descripcion = string.Empty;
        Estado = string.Empty;
    }

}
