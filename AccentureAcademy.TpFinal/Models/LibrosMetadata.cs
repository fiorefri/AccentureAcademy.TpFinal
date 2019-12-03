using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccentureAcademy.TpFinal.Models
{
    public class LibrosMetadata
    {
        [Required(ErrorMessage = "El ISBN es requerido")]
        [Index("UQ_ISBN")]
        [Range(1, 25, ErrorMessage = "El ISBN tiene que estar entre 1 y 25 caracteres numéricos")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [Display(Name = "Título")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El título tiene que estar entre 1 y 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "La descripción tiene que estar entre 1 y 1000 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El género es requerido")]
        [Display(Name = "Género")]
        public int Id_Genero { get; set; }

        [Required(ErrorMessage = "La editorial es requerida")]
        [Display(Name = "Editorial")]
        public int Id_Editorial { get; set; }
    }

    [MetadataType(typeof(LibrosMetadata))]
    public partial class Libros
    {

    }
}