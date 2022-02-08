using System;
using System.Linq;

namespace LabBTI_3;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Szyfr afiniczny");
        Console.WriteLine();
        Console.Write("Podaj tekst do zaszyfrowania: ");
        var textToEncrypt = Console.ReadLine();
        Console.WriteLine("Tekst do zaszyfrowania: " + textToEncrypt);
        Console.WriteLine();
        Console.Write("Podaj pierwszy klucz (liczba pierwsza): ");
        var a = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Podaj drugi klucz: ");
        var b = int.Parse(Console.ReadLine());
        var cipheredText = AffineCipher.Cipher(textToEncrypt, a, b);
        Console.WriteLine("Zaszyfrowany tekst: {0}", cipheredText);
        var decipheredText = AffineCipher.Decipher(cipheredText, a, b);
        Console.WriteLine("Odszyfrowany tekst: {0}", decipheredText);
        Console.ReadKey();
    }
}