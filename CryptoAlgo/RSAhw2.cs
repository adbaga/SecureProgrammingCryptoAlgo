using System;
using System.Threading;

namespace CryptoAlgo
{
    public class RSAhw2
    {
        
        
        public static string runRSA()
        {
            Console.WriteLine("RSA");
            
            var g = new Random();
            long p;

            do
            {
                p = g.Next(100, 500);
            } while (!PrimeChecker(p));
            
            var h = new Random();
            long q;
            do
            {
                q = h.Next(100, 500);
            } while (!PrimeChecker(q));
            
            Console.WriteLine($"P value: {p}");
            Console.WriteLine($"Q value: {q}");

            long n = p * q;
            long m = (p - 1) * (q - 1);
            Console.WriteLine($"n = p*q: {n}");
            Console.WriteLine($"ф(n) = (p-1)*(q-1): {m}");

            long e = 1;
            long gcd = 0;

            do
            {
                e++;
                gcd = Gcd(m, e);
            } while (gcd != 1);
            
            
            
            Console.WriteLine($"Co-prime to the ф(n): {m} is e:{e} ");

            long k = 0;
            do
            {
                if ((1 + k * m) % e == 0) break;
                k++;
            } while (true);
            Console.WriteLine($"K: {k}");

            var d = (1 + k * m) / e;
            Console.WriteLine($"d: {d}");
            
            Console.WriteLine($"Public key n: {n} e: {e}");
            Console.WriteLine($"Private key: p*q =  {p}*{q} ={n}   d:{d}");
            
            Console.WriteLine("Plaintext char:");
            var plainTextStr = Console.ReadLine();

            if (plainTextStr.Length >= 1)
            {
                var table = new Int64[4, plainTextStr.Length];

                var i = 0;
                while (i < plainTextStr.Length)
                {
                    var plainText = (long) plainTextStr[i];
                    table[0, i] = plainText;

                    var encrypted = calcMod(plainText, e, n);
                    table[1, i] = encrypted;

                    table[2, i] = calcMod(encrypted, d, n);
                    i++;
                }
                
                
                Console.Write("Char code: ");
                for (var j = 0; j < plainTextStr.Length; j++)
                {
                    Console.Write($" {table[0,j]}");
                }
                
                Console.Write("\nEncrypted: ");
                for (var j = 0; j < plainTextStr.Length; j++)
                {
                    Console.Write($" {table[1, j]}");
                }
                
                Console.Write("\nDecrypted: ");
                for (var j = 0; j < plainTextStr.Length; j++)
                {
                    Console.Write($" {table[2,j]}");
                }
                Console.WriteLine();
            }
            
            CheckRSA(p*q,e);
            
            static void CheckRSA(long n, long e)
            {
                long x = 100;
                long y = 1;
 
                do
                {
                    x++;
                    y = findPrivKey(n,x);
                } while (!PrimeChecker(x) || !PrimeChecker(y) || y==1);
           
                Console.WriteLine($"Private keys are: X: {x}, Y: {y} \n");
            }


            return "";


        }
        static bool PrimeChecker(long x)
        {
            for (var i = 2; i * i < x; ++i)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        
        
        static long findPrivKey( long n, long x)
        {
            if (n % x == 0)
                return n / x;
            return 1;
        }
        
        static long Gcd(long a, long b)
        {
          
            if (a == 0)
                return b;
            if (b == 0)
                return a;
   
           
            if (a == b)
                return b;
   
            
            if (a > b)
                return Gcd(a-b, b);
            return Gcd(a, b-a);
        }
        
        static long calcMod(long Base, long Secret, long Modulus)
        {
            long returnMod = 1;
            for (var i = 1; i <= Secret; ++i)
            {
                returnMod = (returnMod * Base) % Modulus;
            }
            return returnMod;
        }

    }
}