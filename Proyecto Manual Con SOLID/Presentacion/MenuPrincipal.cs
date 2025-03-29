using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class MenuPrincipal
    {
        MenuNotificacion notificacionGUI = new MenuNotificacion();
        MenuTrabajo trabajoGUI = new MenuTrabajo();
        MenuUsuario usuarioGUI = new MenuUsuario();
        public void Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("1. Agregar Usuario");
                Console.WriteLine("2. Consultar  Usuario");
                Console.WriteLine("3. Modificar Usuario");
                Console.WriteLine("4. Agregar Trabajo");
                Console.WriteLine("5. Consultar Trabajos");
                Console.WriteLine("6. Consultar Notificaciones");
                Console.WriteLine("7. Salir");
                Console.Write("Escoja una opcion: ");
                 op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        usuarioGUI.RegistrarUsuario();
                        break;
                    case 2:
                        Console.Clear();
                        usuarioGUI.ImprimirListadoUsuario();
                        break;
                    case 3:
                        Console.Clear();
                        usuarioGUI.ActualizarEstudiante();
                        break;
                    case 4:
                        Console.Clear();
                        trabajoGUI.RegistrarTrabajoAcademico();
                        break;
                    case 5:
                        Console.Clear();
                        trabajoGUI.ConsultarTrabajosAcademicos();
                        break;
                    case 6:
                        Console.Clear();
                        notificacionGUI.ConsultarNotificaciones();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Gracias por usar productos harold y david");
                        Console.ReadKey();
                        break;
                }
            }
            while (op != 7);
        }
    }
}
