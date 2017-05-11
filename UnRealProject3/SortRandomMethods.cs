using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnRealProject3
{
    class SortMethods
    {
        //Методы сортировки:
        //1. Пузырьком +
        //2. Шелла +
        //3. Подсчётом +
        //4. Блочная +
        //5. Пирамидальная +
        public double MethodOne(int[] array) //Пузырёк
        {
            DateTime time0 = DateTime.Now;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            TimeSpan time1 = DateTime.Now - time0;

            return time1.TotalSeconds;
        }

        public double MethodTwo(int[] array) //Подсчётом
        {
            DateTime time0 = DateTime.Now;
            int[] count = new int[array.Max() - array.Min() + 1];
            int z = 0;

            for (int i = 0; i < count.Length; i++) { count[i] = 0; }
            for (int i = 0; i < array.Length; i++) { count[array[i] - array.Min()]++; }

            for (int i = array.Min(); i <= array.Max(); i++)
            {
                while (count[i - array.Min()]-- > 0)
                {
                    array[z] = i;
                    z++;
                }
            }
            TimeSpan time1 = DateTime.Now - time0;

            return time1.TotalSeconds;
        }

        public double MethodThree(int[] array) //Шелла
        {
            DateTime time0 = DateTime.Now;
            int j;
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        int tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
            TimeSpan time1 = DateTime.Now - time0;

            return time1.TotalSeconds;
        }

        public double MethodFour(int[] array) //Блочная
        {
            DateTime time0 = DateTime.Now;
            int maxValue = array[0];
            int minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];

                if (array[i] < minValue)
                    minValue = array[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++) { bucket[i] = new List<int>(); }
            for (int i = 0; i < array.Length; i++)  { bucket[array[i] - minValue].Add(array[i]); }

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[position] = bucket[i][j];
                        position++;
                    }
                }
            }
            TimeSpan time1 = DateTime.Now - time0;

            return time1.TotalSeconds;
        }

        private static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        public double MethodFive(int[] array) //Пирамидальная
        {
            DateTime time0 = DateTime.Now;

            for (int i = array.Length / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(array, i, array.Length);
                if (prev_i != i) ++i;
            }
            
            int buf;
            for (int k = array.Length - 1; k > 0; --k)
            {
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(array, i, k);
                }
            }
            TimeSpan time1 = DateTime.Now - time0;

            return time1.TotalSeconds;
        }
    }

    class RandomMethods
    {
        Random randomforarray = new Random();

        public int[] MethodOne(int arraysize)
        {
            int[] array = new int[arraysize];
            for (int i = 0; i < arraysize; i++)
            {
                array[i] = randomforarray.Next(0, 100);
            }
            return array;
        }

        public int[] MethodTwo(int arraysize)
        {
            int[] array = new int[arraysize];
            int iarr = 0;
            foreach (var item in GetWithParameters(x => x >= 5 && x <= 6).Take(arraysize - 1))
            {
                iarr++;
                array[iarr] = item;
            }
            return array;
        }

        public int[] MethodThree(int arraysize)
        {
            int[] array = new int[arraysize];
            int iarr = 0;
            foreach (var item in GetUnique().Take(arraysize - 1))
            {
                iarr++;
                array[iarr] = item;
            }
            return array;
        }

        private IEnumerable<int> GetUnique()
        {
            var old = randomforarray.Next(0, 100);
            var current = randomforarray.Next(0, 100);

            while (true)
            {
                while (current == old) current = randomforarray.Next(0, 100);

                yield return current;
                old = current;
            }
        }

        private IEnumerable<int> GetWithParameters(Func<int, bool> expr)
        {
            foreach (var item in GetUnique().Where(expr))
            {
                yield return item;
            }
        }
    }
}
