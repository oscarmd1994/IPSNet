﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll.Models.Beans;
using Payroll.Models.Daos;

namespace Payroll.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginValidate(string username, string password)
        {
            UsuariosBean usuBean  = new UsuariosBean();
            UsuariosDao usuDao    = new UsuariosDao();
            usuBean               = usuDao.sp_Login_Retrieve_Usuario_Inicia_Sesion(username, password);
            Session["iIdUsuario"] = usuBean.iIdUsuario;
            Session["sUsuario"]   = usuBean.sUsuario;
            //Session de empresa modificar una vez de tengan las tablas necesarias para el funcionamiento
            Session["IdEmpresa"] = 1;
            Session["sEmpresa"] = "";
            /////////////////////////
            Session["Administrador"] = 0; Session["Nomina"] = 0; Session["Incidencias"] = 0; Session["Kiosko"] = 0; Session["RH"] = 0;
            Session["Profile"] = usuBean.iPerfil;
            List<PermisosBean> permBean = new List<PermisosBean>();
            MenuDao menDao = new MenuDao();
            int usuSesion = int.Parse(Session["iIdUsuario"].ToString());
            permBean = menDao.sp_Menu_Retrieve_Permisos_Usuario_Menu(usuSesion);
            foreach (var item in permBean) {
                if (item.sPerfil == "Administrador") { Session["Administrador"] = 1; break; }
            }
            foreach (var item in permBean) {
                if (item.sPerfil == "Nomina") { Session["Nomina"] = 1; break; } 
            }
            foreach (var item in permBean) {
                if (item.sPerfil == "Incidencias") { Session["Incidencias"] = 1; break; }
            }
            foreach (var item in permBean) {
                if (item.sPerfil == "Kiosko") { Session["Kiosko"] = 1; break; }
            } 
            foreach (var item in permBean) {
                if (item.sPerfil == "RH") { Session["RH"] = 1; break; }
            }
            return Json(usuBean);
        }
        public ActionResult Logout()
        {
            Session.Remove("iIdUsuario");
            Session.Remove("sUsuario");
            Session.Remove("Administrador");
            Session.Remove("Profile");
            Session.Remove("sEmpresa");
            Session.Remove("IdEmpresa");
            return Redirect("../Home/Index");
        }

    }
}