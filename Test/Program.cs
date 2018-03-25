using System;
using System.Linq;
using System.Reflection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            StartTest();
            Console.ReadKey();
        }

        public static void StartTest()
        {
            TestInteface test = new TestInteface();
            MethodInfo[] allMethod = typeof(TestInteface).GetMethods();
            foreach (MethodInfo method in allMethod)
            {
                if (method.GetParameters().Count() == 0)
                {
                    object[] par = new object[0];
                    try
                    {
                        method.Invoke(test, par);
                        Console.WriteLine($"Tэст {method.Name} Успешно пройден");
                    }
                    catch
                    {
                        Console.WriteLine($"Tэст {method.Name} Провален");
                    }
                }
            }

        }
    }
}
