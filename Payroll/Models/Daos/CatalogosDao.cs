using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Payroll.Models.Daos
{
    public class CatalogosDao { }

    public class CatalogoGeneralDao : Conexion
    {
        public List<CatalogoGeneralBean> sp_CatalogoGeneral_Consulta_CatalogoGeneral(int state, string type, int keycat, int keycam)
        {
            List<CatalogoGeneralBean> listCatGenBean = new List<CatalogoGeneralBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CatalogoGeneral_Consulta_CatalogoGeneral", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlId", keycat));
                cmd.Parameters.Add(new SqlParameter("@ctrlCampoCatalogoId", keycam));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CatalogoGeneralBean catGenBean = new CatalogoGeneralBean();
                        catGenBean.iId = Convert.ToInt32(data["id"].ToString());
                        catGenBean.iCampoCatalogoId = Convert.ToInt32(data["Campos_Catalogo_Id"].ToString());
                        catGenBean.sValor = data["Valor"].ToString();
                        catGenBean.iIdValor = Convert.ToInt32(data["IdValor"].ToString());
                        if (keycat != 0)
                        {
                            catGenBean.sDescripcion = (String.IsNullOrEmpty(data["Descripcion"].ToString())) ? "Sin resultado" : data["Descripcion"].ToString();
                            catGenBean.iCancelado = Convert.ToInt32(data["Cancelado"].ToString());
                            catGenBean.iIdUsuAlta = Convert.ToInt32(data["UsuAlta_id"].ToString());
                            catGenBean.sFechaAlta = data["FechaAlta"].ToString();
                        }
                        listCatGenBean.Add(catGenBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listCatGenBean;
        }
    }

    public class InfDomicilioDao : Conexion
    {

        public List<InfDomicilioBean> sp_CatalogoGeneral_Retrieve_CatalogoGeneral(int catalogid)
        {
            List<InfDomicilioBean> listInfDomBean = new List<InfDomicilioBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CatalogoGeneral_Retrieve_CatalogoGeneral", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCatalogoId", catalogid));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        InfDomicilioBean infDomBean = new InfDomicilioBean();
                        infDomBean.iIdValor = Convert.ToInt32(data["IdValor"].ToString());
                        infDomBean.sValor = data["Valor"].ToString();
                        infDomBean.iId = Convert.ToInt32(data["id"].ToString());
                        listInfDomBean.Add(infDomBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listInfDomBean;
        }

        public List<InfDomicilioBean> sp_Domicilio_Retrieve_Domicilio(int codepost)
        {
            List<InfDomicilioBean> listInfDomBean = new List<InfDomicilioBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Domicilio_Retrieve_Domicilio", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCodigoPostal", codepost));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        InfDomicilioBean infDomBean = new InfDomicilioBean();
                        infDomBean.sCiudad = data["Ciudad"].ToString();
                        infDomBean.iIdColonia = Convert.ToInt32(data["IdColonia"].ToString());
                        infDomBean.sColonia = data["Colonia"].ToString();
                        infDomBean.iIdMunicipio = Convert.ToInt32(data["IdMunicipio"].ToString());
                        infDomBean.sMensaje = data["Municipio"].ToString();
                        infDomBean.sValor = data["Estado"].ToString();
                        listInfDomBean.Add(infDomBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listInfDomBean;
        }

    }

    public class NivelEstudiosDao : Conexion
    {
        public List<NivelEstudiosBean> sp_NivelEstudios_Retrieve_NivelEstudios(int state, string type, int keynivel)
        {
            List<NivelEstudiosBean> listNivEstBean = new List<NivelEstudiosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_NivelEstudios_Retrieve_NivelEstudios", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoNivelEstudio", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdNivelEstudio", keynivel));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NivelEstudiosBean nivEstBean = new NivelEstudiosBean();
                        nivEstBean.iIdNivelEstudio = Convert.ToInt32(data["IdNivelEstudio"].ToString());
                        nivEstBean.sNombreNivelEstudio = data["NombreNivelEstudio"].ToString();
                        if (keynivel != 0)
                        {
                            nivEstBean.iEstadoNivelEstudio = Convert.ToInt32(data["EstadoNivelEstudio"].ToString());
                            nivEstBean.sUsuarioRegistroNivel = data["UsuarioRegistroNivel"].ToString();
                            nivEstBean.sFechaRegistroNivel = data["FechaRegistroNivel"].ToString();
                            nivEstBean.sUsuarioModificaNivel = (String.IsNullOrEmpty(data["UsuarioModificaNivel"].ToString())) ? "Sin resultado" : data["UsuarioModificaNivel"].ToString();
                            nivEstBean.sFechaModificaNivel = (String.IsNullOrEmpty(data["FechaModificaNivel"].ToString())) ? "Sin resultado" : data["FechaModificaNivel"].ToString();
                        }
                        listNivEstBean.Add(nivEstBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listNivEstBean;
        }
    }

    public class TabuladoresDao : Conexion
    {
        public List<TabuladoresBean> sp_Tabuladores_Retrieve_Tabuladores(int state, string type, int keytab)
        {
            List<TabuladoresBean> listTabBean = new List<TabuladoresBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Tabuladores_Retrieve_Tabuladores", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoTabulador", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdTabulador", keytab));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        TabuladoresBean tabBean = new TabuladoresBean();
                        tabBean.iIdTabulador = Convert.ToInt32(data["IdTabulador"].ToString());
                        tabBean.sTabulador = data["Tabulador"].ToString();
                        if (keytab > 0)
                        {
                            tabBean.iEstadoTabulador = Convert.ToInt32(data["EstadoTabulador"].ToString());
                            tabBean.sUsuarioRegistroTabulador = data["UsuarioRegistroTabulador"].ToString();
                            tabBean.sFechaRegistroTabulador = data["FechaRegistroTabulador"].ToString();
                            tabBean.sUsuarioModificaTabulador = (String.IsNullOrEmpty(data["UsuarioModificaTabulador"].ToString())) ? "Sin resultado" : data["UsuarioModificaTabulador"].ToString();
                            tabBean.sFechaModificaTabulador = (String.IsNullOrEmpty(data["FechaModificaTabulador"].ToString())) ? "Sin resultado" : data["FechaModificaTabulador"].ToString();
                        }
                        listTabBean.Add(tabBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listTabBean;
        }
    }

    public class BancosDao : Conexion
    {
        public List<BancosBean> sp_Bancos_Retrieve_Bancos(int state, string type, int keyban)
        {
            List<BancosBean> listBanBean = new List<BancosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Bancos_Retrieve_Bancos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoBanco", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdBanco", keyban));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        BancosBean banBean = new BancosBean();
                        banBean.iIdBanco = Convert.ToInt32(data["IdBanco"].ToString());
                        banBean.sNombreBanco = data["NombreBanco"].ToString();
                        banBean.iClave = Convert.ToInt32(data["Clave"].ToString());
                        if (keyban != 0)
                        {
                            banBean.iEstadoBanco = Convert.ToInt32(data["EstadoBanco"].ToString());
                            banBean.sUsuarioRegistroBanco = data["UsuarioRegistroBanco"].ToString();
                            banBean.sFechaRegistroBanco = data["FechaRegistroBanco"].ToString();
                            banBean.sUsuarioModificaBanco = (String.IsNullOrEmpty(data["UsuarioModificaBanco"].ToString())) ? "Sin resultado"
                                : data["UsuarioModificaBanco"].ToString();
                            banBean.sFechaModificaBanco = (String.IsNullOrEmpty(data["FechaModificaBanco"].ToString())) ? "Sin resultado"
                                : data["FechaModificaBanco"].ToString();
                        }
                        listBanBean.Add(banBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listBanBean;
        }
    }

}