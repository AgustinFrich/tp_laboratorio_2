using System;
using System.Data;
using System.Data.SqlClient;

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
        
        #region Create

        /// <summary>
        /// Metodo de extension.
        /// Inserta el contaminante que llama a la funcion en la talba correspondiente de la base de datos SQL.
        /// Agrega todos los datos del contaminante mas el nombre de su proveedor de datos (Proveniente de la lista generica)
        /// </summary>
        /// <param name="contaminante"></param>
        /// <param name="proveedor"></param>
        /// <returns>Devuelve true si logra insertar correctamente, false en caso contrario.</returns>
        public static bool AgregarASQL(this Contaminante contaminante, string proveedor)
        {
            bool resultado = false;

            try
            {
                if (!contaminante.ComprobarQueNoExista(proveedor))
                {
                    AgregarParametros(contaminante, proveedor, out string tabla);

                    string query = "INSERT INTO " + tabla + " (tipo, provincia, nombre, cantidad, gasesEmitidos, proveedor) VALUES(@tipo, @provincia, @nombre, @cantidad, @gasesEmitidos, @proveedor)";
                    EjecutarQuery(query, out resultado);
                }
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

        #endregion

        #region Read

        /// <summary>
        /// Obtiene de la tabla de fabricas los datos de aquellas fabricas que tengan el mismo proveedor pasado como parametro.
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns>Una GenericList de fabricas con todos los vehiculos que tengan el mismo proveedor.</returns>
        public static GenericList<Fabrica> ObtenerFabricasSQL(string proveedor)
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

        /// <summary>
        /// Obtiene de la tabla de vehiculos los datos de aquellos vehiculos que tengan el mismo proveedor pasado como parametro.
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns>Una GenericList de vehiculos con todos los vehiculos que tengan el mismo proveedor.</returns>
        public static GenericList<Vehiculo> ObtenerVehiculosSQL(string proveedor)
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

        #endregion

        #region Update

        /// <summary>
        /// Metodo de extension.
        /// Modifica el contaminante que llama a la funcion de la tabla correspondiente de la base de datos SQL.
        /// En la tabla, busca por nombre, provincia y proveedor, si encuentra una coincidencia, 
        /// modifica el resto de los atributos.
        /// </summary>
        /// <param name="contaminante"></param>
        /// <param name="proveedor"></param>
        /// <returns>Devuelve true si logra modificar correctamente, false en caso contrario.</returns>
        public static bool ModificarASQL(this Contaminante contaminante, string proveedor)
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
        #endregion

        #region Delete

        /// <summary>
        /// Metodo de extension.
        /// Elimina el contaminante que llama a la funcion de la tabla correspondiente en la base de datos SQL.
        /// Solo elimina si el contaminante existe en la tabla con el mismo nombre, provincia y nombre del proveedor.
        /// </summary>
        /// <param name="contaminante"></param>
        /// <param name="proveedor"></param>
        /// <returns>Devuelve true si logra eliminar correctamente, false en caso contrario</returns>
        public static bool EliminarASQL(this Contaminante contaminante, string proveedor)
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
        #endregion

        #region Metodos auxiliares

        /// <summary>
        /// Metodo utilizado para asignar todos los parametros del contaminante mas el nombre de su proveedor.
        /// También asigna a la variable tabla el nombre correspondiente a la tabla de fabricas o de vehiculos.
        /// Lanza una excepcion si el contaminante no es valido.
        /// </summary>
        /// <param name="contaminante"></param>
        /// <param name="proveedor"></param>
        /// <param name="tabla"></param>
        static void AgregarParametros(Contaminante contaminante, string proveedor, out string tabla)
        {
            command.Parameters.AddWithValue("@provincia", (int)contaminante.Provincia);
            command.Parameters.AddWithValue("@nombre", contaminante.Nombre);
            command.Parameters.AddWithValue("@cantidad", contaminante.Cantidad);
            command.Parameters.AddWithValue("@gasesEmitidos", contaminante.GasesEmitidos);
            command.Parameters.AddWithValue("@proveedor", proveedor);

            if (contaminante.ComprobarContaminante())
            {
                if (contaminante is Fabrica fabrica)
                {
                    tabla =  "dbo.fabricas";
                    command.Parameters.AddWithValue("@tipo", (int)fabrica.TipoFabrica);
                }
                else if (contaminante is Vehiculo vehiculo)
                {
                    tabla = "dbo.vehiculos";
                    command.Parameters.AddWithValue("@tipo", (int)vehiculo.TipoVehiculo);
                }
                else
                {
                    throw new Exception("No se puede usar este tipo de contaminante como parametro.");
                }
            } else
            {
                throw new Exception("El contaminante no es valido, no se puede ejecutar la instrucción. ");
            }
        }

        /// <summary>
        /// Metodo utilizado para ejecutar las instrucciones SQL. La variable resultado se asigna en true o flase 
        /// dependiendo de si afecto o no alguna fila de la tabla.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="resultado"></param>
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

        /// <summary>
        /// Comprueba que un contaminante no exista en la tabla de su base de datos.
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        private static bool ComprobarQueNoExista(this Contaminante contaminante, string proveedor)
        {
            string tabla = "dbo.vehiculos";

            if (contaminante is Fabrica)
                tabla = "dbo.fabricas";

            command.Parameters.AddWithValue("@nombre", contaminante.Nombre);
            command.Parameters.AddWithValue("@provincia", (int)contaminante.Provincia);
            command.Parameters.AddWithValue("@proveedor", proveedor);
            string queryComprobador = "SELECT COUNT(*) FROM " + tabla + " WHERE nombre = @nombre AND provincia = @provincia AND proveedor = @proveedor";

            command.CommandText = queryComprobador;
            command.Connection = connection;

            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }

            int filasAfectadas = (int)command.ExecuteScalar();
            command.Parameters.Clear();
            bool existe = filasAfectadas > 0;
            CerrarConexion();
            return existe;
        }

        /// <summary>
        /// Metodo utilizado para cerrar la conexion al servidor SQL.
        /// </summary>
        private static void CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion
    }
}
