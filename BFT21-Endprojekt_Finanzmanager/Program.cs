using BFT21_Endprojekt_Finanzmanager.Database;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Start:
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
            Console.Write("Initializing");
            DatabaseDefiner dbContext = new DatabaseDefiner();
            User user = dbContext.Users.FirstOrDefault(u => u.Username == "User");
            if (user == null)
            {
                dbContext.Users.Add(new User { Username = "User", Password = "" });
                dbContext.SaveChanges();
                user = dbContext.Users.FirstOrDefault(u => u.Username == "User");
            }
            if (user == null)
            {
                Console.Write("!!!!!!!!!!!!MeNowIsDead!!!!!!!!!!!!");
            }
            else if (!user.Konten.Any())//Unknown Error Here
            {
                user.Konten.Add(new Konto { Name = "Konto", TF1 = "Konto für externe buchungen", User = dbContext.Users.Find(new User { Username = "User", Password = "" }) });
                dbContext.SaveChanges();
            }
            user = null;
            /*if (!dbContext.Users.Any())
            {
                User newUser = new User();
                newUser.Username = "StandardUser";
                newUser.Password = "";
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
            }
            if (!dbContext.Konten.Any())
            {
                Konto newKonto = new Konto();
                newKonto.Name = "StandartBuchungskonto";
                newKonto.User = dbContext.Users.FirstOrDefault(u => u.Username == "StandardUser");
                newKonto.TF1 = "Konto für externe buchungen";
                dbContext.Konten.Add(newKonto);
                dbContext.SaveChanges();
            }*/
                user = Menue.LoginScreen(dbContext);
            if (user == null)
                goto Start;
            Menue.MainUI(dbContext, user);
        }
    }
}