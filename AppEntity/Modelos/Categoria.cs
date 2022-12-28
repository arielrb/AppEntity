using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppEntity.Modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string? CategoriaName { get; set; }

        //Asignado a muchas tareas, no solo unas
        //Añado la annotation para que no entre en bucle
        [JsonIgnore]
        public ICollection<Tarea> tareas { get; set; }
    }
}
