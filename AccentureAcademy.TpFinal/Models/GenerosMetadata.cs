using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccentureAcademy.TpFinal.Models
{
    public class GenerosMetadata
    {
        [Required(ErrorMessage = "El género es requerido")]
        [Index("UQ_GENERO")]
        [Display(Name = "Género")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El género tiene que estar entre 1 y 50 caracteres")]
        public string Genero { get; set; }
    }

    [MetadataType(typeof(GenerosMetadata))]
    public partial class Generos
    {

    }
}