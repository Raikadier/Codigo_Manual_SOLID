using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioUsuario : IRepositorio
    {
        private readonly string file = "Usuarios.txt";
        public List<Usuario> ConsultarUsuarios()
        {
            try
            {
                if (!File.Exists(file))
                {
                    return new List<Usuario>();
                }
                List<Usuario> usuarios = new List<Usuario>();
                StreamReader lector = new StreamReader(file);

                while (!lector.EndOfStream)
                {
                    usuarios.Add(MappingType(lector.ReadLine()));
                }
                lector.Close();
                return usuarios;
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }
        public bool Guardar(Usuario usuario)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(file, true);

                escritor.WriteLine($"{usuario.Id};{usuario.Nombre};{usuario.Correo};{usuario.Rol}");

                escritor.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool GuardarConLista(List<Usuario> usuarios)
        {
            try
            {

                StreamWriter escritor = new StreamWriter(file, false);
                foreach (var usuario in usuarios)
                {
                    escritor.WriteLine($"{usuario.Id};{usuario.Nombre};{usuario.Correo};{usuario.Rol}");
                }


                escritor.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private Usuario MappingType(string linea)
        {
            string[] partes = linea.Split(';');
            string rol = partes[3];
            Usuario usuario;
            if (rol == "Estudiante")
                usuario = new Estudiante();
            else if (rol == "Docente")
                usuario = new Docente();
            else if (rol == "Jurado")
                usuario = new Jurado();
            else
                usuario = new Estudiante();
            usuario.Id = int.Parse(partes[0]);
            usuario.Nombre = partes[1];
            usuario.Correo = partes[2];
            return usuario;
        }
        //Estos métodos no se pueden implementar en la clase RepositorioUsuario
        public List<Notificacion> ConsultarNotifaciones()
        {
            throw new NotImplementedException();
        }

        public List<TrabajoAcademico> ConsultarTrabajos()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Notificacion notificacion)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(TrabajoAcademico trabajo)
        {
            throw new NotImplementedException();
        }


    }
}
