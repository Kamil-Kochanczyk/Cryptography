using System;

namespace Vigenère_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (char letter in VigenèreCipher.LowerCaseAlphabet)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            foreach (char letter in VigenèreCipher.UpperCaseAlphabet)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            Console.WriteLine();

            Console.Write("Text: ");
            string text = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Key: ");
            string key = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Encrypt/Decrypt: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "Encrypt" || choice == "encrypt")
            {
                Console.WriteLine($"Plain text: {text}");
                Console.WriteLine($"Cipher text: {VigenèreCipher.Encrypt(text, key)}");
            }
            else if (choice == "Decrypt" || choice == "decrypt")
            {
                Console.WriteLine($"Cipher text: {text}");
                Console.WriteLine($"Plain text: {VigenèreCipher.Decrypt(text, key)}");
            }
            else
            {
                Console.WriteLine("Wrong input. Please try again.");
            }

            Console.ReadKey();
        }
    }
}