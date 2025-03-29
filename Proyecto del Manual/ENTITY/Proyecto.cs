using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Proyecto : TrabajoAcademico
    {
        public override string Tipo => "Proyecto";
        public string LineaInvestigacion { get; set; }
    }
}
