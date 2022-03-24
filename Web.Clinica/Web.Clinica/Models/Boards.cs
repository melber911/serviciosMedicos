using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Utilities
{
    public class Boards
    {
        /// <summary>
        /// Tabla que contiene las base de datos disponibles para conectarnos
        /// </summary>
        /// <returns>Devuelve una tabla con las Base de Datos Disponibles</returns>
        public DataTable TypeServer()
        {
            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add("Id");
            objDataTable.Columns.Add("TypeServer");
            objDataTable.Columns.Add("State");
            objDataTable.Rows.Add("1", "MSSQL SERVER", "A");
            objDataTable.Rows.Add("2", "ORACLE", "A");

            return objDataTable;
        }
    }

}