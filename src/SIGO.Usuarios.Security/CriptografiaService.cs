using Microsoft.Extensions.Configuration;
using SIGO.Usuarios.Application.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace SIGO.Usuarios.Security
{
    public class CriptografiaService : ICriptografiaService
    {
        public CriptografiaService(IConfiguration configuration)
        {
            Chave = configuration["SIGOCriptografia:key"];
            IV = configuration["SIGOCriptografia:iv"];
        }

        public string Chave { get; }
        public string IV { get; }

        public string Criptografar(string texto)
        {
            using (var rijndael = Rijndael.Create())
            {
                rijndael.Key = Encoding.ASCII.GetBytes(Chave);
                rijndael.IV = Encoding.ASCII.GetBytes(IV);

                var encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                var stream = new MemoryStream();
                var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);

                using (var writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(texto);
                }

                var bytes = stream.ToArray();
                var hex = Array.ConvertAll(bytes, b => b.ToString("X2"));

                return string.Concat(hex);
            }
        }

        public string Descriptografar(string textoCriptografado)
        {
            using (var rijndael = Rijndael.Create())
            {
                rijndael.Key = Encoding.ASCII.GetBytes(Chave);
                rijndael.IV = Encoding.ASCII.GetBytes(IV);

                var decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                var qtdeBytes = textoCriptografado.Length / 2;
                var arrayConteudoCriptografado = new byte[qtdeBytes];

                for (int i = 0; i < qtdeBytes; i++)
                {
                    arrayConteudoCriptografado[i] = Convert.ToByte(textoCriptografado.Substring(i * 2, 2), 16);
                }

                var streamTextoCriptografado = new MemoryStream(arrayConteudoCriptografado);
                string textoDecriptografado = null;
                var csStream = new CryptoStream(streamTextoCriptografado, decryptor, CryptoStreamMode.Read);

                using (StreamReader reader = new StreamReader(csStream))
                {
                    textoDecriptografado = reader.ReadToEnd();
                }

                return textoDecriptografado;
            }
        }
    }
}
