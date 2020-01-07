using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Payroll.Models.Daos
{
    public class PruebaEmpresaDao : Conexion
    {

        public List<PruebaEmpresaBean> sp_Retrieve_PruevaEmpresas()
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        NombreEmpresa = data["NombreEmpresa"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<PruebaEmpresaBean> sp_Retrieve_NombreEmpresas()
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            //cmd.Parameters.Add(new SqlParameter("@ctrlNombreEmpresa", txt));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        RazonSocial = data["NombreEmpresa"].ToString(),
                        NombreEmpresa = data["NombreCorto"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }

        public int sp_Retrieve_ClaveEmpresa()
        {
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_ClaveEmpresa", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            int ClaveEmpresa = 0;
            if (data.HasRows)
            {
                while (data.Read())
                {
                    ClaveEmpresa = int.Parse(data["max"].ToString());
                }
            }
            data.Close();
            return ClaveEmpresa + 1;
        }
        public List<PruebaEmpresaBean> sp_Retrieve_NombreEmpresa(int IdEmpresa)
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        RazonSocial = data["NombreEmpresa"].ToString(),
                        NombreEmpresa = data["NombreCorto"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<string> sp_Insert_FirstStep_Empresas(string nom, string nomc, string rfc, string giro, int usuario_id)
        {
            List<string>res = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Insert_FirstStep_Empresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlsNombreEmpresa", nomc));
            cmd.Parameters.Add(new SqlParameter("@ctrlsRazonSocial", nom));
            cmd.Parameters.Add(new SqlParameter("@ctrlsGiro", giro));
            cmd.Parameters.Add(new SqlParameter("@ctrlsRFC", rfc));
            cmd.Parameters.Add(new SqlParameter("ctrliUsuarioAltaId", usuario_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    res.Add(data["iFlag"].ToString());
                    res.Add(data["sRespuesta"].ToString()); ;
                }
            }
            else
            {
                res.Add("Error");
            }
            data.Close();
            return res;
        }



    }
}