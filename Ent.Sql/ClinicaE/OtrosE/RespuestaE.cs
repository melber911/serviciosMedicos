using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    /// <summary>
    /// Se devolvera la respuesta, falso devolvera mensaje de error, verdadero no devolvera nada.
    /// </summary>
    public class RespuestaE
    {
        public bool Respuesta { get; set; } = false;
        public string Descripcion { get; set; } = "";
        public string DescripcionTraceCodigo { get; set; } = "";
        public bool Continuar { get; set; } = true;

        public RespuestaE()
        {
        }

        public RespuestaE(bool pRespuesta, string pDescripcion)
        {
            Respuesta = pRespuesta;
            Descripcion = pDescripcion;
        }

        public RespuestaE(bool pRespuesta, string pDescripcion, string pDescripcionTraceCodigo)
        {
            Respuesta = pRespuesta;
            Descripcion = pDescripcion;
            DescripcionTraceCodigo = pDescripcionTraceCodigo;
        }

        public RespuestaE(bool pRespuesta, string pDescripcion, string pDescripcionTraceCodigo, bool pContinuar)
        {
            Respuesta = pRespuesta;
            Descripcion = pDescripcion;
            DescripcionTraceCodigo = pDescripcionTraceCodigo;
            Continuar = pContinuar;
        }
    }
}
