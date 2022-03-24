using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Utilities
{
    public class Validations
    {
        public enum TipoCadena
        {
            Nombres = 1,
            Correo = 2,
            Dni = 3,
            Fecha = 4,
            Hora = 5,
            FechaHora = 6
        }

        public enum TipoValidacion
        {
            Numerico = 1,
            DecimalP = 2,
            DocumentoIdentidad = 3,
            Fecha = 4,
            Hora = 5,
            FechaHora = 6,
            Direccion = 11,
            Correo = 12,
            Nombres = 13
        }

        /// <summary>
        ///     ''' Devuelve verdadero cuando no hubo ningún error en la cadena enviada
        ///     ''' </summary>
        ///     ''' <param name="pCadena"></param>
        ///     ''' <param name="pTipoCadena"></param>
        ///     ''' <returns></returns>
        public static bool ValidarCadena(string pCadena, TipoCadena pTipoCadena)
        {
            bool xResult = false;
            string xCadenaResultado = "";
            switch (pTipoCadena)
            {
                case TipoCadena.Nombres:
                    {
                        foreach (char pKey in pCadena)
                            xCadenaResultado += xCadenaResultado + Validacion(pKey, TipoValidacion.Nombres);
                        if (xCadenaResultado == pCadena)
                            xResult = true;
                        break;
                    }

                case TipoCadena.Correo:
                    {
                        xResult = true;
                        break;
                    }

                case TipoCadena.Dni:
                    {
                        foreach (char pKey in pCadena)
                            xCadenaResultado += xCadenaResultado + Validacion(pKey, TipoValidacion.DocumentoIdentidad);
                        if (xCadenaResultado == pCadena)
                            xResult = true;
                        break;
                    }

                case TipoCadena.Fecha:
                    {
                        xResult = true;
                        break;
                    }
            }

            return xResult;
        }

        /// <summary>
        ///     ''' 
        ///     ''' </summary>
        ///     ''' <param name="pKey"></param>
        ///     ''' <param name="pTipoLetra"></param>
        ///     ''' <returns></returns>
        public static char Validacion(char pKey, TipoValidacion pTipoLetra)
        {
            char xResult = '\r';
            int xAscii = (int)pKey;

            switch (pTipoLetra)
            {
                case TipoValidacion.Numerico:
                    {
                        if (xAscii >= 48 & xAscii <= 57)
                            xResult = pKey;
                        else
                            xResult = '\r';
                        break;
                    }

                case TipoValidacion.Nombres:
                    {
                        if (xAscii >= 65 & xAscii <= 90 | xAscii == 32)
                            xResult = pKey;
                        break;
                    }

                case TipoValidacion.DocumentoIdentidad:
                    {
                        if (xAscii >= 48 & xAscii <= 57)
                            xResult = pKey;
                        break;
                    }
            }

            return xResult;
        }
    }
}