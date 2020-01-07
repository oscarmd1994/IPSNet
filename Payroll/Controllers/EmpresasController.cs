using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll.Models.Beans;
using Payroll.Models.Daos;


namespace Payroll.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public JsonResult LoadSEmp()
        {
            List<PruebaEmpresaBean> empresas;
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_PruevaEmpresas();

            return Json(empresas);
        }
        public PartialViewResult Datos_Generales()
        {

            return PartialView();
        }
        public JsonResult New_ClaveEmpresa()
        {
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int ClaveEmpresa = Dao.sp_Retrieve_ClaveEmpresa();
            return Json(ClaveEmpresa);
        }
        public JsonResult LoadEmpresas()
        {
            List<PruebaEmpresaBean> empresas;
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_NombreEmpresas();
            string btnsEmpresas = "<div class='row'>";
            foreach (var item in empresas)
            {
                btnsEmpresas += "" +
                    "<div class='col-12 col-md-4 col-lg-3 col-sm-6'>" +
                        "<div class='input-group mb-3'>" +
                            "<div class='input-group-prepend'>" +
                                "<div class='input-group-text text-dark bg-white'><i class='fas fa-city'></i></div>" +
                            "</div>" +
                            "<div class='form-control btn btn-menu btnsEmpresas' onclick='btnsEmpresas(\"" + item.IdEmpresa + "\",\"" + item.NombreEmpresa + "\")'>" +
                                
                                "<small class=''>" + item.NombreEmpresa + "</small>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "";
            }
            btnsEmpresas += "</div>";
            return Json(btnsEmpresas);
        }
        [HttpPost]
        public JsonResult SearchEmpresas(int txt)
        {
            List<PruebaEmpresaBean> empresas = new List<PruebaEmpresaBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_NombreEmpresa(txt);
            return Json(empresas);
        }
         [HttpPost]
        public JsonResult Insert_Empresa_FirstStep(string nom,string nomc, string rfc, string giro)
        {
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            return Json(Dao.sp_Insert_FirstStep_Empresas(nom, nomc, rfc, giro, int.Parse(Session["iIdUsuario"].ToString())));
        }

    }
}