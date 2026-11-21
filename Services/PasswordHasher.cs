using System.Security.Cryptography;
using System.Text;
namespace SdaTithe.Services;

public static class PasswordHasher
{
    public static string Hash(string p) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(p)));
    public static bool Verify(string p, string hash) => Hash(p) == hash;
}