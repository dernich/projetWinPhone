﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBIG3B9Entities : DbContext
    {
        public DBIG3B9Entities()
            : base("name=DBIG3B9Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Emploi> Emploi { get; set; }
        public virtual DbSet<Entreprise> Entreprise { get; set; }
        public virtual DbSet<ExamenRealise> ExamenRealise { get; set; }
        public virtual DbSet<lieu> lieu { get; set; }
        public virtual DbSet<Medecin> Medecin { get; set; }
        public virtual DbSet<soumissionParticuliere> soumissionParticuliere { get; set; }
        public virtual DbSet<Travailleur> Travailleur { get; set; }
        public virtual DbSet<TypeExamen> TypeExamen { get; set; }
        public virtual DbSet<VisiteMedicale> VisiteMedicale { get; set; }
    }
}
