using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Repositorio
{
    public interface IRepositorioTraducciones
    {
        Traduccion ObtenerTraduccion(string key, string idioma, bool plural);
        List<Traduccion> ObtenerTraducciones(string idioma);
    }
}
