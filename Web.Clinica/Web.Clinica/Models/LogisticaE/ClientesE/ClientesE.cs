using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.LogisticaE.ClientesE
{
    public class ClientesE
    {
        public string CodCliente { get; set; } = "";
        public string CodPaciente { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string DocIdentidad { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string CodDistrito { get; set; } = "";
        public string CodProvincia { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string CodCivil { get; set; } = "";
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public string Sexo { get; set; } = "";
        public string TipDocIdentidad { get; set; } = "";
        public string Ruc { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public string Estado { get; set; } = "";
        public string Vip { get; set; } = "";
        public string Correo { get; set; } = "";
        public string CodTipoPersona { get; set; } = "";
        public string DscApPaterno { get; set; } = "";
        public string DscApMaterno { get; set; } = "";
        public string DscSegundoNombre { get; set; } = "";
        public string DscPrimerNombre { get; set; } = "";
        public string CodUbigeo { get; set; } = "";
        public string CardCode { get; set; } = "";
        public bool FlgEnvioSap { get; set; } = false;
        public DateTime FecEnvioSap { get; set; } = DateTime.Now;
        public int IdeDocentrySap { get; set; } = 0;
        public DateTime FecDocentrySap { get; set; } = DateTime.Now;
        public string CodClienteAnterior { get; set; } = "";
        public DateTime FecBaja { get; set; } = DateTime.Now;
        public string UsrBaja { get; set; } = "";
        public DateTime FecRecepcionSap { get; set; } = DateTime.Now;
        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;
        public string Buscar { get; set; } = "";
        public string NumeroLineas { get; set; } = "";
        public string Key { get; set; } = "";


        public ClientesE()
        {
        }

        public ClientesE(string pCodcliente)
        {
            CodCliente = pCodcliente;
        }

        public ClientesE(string pCodcliente, string pNuevoValor, string pCampo)
        {
            CodCliente = pCodcliente;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public ClientesE(string pBuscar, string pKey, string pNumeroLineas, int pOrden)
        {
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
        }

        /// <summary>
        ///         ''' Sirve para el store *Sp_Clientes_Insert_App*
        ///         ''' </summary>
        ///         ''' <param name="pCodCliente"></param>
        ///         ''' <param name="pCodPaciente"></param>
        ///         ''' <param name="pDscPrimerNombre"></param>
        ///         ''' <param name="pDscSegundoNombre"></param>
        ///         ''' <param name="pDscApPaterno"></param>
        ///         ''' <param name="pDscApMaterno"></param>
        ///         ''' <param name="pDocIdentidad"></param>
        ///         ''' <param name="pTipDocIdentidad"></param>
        ///         ''' <param name="pDireccion"></param>
        ///         ''' <param name="pTelefono"></param>
        ///         ''' <param name="pSexo"></param>
        ///         ''' <param name="pCorreo"></param>
        ///         ''' <param name="pCodUbigeo"></param>
        ///         ''' <param name="pFecNacimiento"></param>
        ///         ''' <param name="pRuc"></param>
        ///         ''' <param name="pCodTipoPersona"></param>
        ///         ''' <param name="pObservaciones"></param>
        ///         ''' <param name="pCodCivil"></param>
        public ClientesE(string pCodCliente, string pCodPaciente, string pDscPrimerNombre, string pDscSegundoNombre, string pDscApPaterno, string pDscApMaterno, string pDocIdentidad, string pTipDocIdentidad, string pDireccion, string pTelefono, string pSexo, string pCorreo, string pCodUbigeo, DateTime pFecNacimiento, string pRuc, string pCodTipoPersona, string pObservaciones, string pCodCivil)
        {
            CodCliente = pCodCliente;
            CodPaciente = pCodPaciente;
            DscPrimerNombre = pDscPrimerNombre;
            DscSegundoNombre = pDscSegundoNombre;
            DscApPaterno = pDscApPaterno;
            DscApMaterno = pDscApMaterno;
            DocIdentidad = pDocIdentidad;
            TipDocIdentidad = pTipDocIdentidad;
            Direccion = pDireccion;
            Telefono = pTelefono;
            Sexo = pSexo;
            Correo = pCorreo;
            CodUbigeo = pCodUbigeo;
            FechaNacimiento = pFecNacimiento;
            Ruc = pRuc;
            CodTipoPersona = pCodTipoPersona;
            Observaciones = pObservaciones;
            CodCivil = pCodCivil;
        }
    }
}
