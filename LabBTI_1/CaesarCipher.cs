using System;

namespace LabBTI_1;

public class CaesarCipher
{
    public static string Encrypt(string text, int key)
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

    public static string Decrypt(string text, int key)
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