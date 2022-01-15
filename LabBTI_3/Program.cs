using System;

namespace LabBTI_3
{
    internal class Program
    {
        // create a affinic cipher program
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz tekst do zaszyfrowania: ");
            string text = Console.ReadLine();
            Console.WriteLine("Podaj klucz 1: ");
            int key1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj klucz 2: ");
            int key2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Zaszyfrowany tekst: " + AffineCipher.Encrypt(text, key1, key2));
            Console.WriteLine("Odszyfrowany tekst: " + AffineCipher.Decrypt(text, key1, key2));
        }
    }
}
