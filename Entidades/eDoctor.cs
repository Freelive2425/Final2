using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDoctor
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Cargo { get; set; }
        public int NumColegiado { get; set; }

        public override string ToString()
        {
            return DNI + "" + Nombre + "" + Especialidad + "" + Cargo + "" + NumColegiado;
        }
    }
}
