using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepositorioUsuario
    {
        bool Guardar(Usuario usuario);
        List<Usuario> Consultar();
        bool GuardarConLista(List<Usuario> usuarios);
    }
}
