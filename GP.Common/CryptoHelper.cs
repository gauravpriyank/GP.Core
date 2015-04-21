using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blowfish_NET;

namespace GP.Common
{
   public class CryptoHelper
    {
       
        //private static readonly byte[] HeaderCharactersBytes = Encoding.ASCII.GetBytes(Constants.EncryptionKeys.HEADER_CHARACTERS);
        //private static readonly byte[] SmallStringHeaderBytes = Encoding.ASCII.GetBytes(Constants.EncryptionKeys.SMALL_STRING_HEADER);
        //private static readonly byte[] EncryptionKeyBytes = Encoding.ASCII.GetBytes(Constants.EncryptionKeys.ENCRYPTION_KEY);

        private static readonly byte[] InitialIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        static CryptoHelper()
        {
        }

        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Encrypts a plain text string using the Blowfish block cipher.
        /// </summary>
        /// <param name="sPlainText"> 
        /// The plain text string to encode.
        /// </param>
        /// <returns>
        /// Hex-encoded ciphertext string.
        /// </returns>

        public static string Encrypt(string sPlainText,byte[] HeaderCharactersBytes,string SMALL_STRING_HEADER,byte[] EncryptionKeyBytes)
        {
            // Encryption Steps - Reverse to Decrypt
            //
            // 1. Convert the clear text into an ASCII byte array 
            // 2. Convert the key ‘CJoTFQOANmSzwIx1’ into an ASCII byte array 
            // 3. Encrypt the clear text byte array with Blowfish 
            // 4. Prepend the 128 bit header ‘!@$*’ to the front of the cipher text 
            // 5. Encode the encrypted byte array to a hex array

            byte[] arrPlainTextBytes;
            StringBuilder sbCiphertextHex = new StringBuilder(ASCIIBytesToHex(HeaderCharactersBytes));

            // If the string being encrypted has 8 or fewer characters,
            // prepend the small string header plus 4 random characters.
            if (sPlainText.Length <= 8)
            {
                string sRandom4 = RandomString(4);
                sPlainText = SMALL_STRING_HEADER + sRandom4 + sPlainText;
            }

            // Convert the plain text string to ASCII byte array
            arrPlainTextBytes = Encoding.ASCII.GetBytes(sPlainText);
            int iPlainTextLen = arrPlainTextBytes.Length;
            int iNumOfBlocks = iPlainTextLen / 8;
            int iLeftOverBytes = iPlainTextLen - (iNumOfBlocks * 8);

            // Encrypt the ASCII byte array, one block at a time, using
            // Blowfish. Then convert the ciphertext ASCII byte array to
            // hex and append it to the final ciphertext string
            byte[] arrLastEncryptedBlock = new byte[8];
            var blowfishcbc = new BlowfishCBC(EncryptionKeyBytes, 0, EncryptionKeyBytes.Length);
            for (int i = 0; i < iNumOfBlocks; i++)
            {
                byte[] arrPlainTextBlock = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    arrPlainTextBlock[j] = arrPlainTextBytes[(i * 8) + j];
                }

                arrLastEncryptedBlock = EncryptBlock(arrPlainTextBlock, blowfishcbc);
                sbCiphertextHex.Append(ASCIIBytesToHex(arrLastEncryptedBlock));
            }

            // If the plain text string contains an incomplete block,
            // encrypt the last complete block again, then XOR that
            // doubly-encrypted block with the incomplete block to
            // get the encrypted bytes.
            if (iLeftOverBytes > 0)
            {
                byte[] arrLastBlockAgain = EncryptBlock(arrLastEncryptedBlock, blowfishcbc);
                byte[] arrXorBytes = new byte[iLeftOverBytes];
                for (int i = 0; i < iLeftOverBytes; i++)
                {
                    byte b1 = arrPlainTextBytes[8 * iNumOfBlocks + i];
                    byte b2 = arrLastBlockAgain[i];
                    byte xorByte = Convert.ToByte(b1 ^ b2);
                    arrXorBytes[i] = xorByte;
                }
                sbCiphertextHex.Append(ASCIIBytesToHex(arrXorBytes));
            }
            return sbCiphertextHex.ToString().Replace(" ", String.Empty);
        }

        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Decrypts a hex-encoded ciphertext string.
        /// </summary>
        /// <param name="sCiphertext"> 
        /// The hex-encoded ciphertext string to decode.
        /// </param>
        /// <returns>
        /// Plain text decrypted string.
        /// </returns>
        public static string Decrypt(string sCiphertext,string HEADER_CHARACTERS,string SMALL_STRING_HEADER,byte[] EncryptionKeyBytes)
        {
            return Decrypt(sCiphertext, Encoding.Default,HEADER_CHARACTERS,SMALL_STRING_HEADER,EncryptionKeyBytes);
        }

        public static string Decrypt(string sCiphertext, Encoding encoding,string HEADER_CHARACTERS,string SMALL_STRING_HEADER,byte[] EncryptionKeyBytes)
        {
            // Encryption Steps - Reverse to Decrypt
            //
            // 1. Convert the clear text into an ASCII byte array 
            // 2. Convert the key ‘CJoTFQOANmSzwIx1’ into an ASCII byte array 
            // 3. Encrypt the clear text byte array with Blowfish 
            // 4. Prepend the 128 bit header ‘!@$*’ to the front of the cipher text 
            // 5. Encode the encrypted byte array to a hex array

            byte[] arrEncryptedBytes;

            // Remove the 128 bit header string from the front of
            // the ciphertext string
            // sCiphertext = sCiphertext.Substring(HEADER_CHARACTERS.Length, sCiphertext.Length - (HEADER_CHARACTERS.Length));
            sCiphertext = sCiphertext.Substring(HEADER_CHARACTERS.Length * 2, sCiphertext.Length - (HEADER_CHARACTERS.Length * 2));
            int iHexLen = sCiphertext.Length;

            int iPlainTextLen = iHexLen / 2;
            int iNumOfBlocks = iPlainTextLen / 8;
            int iLeftOverBytes = iPlainTextLen - (iNumOfBlocks * 8);

            // Convert the ciphertext hex string to ASCII byte array
            arrEncryptedBytes = HexToASCIIBytes(sCiphertext);

            // Decrypt the ciphertext ASCII byte array one block at a time.
            // Then convert the decrypted byte array to a string, and append
            // it to the final plain text string.
            StringBuilder sbPlainText = new StringBuilder();
            byte[] arrLastEncryptedBlock = new byte[8];
            BlowfishCBC blowfishcbc = new BlowfishCBC(EncryptionKeyBytes, 0, EncryptionKeyBytes.Length);
            for (int i = 0; i < iNumOfBlocks; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arrLastEncryptedBlock[j] = arrEncryptedBytes[(i * 8) + j];
                }

                byte[] arrDecryptedBlock = DecryptBlock(arrLastEncryptedBlock, blowfishcbc);
                sbPlainText.Append(encoding.GetString(arrDecryptedBlock));
            }

            // If the ciphertext string contains an incomplete last block,
            // take the last complete encrypted block, encrypt it again,
            // then XOR that doubly-encrypted block with the singly-encrypted
            // incomplete block to get the decrypted string.
            if (iLeftOverBytes > 0)
            {
                byte[] arrLastBlockAgain = EncryptBlock(arrLastEncryptedBlock, blowfishcbc);

                byte[] arrXorBytes = new byte[iLeftOverBytes];
                for (int i = 0; i < iLeftOverBytes; i++)
                {
                    byte b1 = arrEncryptedBytes[8 * iNumOfBlocks + i];
                    byte b2 = arrLastBlockAgain[i];
                    byte xorByte = Convert.ToByte(b1 ^ b2);
                    arrXorBytes[i] = xorByte;
                }

                sbPlainText.Append(encoding.GetString(arrXorBytes));
            }

            // Check for the small string header at the front of the string.
            // If it is present, remove it along with the next 4 characters.
            string strPlain = sbPlainText.ToString();
            if (strPlain.Length >= 4 && strPlain.Substring(0,SMALL_STRING_HEADER.Length).Equals(SMALL_STRING_HEADER))
            {
                int iHeaderLen = SMALL_STRING_HEADER.Length + 4;
                strPlain = strPlain.Substring(iHeaderLen, strPlain.Length - iHeaderLen);
            }
            return strPlain;
        }


        //////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// Encrypts a single plain text block.
        ///// </summary>
        ///// <param name="arrEncryptedBytes"> 
        ///// Array of bytes to encrypt.
        ///// </param>
        ///// <returns>
        ///// Ciphertext byte array.
        ///// </returns>
        //[Obsolete("Do not call EncryptBlock directly")]
        //public static byte[] EncryptBlock(byte[] arrPlainTextBytes)
        //{
        //    byte[] arrEncryptedBytes;

        //    // Encrypt the ASCII byte array using Blowfish
        //    arrEncryptedBytes = new byte[8];
        //    BlowfishCBC bfc = new BlowfishCBC(EncryptionKeyBytes, 0, EncryptionKeyBytes.Length);
        //    bfc.Encrypt(arrPlainTextBytes, 0, arrEncryptedBytes, 0, 8);

        //    return arrEncryptedBytes;
        //}

        private static byte[] EncryptBlock(byte[] plaintextBytes, BlowfishCBC encryptor)
        {
            var encryptedBytes = new byte[8];
            encryptor.SetIV(InitialIV, 0);
            encryptor.Encrypt(plaintextBytes, 0, encryptedBytes, 0, 8);
            return encryptedBytes;
        }

        //////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// Decrypts a single ciphertext block.
        ///// </summary>
        ///// <param name="arrEncryptedBytes"> 
        ///// Array of bytes to decrypt.
        ///// </param>
        ///// <returns>
        ///// Plain text byte array.
        ///// </returns>
        //[Obsolete("Do not call DecryptBlock directly")]
        //public static byte[] DecryptBlock(byte[] arrEncryptedBytes)
        //{
        //    byte[] arrDecryptedBytes;

        //    // Decrypt the ASCII byte array using Blowfish
        //    arrDecryptedBytes = new byte[8];
        //    BlowfishCBC bfc = new BlowfishCBC(EncryptionKeyBytes, 0, EncryptionKeyBytes.Length);
        //    bfc.Decrypt(arrEncryptedBytes, 0, arrDecryptedBytes, 0, arrEncryptedBytes.Length);

        //    return arrDecryptedBytes;
        //}

        private static byte[] DecryptBlock(byte[] encryptedBytes, BlowfishCBC decryptor)
        {
            byte[] decryptedBytes = new byte[8];
            decryptor.SetIV(InitialIV, 0);
            decryptor.Decrypt(encryptedBytes, 0, decryptedBytes, 0, encryptedBytes.Length);
            return decryptedBytes;
        }

        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Generates a random string with the given length.
        /// </summary>
        /// <param name="iLen">
        /// Number of characters in the desired string
        /// </param>
        /// <param name="bLowerCase">
        /// If true, generates lowercase string
        /// </param>
        /// <returns>
        /// Random string
        /// </returns>
        private static string RandomString(int iLen, bool bLowerCase)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < iLen; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
                sb.Append(ch);
            }
            if (bLowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }

        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Generates a random string with the given length.
        /// </summary>
        /// <param name="iLen">
        /// Number of characters in the desired string.
        /// </param>
        /// <returns>
        /// Random string.
        /// </returns>
        private static string RandomString(int iLen)
        {
            return RandomString(iLen, false);
        }
        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Converts an ASCII byte array to a hex encoded string.
        /// </summary>
        /// <param name="arrBytes"> 
        /// ASCII byte array to be converted.
        /// </param>
        /// <returns>
        /// Hex encoded string.
        /// </returns>
        public static string ASCIIBytesToHex(byte[] arrBytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrBytes.Length; i++)
            {
                sb.AppendFormat("{0:X2} ", arrBytes[i]);
            }
            return sb.ToString().Replace(" ", String.Empty);
        }

        public static string ByteArrayToString(byte[] arrBytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrBytes.Length; i++)
            {
                sb.AppendFormat("{0} ", arrBytes[i]);
            }
            return sb.ToString().Replace(" ", String.Empty);
        }
        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Converts a hex string to an ASCII byte array.
        /// </summary>
        /// <param name="sHex"> 
        /// Hex string to be converted.
        /// </param>
        /// <returns>
        /// ASCII byte array.
        /// </returns>
        public static byte[] HexToASCIIBytes(string sHex)
        {
            byte[] arrBytes = new byte[sHex.Length / 2];
            for (int i = 0; i < arrBytes.Length; i++)
            {
                arrBytes[i] = Convert.ToByte(sHex.Substring(i * 2, 2), 16);
            }
            return arrBytes;
        }
    }
}
