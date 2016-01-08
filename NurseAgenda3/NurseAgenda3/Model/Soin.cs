using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.Model
{
    public class Soin
    {
        public int IdPatient { get; set; }
        public int IdInfi { get; set; }
        public String dateSoin { get; set; }

        public Soin()
        {

        }
    }
}
