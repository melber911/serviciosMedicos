using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Oracle.MedisynE.ReservasE
{
    public class AmReservaE
    {
        public string CodProf { get; set; } = "";
        public string IdAmbulatorio { get; set; } = "";
        public string IdCorrelReserva { get; set; } = "";

        public int CorrelHorario { get; set; } = 0;

        public DateTime FecIngresoReserva { get; set; }
        public DateTime FecReserva { get; set; }
        public DateTime HoraReserva { get; set; }
        public int IdPaciente { get; set; }
        public int IdPacienteReserva { get; set; }
        public int CodSucursal { get; set; }
        public int CodEspecialidad { get; set; }
        public string EmailPaciente { get; set; } = "";
        public string Medico { get; set; } = "";

        public string BoxReserva { get; set; } = "";
        public string CodUnidad { get; set; } = "";
        public string DescUnidad { get; set; } = "";
        public string RutPaciente { get; set; } = "";
        public string RutPacienteTitular { get; set; } = "";

        public string DscSucursal { get; set; } = "";
        // Extensiones
        public int ORDEN { get; set; }
        public string FecReserva_String { get; set; } = "";


        public AmReservaE()
        {
        }

        // #Region "New(pID_CORREL_RESERVA)"
        // Public Sub New(ByVal pID_CORREL_RESERVA As String)
        // IdCorrelReserva = pID_CORREL_RESERVA
        // End Sub
        // #End Region

        public AmReservaE(int pOrden, string pID_CORREL_RESERVA)
        {
            IdCorrelReserva = pID_CORREL_RESERVA;
            ORDEN = pOrden;
        }
    }




    // NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class AgendaDatos
    {
        public byte cOD_SUCURSAL { get; set; }
        public string sUCURSAL { get; set; } = "";
        public ushort cOD_PROF { get; set; }
        public uint rUT_PROF { get; set; }
        public string aPEPAT_PROF { get; set; } = "";
        public string aPEMAT_PROF { get; set; } = "";
        public string nOMBRE1_PROF { get; set; } = "";
        public byte cOD_ESPECIALIDAD { get; set; }
        public string dESC_ITEM { get; set; } = "";
        public ushort cORRAGENDA { get; set; }
        public string fECHAINICPROX_AGENDA { get; set; } = "";
        public string fECHA_SISTEMA { get; set; } = "";
        public byte cOD_UNIDAD { get; set; }
        public string dESC_UNIDAD { get; set; } = "";
        public byte hMUL { get; set; }
        public string vERSTAFF { get; set; } = "";
        public DateTime pROXIMA_HORA_DISPONIBLE { get; set; }
        public string pROXIMA_HORA_DISPONIBLE_CHAR { get; set; } = "";
    }
}
