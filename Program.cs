using System;


namespace dotnet_study
{
    public class Program
    {
        static public void Main()
        {
            // NocvkoСourses();
            TestShop1();
        }

        static public void TestShop1()
        {
            Shop1.Shop1 shop1 = new Shop1.Shop1(5000);
            shop1.AddFuncForMes(Console.WriteLine);
            shop1.Bue(59);
            shop1.Supply(600);

        }

        static public void NocvkoСourses()
        {
            Console.WriteLine("Test Codewars");
            nocvko.Codewars.Run();
            Console.ReadKey();

            Console.WriteLine("Test Matrix");
            nocvko.RunMatrix.Run();
            Console.ReadKey();

            Console.WriteLine("Test Figure");
            nocvko.RunFigure.Run();
            Console.ReadKey();

            Console.WriteLine("Test Chess");
            nocvko.RunChess.Run();
            Console.ReadKey();
        }
    }
}
