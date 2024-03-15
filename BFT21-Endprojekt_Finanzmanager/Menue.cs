using BFT21_Endprojekt_Finanzmanager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Menue
    {
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(102, 22);
            Console.SetBufferSize(102, 22);
            Console.Clear();
        }
        public static void Draw()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  ###############################################-FiMa-###############################################");
            for (int i = 0;i < 19; i++)
            {
            Console.WriteLine("  #                                                                                                  #");
            }
            Console.Write("  ##############################################-Alpha1-##############################################");
        }
        internal static Program LoginScreen()
        {
            Console.Clear();
            Console.WriteLine("R/L:");
            string eing = Console.ReadLine().ToLower();
            switch (eing)
            {
                case "r":
                    Console.Clear();
                    Console.WriteLine("Login:\nPassword:");
                    Console.SetCursorPosition(6, 0);
                    Console.ReadLine();
                    Console.SetCursorPosition(9, 1);
                    Functions.InvisType();
                    break;
                case "l":
                    break;
                case "exit":
                    Environment.Exit(130);
                    break;

            }
            return null;
        }
    }
}
