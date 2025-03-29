using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Jurado : Usuario
    {
        public override string Rol => "Jurado";
        public string Especialidad { get; set; }
    }
}
