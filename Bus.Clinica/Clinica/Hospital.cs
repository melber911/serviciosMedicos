using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ent.Sql.ClinicaE.HospitalE;
using Dat.Sql.ClinicaAD.HospitalAD;

#region Información General de la Clase
/// <remarks>
/// DETALLAR CORRECTAMENTE LOS CAMBIOS EN LA CLASE DEBIDO A QUE ESTO ES DOCUMENTACION
/// IMPORTANTE PARA ENTENDER EL FUNCIONAMIENTO DE ESTE.
/// ==========================================================================================
/// INFORMACION GENERAL
/// ==========================================================================================
/// Proyecto                : Bus.Cllinica
/// Desarrollado por        : JCAICEDO
/// Formulario              : 
/// Dependiente de Clase    : 
/// Fecha                   : 
/// ==========================================================================================
/// @Copyright Clinica San Felipe S.A.C. 2020. Todos los derechos reservados.
/// ==========================================================================================
/// DESCRIPCION FUNCIONAL:
///  Servira para interactuar con los datos de hospital.
/// =========================================================================================
/// ACCIONES O EVENTOS RELEVANTES
///  
/// ==========================================================================================
/// Log
///  Fecha       Autor      Nro.    Req.Comentario
///  31/07/2020  JCAICEDO
/// ==========================================================================================
/// </remarks>
#endregion

namespace Bus.Clinica
{
    public class Hospital
    {
        HospitalAD objHospitalAD = new HospitalAD();

        #region Sp_Hospital_Consulta        
        public List<HospitalE> Sp_Hospital_Consulta(HospitalE objHospitalE)
        {
            List<HospitalE> oListHospitalResultE = new List<HospitalE>();
            try
            {
                //Logica y Validación para la confirmación de los correos de los pacientes.
                if (objHospitalE.Orden == 14)
                {
                    List<HospitalE> oListHospitalE = new List<HospitalE>();
                    HospitalE oHospitalE = new HospitalE();
                    oListHospitalE = objHospitalAD.Sp_Hospital_Consulta(objHospitalE);

                    for (int i = 0; i < oListHospitalE.Count; i++)
                    {
                        if (oListHospitalE[i].CodTipo == objHospitalE.CodTipo)
                        {
                            oHospitalE = oListHospitalE[0];
                            if (oHospitalE.FlagCorreo == "1")
                                new Exception("Correo_Confirmado");
                            else if (oHospitalE.Correo == "" || oHospitalE.Correo != objHospitalE.Correo)
                                new Exception("Error_Correo");
                            else
                                oListHospitalResultE.Add(oListHospitalE[i]);
                        }
                        else
                            new Exception("Error_Cod_Tipo");
                    }
                }
                else
                    oListHospitalResultE = objHospitalAD.Sp_Hospital_Consulta(objHospitalE);

                return oListHospitalResultE;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        #endregion

        #region Sp_Hospitaladmision_UpdatexCampo
        public void Sp_HospitalAdmision_UpdatexCampo(HospitalAdmisionE pHospitaladmisionE)
        {
            HospitalAdmisionAD objHospitalAdmisionAD = new HospitalAdmisionAD();
            objHospitalAdmisionAD.Sp_HospitalAdmision_UpdatexCampo(pHospitaladmisionE);
        }
        #endregion
    }
}