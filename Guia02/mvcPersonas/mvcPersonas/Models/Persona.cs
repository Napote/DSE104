using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace mvcPersonas.Models
{
    public class Persona
    {
       [System.ComponentModel.DataAnnotations.Key] public int ID { get; set; }
        public string DUI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
    public class PersonaDBContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public PersonaDBContext(DbContextOptions options)
           : base(options)
        {
            
        }
        #region Required 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
            .Property(b => b.ID)
            .IsRequired();
        }
        #endregion
    }
}


