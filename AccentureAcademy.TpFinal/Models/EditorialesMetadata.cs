using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccentureAcademy.TpFinal.Models
{
    public class EditorialesMetadata
    {
        [Required(ErrorMessage = "La editorial es requerida")]
        [Index("UQ_EDITORIAL")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "La editorial tiene que tener estar entre 1 y 30 caracteres")]
        public string Editorial { get; set; }
    }

    [MetadataType(typeof(EditorialesMetadata))]
    public partial class Editoriales
    {

    }
}