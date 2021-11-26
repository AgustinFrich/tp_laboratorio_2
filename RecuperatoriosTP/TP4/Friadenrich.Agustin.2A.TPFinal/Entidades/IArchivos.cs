using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    interface IArchivos<T> 
    {
        #region Escritura
        /// <summary>
        /// Método pensado para crear una cadena JSON del objeto que llama a la función.
        /// </summary>
        /// <returns></returns>
        string TransformarTodoAJSON();

        /// <summary>
        /// Este método está pensado para  guardar en el path indicado los datos del objeto (llamando a la función TransformarTodoAJSON() para la conversión).
        /// </summary>
        /// <param name="path"></param>
        void GuardarTodo(string path);

        #endregion

        #region Lectura
        /// <summary>
        /// Está pensado para encargarse de leer una cadena JSON y transformarla en un objeto del tipo asignado.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        T LeerJSON(string json);

        /// <summary>
        /// Está pensado para encargarse de leer un archivo ubicado en el path seleccionado, utilizando el método LeerJSON(string json).
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        T LeerTodo(string path);
        #endregion
    }
}
