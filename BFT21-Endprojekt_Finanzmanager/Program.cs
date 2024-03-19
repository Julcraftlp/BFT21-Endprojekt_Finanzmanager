using BFT21_Endprojekt_Finanzmanager.Database;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;



namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region Test-AI
                DatabaseDefiner dbContext = new DatabaseDefiner();
                
                dbContext.BankLeitZahl.Add(new BLZ{Nummer=123,Bank="Test"});
                dbContext.SaveChangesAsync();

                BLZ bank_aktuell = dbContext.BankLeitZahl.FirstOrDefault(k => k.Id == 1); // Angenommen, die ID ist bekannt
                if (bank_aktuell != null)
                {
                    Console.WriteLine(bank_aktuell.Bank);
                }

            #endregion

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