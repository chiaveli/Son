using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Son.Comum.Infra
{
    /// <summary>
    /// 
    /// </summary>
    public static class CriptografiaAES
    {
        // Chave Externa
        private static byte[] _chaveExterna = { 0x6A, 0x8F, 0X45, 0xA1, 0xE2, 0x41, 0xCC, 0x4A, 0x1F, 0xF1, 0xAF, 0x19, 0x1A, 0xDD, 0xA2, 0x19 };
        // Chave Interna
        private const string _chaveInterna = "Wef+/>eDr#sDk$5%dFD?tMSTTRF74Tr=";

        /// <summary>
        /// Criptografa uma string utilizando algorítmo AES.
        /// </summary>
        /// <param name="pTexto">String a ser criptografada.</param>
        /// <returns>String criptografada.</returns>
        public static string Criptografar(string pTexto)
        {
            try
            {
                string chaveBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_chaveInterna), Base64FormattingOptions.InsertLineBreaks);

                if (!string.IsNullOrEmpty(pTexto))
                {
                    byte[] textoSerializado, chaveSerializada;

                    chaveSerializada = Convert.FromBase64String(chaveBase64);
                    textoSerializado = new UTF8Encoding().GetBytes(pTexto);

                    Rijndael rijnDael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Chaves possíves: 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)

                    rijnDael.KeySize = 256;

                    MemoryStream streamCriptografador = new MemoryStream();
                    CryptoStream criptografar = new CryptoStream(streamCriptografador, rijnDael.CreateEncryptor(chaveSerializada, _chaveExterna), CryptoStreamMode.Write);

                    criptografar.Write(textoSerializado, 0, textoSerializado.Length);
                    criptografar.FlushFinalBlock();

                    return Convert.ToBase64String(streamCriptografador.ToArray());
                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criptografar: \n\r" + ex.Message, ex);
            }
        }

        /// <summary>
        /// Descriptografa uma string utilizando algorítmo AES.
        /// </summary>
        /// <param name="pTexto">String a ser descriptografada.</param>
        /// <returns>String descriptografada.</returns>
        public static string Descriptografar(string pTexto)
        {
            try
            {

                string chaveBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_chaveInterna), Base64FormattingOptions.InsertLineBreaks);

                if (!string.IsNullOrEmpty(pTexto))
                {
                    byte[] textoSerializado, chaveSerializada;

                    chaveSerializada = Convert.FromBase64String(chaveBase64);
                    textoSerializado = Convert.FromBase64String(pTexto);

                    Rijndael rijnDael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // chaves possíves: 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)

                    rijnDael.KeySize = 256;

                    MemoryStream streamCriptografador = new MemoryStream();
                    CryptoStream descriptografar = new CryptoStream(streamCriptografador, rijnDael.CreateDecryptor(chaveSerializada, _chaveExterna), CryptoStreamMode.Write);

                    descriptografar.Write(textoSerializado, 0, textoSerializado.Length);
                    descriptografar.FlushFinalBlock();
                    UTF8Encoding utf8 = new UTF8Encoding();
                    return utf8.GetString(streamCriptografador.ToArray());
                }

                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao descriptografar: \n\r" + ex.Message, ex);
            }
        }
    }
}
