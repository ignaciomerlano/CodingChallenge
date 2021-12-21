using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallenge.Data.Repositorio
{
    public class RepositorioTraducciones : IRepositorioTraducciones
    {
        private readonly XElement archivo;
        private static RepositorioTraducciones instance;

        private RepositorioTraducciones()
        {
            string path = string.Empty;
            try
            {
                path = Path.Combine(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.FullName, @"Datos\Traducciones.xml");
                this.archivo = XElement.Load($"{path}");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * Hice un metodo para obtener la instancia si ya existe o crearla si no.   
         */
        public static RepositorioTraducciones GetInstance()
        {
            if (instance == null)
            {
                instance = new RepositorioTraducciones();
            }
            return instance;
        }

        public Traduccion ObtenerTraduccion(string key, string idioma, bool plural)
        {
            Traduccion traduccion = new Traduccion();

            try
            {
                traduccion = (from t in archivo.Descendants("Traduccion")
                              where (string)t.Element("Key") == key
                              select new Traduccion
                              {
                                  Lenguaje = idioma,
                                  Key = key,
                                  Plural = plural,
                                  Texto = (string)t.Element(idioma).Attribute("plural")
                              }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return traduccion;
        }

        public List<Traduccion> ObtenerTraducciones(string idioma)
        {
            List<Traduccion> traducciones = new List<Traduccion>();

            try
            {
                traducciones = (from t in archivo.Descendants("Traduccion").Descendants(idioma)
                                where (bool)t.Attribute("plural")
                                select new Traduccion
                                {
                                    Lenguaje = idioma,
                                    Key = (string)t.Parent.Element("Key"),
                                    Plural = (bool)t.Attribute("plural"),
                                    Texto = (string)t.Value
                                }).Union(from t in archivo.Descendants("Traduccion").Descendants(idioma)
                                         where !(bool)t.Attribute("plural")
                                         select new Traduccion
                                         {
                                             Lenguaje = idioma,
                                             Key = (string)t.Parent.Element("Key"),
                                             Plural = (bool)t.Attribute("plural"),
                                             Texto = (string)t.Value
                                         }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

            return traducciones;
        }
    }
}
