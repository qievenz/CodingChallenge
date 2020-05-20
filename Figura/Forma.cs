//using NCalc2;
using Jace;
using Jace.Execution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Figura
{
    public class Forma
    {
        public int Tipo { get; set; }

        public List<decimal> Lados { get; set; }

        public string Nombre { get; }

        public decimal Area { get;}
        public decimal Perimetro { get; }

        //TODO:Validar cantidad de variables en la formula contra la cantidad de lados ingresados
        public Forma(int tipo, decimal lado)
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                if (currentProperty.DefaultValue.ToString() == tipo.ToString())
                {
                    Lados = new List<decimal>();
                    this.Tipo = tipo;
                    this.Nombre = currentProperty.Name;
                    this.Lados.Add(lado);
                    this.Perimetro = Calcular("Perimetros");
                    this.Area = Calcular("Areas");
                    return;
                }
            }
        }
        public Forma(int tipo, List<decimal> lados)
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                if (currentProperty.DefaultValue.ToString() == tipo.ToString())
                {
                    Lados = new List<decimal>();
                    this.Tipo = tipo;
                    this.Nombre = currentProperty.Name;
                    foreach (var lado in lados) {this.Lados.Add(lado);}
                    this.Perimetro = Calcular("Perimetros");
                    this.Area = Calcular("Areas");
                    return;
                }
            }

        }
        private decimal Calcular(string concepto)
        {
            decimal resultado = 0m;
            //Obtener formula
            var resMana = new ResourceManager("Figura.Resources." + concepto,
                       typeof(Forma).Assembly);
            string formula = resMana.GetString(this.Nombre);
            //Setear Jace y castear a double.. no encontre uno que trabaje directamente con decimal
            CalculationEngine engine = new CalculationEngine();
            Dictionary<string, double> variables = new Dictionary<string, double>();
            //Setar variables
            if (Lados.Count == 1)
            {
                variables.Add("X", (double)Lados.First());
            }
            else
            {
                try
                {
                    variables.Add("A", (double)Lados[0]);
                    variables.Add("B", (double)Lados[1]);
                    variables.Add("C", (double)Lados[2]);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //var a= formula.ParsedExpression;
            //Devolver resultado
            try
            {
                resultado = Convert.ToDecimal(engine.Calculate(formula, variables));

            }
            catch (InvalidOperationException e)
            {

                throw new InvalidOperationException(this.Nombre + "-" + concepto + ":\n" + e);
            }
            
            return resultado;
        }
    }
}
