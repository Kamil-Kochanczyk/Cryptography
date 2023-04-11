using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    public static class CaesarCipher
    {
        private static List<char> _lowerCaseAlphabet = new List<char>();
        private static List<char> _upperCaseAlphabet = new List<char>();

        public static List<char> LowerCaseAlphabet => _lowerCaseAlphabet;
        public static List<char> UpperCaseAlphabet => _upperCaseAlphabet;

        static CaesarCipher()
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                _lowerCaseAlphabet.Add(letter);
                _upperCaseAlphabet.Add(char.ToUpper(letter));
            }
        }

        public static string Encrypt(string plainText, int key)
        {
            StringBuilder cipherText = new StringBuilder(plainText.Length);
            char cipherCharacter;
            int initialIndex, finalIndex;

            key = (Math.Abs(key) >= 26) ? key % 26 : key;

            foreach (char plainCharacter in plainText)
            {
                if (char.IsLetter(plainCharacter))
                {
                    if (char.IsLower(plainCharacter))
                    {
                        initialIndex = LowerCaseAlphabet.FindIndex(letter => letter == plainCharacter);
                    }
                    else
                    {
                        initialIndex = UpperCaseAlphabet.FindIndex(letter => letter == plainCharacter);
                    }

                    finalIndex = initialIndex + key;

                    if (finalIndex >= 26)
                    {
                        finalIndex -= 26;
                    }

                    if (finalIndex <= -1)
                    {
                        finalIndex += 26;
                    }

                    if (char.IsLower(plainCharacter))
                    {
                        cipherCharacter = LowerCaseAlphabet[finalIndex];
                    }
                    else
                    {
                        cipherCharacter = UpperCaseAlphabet[finalIndex];
                    }
                }
                else
                {
                    cipherCharacter = plainCharacter;
                }

                cipherText.Append(cipherCharacter);
            }

            return cipherText.ToString();
        }

        public static string Decrypt(string cipherText, int key)
        {
            return Encrypt(cipherText, key * (-1));
        }
    }
}