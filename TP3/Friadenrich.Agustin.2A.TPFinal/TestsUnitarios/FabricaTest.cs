using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Entidades;
using System;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class FabricaTest
    {
        [TestMethod]
        public void FabricasSonIguales()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1");
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1", 1);
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1", 1, 340000);

            //Act
            bool resultado = fabrica1 == fabrica2 && fabrica1 == fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void FabricasNombreDistinto()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1");
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test2", 1);
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test3", 1, 340000);

            //Act
            bool resultado = fabrica1 != fabrica2 && fabrica1 != fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void FabricasProvinciaDistinta()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1");
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Cementera, EProvincias.Catamarca, "Test1", 1);
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Cementera, EProvincias.SantiagoDelEstero, "Test1", 1, 340000);

            //Act
            bool resultado = fabrica1 != fabrica2 && fabrica1 != fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void FabricasCantidadDistinta()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1");
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1", 5);
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1", 10, 340000);

            //Act
            bool resultado = fabrica1 != fabrica2 && fabrica1 != fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void FabricasTipoDistinto()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Quimica, EProvincias.BsAs, "Test1");
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Farmaceutica, EProvincias.BsAs, "Test1", 1);
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "Test1", 1, 340000);

            //Act
            bool resultado = fabrica1 != fabrica2 && fabrica1 != fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void FabricasGasesEmitidosDistintos()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Quimica, EProvincias.BsAs, "Test1"); //gases emitidos: 500000
            Fabrica fabrica2 = new Fabrica(ETipoFabrica.Farmaceutica, EProvincias.BsAs, "Test1", 1); //gases emitidos 180000
            Fabrica fabrica3 = new Fabrica(ETipoFabrica.Farmaceutica, EProvincias.BsAs, "Test1", 1, 340000); //gases emitidos 340000

            //Act
            bool resultado = fabrica1 != fabrica2 && fabrica1 != fabrica3;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void MostrarFabrica()
        {
            //Arrange
            Fabrica fabrica = new Fabrica(ETipoFabrica.Quimica, EProvincias.Chubut, "Test", 5, 105000);
            StringBuilder sb = new StringBuilder();

            //Act
            sb.AppendFormat("Nombre: {0}, \n", "Test");
            sb.AppendFormat("Ubicación: {0}, \n", "Chubut");
            sb.AppendFormat("Cantidad: {0}, \n", "5");
            sb.AppendFormat("Gases emitidos: {0} toneladas de CO2 anuales, \n", "105000");
            sb.AppendLine("Tipo: " + "Quimica");


            string expected = sb.ToString();
            string actual = fabrica.Mostrar();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FabricaToString()
        {
            //Arrange
            Fabrica fabrica = new Fabrica(ETipoFabrica.Siderurgica, EProvincias.Formosa, "Test2", 2, 200000);
            StringBuilder sb = new StringBuilder();

            //Act
            sb.AppendFormat("Nombre: {0}, \n", "Test2");
            sb.AppendFormat("Ubicación: {0}, \n", "Formosa");
            sb.AppendFormat("Cantidad: {0}, \n", "2");
            sb.AppendFormat("Gases emitidos: {0} toneladas de CO2 anuales, \n", "200000");
            sb.AppendLine("Tipo: " + "Siderurgica");


            string expected = sb.ToString();
            string actual = fabrica.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerificaFabricaCorrecta()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Metalurgica, EProvincias.Formosa, "TestBool", 2, 200000);

            //Act
            bool result = fabrica1.ComprobarContaminante();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void VerificarFabricaNula()
        {
            //Arrange
            Fabrica fabrica1 = null;

            //Act
            bool result = fabrica1.ComprobarContaminante();

        }

        [TestMethod]
        [ExpectedException(typeof(TipoInvalidoException))]
        public void VerificarFabricaErronea()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(0, EProvincias.Formosa, "!TestBool", 1, 200000);
        }

        [TestMethod]
        [ExpectedException(typeof(NumeroFueraDeRangoException))]
        public void FabricaCantidadInvalida()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Metalurgica, EProvincias.Formosa, "TestBool", -20, 200000);
        }

        [TestMethod]
        [ExpectedException(typeof(NumeroFueraDeRangoException))]
        public void FabricaGasesEmitidosInvalidos()
        {
            //Arrange
            Fabrica fabrica1 = new Fabrica(ETipoFabrica.Metalurgica, EProvincias.Formosa, "TestBool", 15, -200000);
        }

        [TestMethod]
        public void ComprobarTipoValido()
        {
            //Arrange
            ETipoFabrica tipo1 = ETipoFabrica.Cementera;
            ETipoFabrica tipo2 = ETipoFabrica.Farmaceutica;
            ETipoFabrica tipo3 = (ETipoFabrica)650000; //correspondiente a "metalúrgica"

            //Act
            bool result = Fabrica.ComprobarTipo(tipo1) && Fabrica.ComprobarTipo(tipo2) && Fabrica.ComprobarTipo(tipo3);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComprobarTipoInvalido()
        {
            //Arrange
            ETipoFabrica tipo1 = 0;
            ETipoFabrica tipo2 = (ETipoFabrica)5; //No incluido en el enumerado de ETipoFabrica

            //Act
            bool result = Fabrica.ComprobarTipo(tipo1) || Fabrica.ComprobarTipo(tipo2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PropiedadGetTipoFabrica()
        {
            Fabrica fabrica = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "TestGet");
            ETipoFabrica expected = ETipoFabrica.Cementera;

            //Act
            ETipoFabrica actual = fabrica.TipoFabrica;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropiedadSetTipoFabrica()
        {
            Fabrica fabrica = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "TestGet");
            ETipoFabrica expected = ETipoFabrica.Metalurgica;

            //Act
            fabrica.TipoFabrica = ETipoFabrica.Metalurgica;
            ETipoFabrica actual = fabrica.TipoFabrica;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
