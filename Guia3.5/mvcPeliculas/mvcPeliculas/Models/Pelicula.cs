using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcPeliculas.Models
{
    public class Pelicula
    {
   
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Titulo { get; set; }

        [Display(Name = "Fecha de Lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaLanzamiento { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genero { get; set; }


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Calificacion { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Productor { get; set; }

        [Display(Name = "Director")]
        public int Director_ID { get; set; }
        public virtual Director DirectorMubi { get; set; } 




    }

    public class PeliculaDBContext : DbContext
    {
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>()
                .HasOne(b => b.DirectorMubi)
                .WithMany(i => i.Mubis)
                .HasForeignKey(b => b.Director_ID);



            modelBuilder.Entity<Director>().HasData(
                new { ID = 1, Nombre = "Gerardo Moreno", Pais = "El Salvador", FechaNacimiento = DateTime.Parse("1998-03-23")},
                new { ID = 2, Nombre = "Brenda Palencia", Pais = "El Salvador", FechaNacimiento = DateTime.Parse("1998-05-14") }

                );

            modelBuilder.Entity<Pelicula>().HasData(
                new { ID = 1, Director_ID = 1, Titulo = "Lluvia de gatos", FechaLanzamiento = DateTime.Parse("2014-10-24"),Genero="Comedia",Precio=6.99M,Calificacion="A",Productor="Hernan Castro" }
                );
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Director> Directores { get; set; }

        public PeliculaDBContext(DbContextOptions options)
          : base(options)
        {

        }

    }
}
