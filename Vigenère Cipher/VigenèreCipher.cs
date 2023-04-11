using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenère_Cipher
{
    public static class VigenèreCipher
    {
        private static List<char> _lowerCaseAlphabet = new List<char>();
        private static List<char> _upperCaseAlphabet = new List<char>();

        public static List<char> LowerCaseAlphabet => _lowerCaseAlphabet;
        public static List<char> UpperCaseAlphabet => _upperCaseAlphabet;

        static VigenèreCipher()
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                _lowerCaseAlphabet.Add(letter);
                _upperCaseAlphabet.Add(char.ToUpper(letter));
            }
        }

        public static string Encrypt(string plainText, string key)
        {
            bool keyValid = true;
            List<int> keyIndexes = new List<int>();

            if (key == null)
            {
                keyValid = false;
            }
            else
            {
                foreach (char character in key)
                {
                    if (char.IsLetter(character))
                    {
                        keyIndexes.Add(LowerCaseAlphabet.FindIndex(letter => letter == char.ToLower(character)));
                    }
                    else
                    {
                        keyValid = false;
                        break;
                    }
                }
            }

            if (!keyValid)
            {
                throw new ArgumentException("Key is not valid.");
            }

            if (keyIndexes.Count == 0)
            {
                keyIndexes.Add(0);
            }

            StringBuilder cipherText = new StringBuilder(plainText.Length);
            char cipherCharacter;
            int auxiliaryVariable = 0, initialIndex, finalIndex;

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

                    finalIndex = initialIndex + keyIndexes[auxiliaryVariable];

                    if (finalIndex >= 26)
                    {
                        finalIndex -= 26;
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

                auxiliaryVariable = (auxiliaryVariable == keyIndexes.Count - 1) ? 0 : auxiliaryVariable + 1;
                cipherText.Append(cipherCharacter);
            }

            return cipherText.ToString();
        }

        public static string Decrypt(string cipherText, string key)
        {
            bool keyValid = true;
            List<int> keyIndexes = new List<int>();

            if (key == null)
            {
                keyValid = false;
            }
            else
            {
                foreach (char character in key)
                {
                    if (char.IsLetter(character))
                    {
                        keyIndexes.Add(LowerCaseAlphabet.FindIndex(letter => letter == char.ToLower(character)));
                    }
                    else
                    {
                        keyValid = false;
                        break;
                    }
                }
            }

            if (!keyValid)
            {
                throw new ArgumentException("Key is not valid.");
            }

            if (keyIndexes.Count == 0)
            {
                keyIndexes.Add(0);
            }

            StringBuilder plainText = new StringBuilder(cipherText.Length);
            char plainCharacter;
            int auxiliaryVariable = 0, initialIndex, finalIndex;

            foreach (char cipherCharacter in cipherText)
            {
                if (char.IsLetter(cipherCharacter))
                {
                    if (char.IsLower(cipherCharacter))
                    {
                        initialIndex = LowerCaseAlphabet.FindIndex(letter => letter == cipherCharacter);
                    }
                    else
                    {
                        initialIndex = UpperCaseAlphabet.FindIndex(letter => letter == cipherCharacter);
                    }

                    finalIndex = initialIndex - keyIndexes[auxiliaryVariable];

                    if (finalIndex <= -1)
                    {
                        finalIndex += 26;
                    }

                    if (char.IsLower(cipherCharacter))
                    {
                        plainCharacter = LowerCaseAlphabet[finalIndex];
                    }
                    else
                    {
                        plainCharacter = UpperCaseAlphabet[finalIndex];
                    }
                }
                else
                {
                    plainCharacter = cipherCharacter;
                }

                auxiliaryVariable = (auxiliaryVariable == keyIndexes.Count - 1) ? 0 : auxiliaryVariable + 1;
                plainText.Append(plainCharacter);
            }

            return plainText.ToString();
        }
    }
}