using System.Security.Cryptography;
using System.Text;

namespace p1.Utilities
{
    public class Hashing
    {
        public static void hashing( string password , out byte[] hashed ,out byte[] passwordSalt)
        {
            using (var hmac =new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public static string MD5Hashing( string password )
        {
            Byte[] mainb;
            Byte[] encodeb;

            MD5 md5;
            md5 = new MD5CryptoServiceProvider();

            mainb = ASCIIEncoding.Default.GetBytes(password);
            encodeb = md5.ComputeHash(mainb);

            return BitConverter.ToString(encodeb);
        }
    }
}
