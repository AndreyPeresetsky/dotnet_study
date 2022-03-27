using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_study.nocvko
{
    internal class Codewars
    {
        // Задание 1.1 +
        public static int summation(int num)
        {
            int s_int = 1;
            string s = "1";
            for (int i = 2; i <= num; i++)
            {
                s += " + " + Convert.ToString(i);
                s_int += i;
            }

            Console.WriteLine(s);
            return s_int;
        }

        // Задание 1.2 +
        public static string JumpingNumber(int number)
        {
            var s = number.ToString();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if ((s[i] - s[i + 1]) != 1 && (s[i] - s[i + 1]) != -1)
                {
                    return "Not!!";
                }
            }
            return "Jumping!!";
        }

        // Задание 1.3 +
        public static string SpecialNumber(int number)
        {
            var s = number.ToString();
            int[] list = {'0', '1', '2', '3', '4', '5' };
            bool inlist = false;
            for (int i = 0; i < s.Length; i++)
            {
                inlist = false;
                foreach (int num in list)
                {
                    if (num == s[i])
                    {
                        inlist = true;
                    }
                }
                if (inlist == false)
                {
                    return "NOT!!";
                }
            }
            return "Special!!";
        }

        // Задагие 1.4 +
        public static string BalancedNumber(int number)
        {
            int half1 = 0;
            int half2 = 0;
            string s = number.ToString();
            int sLength = s.Length;
            for (int i = 0; i <= (sLength / 2); i++)
            { 
                half1 += (int) (System.Convert.ToInt32("" + s[i]));
                half2 += (int) (System.Convert.ToInt32("" + s[sLength - i - 1]));
            }

            if (half1 == half2)
            {
                return "Balanced"; 
            }
            else
            {
                return "Not Balanced";
            }
        }

        // Задание 2.1 +
        public static int MaxNumber(int n)
        {
            string s = n.ToString();
            int[] mas = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                mas[i] = (int)(System.Convert.ToInt32("" + s[i]));
            }
            System.Array.Sort(mas);
            System.Array.Reverse(mas);
            string new_num = "";
            foreach(int num in mas)
            {
                new_num += num;
            }
            int int_new_num = System.Convert.ToInt32(new_num);
            return int_new_num;
        }

        // Задане 2.2 +
        public static int[][] MatrixAddition(int[][] a, int[][] b)
        {
            for(int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < a[i].Length; j++)
                {
                    // Console.Write($"{a[i][j]} + {b[i][j]} = ");
                    a[i][j] += b[i][j];
                    // Console.WriteLine($"{a[i][j]}");
                }
            }

            return a;
        }


        // Задание 2.3 +
        public static (int, int)[] TwosDifference(int[] array)
        {
            (int, int)[] result1 = new (int, int)[array.Length / 2];
            int a = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (System.Math.Abs(array[i] - array[j]) == 2)
                    {                        
                        result1[a] = (array[i], array[j]);
                        a++;
                    }
                }
            }
            return result1;
        }

        // Задание 2.4 +
        public static int ShortestStepsToNum(int num)
        {
            int steps = 0;
            int num_0 = 1;
            while (num > num_0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else if (num % 2 == 1)
                {
                    num--;
                }
                steps++;
            }
            return steps;
        }

        // Задание 3.1
        public static string Swap(string s)
        {            
            char [] s_char = s.ToCharArray();
            int N = s.Length;
            for (int i = 0; i < N; i++)
            {
                if (s_char[i] == 'a' || s_char[i] == 'e' ||
                    s_char[i] == 'i' || s_char[i] == 'o' ||
                    s_char[i] == 'u')
                {
                    s_char[i] = s_char[i].ToString().ToUpperInvariant().ToCharArray()[0];
                }
            }
            return new string(s_char);
        }

        // Задание 3.2
        public static bool Solution(string str, string ending)
        { 
            string str1 = "" ;
            string ending1 = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                str1 += str[i];
            }

            for (int i = ending.Length - 1; i >= 0; i--)
            {
                ending1 += ending[i];
            }
            
            if (str1.IndexOf(ending1) == 0){      
                return true;
            }
            return false;
        }

        // Заданеи 3.3
        public static string Balance1(string book)
        {
            string[] list_of_string0 = book.Split('\n');
            string[] list_of_string = new string[list_of_string0.Length];
            for (int i = 0; i < list_of_string0.Length; i++)
            {
                byte c_ = 0;
                for (int j = 0; j < list_of_string0[i].Length; j++)
                {
                    char c = list_of_string0[i][j];
                    if (Char.IsLetterOrDigit(c) ^ c == '.' ^ c == ' ' ^ c == ',')
                    {
                        if (c == ' ')
                        {
                            c_++;
                            if (c_ >= 2)
                            {
                                continue;
                            }
                            else
                            {
                                list_of_string[i] += c;
                            }
                        }
                        else
                        {
                            list_of_string[i] += c;
                            c_ = 0;
                        }
                    }
                }
            }
            string first_string0 = list_of_string[0].Replace(" ", "").Replace(".", ",");
            string first_string = "";
            foreach (char c in first_string0)
            {
                if (Char.IsDigit(c) ^ c == ',')
                {
                    first_string += c;
                }
            }
            float balance = float.Parse(first_string);
            //float balance = float.Parse(list_of_string[0].Replace(" ", "").Replace(".", ","));
            float balance_0 = balance;
            list_of_string[0] = "Original Balance: " + list_of_string[0].Trim();
            string book1 = "";
            for (int i = 1; i < list_of_string.Length; i++)
            {
                //Console.WriteLine(list_of_string[i].Split()[2].Trim().Replace('.', ','));
                balance -= float.Parse(list_of_string[i].Split()[2].Trim().Replace(',', ' ').Replace('.', ','));
                list_of_string[i] = list_of_string[i].Trim() + " Balance " + balance.ToString().Replace(",", "."); // .Replace(' ', '_')
                //book1 += list_of_string[i].Trim().Replace(' ', '_') + "_Balance_" + balance.ToString() + "\n";
            }
            //Console.WriteLine();
            foreach(string str in list_of_string)
            {
                book1 += str + "\n";
            }

            float total_expense = balance_0 - balance;
            float average_expense = total_expense / (list_of_string.Length - 1);
            book1 += "Total expense  " + total_expense.ToString().Replace(",", ".") + "\n" + "Average expense  " + average_expense.ToString().Replace(",", ".");
            //Console.WriteLine();
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            
            return book1;
        }

        // Задание 3.3 которое прошло тестирование +
        public static string Balance(string book)
        {
            string[] list_of_string0 = book.Split('\n');
            string[] list_of_string = new string[list_of_string0.Length];
            for (int i = 0; i < list_of_string0.Length; i++)
            {
                byte c_ = 0;
                for (int j = 0; j < list_of_string0[i].Length; j++)
                {
                    char c = list_of_string0[i][j];
                    if (Char.IsLetterOrDigit(c) ^ c == '.' ^ c == ' ')// ^ c == ',')
                    {
                        if (c == ' ')
                        {
                            c_++;
                            if (c_ >= 2)
                            {
                                continue;
                            }
                            else
                            {
                                list_of_string[i] += c;
                            }
                        }
                        else
                        {
                            list_of_string[i] += c;
                            c_ = 0;
                        }
                    }
                }
            }
            string first_string0 = list_of_string[0].Replace(" ", "").Replace(".", ",");
            string first_string = "";
            foreach (char c in first_string0)
            {
                if (Char.IsDigit(c) ^ c == ',')
                {
                    first_string += c;
                }
            }
            float balance = float.Parse(first_string);
            //float balance = float.Parse(list_of_string[0].Replace(" ", "").Replace(".", ","));
            float balance_0 = balance;
            list_of_string[0] = "Original Balance: " + list_of_string[0].Trim();
            string book1 = "";
            for (int i = 1; i < list_of_string.Length; i++)
            {
                //Console.WriteLine(list_of_string[i].Split()[2].Trim().Replace('.', ','));
                balance -= float.Parse(list_of_string[i].Split()[2].Trim().Replace(',', ' ').Replace('.', ','));
                list_of_string[i] = list_of_string[i].Trim() + " Balance " + (balance / 100).ToString("0.00");//.Replace(",", "."); // .Replace(' ', '_')
                //book1 += list_of_string[i].Trim().Replace(' ', '_') + "_Balance_" + balance.ToString() + "\n";
            }
            //Console.WriteLine();
            foreach(string str in list_of_string)
            {
                book1 += str + "\n";
            }

            float total_expense = balance_0 - balance;
            float average_expense = total_expense / (list_of_string.Length - 1);
            book1 += "Total expense  " + (total_expense / 100).ToString("0.00").Replace(",", ".") + "\n" + "Average expense  " + System.Math.Round(average_expense / 100, 2).ToString("0.00").Replace(",", ".");
            //Console.WriteLine();
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            
            return book1;
  }
  
        // Задание 3.3 которое прошло тестирование +
        public static void test_Balance()
        {
            string[] test_arr = new string[3];
            test_arr[0] = "      1000.00 \n125 Market 125.45\n126 Hardware 34.95\n127 Video 7.45\n128 Book 14.32\n129 Gasoline 16.10";
            test_arr[1] = "1000.00!=\n125 Market !=:125.45\n126 Hardware =34.95\n127 Video! 7.45\n128 Book   :14.32\n129 Gasoline ::16.10";
            //test_arr[2] = "Original Balance: 1000.00\n125 Market 125.45 Balance 874.55\n126 Hardware 34.95 Balance 839.60\n127 Video 7.45 Balance 832.15\n128 Book 14.32 Balance 817.83\n129 Gasoline 16.10 Balance 801.73\nTotal expense  198.27\nAverage expense  39.65";
            test_arr[2] = "1233.00\n125 Hardware;! 24.80?\n123 Flowers 93.50;\n127 Meat 120.90\n120 Picture 34.00\n124 Gasoline 11.00\n123 Photos;! 71.40?\n122 Picture 93.50\n132 Tyres;! 19.00,?;\n129 Stamps; 13.60\n129 Fruits{} 17.60\n129 Market;! 128.00?\n121 Gasoline;! 13.60?";
            //test_arr[4] = "Original Balance: 1233.00\n125 Hardware 24.80 Balance 1208.20\n123 Flowers 93.50 Balance 1114.70\n127 Meat 120.90 Balance 993.80\n120 Picture 34.00 Balance 959.80\n124 Gasoline 11.00 Balance 948.80\n123 Photos 71.40 Balance 877.40\n122 Picture 93.50 Balance 783.90\n132 Tyres 19.00 Balance 764.90\n129 Stamps 13.60 Balance 751.30\n129 Fruits 17.60 Balance 733.70\n129 Market 128.00 Balance 605.70\n121 Gasoline 13.60 Balance 592.10\nTotal expense  640.90\nAverage expense  53.41";
            byte i = 0;
            foreach (string str in test_arr)
            {
                Console.WriteLine("===============================================================================================================");
                Console.WriteLine(i++);
                Console.WriteLine(str);
                Console.WriteLine();
                Console.WriteLine(Balance(str));
                Console.WriteLine("===============================================================================================================");
            }
        }

        // Задание 3.4
        public static string AlphabetPosition(string text)
        {
            //Console.WriteLine(((short)'z'));
            text = text.ToLower();
            string text_of_num = "";
            foreach (char c in text)
            {
                if (System.Char.IsLetter(c))
                {
                    text_of_num += ((short)c - 96).ToString() + " ";
                }
                
            }
            return text_of_num.Substring(0, text_of_num.Length - 1);
        }


        static public void Run()
        {
            // test();
            Console.WriteLine("hgf");
            Console.ReadKey();
            
        }

        public static void test()
        {
            // Задание 2.2 +
            // int[][] a = MatrixAddition( new int[][] { new int[] { 1, 2, 3}, new int[] { 3, 2, 1}, new int[] { 1, 1, 1} }, new int[][] { new int[] { 2, 2, 1}, new int[] { 3, 2, 3}, new int[] { 1, 1, 3} } 

            /*int[] array = { 1, 2, 3 };
            Array.Clear(array, 0, 1);
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }*/

            // TwosDifference(new int []{ 1, 2, 3, 4});
            
            /*
            Test test_cls = new Test();
            int n = Convert.ToInt32(Console.ReadLine());
            test_cls.test_list(n);
            */
            //Console.WriteLine(Swap("Hello World"));
            
            //Console.WriteLine(string.Compare("abc", "bc"));

            //string s = "abc";
            //string a = "a";
            //Console.WriteLine(s.IndexOf(a));
            // Console.WriteLine(Solution("abc", "bs"));

            //test_Balance();
            //Console.WriteLine(AlphabetPosition("The sunset sets at twelve o' clock."));
            //Console.WriteLine((short)'');
            //Console.WriteLine(Balance("      1000.00 \n125 Market 125.45\n126 Hardware 34.95\n127 Video 7.45\n128 Book 14.32\n129 Gasoline 16.10"));
            
            //Console.WriteLine(string.Compare("abc", "d"));
            //Console.WriteLine(string.Compare("abc", "abc"));
            // Test.Main1();
            //Matrix matrix = new Matrix();
            

            



        }
    }
}
