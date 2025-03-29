using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class MenuTrabajo
    {
        ServicioTrabajoAcademico servicioTrabajoAcademico = new ServicioTrabajoAcademico();
        ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
        public void RegistrarTrabajoAcademico()
        {
            Console.Write("Ingrese el título del trabajo: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese el autor: ");
            string autor = Console.ReadLine();

            Console.WriteLine("Seleccione el tipo de trabajo:");
            Console.WriteLine("1. Proyecto");
            Console.WriteLine("2. Pasantia");
            int tipo = int.Parse(Console.ReadLine());
            TrabajoAcademico trabajo = null;
            switch (tipo)
            {
                case 1:
                    trabajo = new Proyecto { Id=servicioTrabajoAcademico.Consultar().Count()+1,Titulo = titulo, Autor = autor };
                    break;
                case 2:
                    trabajo = new Pasantia { Id = servicioTrabajoAcademico.Consultar().Count() + 1, Titulo = titulo, Autor = autor };
                    break;
                default:
                    trabajo = null;
                    break;
            }
            if (trabajo != null)
            {
                Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1, FechaEnvio=DateTime.Now, Mensaje = $"Nuevo {trabajo.Tipo} registrado: {trabajo.Titulo}" };
                servicioTrabajoAcademico.AgregarTrabajosAcademicos(trabajo);
                servicioNotificacion.AgregarNotificacion(notificacion);
                Console.WriteLine("Trabajo registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Tipo de trabajo inválido.");
            }
            Seguir();
        }
        public void ConsultarTrabajosAcademicos()
        {
            List<TrabajoAcademico> trabajos = servicioTrabajoAcademico.Consultar();
            if (trabajos.Any())
            {
                foreach (var t in trabajos)
                {
                    Console.WriteLine($"{t.Id} - {t.Titulo} ({t.Autor}) - {t.Tipo}");
                }
            }
            else
            {
                Console.WriteLine("No hay trabajos registrados.");
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
