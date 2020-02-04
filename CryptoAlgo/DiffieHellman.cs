
using System;
 
namespace CryptoAlgo
{
    public static class DH
    {
 
       
 
        public static string RunDH()
        {
 
 
 
            int processThis = 0;
            int generator = 0;
            int annaSecret = 0;
            int borisSecret = 0;

            do
            {
                Console.Clear();


                Console.WriteLine("Enter the generator");
                string generatorInput = Console.ReadLine();


                if (int.TryParse(generatorInput, out generator))
                {
                    generator = (int) Convert.ToInt64(generatorInput);
                    processThis++;

                }
                else
                {
                    Console.WriteLine(generatorInput + "is not a number");
                }



                Console.WriteLine("Enter Anna's' secret");
                string annaInput = Console.ReadLine();

                if (int.TryParse(annaInput, out annaSecret))
                {
                    annaSecret = (int) Convert.ToInt64(annaInput);
                    processThis++;

                }
                else
                {
                    Console.WriteLine(annaInput + "is not a number");

                }




                Console.WriteLine("Enter Boris's secret");
                string borisInput = Console.ReadLine();

                if (int.TryParse(borisInput, out borisSecret))
                {
                    borisSecret = (int) Convert.ToInt64(borisInput);
                    processThis++;

                }
                

                else
                {
                    Console.WriteLine($"{borisInput} + is not a number");
                }

            } while (processThis < 3);



            long mod = 601457;
       
            long Anna = diff_hell(generator, annaSecret, mod);
            long temp = Anna;
            long Boris = diff_hell(generator, borisSecret, mod);
            Anna = Boris;
            Boris = temp;
            Anna = diff_hell(Anna, annaSecret, mod);
            Boris = diff_hell(Boris, borisSecret, mod);
            Console.WriteLine("The shared secret for Anna is {0} and for Boris is {1}", Anna, Boris);
 
 
 
 
            return "";
 
 
 
        }
       
       
 
        public static long  diff_hell(long  a, long b, long c)
        {
            if (b == 0)
            {
                return 1;
            }
            else if (b%2 ==0)
 
            {
                long d = diff_hell(a, b / 2, c);
                return (d * d) % c;
            }
            else
            {
                return ((a % c) * diff_hell(a, b - 1, c)) % c;
            }
       
        }
    }
}