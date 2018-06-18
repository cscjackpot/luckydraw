using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDraw
{
    class Program
    {
        private static int NumberBall = 39;
        private static int LuckyBall = 18;
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Enter block hash:");
            string line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                CheckReult(line);
            }
        }
        private static void CheckReult(string strBlockHash)
        {
            string result = string.Empty;
            StringBuilder strBuilder = new StringBuilder();
            List<int> lstResultNumber = new List<int>();
            try
            {
                char[] array = strBlockHash.ToCharArray();
                if (array.Length > 0)
                {
                    List<string> lst = new List<string>();
                    string str = string.Empty;
                    int k = 0;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        str = str + array[i];
                        k++;
                        if (k % 4 == 0)
                        {
                            string number = ReverseNumber(str);
                            k = 0;
                            lst.Add(number);
                            str = string.Empty;
                        }
                    }


                    if (lst != null && lst.Count > 0)
                    {
                        foreach (var item in lst)
                        {
                            int test = Convert.ToInt32(item, 16);
                            if (lstResultNumber.Count < 5)
                            {
                                test = test % NumberBall;
                                if (!lstResultNumber.Contains(test))
                                {
                                    if (test == 0)
                                    {
                                        test = NumberBall;
                                    }
                                    lstResultNumber.Add(test);
                                }
                            }
                            else if (lstResultNumber.Count == 5)
                            {
                                test = test % LuckyBall;
                                if (test == 0)
                                {
                                    test = LuckyBall;
                                }
                                lstResultNumber.Add(test);
                                break;
                            }
                        }
                    }
                }
                if (lstResultNumber != null && lstResultNumber.Count > 5)
                {
                    Console.WriteLine("Balls 1: " + lstResultNumber[0]);
                    Console.WriteLine("Balls 2: " + lstResultNumber[1]);
                    Console.WriteLine("Balls 3: " + lstResultNumber[2]);
                    Console.WriteLine("Balls 4: " + lstResultNumber[3]);
                    Console.WriteLine("Balls 5: " + lstResultNumber[4]);
                    Console.WriteLine("Lucky Ball : " + lstResultNumber[5]);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string ReverseNumber(string number)
        {
            string str = string.Empty;
            char[] array = number.ToCharArray();
            if (array.Length > 0)
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    str = str + array[i];
                }
            }
            return str;
        }
    }
}
