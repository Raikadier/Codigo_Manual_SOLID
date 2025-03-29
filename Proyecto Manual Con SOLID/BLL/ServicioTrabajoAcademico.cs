using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;  
namespace BLL
{
    public class ServicioTrabajoAcademico
    {
        RepositorioTrabajoAcademico repositorioTrabajoAcademico = new RepositorioTrabajoAcademico();
        List<TrabajoAcademico> trabajos;
        public ServicioTrabajoAcademico()
        {
            trabajos = new List<TrabajoAcademico>();
            trabajos = repositorioTrabajoAcademico.Consultar();
        }

        public void AgregarTrabajosAcademicos(TrabajoAcademico trabajoAcademico)
        {
            if (repositorioTrabajoAcademico.Guardar(trabajoAcademico))
            {
                trabajos.Add(trabajoAcademico);
            }
        }
        public List<TrabajoAcademico> Consultar()
        {
            return repositorioTrabajoAcademico.Consultar();
        }
    }
}
