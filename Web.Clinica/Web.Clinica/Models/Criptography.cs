using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Bus.Utilities
{
    public class Criptography
    {
        #region CharactersKey
        /// <summary>
        ///     ''' Character string for the key /Cadena de caracteres para la clave
        ///     ''' </summary>
        private const string CharactersKey = "rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"; // No se puede alterar la cantidad de caracteres.
        #endregion

        #region EncryptKey
        /// <summary>
        ///     ''' Chain for the encrypted key / Cadena para la clave encriptada.
        ///     ''' </summary>
        ///     ''' La clave debe ser de 8 caracteres.
        private const string EncryptKey = "csf3lipe";
        #endregion

        #region EncryptConectionString
        /// <summary>
        ///     ''' Función que devuelve la cadena de conexión o una cadena de texto encriptada.
        ///     ''' </summary>
        ///     ''' <param name="pConectionStringDecrypt">Enviar la cadena de conexión desencriptada.</param>
        ///     ''' <returns></returns>
        public static string EncryptConectionString(string pConectionStringDecrypt)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes(EncryptKey);
            byte[] EncryptionKey = Convert.FromBase64String(CharactersKey);
            byte[] buffer = Encoding.UTF8.GetBytes(pConectionStringDecrypt);
            //TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();            
            TripleDES des = TripleDES.Create();
            des.Key = EncryptionKey;
            des.IV = IV;

            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        #endregion

        #region DecryptConectionString
        /// <summary>
        ///     ''' Función que devuelve la cadena de conexión o una cadena de texto desencriptada.
        ///     ''' </summary>
        ///     ''' <param name="pConectionStringEncrypt">Enviar la cadena de conexión encriptada.</param>
        ///     ''' <returns></returns>
        public static string DecryptConectionString(string pConectionStringEncrypt)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes(EncryptKey);
            byte[] EncryptionKey = Convert.FromBase64String(CharactersKey);
            byte[] buffer = Convert.FromBase64String(pConectionStringEncrypt);
            //TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            TripleDES des = TripleDES.Create();
            des.Key = EncryptionKey;
            des.IV = IV;

            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        #endregion

        #region EncryptPasswordClinica
        /// <summary>
        ///     ''' Encripta la contraseña de los usuarios de las bases de datos (clinica, logistica, ...)
        ///     ''' </summary>
        ///     ''' <param name="Password">Enviar la contraseña que desea encriptar.</param>
        ///     ''' <returns></returns>
        public static string EncryptPasswordClinica(string Password)
        {
            string wqCadenaEncriptada = "";
            int wqLenCodigo = 0;
            int wqi = 1;

            wqLenCodigo = Password.Length;
            while (wqi < wqLenCodigo)
            {
                //wqCadenaEncriptada = wqCadenaEncriptada.Trim + (Password.Substring(wqi, 1) + 17 + (wqi - 1) * 2) ;
                wqi = wqi + 1;
            }

            return wqCadenaEncriptada;
        }
        #endregion

        public class SHA
        {
            public static string GenerateSHA256String(object inputString)
            {
                SHA256 sha256 = SHA256.Create();
                byte[] bytes = Encoding.UTF8.GetBytes((string)inputString);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i <= hash.Length - 1; i++)
                    stringBuilder.Append(hash[i].ToString("X2"));

                return stringBuilder.ToString();
            }

            public static string GenerateSHA512String(object inputString)
            {
                SHA512 sha512 = SHA512.Create();
                byte[] bytes = Encoding.UTF8.GetBytes((string)inputString);
                byte[] hash = sha512.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i <= hash.Length - 1; i++)
                    stringBuilder.Append(hash[i].ToString("X2"));

                return stringBuilder.ToString();
            }
        }
    }
}