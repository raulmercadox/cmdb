using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace CMDBApplication.Repository
{
    public abstract class Repository
    {
        protected SqlConnection Conexion { get; set; }

        public Repository()
        {
            Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadcon"].ConnectionString);
        }

        public Repository(string cadcon)
        {
            Conexion = new SqlConnection(cadcon);
        }
    }
}
