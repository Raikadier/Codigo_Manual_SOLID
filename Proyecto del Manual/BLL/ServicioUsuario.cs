using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioUsuario
    {
        RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
        ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
        List<Usuario> usuarios;
        public ServicioUsuario()
        {
            usuarios = new List<Usuario>();
            usuarios = repositorioUsuario.ConsultarUsuarios();
        }

        public string AgregarUsuario(Usuario usuario, Notificacion notificacion)
        {
            if (repositorioUsuario.Guardar(usuario))
            {
                usuarios.Add(usuario);
                
                servicioNotificacion.AgregarNotificacion(notificacion);
                return $"El estudiante {usuario.Nombre} registrado exitosamente";
            }
            else
            {
                return "Error en el guardado";
            }

        }
        public Usuario ExisteUsuario(int id)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            return null;
        }
        public List<Usuario> Consultar()
        {
            return repositorioUsuario.ConsultarUsuarios();
        }
        public string ActualizarUsuario(Usuario usuario,Notificacion notificacion)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Id == usuario.Id)
                {
                    Usuario usuarionew = null;
                    switch (usuario.Rol)
                    {
                        case "Estudiante":
                            usuarionew = new Estudiante { Id = usuario.Id, Nombre = usuario.Nombre, Correo = usuario.Correo };
                            break;
                        case "Docente":
                            usuarionew = new Docente { Id = usuario.Id, Nombre = usuario.Nombre, Correo = usuario.Correo };
                            break;
                        case "Jurado":
                            usuarionew = new Jurado { Id = usuario.Id, Nombre = usuario.Nombre, Correo = usuario.Correo };
                            break;
                    }

                    if (usuarionew != null)
                    {
                        usuarios[i] = usuarionew;
                    }
                    break;
                }
            }
            repositorioUsuario.GuardarConLista(usuarios);
            
            servicioNotificacion.AgregarNotificacion(notificacion);
            return "Proceso realizado";
        }
    }
}
