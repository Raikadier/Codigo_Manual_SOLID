using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepositorio
    {
        bool Guardar(Notificacion notificacion);
        List<Notificacion> ConsultarNotifaciones();
        bool Guardar(TrabajoAcademico trabajo);
        List<TrabajoAcademico> ConsultarTrabajos();
        bool Guardar(Usuario usuario);
        List<Usuario> ConsultarUsuarios();
        bool GuardarConLista(List<Usuario> usuarios);
    }
}
