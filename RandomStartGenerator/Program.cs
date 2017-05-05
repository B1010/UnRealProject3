using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStartGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ia = new int[501];
            int[] ja = new int[501];
            int iaa = 0;
            int jaa = 0;
            foreach (var item in Generator.GetUnique().Take(500))
            {
                iaa++;
                ia[iaa] = item;
            }

            for (int i = 1; i < 500; i++)
            {
                if (ia[i] == ia[i - 1] || ia[i] == ia[i + 1])
                {
                    Console.WriteLine("Попался! 0 {0}", i);
                }
            }

            foreach (var item in Generator.GetWithParameters(x => x >= 1 && x <= 6).Take(500))
            {
                jaa++;
                ja[jaa] = item;
                Console.Write(".{0}", item);
            }

            for (int i = 1; i < 500; i++)
            {
                if (ja[i] == ja[i - 1] || ja[i] == ja[i + 1])
                {
                    Console.WriteLine("Попался! 1 {0}", i);
                }
            }

            Console.ReadKey();
        }
    }
    public class Generator
    {
        static Random rnd = new Random();
        public static IEnumerable<int> GetUnique()
        {
            var old = rnd.Next(0, 100);
            var current = rnd.Next(0, 100);

            while (true)
            {
                while (current == old) current = rnd.Next(0, 100);

                yield return current;
                old = current;
            }
        }

        public static IEnumerable<int> GetWithParameters(Func<int, bool> expr)
        {
            foreach (var item in GetUnique().Where(expr))
            {
                yield return item;
            }
        }
    }
}
