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
using System.Text;
using Idioma;
using Figura.Controllers;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica 
    {
        private readonly Dictionary<string, decimal> _lado;
        private static IdiomaManager _idiomaManager;

        public int Tipo { get; set; }
        public FormaGeometrica(int tipo, decimal ancho)
        {
            _lado = new Dictionary<string, decimal>();
            Tipo = tipo;
            _lado.Add("A", ancho);
        }
        public FormaGeometrica(int tipo, Dictionary<string, decimal> ancho)
        {
            _lado = new Dictionary<string, decimal>();
            Tipo = tipo;
            _lado = ancho;
        }
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

                var listaFormas = new List<FiguraController>();
                for (var i = 0; i < formas.Count; i++)
                {
                    var forma = new FiguraController(formas[i].Tipo, formas[i]._lado);
                    if (forma.Nombre == null)
                    {
                        throw new Exception(_idiomaManager.GetString("FormaDesconocida"));
                    }
                    listaFormas.Add(forma);
                }

                sb.Append(ObtenerLineas(listaFormas));

                // FOOTER
                sb.Append(_idiomaManager.GetString("Total") + ":<br/>");
                sb.Append(listaFormas.Count().ToString() + " " + _idiomaManager.GetString("Forma").ToLower() + "s");
                //Recorrer formulas para la sumatoria del total de las formas
                foreach (var formula in listaFormas.FirstOrDefault().Resultados.Keys)
                {
                    var total = listaFormas.Where(w => w.Resultados[formula.ToString()] > 0).Sum(s => Convert.ToDecimal(s.Resultados[formula.ToString()]));
                    if (total > 0)
                    {
                        sb.Append(" ");
                        var valorResultado = $"{Math.Round(total, 2):#.##}";
                        sb.Append(_idiomaManager.GetString(formula.ToString()) + " " + valorResultado);
                    }
                }
            }
            return sb.ToString();
        }
        private static StringBuilder ObtenerLineas(List<FiguraController> listaFormas)
        {
            StringBuilder resultado = new StringBuilder(); ;
            if (listaFormas.Count > 0)
            {
                //Recorrer tipos de formas
                foreach (var line in listaFormas.GroupBy(l => l.Tipo)
                        .Select(group => new {
                            Tipo = group.Key,
                            Count = group.Count(),
                            Nombre = group.First().Nombre,
                            Resultados = group.Select(a=> a.Resultados)
                        }))
                {
                    resultado.Append($"{line.Count} {(line.Count == 1 ? _idiomaManager.GetString(line.Nombre) : (_idiomaManager.GetString(line.Nombre) + "s"))}");
                    //Recorrer formulas para la sumatoria por tipo de forma
                    foreach (var formula in line.Resultados.FirstOrDefault().Keys)
                    {
                        var total = line.Resultados.Where(w => Convert.ToDecimal(w[formula.ToString()]) > 0).Sum(s => Convert.ToDecimal(s[formula.ToString()]));
                        if (total > 0)
                        {
                            resultado.Append(" | ");
                            var valorResultado = $"{Math.Round(total, 2):#.##}";
                            resultado.Append($"{_idiomaManager.GetString(formula.ToString())} {valorResultado}");
                        }
                    }
                    resultado.Append(" <br/>");
                }
            }
            return resultado;
        }
    }
}
