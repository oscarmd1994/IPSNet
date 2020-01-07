namespace Payroll.Models.Beans
{
    public class CatalogosBean
    {
    }

    public class CatalogoGeneralBean
    {
        public int iId { get; set; }
        public int iCampoCatalogoId { get; set; }
        public int iIdValor { get; set; }
        public string sValor { get; set; }
        public string sDescripcion { get; set; }
        public int iCancelado { get; set; }
        public int iIdUsuAlta { get; set; }
        public string sFechaAlta { get; set; }
        public string sMensaje { get; set; }
    }

    public class InfDomicilioBean
    {

        // Beans catalogo general estados \\
        public int iId { get; set; }
        public int iIdValor { get; set; }
        public string sValor { get; set; }
        public int iIdCodigoPostal { get; set; }
        public string sCiudad { get; set; }
        public int iIdColonia { get; set; }
        public string sColonia { get; set; }
        public int iIdMunicipio { get; set; }
        public string sMensaje { get; set; }
    }

    public class NivelEstudiosBean
    {
        public int iIdNivelEstudio { get; set; }
        public string sNombreNivelEstudio { get; set; }
        public int iEstadoNivelEstudio { get; set; }
        public string sUsuarioRegistroNivel { get; set; }
        public string sFechaRegistroNivel { get; set; }
        public string sUsuarioModificaNivel { get; set; }
        public string sFechaModificaNivel { get; set; }
        public string sMensaje { get; set; }
    }

    public class TipoSangreBean
    {
        public int iIdTipoSangre { get; set; }
        public string sNombreTipoSangre { get; set; }
        public int iEstadoTipoSangre { get; set; }
        public string sUsuarioRegistroTipo { get; set; }
        public string sFechaRegistroTipo { get; set; }
        public string sUsuarioModificaTipo { get; set; }
        public string sFechaModificaTipo { get; set; }
        public string sMensaje { get; set; }
    }

    public class TabuladoresBean
    {
        public int iIdTabulador { get; set; }
        public string sTabulador { get; set; }
        public int iEstadoTabulador { get; set; }
        public string sUsuarioRegistroTabulador { get; set; }
        public string sFechaRegistroTabulador { get; set; }
        public string sUsuarioModificaTabulador { get; set; }
        public string sFechaModificaTabulador { get; set; }
        public string sMensaje { get; set; }
    }

    public class BancosBean
    {
        public int iIdBanco { get; set; }
        public string sNombreBanco { get; set; }
        public int iClave { get; set; }
        public int iEstadoBanco { get; set; }
        public string sUsuarioRegistroBanco { get; set; }
        public string sFechaRegistroBanco { get; set; }
        public string sUsuarioModificaBanco { get; set; }
        public string sFechaModificaBanco { get; set; }
        public string sMensaje { get; set; }
    }
}