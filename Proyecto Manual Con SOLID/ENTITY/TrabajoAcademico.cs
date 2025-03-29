using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    //Aqui tambien se aplica SRP
    //Aqui tambien se aplica OCP
    public abstract class TrabajoAcademico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public  abstract string Tipo {get; }
    }
}
