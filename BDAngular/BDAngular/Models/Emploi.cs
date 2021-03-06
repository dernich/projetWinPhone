//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDAngular.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emploi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emploi()
        {
            this.soumissionParticuliere = new HashSet<soumissionParticuliere>();
            this.VisiteMedicale = new HashSet<VisiteMedicale>();
        }
    
        public int codeEmploi { get; set; }
        public string soumisYN { get; set; }
        public System.DateTime dateEntree { get; set; }
        public Nullable<System.DateTime> dateSortie { get; set; }
        public int idTrav { get; set; }
        public int numeroEntr { get; set; }
    
        public virtual Entreprise Entreprise { get; set; }
        public virtual Travailleur Travailleur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<soumissionParticuliere> soumissionParticuliere { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisiteMedicale> VisiteMedicale { get; set; }
    }
}
