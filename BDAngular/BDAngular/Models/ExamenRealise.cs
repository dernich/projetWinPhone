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
    
    public partial class ExamenRealise
    {
        public int codeExamReal { get; set; }
        public decimal duree { get; set; }
        public string resultat { get; set; }
        public decimal prix { get; set; }
        public int codeTypeExam { get; set; }
        public int idVM { get; set; }
        public int idMed { get; set; }
    
        public virtual Medecin Medecin { get; set; }
        public virtual TypeExamen TypeExamen { get; set; }
        public virtual VisiteMedicale VisiteMedicale { get; set; }
    }
}
