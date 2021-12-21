using CodingChallenge.Data.Interfaces;
using CodingChallenge.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        private IRepositorioTraducciones _repoTraducciones;

        public FormaGeometrica(IRepositorioTraducciones repoTraducciones)
        {
            _repoTraducciones = repoTraducciones;
        }

        #region Clases Auxiliares
        private class Grupo
        {
            public int Cantidad;
            public decimal Area;
            public decimal Perimetro;
            public string Tipoforma;
        }
        #endregion

        public string Imprimir(List<IFormaGeometrica> formas, string idioma)
        {
            var sb = new StringBuilder();

            var traducciones = _repoTraducciones.ObtenerTraducciones(idioma);

            if (!formas.Any())
            {
                sb.Append($"<h1>{traducciones.Where(x => x.Key == "ListaVacia").FirstOrDefault().Texto}</h1>");
            }
            else
            {
                sb.Append($"<h1>{traducciones.Where(x => x.Key == "Encabezado").FirstOrDefault().Texto}</h1>");

                //al ver en los Tests que las formas debian aparecer en el reporte de acuerdo al orden de la lista, implemente un diccionario para agruparlas en orden.
                var formasAgrupadas = new Dictionary<int, Grupo>();

                //inserto las formas en el diccionario
                foreach (var forma in formas)
                {
                    if (formasAgrupadas.ContainsKey(forma.tipo.Id))
                    {
                        formasAgrupadas[forma.tipo.Id].Cantidad += 1;
                        formasAgrupadas[forma.tipo.Id].Area += forma.Area();
                        formasAgrupadas[forma.tipo.Id].Perimetro += forma.Perimetro();
                    }
                    else
                    {
                        var grupo = new Grupo()
                        {
                            Cantidad = 1,
                            Area = forma.Area(),
                            Perimetro = forma.Perimetro(),
                            Tipoforma = forma.tipo.Descripcion
                        };
                        formasAgrupadas.Add(forma.tipo.Id, grupo);
                    }
                }

                //recorro el diccionario y voy agregando las lineas en el SB
                string linea = @"{0} {1} | " + traducciones.Where(x => x.Key == "Area").FirstOrDefault().Texto + " {2} | " + traducciones.Where(x => x.Key == "Perimetro").FirstOrDefault().Texto + " {3} <br/>";
                foreach (var grupo in formasAgrupadas)
                {
                    sb.AppendFormat(linea, grupo.Value.Cantidad, traducciones.Where(x => x.Key == grupo.Value.Tipoforma && x.Plural == (grupo.Value.Cantidad > 1)).FirstOrDefault().Texto, grupo.Value.Area.ToString("#.##"), grupo.Value.Perimetro.ToString("#.##"));
                }

                // FOOTER
                sb.Append($"{traducciones.Where(x => x.Key == "Total").FirstOrDefault().Texto.ToUpper()}:<br/>");
                sb.Append($"{formas.Count()} {traducciones.Where(x => x.Key == "Forma" && x.Plural == (formas.Count() > 1)).FirstOrDefault().Texto.ToLower()} ");
                sb.Append($"{traducciones.Where(x => x.Key == "Perimetro").FirstOrDefault().Texto} {formas.Sum(x => x.Perimetro()).ToString("#.##")} ");
                sb.Append($"{traducciones.Where(x => x.Key == "Area").FirstOrDefault().Texto} {formas.Sum(x => x.Area()).ToString("#.##")}");
            }

            return sb.ToString();
        }
    }
}
