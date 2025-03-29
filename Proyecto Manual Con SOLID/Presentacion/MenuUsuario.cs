using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;
namespace Presentacion
{
    
    class MenuUsuario
    {
        ServicioUsuario servicioUsuario = new ServicioUsuario();
        ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
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
            Usuario usuario=null;
            switch (tipo)
            {
                case 1:
                    usuario = new Estudiante { Id= servicioUsuario.Consultar().Count()+1,Nombre = nombre, Correo = correo };
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
                servicioUsuario.AgregarUsuario(usuario);
                Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1,FechaEnvio=DateTime.Now,
                    Mensaje = $"Nuevo usuario registrado: {usuario.Nombre} con rol {usuario.Rol}" };
                servicioNotificacion.AgregarNotificacion(notificacion);
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
                usuario= DefinirUsuario(servicioUsuario.ExisteUsuario(ced));
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
                    Console.SetCursorPosition(8, 22); Console.WriteLine(servicioUsuario.ActualizarUsuario(usuario));
                    Notificacion notificacion = new Notificacion { IdNotificacion = servicioNotificacion.Consultar().Count() + 1, FechaEnvio=DateTime.Now, Mensaje = $"Un usuario fue modificado: {servicioUsuario.ExisteUsuario(ced).Nombre} ({servicioUsuario.ExisteUsuario(ced).Correo} a {usuario.Nombre} ({usuario.Correo}))" };
                    servicioNotificacion.AgregarNotificacion(notificacion);
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
    }
}
