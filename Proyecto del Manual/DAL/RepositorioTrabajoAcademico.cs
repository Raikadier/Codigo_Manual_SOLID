using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioTrabajoAcademico : IRepositorio
    {
        private readonly string file = "TrabajosAcademicos.txt";
        public List<TrabajoAcademico> ConsultarTrabajos()
        {
            try
            {
                if (!File.Exists(file))
                {
                    return new List<TrabajoAcademico>();
                }
                List<TrabajoAcademico> trabajoAcademicos = new List<TrabajoAcademico>();
                StreamReader lector = new StreamReader(file);

                while (!lector.EndOfStream)
                {
                    trabajoAcademicos.Add(MappingType(lector.ReadLine()));
                }
                lector.Close();
                return trabajoAcademicos;
            }
            catch (Exception ex)
            {
                return new List<TrabajoAcademico>();
            }
        }
        public bool Guardar(TrabajoAcademico trabajo)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(file, true);

                escritor.WriteLine($"{trabajo.Id};{trabajo.Titulo};{trabajo.Autor};{trabajo.Tipo}");

                escritor.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private TrabajoAcademico MappingType(string linea)
        {
            string[] partes = linea.Split(';');
            string tipo = partes[3];
            TrabajoAcademico trabajo;
            if (tipo == "Proyecto")
                trabajo = new Proyecto();
            else if (tipo == "Pasantia")
                trabajo = new Pasantia();
            else
                trabajo = new Proyecto();
            trabajo.Id = int.Parse(partes[0]);
            trabajo.Titulo = partes[1];
            trabajo.Autor = partes[2];
            return trabajo;
        }
        //Estos métodos no se pueden implementar en la clase RepositorioTrabajoAcademico
        public List<Notificacion> ConsultarNotifaciones()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ConsultarUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Notificacion notificacion)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool GuardarConLista(List<Usuario> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
