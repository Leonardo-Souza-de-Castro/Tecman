using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Utils
{
    public static class Cripto
    {
        public static string Gerar_Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Comparar(string senhalogin, string Hash)
        {
            return BCrypt.Net.BCrypt.Verify(senhalogin, Hash);
        }
    }
}
