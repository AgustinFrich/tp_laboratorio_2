using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Entidades
{
    public static class SQLExtension
    {
      
        static SqlConnection connection = new SqlConnection("Server=localhost;Database=FriadenrichAgustin;Trusted_Connection=True;");
        static SqlCommand command = new SqlCommand
        {
            CommandType = CommandType.Text
        };

        static SqlDataReader reader;

        public static GenericList<Fabrica> ObtenerFabricas(string proveedor)
        {
            GenericList<Fabrica> lista = new GenericList<Fabrica>(proveedor);

            try
            {
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.CommandText = "SELECT tipo, provincia, nombre, cantidad, gasesEmitidos FROM dbo.fabricas WHERE proveedor = @proveedor";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Fabrica item = new Fabrica
                    {
                        TipoFabrica = (ETipoFabrica)reader[0],
                        Provincia = (EProvincias)reader[1],
                        Nombre = reader[2].ToString(),
                        Cantidad = (int)reader[3],
                        GasesEmitidos = (int)reader[4]
                    };

                    if (item.ComprobarContaminante())
                        lista += item;
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                command.Parameters.Clear();
                CerrarConexion();
            }

            return lista;
        }

        public static GenericList<Vehiculo> ObtenerVehiculos(string proveedor)
        {
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>(proveedor);

            try
            {
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.CommandText = "SELECT tipo, provincia, nombre, cantidad, gasesEmitidos FROM dbo.vehiculos WHERE proveedor = @proveedor";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Vehiculo item = new Vehiculo
                    {
                        TipoVehiculo = (ETipoVehiculo)reader[0],
                        Provincia = (EProvincias)reader[1],
                        Nombre = reader[2].ToString(),
                        Cantidad = (int)reader[3],
                        GasesEmitidos = (int)reader[4]
                    };

                    if (item.ComprobarContaminante())                    
                        lista += item;
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                command.Parameters.Clear();
                CerrarConexion();
            }

            return lista;
        }

        public static bool Agregar(this Contaminantes contaminante, string proveedor)
        {
            bool resultado;

            try
            {
                AgregarParametros(contaminante, proveedor, out string tabla);

                string query = "INSERT INTO " + tabla + " (tipo, provincia, nombre, cantidad, gasesEmitidos, proveedor) VALUES(@tipo, @provincia, @nombre, @cantidad, @gasesEmitidos, @proveedor)";
                
                EjecutarQuery(query, out resultado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = false;
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }


        public static bool Modificar(this Contaminantes contaminante, string proveedor)
        {
            bool resultado;

            try
            {
                AgregarParametros(contaminante, proveedor, out string tabla);

                string query = "UPDATE " + tabla + " SET tipo = @tipo, cantidad = @cantidad, gasesEmitidos = @gasesEmitidos WHERE nombre = @nombre AND provincia = @provincia AND proveedor = @proveedor";

                EjecutarQuery(query, out resultado);
            }
            catch (Exception)
            {
                resultado = false;
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }

        public static bool Eliminar(this Contaminantes contaminante, string proveedor)
        {
            bool resultado;
            string tabla;
            try
            {
                command.Parameters.AddWithValue("@nombre", contaminante.Nombre);
                command.Parameters.AddWithValue("@provincia", contaminante.Provincia);
                command.Parameters.AddWithValue("@proveedor", proveedor);

                if (contaminante is Fabrica)
                {
                    tabla = "dbo.fabricas";

                }
                else if (contaminante is Vehiculo)
                {
                    tabla = "dbo.vehiculos";
                }
                else
                {
                    throw new Exception("No se puede eliminar un contaminante que no sea fabrica o vehiculo.");
                }

                string query = "DELETE FROM " + tabla + " WHERE nombre = @nombre AND provincia = @provincia AND proveedor = @proveedor";

                EjecutarQuery(query, out resultado);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = false;
            }
            finally
            {
                CerrarConexion();
            }

            return resultado;
        }

        static void AgregarParametros(Contaminantes contaminante, string proveedor, out string tabla)
        {
            command.Parameters.AddWithValue("@provincia", (int)contaminante.Provincia);
            command.Parameters.AddWithValue("@nombre", contaminante.Nombre);
            command.Parameters.AddWithValue("@cantidad", contaminante.Cantidad);
            command.Parameters.AddWithValue("@gasesEmitidos", contaminante.GasesEmitidos);
            command.Parameters.AddWithValue("@proveedor", proveedor);

            if (contaminante is Fabrica)
            {
                tabla =  "dbo.fabricas";
                command.Parameters.AddWithValue("@tipo", (int)((Fabrica)contaminante).TipoFabrica);
            }
            else if (contaminante is Vehiculo)
            {
                tabla = "dbo.vehiculos";
                command.Parameters.AddWithValue("@tipo", (int)((Vehiculo)contaminante).TipoVehiculo);
            }
            else
            {
                throw new Exception("No se puede usar este tipo de contaminante como parametro.");
            }
        }

        static void EjecutarQuery(string query, out bool resultado)
        {
            resultado = true;

            command.CommandText = query;
            command.Connection = connection;
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }

            int filasAfectadas = command.ExecuteNonQuery();
            command.Parameters.Clear();

            if (filasAfectadas == 0)
            {
                resultado = false;
            }
        }

        private static void CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
