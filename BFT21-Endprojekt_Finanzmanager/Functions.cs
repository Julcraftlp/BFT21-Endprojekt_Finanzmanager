﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Functions
    {
        public static string? InvisType()
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = "";
            string CharList1 = "abcdefghijklmopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    Entert = Entert + keyInfo.KeyChar;
                    maxlength = Entert.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < Entert.Length; i++)
                {
                    Console.Write("*");
                }
            }
        }
        public static string? Type()
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = "";
            string CharList1 = "abcdefghijklmnopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    Entert = Entert + keyInfo.KeyChar;
                    maxlength = Entert.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength + 1; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                Console.Write(Entert);
            }
        }
        public static string? EditType(string input)
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = input;
            string CharList1 = "abcdefghijklmnopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    Entert = Entert + keyInfo.KeyChar;
                    maxlength = Entert.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength + 1; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                Console.Write(Entert);
            }
        }
        public static string? InvisType(short limit)
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = "";
            string CharList1 = "abcdefghijklmopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    if (Entert.Length < limit)
                    {
                        Entert = Entert + keyInfo.KeyChar;
                        maxlength = Entert.Length;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < Entert.Length; i++)
                {
                    Console.Write("*");
                }
            }
        }
        public static string? Type(short limit)
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = "";
            string CharList1 = "abcdefghijklmnopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    if (Entert.Length < limit)
                    {
                        Entert = Entert + keyInfo.KeyChar;
                        maxlength = Entert.Length;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength + 1; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                Console.Write(Entert);
            }
        }
        public static string? EditType(string input, short limit)
        {
            Console.CursorVisible = true;
            int left;
            int top;
            (left, top) = Console.GetCursorPosition();
            string Entert = input;
            string CharList1 = "abcdefghijklmnopqrstuvwxyzäöü";
            string CharList2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
            string CharList3 = "1234567890";
            string CharList4 = "!@#$%^&*-_+=?/:;,.<>|[]{}";
            int maxlength = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (CharList1.Contains(keyInfo.KeyChar) | CharList2.Contains(keyInfo.KeyChar) | CharList3.Contains(keyInfo.KeyChar) | CharList4.Contains(keyInfo.KeyChar))
                {
                    if (Entert.Length < limit)
                    {
                        Entert = Entert + keyInfo.KeyChar;
                        maxlength = Entert.Length;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace & Entert.Length > 0)
                {
                    Entert = Entert.Substring(0, Entert.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = false;
                    return Entert;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return null;
                }
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < maxlength + 1; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(left, top);
                Console.Write(Entert);
            }
        }
    }
}

