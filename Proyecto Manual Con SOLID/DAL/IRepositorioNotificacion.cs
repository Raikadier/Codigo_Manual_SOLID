using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DAL
{
    public interface IRepositorioNotificacion
    {
        bool Guardar(Notificacion notificacion);
        List<Notificacion> Consultar();
    }
}
