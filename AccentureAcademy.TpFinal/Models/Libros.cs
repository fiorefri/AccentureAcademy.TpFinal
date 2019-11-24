//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccentureAcademy.TpFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Libros()
        {
            this.EscritoPor = new HashSet<EscritoPor>();
        }
    
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
        public int Id_Genero { get; set; }
        public int Id_Editorial { get; set; }
        public int Id_Nivel { get; set; }
    
        public virtual Editoriales Editoriales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EscritoPor> EscritoPor { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual Niveles Niveles { get; set; }
    }
}
