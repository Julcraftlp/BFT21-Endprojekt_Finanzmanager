using BFT21_Endprojekt_Finanzmanager.Database;

namespace BFT21_Endprojekt_Finanzmanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menue.Init();
            Menue.Draw();
            Person person = Menue.Login();
            Console.ReadLine();
        }
    }
}