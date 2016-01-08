using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.Model
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String DateNaissance { get; set; }
        public String Rue { get; set; }
        public String Numero { get; set; }
        public String CodePostal { get; set; }
        public String Localite { get; set; }
        public String NumTelephone { get; set; }
        public String DateDebutSoin { get; set; }
        public String DateFinSoin { get; set; }
        public List<Soin> Soins { get; set; }


        public Patient(int idPatient, String nom, String prenom, String dateNaissance, String rue, String numero, String codePostal, String localite, String telephone, String dateDebutSoin, String dateFinSoin)
        {
            IdPatient = idPatient;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
            Localite = localite;
            NumTelephone = telephone;
            DateDebutSoin = dateDebutSoin;
            DateFinSoin = dateFinSoin;
        }

        public Patient() { }
    }
}
