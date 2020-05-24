using Figura.Models;
using Jace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Figura.Controllers
{
    public class FiguraController
    {
        public int Tipo { get; }

        public Dictionary<string, decimal> Lados { get; }

        public string Nombre { get; }

        public Dictionary<string, decimal> Resultados { get; set; }

        public FiguraController(int tipo, decimal lado)
        {
            if (tipo < 0) throw new InvalidOperationException($"Tipo de figura invalida: {tipo}");

            List<Tuple<string, object>> columnaValor = ObtenerColumnaRegistroFigura(tipo);

            this.Lados = new Dictionary<string, decimal>();
            this.Resultados = new Dictionary<string, decimal>();
            this.Lados.Add("A", lado);
            this.Tipo = (int)columnaValor[0].Item2;
            this.Nombre = columnaValor[1].Item2.ToString();

            ObtenerResultados(columnaValor);
        }
        public FiguraController(int tipo, Dictionary<string,decimal> lados)
        {
            if (tipo < 0) throw new InvalidOperationException($"Tipo de figura invalida: {tipo}");

            List<Tuple<string, object>> columnaValor = ObtenerColumnaRegistroFigura(tipo);

            this.Lados = new Dictionary<string, decimal>();
            this.Resultados = new Dictionary<string, decimal>();
            this.Lados = lados;
            this.Tipo = (int)columnaValor[0].Item2;
            this.Nombre = columnaValor[1].Item2.ToString();

            ObtenerResultados(columnaValor);
        }
        private List<Tuple<string, object>> ObtenerColumnaRegistroFigura(int tipoFigura)
        {
            List<Tuple<string, object>> resultado;

            using (var context = new FormaGeometricaDBContext())
            {
                var figura = context.Figura.Where(f => f.ID == tipoFigura).FirstOrDefault();

                if (figura == null)
                {
                    throw new InvalidOperationException($"Tipo de figura no encontrada: {tipoFigura}");
                }
                else
                {
                    var entry = context.Entry(figura);
                    var currentPropertyValues = entry.CurrentValues;

                    resultado = currentPropertyValues.PropertyNames
                        .Select(name => Tuple.Create(name, currentPropertyValues[name]))
                        .ToList();
                }
            }
            return resultado;
        }
        private void ObtenerResultados(List<Tuple<string, object>> columnaValor)
        {
            foreach (var item in columnaValor.Skip(2))
            {
                //Si la funcion no esta parametrizada se informa -1 a modo de error
                if (item.Item2 == null || string.IsNullOrEmpty(item.Item2.ToString()))
                {
                    this.Resultados.Add(item.Item1.ToString(), -1);
                }
                else
                {
                    this.Resultados.Add(item.Item1.ToString(), Calcular(item.Item2.ToString()));
                }
            }
        }
        private decimal Calcular(string formula)
        {
            decimal resultado = 0m;
            //Setear Jace y castear a double.. no encontre uno que trabaje directamente con decimal
            CalculationEngine engine = new CalculationEngine();
            Dictionary<string, double> variables = new Dictionary<string, double>();
            //Setar variables
            variables = this.Lados.ToDictionary(pair => pair.Key,
                                                pair => (Double)pair.Value);
            //Devolver resultado
            try
            {
                resultado = Convert.ToDecimal(engine.Calculate(formula, variables));
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException($"Error al calcular el {formula} del {this.Nombre}:\n{e}");
            }
            return resultado;
        }
    }
}
