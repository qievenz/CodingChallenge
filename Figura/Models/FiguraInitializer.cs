namespace Figura.Models
{
    using System.Collections.Generic;
    using System.Data.Entity;
    public class FigurasInitializer : DropCreateDatabaseIfModelChanges<FormaGeometricaDBContext>
    {
        protected override void Seed(FormaGeometricaDBContext context)
        {
            var figuras = new List<Figura>
            {
                new Figura{ID = 1, Nombre = "Cuadrado", Area = "A * A", Perimetro = "4 * A"},
                new Figura{ID = 2, Nombre = "TrianguloEquilatero", Area = "(Sqrt(3) / 4) * A * A", Perimetro = "3 * A" },
                new Figura{ID = 3, Nombre = "Circulo", Area = "pi * ( A  / 2) * ( A / 2)", Perimetro = "pi * A" },
                new Figura{ID = 4, Nombre = "Trapecio", Area = "sqrt( A*A - ( ((C - B)/2) * ((C - B)/2)) )  * ( ( B + C ) / 2 )", Perimetro = "A * 2 + B + C" },
                new Figura{ID = 5, Nombre = "Rectangulo", Area =  "A * B", Perimetro = "2 * A + 2 * B" },
                new Figura{ID = 6, Nombre = "Pentagono", Area =  null, Perimetro = "5 * A" },
                new Figura{ID = 7, Nombre = "CuadradoConVolumen", Area = "A * A", Perimetro = "4 * A", Volumen = "A * A * A"}
            };
            figuras.ForEach(s => context.Figura.Add(s));
            context.SaveChanges();
        }
    }
}
