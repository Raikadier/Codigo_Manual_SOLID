using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioTrabajoAcademico
    {
        RepositorioTrabajoAcademico repositorioTrabajoAcademico = new RepositorioTrabajoAcademico();
        ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
        List<TrabajoAcademico> trabajos;
        public ServicioTrabajoAcademico()
        {
            trabajos = new List<TrabajoAcademico>();
            trabajos = repositorioTrabajoAcademico.ConsultarTrabajos();
        }

        public void AgregarTrabajosAcademicos(TrabajoAcademico trabajo, Notificacion notificacion)
        {
            if (repositorioTrabajoAcademico.Guardar(trabajo))
            {
                
                servicioNotificacion.AgregarNotificacion(notificacion);
                trabajos.Add(trabajo);
            }
        }
        public List<TrabajoAcademico> Consultar()
        {
            return repositorioTrabajoAcademico.ConsultarTrabajos();
        }
    }
}
