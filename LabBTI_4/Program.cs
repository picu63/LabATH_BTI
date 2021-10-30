using System;
using System.Linq;

namespace LabBTI_4
{
    internal class Program
    {
        public static char[][] tableChars = new char[5][];
        static void Main(string[] args)
        {
            var input = "Testowy";
            if (input.Any(c => !char.IsLetter(c)))
            {
                throw new Exception("Input characters must be letters");
            }
            var inputFormatted = new string(input.ToUpper().Replace('J','I').Distinct().ToArray());
            Console.WriteLine($"Your key is: {inputFormatted}");
            var alphabetFormatted = new string(Enumerable.Range(65, 26).Select(i=>(char)i).Where(c => !c.Equals('J')).ToArray());
            foreach (var letter in alphabetFormatted)
            {
                Console.Write(letter + "; ");
            }

            for (var index = 0; index < inputFormatted.Length; index++)
            {
                var letter = inputFormatted[index];
                var alphLetterIndex = alphabetFormatted[index];
                alphabetFormatted.Replace(alphLetterIndex, letter);
            }
        }
    }
}
