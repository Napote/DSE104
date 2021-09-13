using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcPeliculas.Models
{
    public class Director
    {

        public Director()
        {
            this.Mubis = new HashSet<Pelicula>();
        }

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Pais { get; set; }

        [Display(Name = "Peliculas")]
        public virtual ICollection<Pelicula> Mubis { get; set; }
 


    }




}
