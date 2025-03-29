using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioTrabajoAcademico : IRepositorioTrabajoAcademico
    {
        private readonly string file = "TrabajosAcademicos.txt";

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
        public List<TrabajoAcademico> Consultar()
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
    }
}
