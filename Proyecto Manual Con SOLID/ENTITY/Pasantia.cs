using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pasantia : TrabajoAcademico
    {
        public override string Tipo => "Pasantia";
        public string Empresa { get; set; }
    }
}
