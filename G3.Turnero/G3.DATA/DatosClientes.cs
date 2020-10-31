﻿using G3.CLASS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.DATA
{
    public class DatosClientes : DatosConexion
    {
        public int AltaClientes(string accion, Cliente clientes) 
        {
            int resultado = 0;
            string orden = string.Empty;

            switch (accion)
            {
                case "Alta":
                    orden = "insert into Clientes " + "values ("
                                            + "'" + clientes.Id + "',"
                                            + "'" + clientes.Nombre_Apellido + "'"
                                            + ");";
                    break;
            }

            SqlCommand sqlcmd = new SqlCommand(orden, conexion);
            try
            {
                AbrirConex();
                resultado = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de cargar los datos de Cliente", e);
            }
            finally
            {
                CerrarConex();
                sqlcmd.Dispose();
            }
            return resultado;
        }
    }
}
