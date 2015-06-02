using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brackets
{
    class Program
    {
        public static bool isValid(string expression)
        {
            List<char> list = new List<char>();
            if (expression[0] != '{' && expression[0] != '[' && expression[0] != '(')
            {
                return false;
            }
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '{' || expression[i] == '}' || expression[i] == '(' || expression[i] == ')' || expression[i] == '[' || expression[i] == ']')
                {
                    list.Add(expression[i]);
                }
            }

            int countSmallBrackets = 0;
            int countMediumBrackets = 0;
            int countLargeBrackets = 0;

            for (int i = 0; i < list.Count; i++)
            {
                switch (list[i])
                {
                    case '{': countLargeBrackets++; break;
                    case '}': countLargeBrackets--; break;
                    case '[': countMediumBrackets++; break;
                    case ']': countMediumBrackets--; break;
                    case '(': countSmallBrackets++; break;
                    case ')': countSmallBrackets--; break;
                    default:
                        break;
                }

                if (list[i] == '{' && i > 0)
                {
                    return false;
                }

                if (countSmallBrackets > 1 || countMediumBrackets > 1 || countLargeBrackets > 1)
                {
                    return false;
                }

                if (countSmallBrackets < 0 || countMediumBrackets < 0 || countLargeBrackets < 0)
                {
                    return false;
                }

                if (list[i] == ']' && countSmallBrackets > 0)
                {
                    return false;
                }

                if (list[i] == '[' && countSmallBrackets > 0)
                {
                    return false;
                }

                if (list[i] == '(' && countMediumBrackets == 0 && countLargeBrackets == 1)
                {
                    return false;
                }

            }
            return true;
        }

        public static long inAnyBrackets(string expression, int position, int counter)
        {
            long result = 0;
            result = int.Parse(expression[position].ToString())*(long)Math.Pow(10,counter);
            return result;
        }

        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            bool isInSmallBrackets = false;
            bool isInMiddleBrackets = false;
            bool isInLargeBrackets = false;
            long result = 0;

            if (isValid(expression))
            {
                int counter = 0;

                for (int i = expression.Length - 1; i >= 0; i--)
                {
                    if (expression[i] == '}')
                    {   
                        isInLargeBrackets = true;
                        counter = 0;
                        continue;
                    }
                    else if (expression[i] == ']')
                    {
                        isInMiddleBrackets = true;
                        counter = 0;
                        continue;
                    }
                    else if (expression[i] == ')')
                    {
                        isInSmallBrackets = true;
                        counter = 0;
                        continue;
                    }
                    else if (expression[i] == '{')
                    {
                        isInLargeBrackets = false;
                        counter = 0;
                        continue;
                    }
                    else if (expression[i] == '[')
                    {
                        isInMiddleBrackets = false;
                        counter = 0;
                        continue;
                    }
                    else if (expression[i] == '(')
                    {
                        isInSmallBrackets = false;
                        counter = 0;
                        continue;
                    }

                    if (isInLargeBrackets)
                    {
                        if (isInSmallBrackets)
	                    {
		                    result += inAnyBrackets(expression, i, counter) * 2;
	                    }
                        if (isInMiddleBrackets)
                        {
                            result += inAnyBrackets(expression, i, counter) * 2;
                        }
                        else
                        {
                            result += inAnyBrackets(expression, i, counter);      
                        }
                             
                        counter++;
                    }
                    else if (isInMiddleBrackets)
                    {
                        if (isInSmallBrackets)
                        {
                            result += inAnyBrackets(expression, i, counter) * 2;
                        }
                        else
                        {
                            result += inAnyBrackets(expression, i, counter);
                        }
                        counter++;
                    }
                    else if (isInSmallBrackets)
                    {
                        result += inAnyBrackets(expression, i, counter);
                        counter++;
                    }

                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("NO");
            }


        }
    }
}
