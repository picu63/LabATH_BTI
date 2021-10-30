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
            var encryptionMethod = args[0];
            var keyExist = int.TryParse(args[1], out int key);
            if (!keyExist)
            {
                Console.WriteLine("Cannot parse second parameter - must be integer");
                return;
            }
            if (encryptionMethod == "encrypt")
            {
                var encryptedTxt = Encrypt(args[2], key);
                Console.WriteLine(encryptedTxt);
            }
            else if (encryptionMethod == "decrypt")
            {
                var decryptedTxt = Decrypt(args[2], key);
                Console.WriteLine(decryptedTxt);
            }
        }

        private static string Encrypt(string text, int key)
        {
            var encrypted = string.Empty;

            foreach (var character in text)
            {
                if (char.IsUpper(character))
                {
                    var characterIndex = character - 'A';
                    var characterShifted = (characterIndex + key) % 26 + 'A';
                    encrypted += (char)(characterShifted);
                }
                else if (char.IsLower(character))
                {
                    var characterIndex = character - 'a';
                    var characterShifted = (characterIndex + key) % 26 + 'a';
                    encrypted += (char)(characterShifted);
                }
                else
                {
                    throw new ArgumentException("Text cannot be different than alphabet");
                }
            }
            return encrypted;
        }

        private static string Decrypt(string text, int key)
        {
            var decrypted = string.Empty;
            key %= 26;

            foreach (var character in text)
            {
                if (char.IsUpper(character))
                {
                    var characterIndex = character - 'A';
                    var characterOrgPos = (characterIndex - key) % 26 + 'A';
                    decrypted += (char)(characterOrgPos);
                }
                else if (char.IsLower(character))
                {
                    var characterIndex = character - 'a';
                    var characterOrgPos = (characterIndex - key) % 26 + 'a';
                    decrypted += (char)(characterOrgPos);
                }
                else
                {
                    throw new ArgumentException("Text cannot be different than alphabet");
                }
            }
            return decrypted;
        }
    }
}