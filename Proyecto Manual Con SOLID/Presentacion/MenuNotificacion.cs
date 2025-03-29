using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class MenuNotificacion
    {
        ServicioNotificacion servicioNotificacion= new ServicioNotificacion();
        public void ConsultarNotificaciones()
        {
            var notificaciones = servicioNotificacion.Consultar();
            if (notificaciones.Any())
            {
                foreach (var n in notificaciones)
                {
                    Console.WriteLine($"{n.IdNotificacion} - {n.FechaEnvio} - {n.Mensaje}");
                }
            }
            else
            {
                Console.WriteLine("No hay notificaciones.");
            }
            Seguir();
        }
        public void Seguir()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
