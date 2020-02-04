using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using MenuSystem;
using CryptoAlgo;

namespace pleaseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("بِسْمِ ٱللّٰهِ ٱلرَّحْمٰنِ ٱلرَّحِيمِ"); //in the name  of God, the most precious
            Console.WriteLine("Bismillarhhirahmaanirrahiimِ"); //and the most merciful
            var menu0 = new Menu(0)
            {
                Title = "Choose Crypto",
                MenuItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Command = "1",
                        Title = "Caesar Cipher",
                        CommandToExecute = Caesar.RunCaesar
                    },

                    new MenuItem()
                    {
                        Command = "2",
                        Title = "Vigenere",
                        CommandToExecute = Vigenere.RunVigener
                    },
                    new MenuItem()
                    {
                        Command = "3",
                        Title = "Diffie-Hellman Key Exchange",
                        CommandToExecute = DH.RunDH
                    },
                    
                    new MenuItem()
                    {
                        Command = "4",
                        Title = "RSA",
                        CommandToExecute = RSAhw2.runRSA
                    }
                    
                    

                }
            };
            menu0.Run();
        }

    }
        
}
