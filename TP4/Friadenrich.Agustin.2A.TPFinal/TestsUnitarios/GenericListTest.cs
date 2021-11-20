using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;
using System;
using System.IO;

namespace TestsUnitarios
{
    [TestClass]
    public class GenericListTest
    {
        [TestMethod]
        public void AgregarElementoCorrecto()
        {
            //Arrange
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            Vehiculo vehiculo = new Vehiculo(ETipoVehiculo.Grande, EProvincias.BsAs, "Vehiculo_Test");

            //Act
            lista += vehiculo;
            bool result = lista.Elementos.Contains(vehiculo);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(TipoInvalidoException))]
        public void AgregarElementoConTipoInvalido()
        {
            //Arrange
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            Vehiculo vehiculo = new Vehiculo(0, EProvincias.BsAs, "Vehiculo_Test"); 

            //Act
            lista += vehiculo;

            bool result = lista.Elementos.Contains(vehiculo);

            //Assert controlado por ExpectedException.
        }

        [TestMethod]
        [ExpectedException(typeof(NumeroFueraDeRangoException))]
        public void AgregarElementoCantidadInvalida()
        {
            //Arrange
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            Vehiculo vehiculo = new Vehiculo(ETipoVehiculo.Grande, EProvincias.BsAs, "Vehiculo_Test", -20);

            //Act
            lista += vehiculo;

            bool result = lista.Elementos.Contains(vehiculo);

            //Assert controlado por ExpectedException.
        }

        [TestMethod]
        [ExpectedException(typeof(NumeroFueraDeRangoException))]
        public void AgregarElementoGasesEmitidosInvalidos()
        {
            //Arrange
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            Vehiculo vehiculo = new Vehiculo(ETipoVehiculo.Grande, EProvincias.BsAs, "Vehiculo_Test", 5, -250000);

            //Act
            lista += vehiculo;

            bool result = lista.Elementos.Contains(vehiculo);

            //Assert controlado por ExpectedException.
        }

        [TestMethod]
        public void EliminarElementoValido()
        {
            //Arrange
            Vehiculo vehiculo1 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_1");
            Vehiculo vehiculo2 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            lista += vehiculo1;
            lista += vehiculo2;

            //Act
            lista -= vehiculo1;
            lista -= new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);
            
            bool result = lista.Elementos.Contains(vehiculo1) && lista.Elementos.Contains(vehiculo2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EliminarElementoNoValido()
        {
            //Arrange
            Vehiculo vehiculo1 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_1");
            Vehiculo vehiculo2 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);
            Vehiculo vehiculo3 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_3");
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            lista += vehiculo1;
            lista += vehiculo2;

            //Act
            lista -= vehiculo3;
            lista -= new Vehiculo(ETipoVehiculo.Mediano, EProvincias.SantiagoDelEstero, "Vehiculo_Test_2", 1000, 77);
            bool result = lista.Elementos.Contains(vehiculo1) && lista.Elementos.Contains(vehiculo2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EliminarTodo()
        {
            //Arrange
            Vehiculo vehiculo1 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_1");
            Vehiculo vehiculo2 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);
            Vehiculo vehiculo3 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_3");
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            lista += vehiculo1;
            lista += vehiculo2;
            lista += vehiculo3;

            //Act
            lista.Borrar();
            bool result = lista.Elementos.Contains(vehiculo1) || lista.Elementos.Contains(vehiculo2) || lista.Elementos.Contains(vehiculo3);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GuardarArchivoCorrecto()
        {
            //Arrange
            GenericList<Vehiculo> vehiculos = new GenericList<Vehiculo>("TestList");
            Vehiculo vehiculo1 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_1");
            Vehiculo vehiculo2 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);

            vehiculos += vehiculo1;
            vehiculos += vehiculo2;

            string path = Environment.CurrentDirectory + "/test.json";

            vehiculos.GuardarTodo(path);

            //Act
            StreamReader sr = new StreamReader(path);
            string actual = sr.ReadToEnd();
            sr.Close();

            string expected = vehiculos.TransformarTodoAJSON();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GuardarYLeerArchivoCorrecto()
        {
            //Arrange
            GenericList<Vehiculo> lisaAGuardar = new GenericList<Vehiculo>("TestList");
            GenericList<Vehiculo> copiaAuxiliar;
            Vehiculo vehiculo1 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.BsAs, "Vehiculo_Test_1");
            Vehiculo vehiculo2 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Cordoba, "Vehiculo_Test_2", 1000, 77);

            lisaAGuardar += vehiculo1;
            lisaAGuardar += vehiculo2;

            copiaAuxiliar = lisaAGuardar;

            //Act

            string path = Environment.CurrentDirectory + "/test2.json";

            lisaAGuardar.GuardarTodo(path);

            lisaAGuardar.Borrar();

            lisaAGuardar = lisaAGuardar.LeerTodo(path);

            string expected = copiaAuxiliar.ToString();
            string actual = lisaAGuardar.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
