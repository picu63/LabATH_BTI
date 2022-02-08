using System;
using System.Linq;

namespace LabBTI_2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Szyfrowanie Vigenere'a, wybierz opcję:");
        Console.WriteLine("1. Szyfrowanie");
        Console.WriteLine("2. Deszyfrowanie");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.D1)
        {
            Console.WriteLine("\nWybrano szyfrowanie");
            Console.WriteLine("Podaj tekst do zaszyfrowania:");
            var textToEncrypt = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            var password = Console.ReadLine();
            var encryptedText = VignereCipher.Encrypt(textToEncrypt, password);
            Console.WriteLine($"Zaszyfrowany tekst: \"{encryptedText}\"");
        }
        else if (key.Key == ConsoleKey.D2)
        {
            Console.WriteLine("\nWybrano deszyfrowanie");
            Console.WriteLine("Podaj tekst do deszyfrowania:");
            var textToDecrypt = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            var password = Console.ReadLine();
            var decryptedText = VignereCipher.Decrypt(textToDecrypt, password);
            Console.WriteLine($"Odszyfrowany tekst: \"{decryptedText}\"");
        }
        else
        {
            Console.WriteLine("Wybrany klawisz musi być 1 lub 2");
        }
    }
}