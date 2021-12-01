using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyApp.Commands
{
    class Program
    {
        static void Main(string[] args)
        {


            var result = CheckClasswithSuffixUsingLambda();

            result = CheckClasswithSuffixUsingLambda();

            result = CheckClassWithSuffixUsingLinq();

            result = CheckClasswithSuffixWithCorrectNameSpaceUsingLambda();

            result = CheckClasswithSuffixWithCorrectNameSpaceUsingLinq();


        }

        private static List<string> CheckClasswithSuffixUsingLambda()
        {
            return (Assembly.GetExecutingAssembly().DefinedTypes.ToList().Where(x =>!x.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase)).ToList().Select(t => t.Name).ToList());

        }
        private static List<string> CheckClasswithSuffixWithCorrectNameSpaceUsingLambda()
        {
            return (Assembly.GetExecutingAssembly().DefinedTypes.ToList().Where(x => x.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase) && !x.FullName.StartsWith("MyApp.Commands", StringComparison.InvariantCultureIgnoreCase)).ToList().Select(t => t.FullName).ToList());
        }

        private static List<string> CheckClassWithSuffixUsingLinq()
        {
            var str = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
            var query = from element in str
                        where ! (element.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase))
                        select element;

             return query.ToList().Select(t=>t.Name).ToList();
        }

        private static List<string> CheckClasswithSuffixWithCorrectNameSpaceUsingLinq()
        {
            var str = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
            var query = from element in str
                        where (element.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase))
                        where !(element.FullName.StartsWith("MyApp.Commands", StringComparison.InvariantCultureIgnoreCase))
                        select element;
            return query.ToList().Select(t => t.FullName).ToList();
        }
    }
}
