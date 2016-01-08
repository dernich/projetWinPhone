using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.Model
{
    public static class AllPatients
    {
        public static IEnumerable<Patient> Students { get; set; }

        public static IEnumerable<Patient> GetAllPatients()
        {
            return Students = new List<Patient>
            {
                /*new Patient("Dernivoix", "Antoine", "09/11/1993", "Place de la gare", 7, "6840", "Longlier", "0494089554"),
                new Patient("Doumont", "Kévin", "02/11/1995", "Place de la gare", 7, "6840", "Longlier", "0494089554"),
                new Patient("Degraux", "Maxence", "19/06/1995", "Place de la gare", 7, "6840", "Longlier", "0494089554"),
                new Patient("Leonard", "Sebastien", "18/06/1995", "Rue du triboli", 20, "4020", "Liege", "0499135566"),
                new Patient("Hayward", "Juliette", "10/01/1992", "Avenue Roi baudouin", 15, "6600", "Bastogne", "0494485638"),
                new Patient("Nicolay", "Quentin", "26/07/1994", "Place de la gare", 7, "6840", "Longlier", "0494089554"),
                new Patient("Frantz", "Corentin", "13/04/1993", "Place de la gare", 7, "6840", "Longlier", "0494089554")*/
            };
        }
    }
}
