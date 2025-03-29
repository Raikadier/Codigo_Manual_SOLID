using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Docente : Usuario
    {
        public override string Rol => "Docente";
        public string Departamento { get; set; }
    }
}
