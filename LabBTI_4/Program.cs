using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBTI_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var toEncrypt = "To jest wiadomosc do zaszyfrowania";
            var key = "Tesowa";
            Console.WriteLine($"Wiadomość do zaszyfrowania: {toEncrypt}");
            var encrypted = PlayfairCipher.Encipher(toEncrypt, key);
            Console.WriteLine("Zaszyfrowana wiadomość: " + encrypted);
            var decrypted = PlayfairCipher.Decipher(encrypted, key);
            Console.WriteLine($"Odszyfrowana wiadomość: {decrypted}");
        }
    }
}
