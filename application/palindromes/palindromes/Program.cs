using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindromes
{
    class Program
    {
        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int flag = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string first = input.Substring(0, i);
                string second = input.Substring(i);
                string result = second + first;
                if (IsPalindrome(result))
                {
                    flag = 1;
                    Console.WriteLine(result);
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("NONE");
            }

        }
    }
}
