using System.Security.Cryptography;
using System.Text;

namespace KetamaHash
{
    internal class HashAlgorithm
    {
        public static long hash(byte[] digest, int nTime)
        {
            long rv = ((long)(digest[3 + nTime * 4] & 0xFF) << 24)
                    | ((long)(digest[2 + nTime * 4] & 0xFF) << 16)
                    | ((long)(digest[1 + nTime * 4] & 0xFF) << 8)
                    | ((long)digest[0 + nTime * 4] & 0xFF);

            return rv & 0xffffffffL; // Truncate to 32-bits
        }

        /// <summary>
        /// Get the md5 of the given key.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static byte[] computeMd5(string k)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] keyBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(k));
            md5.Clear();
            return keyBytes;
        }
    }
}
