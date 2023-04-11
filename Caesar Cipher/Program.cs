using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (char letter in CaesarCipher.LowerCaseAlphabet)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            foreach (char letter in CaesarCipher.UpperCaseAlphabet)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            Console.WriteLine();

            Console.Write("Text: ");
            string text = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Key: ");
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Encrypt/Decrypt: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "Encrypt" || choice == "encrypt")
            {
                Console.WriteLine($"Plain text: {text}");
                Console.WriteLine($"Cipher text: {CaesarCipher.Encrypt(text, key)}");
            }
            else if (choice == "Decrypt" || choice == "decrypt")
            {
                Console.WriteLine($"Cipher text: {text}");
                Console.WriteLine($"Plain text: {CaesarCipher.Decrypt(text, key)}");
            }
            else
            {
                Console.WriteLine("Wrong input. Please try again.");
            }

            Console.ReadKey();
        }
    }
}