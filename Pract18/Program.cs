using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pract16
{
    class Program
    {
        static bool IsBalanced(string str)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    // Если это открывающая скобка, добавляем её в стек
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Если это закрывающая скобка
                    if (stack.Count == 0)
                    {
                        // Если стек пуст, значит нет открывающей скобки для текущей закрывающей
                        return false;
                    }

                    char top = stack.Pop(); // Снимаем скобку с вершины стека
                    if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    {
                        // Если скобка с вершины стека не соответствует текущей закрывающей скобке
                        return false;
                    }
                }
            }

            // Если после прохода по всей строке стек пуст, значит скобки расставлены корректно
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            string str1 = "([]{})"; // Корректные скобки
            string str2 = "([]])";  // Некорректные скобки

            Console.WriteLine("Строка \"{0}\" имеет {1} скобок", str1, IsBalanced(str1) ? "корректные" : "некорректные");
            Console.WriteLine("Строка \"{0}\" имеет {1} скобок", str2, IsBalanced(str2) ? "корректные" : "некорректные");
        }
    }
}