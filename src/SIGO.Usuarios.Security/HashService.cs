using SIGO.Usuarios.Application.Services;
using System.Security.Cryptography;
using System.Text;

namespace SIGO.Usuarios.Security
{
    public class HashService : IHashService
    {
        public string Hash(string text)
        {
            using (var sha512Managed = new SHA512Managed())
            {
                var bytes = sha512Managed.ComputeHash(Encoding.ASCII.GetBytes(text));
                var builder = new StringBuilder(string.Empty);

                foreach (var textByte in bytes)
                {
                    builder.Append(textByte.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
