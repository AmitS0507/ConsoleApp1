using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result = CheckClasswithSuffix();
            result = CheckClasswithSuffixWithCorrectNameSpace();
            
        }

        private static List<string> CheckClasswithSuffix()
        {
            var result = new List<string>();
            result.Add("MyApp.FirstCommand");
            result.Add("MyApp.Namespace.Commands.SecondCommand");
            result.Add("MyApp.Commands.ThirdCommand");
            result.Add("MyApp.Commands.SomeClass");
            result.Add("MyApp.Commands.Namespace.TestClass");

            if (result != null && result.Count > 1)
            {
                foreach (var itemWithCorrectSuffix in result.ToList())
                {

                    if (itemWithCorrectSuffix.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Remove(itemWithCorrectSuffix);


                    }
                }
            }

            return result;
        }
        private static List<string> CheckClasswithSuffixWithCorrectNameSpace()
        {
            var result = new List<string>();
            result.Add("MyApp.FirstCommand");
            result.Add("MyApp.Namespace.Commands.SecondCommand");
            result.Add("MyApp.Commands.ThirdCommand");
            result.Add("MyApp.Commands.SomeClass");
            result.Add("MyApp.Commands.Namespace.TestClass");

            if (result != null && result.Count >1)
            {
                foreach (var itemWithInCorrectSuffix in result.ToList())
                {
                    if (!itemWithInCorrectSuffix.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Remove(itemWithInCorrectSuffix);

                    }
                }

                foreach (var itemUnderIncorrectNameSpace in result.ToList())
                {
                    var str = itemUnderIncorrectNameSpace.Split('.');
                    if (str.Count() > 1)
                    {

                        if (str[0].ToLower() == "myapp" && str[1].ToLower() == "commands")
                        {
                            result.Remove(itemUnderIncorrectNameSpace);
                        }
                    }
                }
            }
            return result;

        }
    }
}
