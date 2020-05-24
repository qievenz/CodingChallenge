using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Area 25 Perimetro 20", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            Dictionary<string, decimal> lados = new Dictionary<string, decimal>();
            lados.Add("A", 4);
            lados.Add("B", 13);
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(5, lados) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, 2);

            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 52 | Perimeter 34 <br/>TOTAL:<br/>1 shapes Area 52 Perimeter 34", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecio = new List<FormaGeometrica>
            {
                new FormaGeometrica(4, new Dictionary<string, decimal>{ { "A", 3 },{ "B", 5 },{ "C", 8 } })
            };

            var resumen = FormaGeometrica.Imprimir(trapecio, 2);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 16,89 | Perimeter 19 <br/>TOTAL:<br/>1 shapes Area 16,89 Perimeter 19", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(Cuadrado, 5),
                new FormaGeometrica(Cuadrado, 1),
                new FormaGeometrica(Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Area 35 Perimeter 36", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(Cuadrado, 5),
                new FormaGeometrica(Circulo, 3),
                new FormaGeometrica(TrianguloEquilatero, 4),
                new FormaGeometrica(Cuadrado, 2),
                new FormaGeometrica(TrianguloEquilatero, 9),
                new FormaGeometrica(Circulo, 2.75m),
                new FormaGeometrica(TrianguloEquilatero, 4.2m),
                new FormaGeometrica(Trapecio, new Dictionary<string, decimal>{ { "A", 3 },{ "B", 5 },{ "C", 8 } })
            };

            var resumen = FormaGeometrica.Imprimir(formas, Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Trapezium | Area 16,89 | Perimeter 19 <br/>TOTAL:<br/>8 shapes Area 108,54 Perimeter 116,66",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(Cuadrado, 5),
                new FormaGeometrica(Circulo, 3),
                new FormaGeometrica(TrianguloEquilatero, 4),
                new FormaGeometrica(Cuadrado, 2),
                new FormaGeometrica(TrianguloEquilatero, 9),
                new FormaGeometrica(Circulo, 2.75m),
                new FormaGeometrica(TrianguloEquilatero, 4.2m),
                new FormaGeometrica(Trapecio, new Dictionary<string, decimal>{ { "A", 3 },{ "B", 5 },{ "C", 8 } })
            };

            var resumen = FormaGeometrica.Imprimir(formas, Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Trapecio | Area 16,89 | Perimetro 19 <br/>TOTAL:<br/>8 formas Area 108,54 Perimetro 116,66",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnaFuncionNoEstablecidaEnIngles()
        {
            var pentagonos = new List<FormaGeometrica>
            {
                new FormaGeometrica(6, 12),
                new FormaGeometrica(6, 7),
                new FormaGeometrica(6, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(pentagonos, 2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Pentagons | Perimeter 116 <br/>TOTAL:<br/>3 shapes Perimeter 116", resumen);
        }

        [TestCase]
        public void TestResumenListaConAlgunasFuncionesSinEstablecerEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(3, 3),
                new FormaGeometrica(6, 12),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(6, 7),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(6, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>1 Circle | Area 7,07 | Perimeter 9,42 <br/>3 Pentagons | Perimeter 116 <br/>1 Triangle | Area 6,93 | Perimeter 12 <br/>1 Square | Area 4 | Perimeter 8 <br/>TOTAL:<br/>6 shapes Area 18 Perimeter 145,42", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoConVolumen()
        {
            var cuadradoConVolumen = new List<FormaGeometrica> { new FormaGeometrica(7, 3) };

            var resumen = FormaGeometrica.Imprimir(cuadradoConVolumen, Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado con volumen | Area 9 | Perimetro 12 | Volumen 27 <br/>TOTAL:<br/>1 formas Area 9 Perimetro 12 Volumen 27", resumen);
        }
    }
}
