using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioNotificacion
    {
        RepositorioNotificacion repositorioNotificacion = new RepositorioNotificacion();
        List<Notificacion> notificaciones;
        public ServicioNotificacion()
        {
            notificaciones = new List<Notificacion>();
            notificaciones = repositorioNotificacion.Consultar();
        }

        public void AgregarNotificacion(Notificacion notificacion)
        {
            if (repositorioNotificacion.Guardar(notificacion))
            {
                notificaciones.Add(notificacion);
            }
        }
        public List<Notificacion> Consultar()
        {
            return repositorioNotificacion.Consultar();
        }
    }
}
