using BFT21_Endprojekt_Finanzmanager;
using BFT21_Endprojekt_Finanzmanager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Menue
    {
        //static DatabaseDefiner dbContext = new DatabaseDefiner();
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(102, 22);
            Console.SetBufferSize(102, 22);
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
        }
        internal static User? LoginScreen()
        {
            Console.Clear();
            Console.Write("[R]/[L]");
            ConsoleKeyInfo eing = Console.ReadKey();
            switch (eing.Key)
            {
                case ConsoleKey.R:
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("FirstName:");
                        string? fn = Functions.Type(20);
                        if (fn == null) return null;
                        Console.Write("\nLastName:");
                        string? ln = Functions.Type(20);
                        if (ln == null) return null;
                        Console.Clear();
                    Password:
                        Console.Write("LoginCredentials::\nUsername:");
                        string? l = Functions.Type(20);
                        if (l == null)
                            return null;
                        else if (l == "")
                        {
                            Console.Clear();
                            Console.Write("Username may not be empty\nEnter to try agan\nEscape to exit");
                            while (true)
                            {
                                ConsoleKeyInfo keyinfo = Console.ReadKey();
                                if (keyinfo.Key == ConsoleKey.Enter)
                                    goto Password;
                                if (keyinfo.Key == ConsoleKey.Escape)
                                    return null;
                            }
                        }
                        else if (Program.dbContext.Users.Any(u => u.Username == l))
                        {
                            Console.Clear();
                            Console.Write("Username Already in use\nEnter to try agan\nEscape to exit");
                            while (true)
                            {
                                ConsoleKeyInfo keyinfo = Console.ReadKey();
                                if (keyinfo.Key == ConsoleKey.Enter)
                                    goto Password;
                                if (keyinfo.Key == ConsoleKey.Escape)
                                    return null;
                            }
                        }
                        Console.CursorVisible = false;
                        Console.Write("\nPassword:");
                        string? pw1 = Functions.InvisType(52);
                        if (pw1 == null)
                            return null;
                        Console.Write("\nRepeat:");
                        string? pw2 = Functions.InvisType(52);
                        if (pw2 == null)
                            return null;
                        if (pw1 != pw2)
                        {
                            Console.Clear();
                            Console.WriteLine("Password's Don't Match\nEnter to try agan\nEscape to exit");
                            while (true)
                            {
                                ConsoleKeyInfo keyinfo = Console.ReadKey();
                                if (keyinfo.Key == ConsoleKey.Enter)
                                    goto Password;
                                if (keyinfo.Key == ConsoleKey.Escape)
                                    return null;
                            }
                        }
                        User user = new User();
                        user.FirstName = fn;
                        user.LastName = ln;
                        user.Username = l;
                        user.Password = pw1;
                        Program.dbContext.Users.Add(user);
                        Program.dbContext.SaveChanges();
                        return user;
                    }
                case ConsoleKey.L:
                    {
                    Username:
                        Console.Clear();
                        Console.Write("Username:");
                        string? un = Functions.Type(20);
                        User? user = Program.dbContext.Users.FirstOrDefault(u => u.Username == un);
                        if (user == null)
                        {
                            Console.Clear();
                            Console.Write("Username Not Found\nEnter to try agan\nEscape to exit");
                            while (true)
                            {
                                ConsoleKeyInfo keyinfo = Console.ReadKey();
                                if (keyinfo.Key == ConsoleKey.Enter)
                                    goto Username;
                                if (keyinfo.Key == ConsoleKey.Escape)
                                    return null;
                            }
                        }
                        else
                        if (user.LockedUntil > DateTime.Now)
                        {
                            Console.Clear();
                            Console.Write($"The user {user.Username} is currently locked\nit unlocks at {user.LockedUntil}.\nConfirm with Enter");
                            while (Console.ReadKey().Key == ConsoleKey.Enter) { }
                            return null;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write("\nPassword:");
                            string? pw = Functions.InvisType(52);
                            if (pw == null)
                                return null;
                            if (pw != user.Password)
                            {
                                Console.Clear();
                                Console.Write($"Wrong password {2 - i} tries left\nUsername:{un}");
                            }
                            else
                            {
                                return user;
                            }
                        }
                        user.LockedUntil = DateTime.Now.AddMinutes(5);
                        Program.dbContext.SaveChanges();
                        Console.Write($"\nAccaunt is now being locked until {user.LockedUntil}\nConfirm with Enter");
                        while (Console.ReadKey().Key == ConsoleKey.Enter) { }
                        return null;
                    }
                case ConsoleKey.Escape:
                    Environment.Exit(130);
                    break;

            }
            return null;
        }
        internal static void MainUI(User user)
        {
            Start:
            Console.Clear();
            Console.Write(" ╔══════════════════════════════╦══╦══════════Main-Menue══════════════╦═════════════════════════════╗\n" +
                          " ╠═══════════UserInfo═══════════╣  ╠═════════════Accounts═════════════╣                             ║\n" +
                          " ║FirstName:{0,-20}" +         "║  ╠════════Name════════╦════Value════╣                             ║\n" +
                          " ║LastName :{1,-20}" +         "║                                                                   ║\n" +
                          " ║Username :{2,-20}" +         "║                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╝                                                                   ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ╚══════════════════════════════════════════════════════════════════════════════════════════════════╝"
                , user.FirstName, user.LastName, user.Username);
            short verticalPos = 3;
            Console.SetCursorPosition(35, verticalPos);
            if (user.Accounts != null)
            {
                foreach (Account account in user.Accounts)
                {
                    if (verticalPos > 20)
                        break;
                    string formattedValue = account.Betrag.ToString("#,0.00", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                    Console.SetCursorPosition(35, verticalPos);
                    Console.Write("║{0,-20}║{1,13}║", account.Name, formattedValue);
                    verticalPos++;
                }
            }
            Console.SetCursorPosition(35, verticalPos);
            if (verticalPos < 21)
            {
                Console.Write("╚════════════════════╩═════════════╝");
            } else
            {
                Console.Write("╩════════════════════╩═════════════╩");
            }
            //verticalPos = 6;
            verticalPos = 1;
            while (true)
            {
                Console.SetCursorPosition(0, 6);
                if (verticalPos < 1)
                    verticalPos = 1;
                if (verticalPos > 5)
                    verticalPos = 5;
                //Profile Settings
                //Active
                Console.Write(" ╠═══");
                if (verticalPos == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Profile Settings\n");
                //Manage Accounts
                //Inactive
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Manage Accounts\n");
                //Manage Transactions
                //Inactive
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Manage Transactions\n");
                //Log Out
                //Active
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Log Out\n");
                //Exit Programm
                //Active
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Exit Programm\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        verticalPos--;
                        break;
                    case ConsoleKey.DownArrow:
                        verticalPos++;
                        break;
                    case ConsoleKey.Enter:
                        switch (verticalPos)
                        {
                            case 1://Profile Settings
                                ProfileSettings(user);
                                goto Start;
                            case 2://Manage Accounts
                                break;
                            case 3://Manage Transactions
                                break;
                            case 4://Log Out
                                return;
                            case 5://Exit Programm
                                Environment.Exit(130);
                                break;
                        }
                        break;
                }
            }
        }
        internal static void ProfileSettings(User user)
        {
            Start:
            Console.Write(" ╔══════════════════════════════╦═══════════User-SettIngs═══════════════════════════════════════════╗\n" +
                          " ╠═══════════UserInfo═══════════╣                                                                   ║\n" +
                          " ║FirstName:{0,-20}" +         "║                                                                   ║\n" +
                          " ║LastName :{1,-20}" +         "║                                                                   ║\n" +
                          " ║Username :{2,-20}" +         "║                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠══════════════════════════════╝                                                                   ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ║                                                                                                  ║\n" +
                          " ╚══════════════════════════════════════════════════════════════════════════════════════════════════╝"
                , user.FirstName, user.LastName, user.Username);
            short verticalPos = 1;
            while (true)
            {
                Console.SetCursorPosition(0, 6);
                if (verticalPos < 1)
                    verticalPos = 1;
                if (verticalPos > 5)
                    verticalPos = 5;
                Console.Write(" ╠═══");
                if (verticalPos == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("First Name\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Last Name\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Username\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Password\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ╠═══");
                if (verticalPos == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write("Return\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Gray;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        verticalPos--;
                        break;
                    case ConsoleKey.DownArrow:
                        verticalPos++;
                        break;
                    case ConsoleKey.Enter:
                        string? result = null;
                        switch (verticalPos)
                        {
                            case 1://First Name
                                Console.SetCursorPosition(11, 2);
                                result = Functions.EditType(user.FirstName, 20);
                                if (result == null)
                                    goto Start;
                                user.FirstName = result;
                                goto Start;
                            case 2://Last Name
                                Console.SetCursorPosition(11, 3);
                                result = Functions.EditType(user.LastName, 20);
                                if (result == null)
                                    goto Start;
                                user.LastName = result;
                                goto Start;
                            case 3://Username
                                Console.SetCursorPosition(11, 4);
                                result = Functions.EditType(user.Username, 20);
                                if (result == null)
                                    goto Start;
                                user.Username = result;
                                goto Start;
                            case 4://Password
                                Password:
                                Console.SetCursorPosition(32, 1);
                                Console.Write("╬═══════════════════════════════════════════════════════════════════╣");
                                Console.SetCursorPosition(32, 2);
                                Console.Write("║Old Password:");
                                Console.SetCursorPosition(32, 3);
                                Console.Write("║New Password:");
                                Console.SetCursorPosition(32, 4);
                                Console.Write("║Repeat      :");
                                Console.SetCursorPosition(32, 5);
                                Console.Write("╬═══════════════════════════════════════════════════════════════════╣");

                                Console.SetCursorPosition(46, 2);
                                string? pw1 = Functions.InvisType(52);
                                if (pw1 == null)
                                    goto Start;
                                else if (pw1 != user.Password)
                                {
                                    //Error msg here
                                    goto Password;
                                }
                                Console.SetCursorPosition(46, 3);
                                string? pw2 = Functions.InvisType(52);
                                if (pw2 == null)
                                    goto Start;
                                Console.SetCursorPosition(46, 4);
                                string? pw3 = Functions.InvisType(52);
                                if (pw3 == null)
                                    goto Start;
                                if (pw2 == pw3)
                                {
                                    user.Password = pw2;
                                    Program.dbContext.SaveChanges();
                                    goto Start;
                                } else
                                {
                                    //Error msg here
                                    goto Password;
                                }
                            case 5://Return
                                return;
                        }
                        break;
                }
            }
        }
    }
}
