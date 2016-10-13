using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LegalApp.Common
{
    public class Encryption
    {
        #region Private Variable
        private static string Key = "kd235f95123b1256";
        #endregion

        #region Encrypt / Decrypt PlainText And String
        /// <summary>
        /// Encrypt PlainText 
        /// Created: 22-FEB-16 by CIPL/VivekParekh 
        /// <param name="PlainText"></param>
        /// </summary>
        /// <returns>Encrypted String</returns>
        public static string Encrypt(String PlainText)
        {
            string Encrypted = null;
            try
            {
                byte[] InputBytes = ASCIIEncoding.ASCII.GetBytes(PlainText);
                byte[] Pwdhash = null;
                MD5CryptoServiceProvider Hashmd5;
                Hashmd5 = new MD5CryptoServiceProvider();
                Pwdhash = Hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                Hashmd5 = null;
                TripleDESCryptoServiceProvider TdesProvider = new TripleDESCryptoServiceProvider();
                TdesProvider.Key = Pwdhash;
                TdesProvider.Mode = CipherMode.ECB;
                Encrypted = System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(
                    TdesProvider.CreateEncryptor().TransformFinalBlock(InputBytes, 0, InputBytes.Length)));
            }
            catch
            {
                throw;
            }
            return Encrypted;
        }

        /// <summary>
        /// Decrypt EncryptedString 
        /// Created: 22-FEB-16 by CIPL/VivekParekh 
        /// <param name="EncryptedString"></param>
        /// </summary>
        /// <returns>Decyprted String</returns>
        public static String Decrypt(string EncryptedString)
        {
            string Decyprted = null;
            byte[] InputBytes = null;

            try
            {
                InputBytes = Convert.FromBase64String(System.Web.HttpUtility.UrlDecode(EncryptedString).Replace(" ", "+"));
                byte[] Pwdhash = null;
                MD5CryptoServiceProvider Hashmd5;
                Hashmd5 = new MD5CryptoServiceProvider();
                Pwdhash = Hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                Hashmd5 = null;
                TripleDESCryptoServiceProvider TdesProvider = new TripleDESCryptoServiceProvider();
                TdesProvider.Key = Pwdhash;
                TdesProvider.Mode = CipherMode.ECB;
                Decyprted = ASCIIEncoding.ASCII.GetString(
                    TdesProvider.CreateDecryptor().TransformFinalBlock(InputBytes, 0, InputBytes.Length));
            }
            catch
            {
                throw;
            }
            return Decyprted;
        }

        /// <summary>
        /// DecryptQueryString.
        /// Created: 22-FEB-16 by CIPL/VivekParekh 
        /// <param name="cryptedString"></param>
        /// </summary>
        /// <returns>Orignal String</returns>
        public static string DecryptQueryString(string cryptedString)
        {
            cryptedString = HttpUtility.UrlDecode(cryptedString);
            cryptedString = cryptedString.Replace(" ", "+");
            cryptedString = cryptedString.Replace("@@@", "+");
            cryptedString = cryptedString.Replace("~", "/");
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("013A1V1a");
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            //return HttpUtility.UrlDecode(reader.ReadToEnd());
            return HttpUtility.HtmlDecode(reader.ReadToEnd());
        }

        /// <summary>
        /// EncryptQueryString.
        /// Created: 22-FEB-16 by CIPL/VivekParekh 
        /// <param name="originalString"></param>
        /// </summary>
        /// <returns>Encrypted string </returns>
        public static string EncryptQueryString(string originalString)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("013A1V1a");
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return HttpUtility.UrlEncode(Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length)).Replace("%2b", "@@@").Replace("%2f", "~");
        }
        #endregion

        #region Password Hash
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 256;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;
        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
        public static string DecryptData(string cipherText)
        {
            string EncryptionKey = "kd235f95123b1256";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public static string Decrypt(string data, string NewPassword)
        {
            MemoryStream Ms = new MemoryStream(Convert.ToByte(data));
            Rfc2898DeriveBytes PasswordKey;
            SymmetricAlgorithm Algo;
            CryptoStream CrStream;
            string Password = NewPassword;
            char[] delimiter = { ':' };
            string[] split = Password.Split(delimiter);
            byte[] SaltString = Convert.FromBase64String(split[SALT_INDEX]);
            Algo = new RijndaelManaged();
            PasswordKey = new Rfc2898DeriveBytes(Password, SaltString);
            Algo.Key = PasswordKey.GetBytes(Algo.KeySize / 8);
            Algo.IV = PasswordKey.GetBytes(Algo.BlockSize / 8);
            ICryptoTransform Decryptor = Algo.CreateDecryptor();
            CrStream = new CryptoStream(Ms, Decryptor, CryptoStreamMode.Read);
            StreamReader Sr = new StreamReader(CrStream);
            return Sr.ReadToEnd();
        }
        #endregion
    }
}