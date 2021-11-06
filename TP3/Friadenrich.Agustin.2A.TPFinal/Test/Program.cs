using System;
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
            GenericList<Vehiculo> vehiculos = new GenericList<Vehiculo>();
            GenericList<Fabrica> fabricas = new GenericList<Fabrica>();

            vehiculos += v1;
            vehiculos += v2;
            vehiculos += v3;
            vehiculos += v4;
            // agrego repetido
            vehiculos += v2;

            fabricas += f1;
            fabricas += f2;
            fabricas += f3;
            fabricas += f4;
            // agrego repetido
            fabricas += f4;

            Console.WriteLine("Muestro la lista de vehiculos: ");
            Console.WriteLine("");

            Console.WriteLine(vehiculos.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Muestro la lista de fabricas: ");
            Console.WriteLine("");

            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            //Saco 2 y saco uno que no está en la lista
            vehiculos -= v4;
            vehiculos -= v3;
            vehiculos -= new Vehiculo(ETipoVehiculo.Grande, EProvincias.Formosa, "V5", 200, 72);

            //Saco 2 y saco uno que no está en la lista
            fabricas -= f4;
            fabricas -= f3;
            //fabricas -= v2; -> error en tiempo de compliación
            fabricas -= new Fabrica(ETipoFabrica.Quimica, EProvincias.Chaco, "Fiat", 3, 500000);

            Console.WriteLine("Muestro la lista de vehiculos despues de eliminar 2: ");
            Console.WriteLine("");

            Console.WriteLine(vehiculos.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Muestro la lista de fabricas despues de eliminar 2: ");
            Console.WriteLine("");

            Console.WriteLine(fabricas.Listar());

            Console.WriteLine("\nPresione enter para continuar");
            Console.ReadLine();
            Console.Clear();

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

            Console.WriteLine("En la lista de fabricas, Gases totales en la provincia Misiones: " + fabricas.ContaminacionEnLaProvincia(EProvincias.Misiones));
            
            Console.WriteLine("\nEn la lista de vehiculos, Gases totales en la provincia Misiones: " + vehiculos.ContaminacionEnLaProvincia(EProvincias.Misiones));
            
            Console.WriteLine("\nEn la lista de fabricas, Gases totales en el tipo Metalurgica: " + fabricas.ContaminacionPorTipo((int)ETipoFabrica.Metalurgica));
            
            Console.WriteLine("\nEn la lista de vehiculos, Gases totales en el tipo Mediano: " + vehiculos.ContaminacionPorTipo((int)ETipoVehiculo.Mediano));
           
            Console.WriteLine("\nPresione enter para salir.");
            Console.ReadLine();
        }
    }
}
