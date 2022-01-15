using System;
using System.Linq;

namespace LabBTI_2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Podaj tekst do zaszyfrowania: ");
        var textToEncrypt = Console.ReadLine();
        var encryptedText = VignereCipher.Encrypt(textToEncrypt, "myPassword");
        Console.WriteLine($"Zaszyfrowany tekst: \"{encryptedText}\"");
        var decryptedText = VignereCipher.Decrypt(encryptedText, "myPassword");
        Console.WriteLine($"Odszyfrowany tekst: \"{decryptedText}\"");
        Console.ReadKey();
    }
}