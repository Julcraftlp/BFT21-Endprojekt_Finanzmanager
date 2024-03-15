using BFT21_Endprojekt_Finanzmanager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;
using Microsoft.EntityFrameworkCore;
namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Menue
    {
        static DatabaseDefiner dbContext = new DatabaseDefiner();
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(102, 22);
            Console.SetBufferSize(102, 22);
            Console.Clear();
        }
        /*public static void Draw()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  ###############################################-FiMa-###############################################");
            for (int i = 0;i < 19; i++)
            {
            Console.WriteLine("  #                                                                                                  #");
            }
            Console.Write("  ##############################################-Alpha1-##############################################");
        }*/
        internal static User LoginScreen()
        {
            Console.Clear();
            Console.Write("R/L:");
            ConsoleKeyInfo eing = Console.ReadKey();
            switch (eing.Key)
            {
                case ConsoleKey.R:
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("FirstName:");
                        string fn = Functions.Type();
                        if (fn == null)
                            return null;
                        Console.Write("\nLastName:");
                        string ln = Functions.Type();
                        if (ln == null)
                            return null;
                        Console.Clear();
                    Password:
                        Console.Write("LoginCredentials::\nUsername:");
                        string l = Functions.Type();
                        if (l == null)
                            return null;
                        if (dbContext.Users.Any(u => u.Username == l))
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
                        Console.Write("Password:");
                        string pw1 = Functions.InvisType();
                        if (pw1 == null)
                            return null;
                        Console.Write("\nRepeat:");
                        string pw2 = Functions.InvisType();
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
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        return user;
                    }
                case ConsoleKey.L:
                    {
                        Username:
                        Console.Clear();
                        Console.Write("Username:");
                        string un = Functions.Type();
                        User user = dbContext.Users.FirstOrDefault(u => u.Username == un);
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
                            string pw = Functions.InvisType();
                            if (pw == null)
                                return null;
                            if (pw != user.Password)
                            {
                                Console.Clear();
                                Console.Write($"Wrong password this is try {i} of 3");
                            }
                        }
                        user.LockedUntil = DateTime.Now.AddMinutes(90);
                        dbContext.SaveChanges();
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
    }
}
