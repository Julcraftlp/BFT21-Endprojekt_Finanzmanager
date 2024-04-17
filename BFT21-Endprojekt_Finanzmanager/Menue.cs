﻿using BFT21_Endprojekt_Finanzmanager.Database;
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
        internal static User LoginScreen(DatabaseDefiner dbContext)
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
                        Console.Write("\nPassword:");
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
                            string pw = Functions.InvisType();
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
        internal static void MainUI(DatabaseDefiner dbContext, User user)
        {
            
            Console.Clear();
            Console.Write(" ╔══════════════════════════════╦══╦══════════Main-Menue══════════════╦═════════════════════════════╗\n" +
                          " ╠═══════════UserInfo═══════════╣  ╠═════════════Accounts═════════════╣                             ║\n" +
                          " ║FirstName:{0,20}" +          "║  ╠════════Name════════╦════Value════╣                             ║\n" +
                          " ║LastName :{1,20}" +          "║                                                                   ║\n" +
                          " ║Username :{2,20}" +          "║                                                                   ║\n" +
                          " ╠══════════════════════════════╣                                                                   ║\n" +
                          " ╠═══Profile Settings═══════════╣                                                                   ║\n" +
                          " ╠═══Manage Accounts════════════╣                                                                   ║\n" +
                          " ╠═══Manage Transactions════════╣                                                                   ║\n" +
                          " ╠═══Log Out════════════════════╣                                                                   ║\n" +
                          " ╠═══Exit Programm══════════════╝                                                                   ║\n" +
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
                if (verticalPos == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ╠═══Profile Settings═══════════\n");
                if (verticalPos == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ╠═══Manage Accounts════════════\n");
                if (verticalPos == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ╠═══Manage Transactions════════\n");
                if (verticalPos == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ╠═══Log Out════════════════════\n");
                if (verticalPos == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ╠═══Exit Programm══════════════\n");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        verticalPos--;
                        break;
                    case ConsoleKey.DownArrow:
                        verticalPos++;
                        break;
                    case ConsoleKey.Enter:
                        //Missing Case Handling
                        break;
                }
            }
        }
    }
}
