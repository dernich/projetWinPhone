//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VisiteMedicale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisiteMedicale()
        {
            this.ExamenRealise = new HashSet<ExamenRealise>();
        }
    
        public int idVM { get; set; }
        public System.DateTime dateVisite { get; set; }
        public int codeEmploi { get; set; }
        public int idLieu { get; set; }
    
        public virtual Emploi Emploi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamenRealise> ExamenRealise { get; set; }
        public virtual lieu lieu { get; set; }
    }
}
