using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class MenuPrincipal
    {
        ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
        ServicioTrabajoAcademico servicioTrabajoAcademico = new ServicioTrabajoAcademico();
        ServicioUsuario servicioUsuario = new ServicioUsuario();
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
                        RegistrarUsuario();
                        break;
                    case 2:
                        Console.Clear();
                        ImprimirListadoUsuario();
                        break;
                    case 3:
                        Console.Clear();
                        ActualizarEstudiante();
                        break;
                    case 4:
                        Console.Clear();
                        RegistrarTrabajoAcademico();
                        break;
                    case 5:
                        Console.Clear();
                        ConsultarTrabajosAcademicos();
                        break;
                    case 6:
                        Console.Clear();
                        ConsultarNotificaciones();
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
        public void RegistrarUsuario()
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el correo: ");
            string correo = Console.ReadLine();

            Console.WriteLine("Seleccione el tipo de usuario:");
            Console.WriteLine("1. Estudiante");
            Console.WriteLine("2. Docente");
            Console.WriteLine("3. Jurado");
            int tipo = int.Parse(Console.ReadLine());
            Usuario usuario = null;
            switch (tipo)
            {
                case 1:
                    usuario = new Estudiante { Id = servicioUsuario.Consultar().Count() + 1, Nombre = nombre, Correo = correo };
                    break;
                case 2:
                    usuario = new Docente { Id = servicioUsuario.Consultar().Count() + 1, Nombre = nombre, Correo = correo };
                    break;
                case 3:
                    Jurado jurado = new Jurado { Nombre = nombre, Correo = correo };
                    break;
                default:
                    usuario = null;
                    break;
            }


            if (usuario != null)
            {
                Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1, FechaEnvio = DateTime.Now, Mensaje = $"Nuevo usuario registrado: {usuario.Nombre} con rol {usuario.Rol}" };
                servicioUsuario.AgregarUsuario(usuario, notificacion);
                Console.WriteLine("Usuario registrado correctamente.");
                Seguir();
            }
            else
            {
                Console.WriteLine("Tipo de usuario inválido.");
                Seguir();
            }
        }
        public void ImprimirListadoUsuario()
        {
            List<Usuario> usuarios = servicioUsuario.Consultar();
            if (usuarios.Any())
            {
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"{u.Id} - {u.Nombre} ({u.Correo}) - {u.Rol}");
                }
                Seguir();
            }
            else
            {
                Console.WriteLine("No hay usuarios registrados.");
                Seguir();
            }
        }
        public void ActualizarEstudiante()
        {
            int ced;
            Console.Clear();
            Console.SetCursorPosition(14, 4); Console.WriteLine("ACTUALIZAR LOS DATOS DE UN USUARIO");
            Console.SetCursorPosition(4, 6); Console.Write("Digite la cedula del usuario a actualizar datos: ");
            Console.SetCursorPosition(60, 6); ced = int.Parse(Console.ReadLine());
            if (servicioUsuario.ExisteUsuario(ced) != null)
            {
                Usuario usuario = null;
                usuario = DefinirUsuario(servicioUsuario.ExisteUsuario(ced));
                Console.SetCursorPosition(10, 9); Console.WriteLine("Usuario encontrado...");
                Console.SetCursorPosition(8, 11); Console.WriteLine($"ID: {servicioUsuario.ExisteUsuario(ced).Id}");
                Console.SetCursorPosition(8, 12); Console.WriteLine($"NOMBRE: {servicioUsuario.ExisteUsuario(ced).Nombre}");
                Console.SetCursorPosition(8, 13); Console.WriteLine($"CORREO: {servicioUsuario.ExisteUsuario(ced).Correo}");
                Console.SetCursorPosition(8, 14); Console.WriteLine($"ROL: {servicioUsuario.ExisteUsuario(ced).Rol}");
                Console.SetCursorPosition(12, 17); Console.WriteLine("Diligencie los nuevos datos del estudiante");
                usuario.Id = ced;
                Console.SetCursorPosition(8, 18); Console.Write("Nombre: ");
                Console.SetCursorPosition(8, 19); Console.Write("Correo: ");
                Console.SetCursorPosition(19, 18); usuario.Nombre = Console.ReadLine();
                Console.SetCursorPosition(19, 19); usuario.Correo = Console.ReadLine();
                Console.Clear();
                Console.SetCursorPosition(14, 4); Console.WriteLine("ACTUALIZAR LOS DATOS DE UN USUARIO");
                Console.SetCursorPosition(18, 6); Console.WriteLine("DATOS ANTIGUOS"); Console.SetCursorPosition(40, 6); Console.WriteLine("DATOS NUEVOS");
                Console.SetCursorPosition(6, 10); Console.WriteLine($"ID:");
                Console.SetCursorPosition(6, 11); Console.WriteLine($"NOMBRE:");
                Console.SetCursorPosition(6, 12); Console.WriteLine($"CORREO:");
                Console.SetCursorPosition(6, 13); Console.WriteLine($"ROL:");
                Console.SetCursorPosition(18, 10); Console.WriteLine(servicioUsuario.ExisteUsuario(ced).Id);
                Console.SetCursorPosition(18, 11); Console.WriteLine(servicioUsuario.ExisteUsuario(ced).Nombre);
                Console.SetCursorPosition(18, 12); Console.WriteLine(servicioUsuario.ExisteUsuario(ced).Correo);
                Console.SetCursorPosition(18, 13); Console.WriteLine(servicioUsuario.ExisteUsuario(ced).Rol);
                Console.SetCursorPosition(40, 10); Console.WriteLine(usuario.Id);
                Console.SetCursorPosition(40, 11); Console.WriteLine(usuario.Nombre);
                Console.SetCursorPosition(40, 12); Console.WriteLine(usuario.Correo);
                Console.SetCursorPosition(40, 13); Console.WriteLine(usuario.Rol);
                Console.SetCursorPosition(8, 15); Console.WriteLine("Esta seguro de actualizar?: (Presiones s para seguir y cualquier tecla si no)");
                ConsoleKeyInfo o = Console.ReadKey(false);
                char conf2 = o.KeyChar;
                if (conf2 == 's' || conf2 == 'S')
                {
                    Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1, FechaEnvio = DateTime.Now, Mensaje = $"Un usuario fue modificado: {servicioUsuario.ExisteUsuario(ced).Nombre} ({servicioUsuario.ExisteUsuario(ced).Correo}) a {usuario.Nombre} ({usuario.Correo})" };
                    Console.SetCursorPosition(8, 22); Console.WriteLine(servicioUsuario.ActualizarUsuario(usuario,notificacion));
                }
            }
            else
            {
                Console.SetCursorPosition(8, 9); Console.Write("El estudiante no fue encontrado...");
            }
            Seguir();
        }
        public Usuario DefinirUsuario(Usuario usuario)
        {
            if (usuario.Rol == "Estudiante")
            {
                return new Estudiante();
            }
            else if (usuario.Rol == "Docente")
            {
                return new Docente();
            }
            else if (usuario.Rol == "Jurado")
            {
                return new Jurado();
            }
            else
            {
                return null;
            }
        }
        public void Seguir()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
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
                    trabajo = new Proyecto { Id = servicioTrabajoAcademico.Consultar().Count() + 1, Titulo = titulo, Autor = autor };
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
                Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1, FechaEnvio = DateTime.Now, Mensaje = $"Nuevo {trabajo.Tipo} registrado: {trabajo.Titulo}" };
                servicioTrabajoAcademico.AgregarTrabajosAcademicos(trabajo, notificacion);
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
    }
}
