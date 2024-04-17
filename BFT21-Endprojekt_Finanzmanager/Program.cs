using BFT21_Endprojekt_Finanzmanager.Database;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        public static DatabaseDefiner dbContext = new DatabaseDefiner();
        static void Main(string[] args)
        {
        Start:
            Menue.Init();
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
            Console.Write("Initializing");
            User? user = dbContext.Users.Include(u => u.Accounts).FirstOrDefault(u => u.Username == "User");
            if (user == null)
            {
                dbContext.Users.Add(new User { Username = "User", Password = "" });
                dbContext.SaveChanges();
                user = dbContext.Users.Include(a => a.Accounts).FirstOrDefault(u => u.Username == "User");
            }
            if (user == null)
            {
                Console.Write("!!!!!!!!!!!!MeNowIsDead!!!!!!!!!!!!");
            }
            else if (user.Accounts.Count()==0)
            {
                dbContext.Konten.Add(new Account { Name = "Konto", TF1 = "Konto für externe buchungen", User = user });
                dbContext.SaveChanges();
            }
            user = null;
                user = Menue.LoginScreen(dbContext);
            if (user == null)
                goto Start;
            Menue.MainUI(dbContext, user);
        }
    }
}