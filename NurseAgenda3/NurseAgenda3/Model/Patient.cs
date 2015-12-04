using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.Model
{
    public class Patient
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String DateNaissance { get; set; }
        public String Rue { get; set; }
        public int Numero { get; set; }
        public String CodePostal { get; set; }
        public String Localite { get; set; }
        public String Telephone { get; set; }

        public Patient(String nom, String prenom, String dateNaissance, String rue, int numero, String codePostal, String localite, String telephone)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
            Localite = localite;
            Telephone = telephone;
        }

        public Patient() { }
    }
}
