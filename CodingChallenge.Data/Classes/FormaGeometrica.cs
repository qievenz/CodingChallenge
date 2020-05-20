/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using Idioma;
using Figura;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        private readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }
        private static IdiomaManager _idiomaManager;
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            _idiomaManager = new IdiomaManager(idioma);

            if (!formas.Any())
            {
                sb.Append("<h1>" + _idiomaManager.GetString("ListaVacia") + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>" + _idiomaManager.GetString("ReporteFormas") + "</h1>");

                var listaFormas = new List<Forma>();
                for (var i = 0; i < formas.Count; i++)
                {
                    var forma = new Forma(formas[i].Tipo, formas[i]._lado);
                    if (forma.Nombre == null)
                    {
                        throw new Exception(_idiomaManager.GetString("FormaDesconocida"));
                    }
                    listaFormas.Add(forma);
                }

                sb.Append(ObtenerLineas(listaFormas));

                // FOOTER
                sb.Append(_idiomaManager.GetString("Total") + ":<br/>");
                sb.Append(listaFormas.Count().ToString() + " " + _idiomaManager.GetString("Forma").ToLower() + "s ");
                sb.Append(_idiomaManager.GetString("Perimetro") + " " + listaFormas.Sum(item => item.Perimetro).ToString("#.##") + " ");
                sb.Append(_idiomaManager.GetString("Area") + " " + listaFormas.Sum(item => item.Area).ToString("#.##"));

            }

            return sb.ToString();
        }
        private static string ObtenerLineas(List<Forma> listaFormas)
        {
            string resultado = string.Empty;
            if (listaFormas.Count > 0)
            {
                foreach (var line in listaFormas.GroupBy(l => l.Tipo)
                        .Select(group => new {
                            Tipo = group.Key,
                            Count = group.Count(),
                            Nombre = group.First().Nombre,
                            TotalArea = group.Sum(a => a.Area),
                            TotalPerimetro = group.Sum(p => p.Perimetro)
                        }))
                {
                    resultado += $"{line.Count} {(line.Count == 1 ? _idiomaManager.GetString(line.Nombre) : (_idiomaManager.GetString(line.Nombre) + "s"))} | {_idiomaManager.GetString("Area")} {Math.Round(line.TotalArea,2):#.##} | {_idiomaManager.GetString("Perimetro")} {Math.Round(line.TotalPerimetro,2):#.##} <br/>";
                }
            }
            return resultado;
        }
    }
}
