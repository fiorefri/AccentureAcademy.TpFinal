using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccentureAcademy.TpFinal.Models
{
    public class AutoresMetadata
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [Index("UQ_NOMBREAUTOR")]
        [Display(Name = "Autor")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre tiene que estar entre 1 y 100 caracteres")]
        public string NombreAutor { get; set; }
    }

    [MetadataType(typeof(AutoresMetadata))]
    public partial class Autores
    {

    }
}