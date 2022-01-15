﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabBTI_4
{
    public static class PlayfairCipher
    {
        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }

        private static int Mod(int a, int b)
		{
            return (a % b + b) % b;
		}

        private static char[,] GenerateKeySquare(string key)
		{
			
			var keySquare = new char[5, 5];
			var defaultKeySquare = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("Key cannot be null or empty");
            }
			var tempKey = key.ToUpper();

			tempKey = tempKey.Replace("J", "");
			tempKey += defaultKeySquare;
            tempKey = new string(tempKey.Distinct().ToArray());

            for (var i = 0; i < 25; ++i)
				keySquare[i / 5, i % 5] = tempKey[i];

			return keySquare;
		}

        private static void GetPosition(ref char[,] keySquare, char ch, ref int row, ref int col)
		{
			if (ch == 'J')
				GetPosition(ref keySquare, 'I', ref row, ref col);

			for (var i = 0; i < 5; ++i)
				for (var j = 0; j < 5; ++j)
					if (keySquare[i, j] == ch)
					{
						row = i;
						col = j;
					}
		}

        private static char[] SameRow(ref char[,] keySquare, int row, int col1, int col2, int encipher)
		{
			return new[] { keySquare[row, Mod(col1 + encipher, 5)], keySquare[row, Mod(col2 + encipher, 5)] };
		}

        private static char[] SameColumn(ref char[,] keySquare, int col, int row1, int row2, int encipher)
		{
			return new[] { keySquare[Mod(row1 + encipher, 5), col], keySquare[Mod(row2 + encipher, 5), col] };
		}

        private static char[] SameRowColumn(ref char[,] keySquare, int row, int col, int encipher)
		{
			return new[] { keySquare[Mod(row + encipher, 5), Mod(col + encipher, 5)], keySquare[Mod(row + encipher, 5), Mod(col + encipher, 5)] };
		}

        private static char[] DifferentRowColumn(ref char[,] keySquare, int row1, int col1, int row2, int col2)
		{
			return new[] { keySquare[row1, col2], keySquare[row2, col1] };
		}

        private static string RemoveOtherChars(string input)
		{
			var output = input;

			for (var i = 0; i < output.Length; ++i)
				if (!char.IsLetter(output[i]))
					output = output.Remove(i, 1);

			return output;
		}

        private static string AdjustOutput(string input, string output)
		{
			var retVal = new StringBuilder(output);

			for (var i = 0; i < input.Length; ++i)
			{
				if (!char.IsLetter(input[i]))
					retVal = retVal.Insert(i, input[i]);

				if (char.IsLower(input[i]))
					retVal[i] = char.ToLower(retVal[i]);
			}

			return retVal.ToString();
		}

        private static string Cipher(string input, string key, bool encipher)
		{
			var retVal = string.Empty;
			var keySquare = GenerateKeySquare(key);
			var tempInput = RemoveOtherChars(input);
			var e = encipher ? 1 : -1;

			if (tempInput.Length % 2 != 0)
				tempInput += "X";

			for (var i = 0; i < tempInput.Length; i += 2)
			{
				var row1 = 0;
				var col1 = 0;
				var row2 = 0;
				var col2 = 0;

				GetPosition(ref keySquare, char.ToUpper(tempInput[i]), ref row1, ref col1);
				GetPosition(ref keySquare, char.ToUpper(tempInput[i + 1]), ref row2, ref col2);

				if (row1 == row2 && col1 == col2)
				{
					retVal += new string(SameRowColumn(ref keySquare, row1, col1, e));
				}
				else if (row1 == row2)
				{
					retVal += new string(SameRow(ref keySquare, row1, col1, col2, e));
				}
				else if (col1 == col2)
				{
					retVal += new string(SameColumn(ref keySquare, col1, row1, row2, e));
				}
				else
				{
					retVal += new string(DifferentRowColumn(ref keySquare, row1, col1, row2, col2));
				}
			}

			retVal = AdjustOutput(input, retVal);

			return retVal;
		}
    }
}