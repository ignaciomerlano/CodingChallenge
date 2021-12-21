using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.Formas;
using CodingChallenge.Data.Interfaces;
using CodingChallenge.Data.Repositorio;
using Moq;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private IRepositorioTraducciones _repoTraducciones;

        [SetUp]
        public void Setup()
        {
            /*
             * Quizá acá lo correcto sería mockear el repositorio, pero para fines de poder consumir los datos reales del XML dejo la instancia real.
            */
            _repoTraducciones = RepositorioTraducciones.GetInstance();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            //Arrange
            var lista = new List<IFormaGeometrica> { };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(lista, "Castellano");

            //Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resumen);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            //Arrange
            var lista = new List<IFormaGeometrica> { };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(lista, "Ingles");

            //Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            //Arrange
            var cuadrados = new List<IFormaGeometrica> {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(cuadrados, "Castellano");

            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosCastellano()
        {
            //Arrange
            var cuadrados = new List<IFormaGeometrica> {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Cuadrado(1, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Cuadrado(3, new TipoForma { Id = 1, Descripcion = "Cuadrado" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(cuadrados, "Castellano");

            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>3 Cuadrados | Area 35 | Perimetro 36 <br/>TOTAL:<br/>3 formas Perimetro 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosIngles()
        {
            //Arrange
            var cuadrados = new List<IFormaGeometrica> {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Cuadrado(1, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Cuadrado(3, new TipoForma { Id = 1, Descripcion = "Cuadrado" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(cuadrados, "Ingles");

            //Assert
            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Circulo(3, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new TrianguloEquilatero(4, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" }),
                new Cuadrado(2, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new TrianguloEquilatero(9, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" }),
                new Circulo(2.75m, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new TrianguloEquilatero(4.2m, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Ingles");

            //Assert
            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Circulo(3, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new TrianguloEquilatero(4, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" }),
                new Cuadrado(2, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new TrianguloEquilatero(9, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" }),
                new Circulo(2.75m, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new TrianguloEquilatero(4.2m, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Castellano");

            //Assert
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioCastellano()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Castellano");

            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 65 | Perimetro 25 <br/>TOTAL:<br/>1 forma Perimetro 25 Area 65", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioFrances()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Frances");

            //Assert
            Assert.AreEqual("<h1>Rapport de formulaires</h1>1 Trapèze | Zone 65 | Périmètre 25 <br/>LE TOTAL:<br/>1 forme Périmètre 25 Zone 65", resumen);
        }

        [TestCase]
        public void TestResumenListaConVariosTrapeciosFrances()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" }),
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" }),
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Frances");

            //Assert
            Assert.AreEqual("<h1>Rapport de formulaires</h1>3 Trapèzes | Zone 195 | Périmètre 75 <br/>LE TOTAL:<br/>3 formes Périmètre 75 Zone 195", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnFrances()
        {
            //Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Circulo(3, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new TrianguloEquilatero(4, new TipoForma { Id = 2, Descripcion = "TrianguloEquilatero" }),
                new Cuadrado(2, new TipoForma { Id = 1, Descripcion = "Cuadrado" }),
                new Rectangulo(9, 4, new TipoForma { Id = 5, Descripcion = "Rectangulo" }),
                new Circulo(2.75m, new TipoForma { Id = 3, Descripcion = "Circulo" }),
                new Trapecio(5, 8, 6, 6, 10, new TipoForma { Id = 4, Descripcion = "Trapecio" })
            };
            FormaGeometrica forma = new FormaGeometrica(_repoTraducciones);

            //Act
            var resumen = forma.Imprimir(formas, "Frances");

            //Assert
            Assert.AreEqual(
                "<h1>Rapport de formulaires</h1>2 Carrés | Zone 29 | Périmètre 28 <br/>2 Cercles | Zone 13,01 | Périmètre 18,06 <br/>1 Triangle | Zone 6,93 | Périmètre 12 <br/>1 Rectangle | Zone 36 | Périmètre 26 <br/>1 Trapèze | Zone 65 | Périmètre 25 <br/>LE TOTAL:<br/>7 formes Périmètre 109,06 Zone 149,94",
                resumen);
        }
    }
}
