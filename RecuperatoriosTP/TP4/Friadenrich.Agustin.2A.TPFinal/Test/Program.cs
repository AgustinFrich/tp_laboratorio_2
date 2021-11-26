﻿using System;
using System.IO;
using Entidades;
using Excepciones;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Friadenrich Agustin";
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2 + 50 , Console.LargestWindowHeight - 20);

            Vehiculo v1 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.Misiones, "V1", 7500, 85);
            Vehiculo v2 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.SantaCruz, "V2", 3200);
            Vehiculo v3 = new Vehiculo(ETipoVehiculo.Mediano, EProvincias.LaPampa, "V3", 450);
            Vehiculo v4 = new Vehiculo(ETipoVehiculo.Grande, EProvincias.Salta, "V4", 1500);
            try
            {
                Vehiculo v5 = new Vehiculo(ETipoVehiculo.Hibrido, EProvincias.Corrientes, "");
            } catch (StringInvalidoException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("");
            }
            
            Fabrica f1 = new Fabrica(ETipoFabrica.Metalurgica, EProvincias.Catamarca, "FA");
            Fabrica f2 = new Fabrica(ETipoFabrica.Quimica, EProvincias.Misiones, "FB");
            Fabrica f3 = new Fabrica(ETipoFabrica.Metalurgica, EProvincias.Misiones, "FC", 1, 750000);
            Fabrica f4 = new Fabrica(ETipoFabrica.Cementera, EProvincias.BsAs, "FD", 12);
            try
            {
                Fabrica f5 = new Fabrica(ETipoFabrica.Cementera, EProvincias.Corrientes, "FE", -5);
            }
            catch (NumeroFueraDeRangoException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("");
            }
            GenericList<Vehiculo> vehiculos = new GenericList<Vehiculo>("TestProgram1");
            GenericList<Fabrica> fabricas = new GenericList<Fabrica>("TestProgram1");

            Console.WriteLine("Antes de comenzar, conecte la base de datos.");
            Console.WriteLine("Los archivos estan en la carpeta base del proyecto");
            Console.ReadLine();
            Console.Clear();

            vehiculos += v1;
            vehiculos += v2;
            vehiculos += v3;
            vehiculos += v4;
            // agrego repetido
            vehiculos += v2;

            //agrego a la base de datos
            if (!v1.AgregarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + v1.Nombre + " a la base de datos");
            if (!v2.AgregarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + v2.Nombre + " a la base de datos");
            if (!v3.AgregarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + v3.Nombre + " a la base de datos");
            if (!v4.AgregarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + v4.Nombre + " a la base de datos");
            //argrego repetido
            if (!v2.AgregarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + v2.Nombre + " a la base de datos");

            fabricas += f1;
            fabricas += f2;
            fabricas += f3;
            fabricas += f4;
            // agrego repetido
            fabricas += f4;

            //agrego a la base de datos
            if (!f1.AgregarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + f1.Nombre + " a la base de datos");
            if (!f2.AgregarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + f2.Nombre + " a la base de datos");
            if (!f3.AgregarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + f3.Nombre + " a la base de datos");
            if (!f4.AgregarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + f4.Nombre + " a la base de datos");
            //argrego repetido
            if (!f4.AgregarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo agregar " + f4.Nombre + " a la base de datos");

            //Mostrar lista local
            Console.WriteLine("Muestro la lista de vehiculos: ");
            Console.WriteLine("");

            Console.WriteLine(vehiculos.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //Mostrar desde base de datos.
            Console.WriteLine("Muestro la lista de vehiculos desde la base de datos: ");
            Console.WriteLine("");

            vehiculos = SQLExtension.ObtenerVehiculosSQL(vehiculos.Titulo);
            Console.WriteLine(vehiculos.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //Mostrar lista local
            Console.WriteLine("Muestro la lista de fabricas: ");
            Console.WriteLine("");

            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //Mostrar desde base de datos.
            Console.WriteLine("Muestro la lista de fabricas desde la base de datos: ");
            Console.WriteLine("");

            fabricas = SQLExtension.ObtenerFabricasSQL(fabricas.Titulo);
            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //Saco 2 y saco uno que no está en la lista
            vehiculos -= v4;
            vehiculos -= v3;
            vehiculos -= new Vehiculo(ETipoVehiculo.Grande, EProvincias.Formosa, "V5", 200, 72);
            
            //Lo mismo pero en la base de datos:
            v4.EliminarASQL(vehiculos.Titulo);
            v3.EliminarASQL(vehiculos.Titulo);
            if (!new Vehiculo(ETipoVehiculo.Grande, EProvincias.Formosa, "V5", 200, 72).EliminarASQL(vehiculos.Titulo))
                Console.WriteLine("\nNo se pudo eliminar el vehiculo, ya que no existe en la base de datos");
            
            //Saco 2 y saco uno que no está en la lista
            fabricas -= f4;
            fabricas -= f3;
            //fabricas -= v2; -> error en tiempo de compliación
            fabricas -= new Fabrica(ETipoFabrica.Quimica, EProvincias.Chaco, "Fiat", 3, 500000);
            
            //Lo mismo pero en la base de datos:
            f4.EliminarASQL(fabricas.Titulo);
            f3.EliminarASQL(fabricas.Titulo);
            if (!new Fabrica(ETipoFabrica.Quimica, EProvincias.Chaco, "Fiat", 3, 500000).EliminarASQL(fabricas.Titulo))
                Console.WriteLine("\nNo se pudo eliminar la fabrica, ya que no existe en la base de datos");
            
            //muestro lista local
            Console.WriteLine("Muestro la lista de vehiculos despues de eliminar 2: ");
            Console.WriteLine("");

            Console.WriteLine(vehiculos.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //muestro lista SQL
            Console.WriteLine("Muestro la lista de vehiculos desde la base de datos: ");
            Console.WriteLine("");

            fabricas = SQLExtension.ObtenerFabricasSQL(fabricas.Titulo);
            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            
            //Muestro lista local
            Console.WriteLine("Muestro la lista de fabricas despues de eliminar 2: ");
            Console.WriteLine("");

            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            //Muestro lista SQL
            
            Console.WriteLine("Muestro la lista de fabricas desde la base de datos: ");
            Console.WriteLine("");

            fabricas = SQLExtension.ObtenerFabricasSQL(fabricas.Titulo);
            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            //Elimino lo que queda en las listas SQL para evitar errores en la proxima ejecucion
            v2.EliminarASQL(vehiculos.Titulo);
            v1.EliminarASQL(vehiculos.Titulo);
            f2.EliminarASQL(fabricas.Titulo);
            f1.EliminarASQL(fabricas.Titulo);

            //Archivos
            //Creo un archivo y guardo los datos en el. Luego, borro los datos de la lista actual

            string path = Environment.CurrentDirectory + "/fabricas.json";
            if (!File.Exists(path)){
                File.Create(path);
            }

            fabricas.GuardarTodo(path);
            fabricas.Borrar();

            Console.WriteLine("Se crea el archivo fabricas.json en el directorio actual. ");
            Console.WriteLine("");
            Console.WriteLine("Muestro la lista vacia: ");
            Console.WriteLine("");
            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            //Leo los datos del archivo: 
            fabricas = fabricas.LeerTodo(path);

            Console.WriteLine("Se obtienen los datos de fabricas.json: ");

            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("En la lista de fabricas, Gases totales en la provincia Misiones: " + fabricas.ContaminacionEnLaProvincia(EProvincias.Misiones, out int coincidencias1));
            Console.WriteLine("La cantidad de fabricas en Misiones es: " + coincidencias1);

            Console.WriteLine("\nEn la lista de vehiculos, Gases totales en la provincia Misiones: " + vehiculos.ContaminacionEnLaProvincia(EProvincias.Misiones, out int coincidencias2));
            Console.WriteLine("La cantidad de vehiculos en Misiones es: " + coincidencias2);
            
            Console.WriteLine("\nEn la lista de fabricas, Gases totales en el tipo Metalurgica: " + fabricas.ContaminacionPorTipo((int)ETipoFabrica.Metalurgica, out int coincidencias3));
            Console.WriteLine("La cantidad de fabricas metalurgicas es: " + coincidencias3);
            
            Console.WriteLine("\nEn la lista de vehiculos, Gases totales en el tipo Mediano: " + vehiculos.ContaminacionPorTipo((int)ETipoVehiculo.Mediano, out int coincidencias4));
            Console.WriteLine("La cantidad de vehiculos medianos es: " + coincidencias4);
           
            Console.WriteLine("\nPresione enter para salir.");
            Console.ReadLine();
        }
    }
}
