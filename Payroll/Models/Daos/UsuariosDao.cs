﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payroll.Models.Utilerias;
using Payroll.Models.Daos;
using Payroll.Models.Beans;
using System.Data.SqlClient;
using System.Data;

namespace Payroll.Models.Daos
{
    public class UsuariosDao : Conexion
    {

        public UsuariosBean sp_Login_Retrieve_Usuario_Inicia_Sesion(string username, string password)
        {
            UsuariosBean usuBean = new UsuariosBean();
            string encryptPassword = "";
            encryptPassword = Encriptamiento.SHA512(password);
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Login_Retrieve_Usuario_Inicia_Sesion", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlsUsuario",  username));
                cmd.Parameters.Add(new SqlParameter("@ctrlsPassword", encryptPassword));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    if (data["sRespuesta"].ToString() == "") {
                        usuBean.iIdUsuario = int.Parse(data["iIdUsuario"].ToString());
                        usuBean.iPerfil    = int.Parse(data["iPerfil"].ToString());
                        
                        usuBean.sUsuario   = data["sUsuario"].ToString();
                        usuBean.sMensaje   = "success";
                    } else {
                        usuBean.sMensaje = data["sRespuesta"].ToString();
                    }
                } else {
                    usuBean.sMensaje = data["sRespuesta"].ToString();
                }
                cmd.Dispose();
                data.Close();
                conexion.Close();
            }
            catch (Exception exc) {
                Console.WriteLine(exc);
                usuBean.sMensaje = "Error - Catch " + exc.ToString();
            }
            return usuBean;
        }

    }
}