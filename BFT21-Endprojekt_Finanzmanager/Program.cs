using BFT21_Endprojekt_Finanzmanager.Database;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menue.Init();
            //Menue.Draw();
            Console.WriteLine("Disclaimer:\nThis software is for demonstrational purposes only\nUse at your own risk, the software does not guarante Anything.\n" +
                "\nAt any point you can navigate to the Main menu by typing exit,\nonly exeption is the Register/Login screen\nIf u type exit at any point in this screen the program will terminate Immediately\n" +
                "Press Enter to confirm & Continue\n");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
            } while (keyinfo.Key != ConsoleKey.Enter);
            Program person = Menue.LoginScreen();
            Console.ReadLine();
        }
    }
}