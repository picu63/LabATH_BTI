using System;
using System.Linq;

namespace LabBTI_3;

internal static class AffineCipher
{
    private static readonly char[] CharCollection =
        Enumerable.Range('A', 26)
            .Concat(Enumerable.Range('a', 26)) // dodanie całego alfabetu
            .Concat(Enumerable.Range(' ', 1)) // dodanie spacji
            .Concat((new int[] { '?', '!', '.', ':', '-', '_', '(', ')' })) // dodanie znaków interpunkcyjnych
            .Select(x => (char)x)
            .ToArray();

    // szyfrowanie
    public static string Cipher(string textToEncrypt, int a, int b)
    {
        if (!AssertAB(a, b)) return textToEncrypt;

        var result = string.Empty;

        var m = CharCollection.Length;

        var result1 = result;
        foreach (var pChar in textToEncrypt)
        {
            var p = Array.IndexOf(CharCollection, pChar);
            var c = a * p + b % m;
            var cIdx = c % CharCollection.Length;
            var c1 = CharCollection[cIdx];
            result1 += c1;
        }

        return result1;
    }

    // Deszyfrowanie
    public static string Decipher(string textToDecrypt, int a, int b)
    {
        if (!AssertAB(a, b)) return textToDecrypt;

        var result = string.Empty;

        foreach (var cChar in textToDecrypt)
        {
            var c = Array.IndexOf(CharCollection, cChar);

            var aInverse = GetMultiplicativeInverse(a);
            var pIdx = aInverse * (c - b) % CharCollection.Length;
            if (pIdx < 0)
            {
                pIdx += CharCollection.Length;
            }
            var pChar = CharCollection[pIdx];

            result += pChar;
        }

        return result;
    }

    // Zwraca największy wspólny dzielnik
    private static int GreatestCommonDivisor(int a, int b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }

    // Sprawdza czy są liczbami pierwszymi
    private static bool AreRelativelyPrimes(int m, int n)
    {
        return GreatestCommonDivisor(m, n) == 1;
    }

    // walidacja wartości kluczy
    private static bool AssertAB(int a, int b)
    {
        var result = false;

        var message = string.Empty;

        // Parametry a oraz b muszą być pomiędzy 1 <= a <= CharCollection.Length
        if (a < 1 || a > CharCollection.Length)
        {
            message = $"'a' musi być pomiędzy [1,{CharCollection.Length}]";
        }

        else if (b < 1 || b > CharCollection.Length)
        {
            message = $"'b' musi być pomiędzy [1,{CharCollection.Length}]";
        }

        else if (!AreRelativelyPrimes(a, CharCollection.Length))
        {
            message = $"'a' musi być liczbą pierwszą do {CharCollection.Length}";
        }
        else
        {
            result = true;
        }

        Console.WriteLine(message);

        return result;
    }

    // odwracanie multiplikatywne
    private static int GetMultiplicativeInverse(int a)
    {
        var result = 1;

        for (var i = 1; i <= CharCollection.Length; i++)
        {
            if ((a * i) % (CharCollection.Length) == 1)
            {
                result = i;
            }
        }

        return result;
    }
}