using System;

namespace CryptoAlgo
{
    public static class Caesar
    {
        public static string RunCaesar()
        {
            Console.WriteLine("Veni Vidi Vici");

            var command = "";
            
            do
            {
                Console.WriteLine("E - Encrypt Message");
                Console.WriteLine("D - Decrypt Message");
                Console.WriteLine("X - Exit");
                Console.WriteLine("-----------");
                Console.WriteLine(">");
                command = Console.ReadLine().ToUpper();
                switch (command)
                {
                    case "E":
                        RunCaesarEncrypt();
                        break;
                    case "D":
                        RunCaesarDecrypt();
                        break;
                }
            } while (command != "X");



            static void RunCaesarEncrypt()
            {
                Console.WriteLine("Text to encrypt");
                Console.Write(">");
                var plainText = Console.ReadLine()?.Trim().ToUpper() ?? "";

                Console.WriteLine("Amount to shift");
                Console.Write(">");
                string shiftAmountText = Console.ReadLine();

                int shiftAmount = 0;
                if (int.TryParse(shiftAmountText, out shiftAmount))
                {
                    string encryptedText = CaesarEncrypt(plainText, shiftAmount);
                    Console.WriteLine("----------------");
                    Console.WriteLine("original:" + plainText);
                    Console.WriteLine("shift:" + shiftAmount);
                    Console.WriteLine("----------------");
                    Console.WriteLine("encrypted:" + encryptedText);
                }
                else
                {
                    Console.WriteLine("Error: " + shiftAmountText + " is not a number");
                }
            }

            static void RunCaesarDecrypt()
            {
                Console.WriteLine("Text to decrypt");
                Console.Write(">");
                var encryptedText = Console.ReadLine()?.Trim().ToUpper() ?? "";

                Console.WriteLine("Amount to shift");
                Console.Write(">");
                string shiftAmountText = Console.ReadLine();

                int shiftAmount = 0;
                if (int.TryParse(shiftAmountText, out shiftAmount))
                {
                    string plainText = CaesarDecrypt(encryptedText, shiftAmount);
                    Console.WriteLine("----------------");
                    Console.WriteLine("original:" + encryptedText);
                    Console.WriteLine("shift:" + shiftAmount);
                    Console.WriteLine("----------------");
                    Console.WriteLine("decrypted:" + plainText);
                }
                else
                {
                    Console.WriteLine(shiftAmountText + "is not a number");
                }
            }
            return "";
        }
            
            private static char[] _alphabet = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z', ' '
            };

            static string CaesarEncrypt(string plainText, int shiftAmount)
            {
                Console.WriteLine("Alphabet size: " + _alphabet.Length);
                string result = "";
                
                for (int i = 0; i < plainText.Length; i++)
                {
                    var letter = plainText[i];
                    var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                    indexInAlphabet = (indexInAlphabet + shiftAmount) % _alphabet.Length;
                    result = result + _alphabet[indexInAlphabet];
                }
                
                return result;
            }
            
            static string CaesarDecrypt(string encryptedText, int shiftAmount)
            {
                Console.WriteLine("Alphabet size: " + _alphabet.Length);
                string result = "";
                
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    var letter = encryptedText[i];
                    var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                    indexInAlphabet = (indexInAlphabet - shiftAmount) % _alphabet.Length;
                    result = result + _alphabet[indexInAlphabet];
                }
                
                return result;
            }
    }
}