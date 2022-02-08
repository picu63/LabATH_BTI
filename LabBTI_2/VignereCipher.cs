using System;
using System.Linq;

namespace LabBTI_2;

public static class VignereCipher
{
    public static string Encrypt(string textToEncrypt, string password)
    {
        return VignereCipher.Cipher(textToEncrypt, password, true);
    }

    public static string Decrypt(string textToDecrypt, string password)
    {
        return VignereCipher.Cipher(textToDecrypt, password, false);
    }

    private static string Cipher(string input, string password, bool encrypt)
    {
        if (password.Any(t => !char.IsLetter(t)))
        {
            throw new ArgumentException("Jeden lub więcej znaków nie jest literą lub spacją.");
        }

        var output = string.Empty;
        int nonAlphaCharCount = default;

        for (var i = 0; i < input.Length; ++i)
        {
            if (!char.IsLetter(input[i]))
            {
                output += input[i];
                ++nonAlphaCharCount;
            }
            else
            {
                var cIsUpper = char.IsUpper(input[i]);
                var offset = cIsUpper ? 'A' : 'a';
                var keyIndex = (i - nonAlphaCharCount) % password.Length;
                var k = (cIsUpper ? char.ToUpper(password[keyIndex]) : char.ToLower(password[keyIndex])) - offset;
                k = encrypt ? k : -k;
                var ch = (char)(Modulo(((input[i] + k) - offset), 26) + offset);
                output += ch;
            }
        }

        return output;
    }
    private static int Modulo(int a, int b)
    {
        return (a % b + b) % b;
    }
}