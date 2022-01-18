using System;
using System.Collections;
using System.Collections.Generic;

namespace LabBTI_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Program for encryption/decryption must have 3 parameters:\n" +
                                  "1) 'encrypt' or 'decrypt' keyword\n" +
                                  "2) Integer key\n" +
                                  "3) Text to encrypt");
            }
            if(args.Length != 3)
                return;
            var encryptionMethod = args[0];
            var keyExist = int.TryParse(args[1], out int key);
            if (!keyExist)
            {
                Console.WriteLine("Cannot parse second parameter - must be integer");
                return;
            }
            if (encryptionMethod == "encrypt")
            {
                var encryptedTxt = CaesarCipher.Encrypt(args[2], key);
                Console.WriteLine(encryptedTxt);
            }
            else if (encryptionMethod == "decrypt")
            {
                var decryptedTxt = CaesarCipher.Decrypt(args[2], key);
                Console.WriteLine(decryptedTxt);
            }
        }
    }
}