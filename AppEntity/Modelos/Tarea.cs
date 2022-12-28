using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEntity.Modelos
{
    public class Tarea
    {
        //Primer atributo
        public int TareaId { get; set; }

        public int IdCategoria { get; set; }

        public string TareaName { get; set; }
        public Categoria categoria { get; set; }


    }
}
