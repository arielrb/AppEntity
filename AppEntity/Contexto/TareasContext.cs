using Microsoft.EntityFrameworkCore;
using AppEntity.Modelos;

namespace AppEntity.Contexto
{
    public class TareasContext : DbContext
    {
        //DbSets, son los que se van a convertir en tablas
        //Esto se llama Code First
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Tarea> tareas { get; set; }

        //Constructor del contexto
        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }

        //Cuando se creeen los modelos, seteamos distintos parametros
        //Esto es posible gracias a Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Categoria> categoriaInit = new List<Categoria>();
            categoriaInit.Add(new Categoria() { CategoriaId = 1, CategoriaName = "Tareas Personales" });
            categoriaInit.Add(new Categoria() { CategoriaId = 2, CategoriaName = "Tareas que voy a patear" });
            //Creamos la tabla Categorias
            modelBuilder.Entity<Categoria>(categoria =>
            {
                //Convertimos a tabla y asignamos el nombre
                categoria.ToTable("Categorias");
                //Designamos la clave primaria
                categoria.HasKey(p => p.CategoriaId);
                //Asignamos las columans o campos y restricciones
                categoria.Property(a => a.CategoriaName).IsRequired().HasMaxLength(150);

                categoria.HasData(categoriaInit);

            }
            );



            List<Tarea> tareasInit = new List<Tarea>();


            tareasInit.Add(new Tarea() { TareaId = 1, IdCategoria = 1, TareaName = "Lavar los platos" });
            tareasInit.Add(new Tarea() { TareaId = 2, IdCategoria = 1, TareaName = "Ordenar los juguetes" });
            
            

            //Creo la tabla de Tareas
            modelBuilder.Entity<Tarea>(tarea =>
            {
                //Convertimos a tabla y asignamos el nombre
                tarea.ToTable("TareasNovedosasSuperExclusivas");
                //Designamos la clave primaria
                tarea.HasKey(p => p.TareaId);
                //Designamos la clave foranea
                tarea.HasOne(p => p.categoria).WithMany(p => p.tareas).HasForeignKey(p => p.IdCategoria);

                //Asignamos las columans o campos y restricciones
                tarea.Property(p => p.TareaName);

                tarea.HasData(tareasInit);

            });
        }
    }
}
