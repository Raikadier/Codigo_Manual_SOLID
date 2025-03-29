using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioNotificacion : IRepositorioNotificacion
    {
        private readonly string file = "Notificaciones.txt";
        
        public bool Guardar(Notificacion notificacion)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(file, true);

                escritor.WriteLine($"{notificacion.IdNotificacion};{notificacion.FechaEnvio};{notificacion.Mensaje}");
                escritor.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Notificacion> Consultar()
        {
            try
            {
                if (!File.Exists(file))
                {
                    return new List<Notificacion>();
                }
                List<Notificacion> notificaciones = new List<Notificacion>();
                StreamReader lector = new StreamReader(file);

                while (!lector.EndOfStream)
                {
                    notificaciones.Add(MapearNotificacion(lector.ReadLine()));
                }
                lector.Close();
                return notificaciones;
            }
            catch (Exception ex)
            {
                return new List<Notificacion>();
            }
        }

        private Notificacion MapearNotificacion(string linea)
        {
            string[] partes = linea.Split(';');
            Notificacion notificacion = new Notificacion();
            notificacion.IdNotificacion = int.Parse(partes[0]);
            notificacion.FechaEnvio = DateTime.Parse(partes[1]);
            notificacion.Mensaje = partes[2];
            return notificacion;
        }
    }
}
