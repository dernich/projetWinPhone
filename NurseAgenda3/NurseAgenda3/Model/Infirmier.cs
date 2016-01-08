using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.Model
{
    public class Infirmier
    {
        public int IdInfirmier { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Login { get; set; }
        public String MotDePasse { get; set; }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public String Type { get; set; }

        public Infirmier()
        {

        }
    }
}
