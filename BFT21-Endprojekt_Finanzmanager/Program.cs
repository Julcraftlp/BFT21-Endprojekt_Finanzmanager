using BFT21_Endprojekt_Finanzmanager.Database;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menue.Init();
            Console.WriteLine("Disclaimer:\nThis software is for demonstrational purposes only\nUse at your own risk, the software does not guarante Anything.\n" +
                "\nAt any point you can return to the Menue by pressing Escape,\nonly exeption is the Register/Login screen\nIf you do so at any point in this screen the program will terminate Immediately\n" +
                "Press Enter to confirm & Continue or Escape to exit\n");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key == ConsoleKey.Escape)
                    Environment.Exit(130);
            } while (keyinfo.Key != ConsoleKey.Enter);
            User user;

            do
            {
                user = Menue.LoginScreen();
            } while (user == null);
            Console.ReadLine();
        }
    }
}