using System;

namespace CryptoAlgo
{
    public static class Vigenere
    {

        public static string VigenerEnc(string pt, string key)
        {

            string ct = "";
            char[] keys = key.ToCharArray();
            int j = 0;
            foreach (char c in pt)
            {
                int k = c - 65; //65 is "A" in ASCII
                int y = keys[j] - 65;

                ct += (char) ((k + y) % 26 + 65);

                j = (j + 1) % key.Length;
            }

            return ct;
        }


        public static string VigenerDec(string pt, string key)
        {
            string ct = "";
            char[] keys = key.ToCharArray();
            int j = 0;
            foreach (char c in pt)
            {
                int k = c - 65;
                int y = keys[j] - 65;
                if (k >= y)
                    ct += (char) ((k - y) % 26 + 65);

                else
                {
                    ct += (char) ((k - y + 26) % 26 + 65);

                }

                j = (j + 1) % key.Length;

            }

            return ct;
        }

        public static string RunVigener()
        {
            string plaintext = "";
            Console.WriteLine("Write text to encrypt / decrypt:");
            plaintext = Console.ReadLine();


            string key = "";
            Console.WriteLine("Key please: ");
            key = Console.ReadLine();


            Console.WriteLine("E : Encrypt");
            Console.WriteLine("D : Decrypt");
            Console.WriteLine("X : Exit");

            var command = "";
            command = Console.ReadLine().ToUpper();
            switch (command)
            {
                case "E":
                    string cpt = VigenerEnc(plaintext.ToUpper(), key.ToUpper());
                    Console.WriteLine(plaintext + "\n" + cpt);
                    break;

                case "D":
                    string dpt = VigenerDec(plaintext.ToUpper(), key.ToUpper());
                    Console.WriteLine("\n\n" + plaintext + "\n" + dpt);
                    break;
                case "X":
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;

            }

            return "";
        }
    }
}
