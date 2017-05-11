using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UnRealProject3
{
    public partial class Form1 : Form
    {
        double[] massX = { 1, 2, 3, 4, 5 };
        double[] massY_result = new double[5];

        SortMethods methods = new SortMethods();
        RandomMethods random = new RandomMethods();
        Thread[] thread = new Thread[5];

        static int arraysize = 10000; //Размер массива
        static int repeat = 20; //Количество повторов для усреднения результата
        int[] iarray = new int[arraysize];
        int[] array1 = new int[arraysize], array2 = new int[arraysize], array3 = new int[arraysize], array4 = new int[arraysize], array5 = new int[arraysize];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] massY = { 0, 0, 0, 0, 0 };
            double srednee_max = 0, srednee_min = 0;

            for (int i = 1; i < repeat; i++)
            {
                onerandomresult();
                srednee_max += massY_result.Max();
                srednee_min += massY_result.Min();

                for (int j = 0; j < 5; j++)
                {
                    massY[j] += massY_result[j];
                }
            }

            srednee_max /= repeat;
            srednee_min /= repeat;

            for(int i = 0; i < 5; i++)
            {
                massY[i] /= repeat;
            }

            textBox1.Text = Convert.ToString(srednee_max);
            textBox2.Text = Convert.ToString(srednee_min);

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.DataBindXY(massX, massY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] massY = { 0, 0, 0, 0, 0 };
            double srednee_max = 0, srednee_min = 0;

            for (int i = 1; i < repeat; i++)
            {
                tworandomresult();
                srednee_max += massY_result.Max();
                srednee_min += massY_result.Min();

                for (int j = 0; j < 5; j++)
                {
                    massY[j] += massY_result[j];
                }
            }

            srednee_max /= repeat;
            srednee_min /= repeat;

            for (int i = 0; i < 5; i++)
            {
                massY[i] /= repeat;
            }

            textBox4.Text = Convert.ToString(srednee_max);
            textBox3.Text = Convert.ToString(srednee_min);

            chart1.Series[1].Points.Clear();
            chart1.Series[1].Points.DataBindXY(massX, massY);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] massY = { 0, 0, 0, 0, 0 };
            double srednee_max = 0, srednee_min = 0;

            for (int i = 1; i < repeat; i++)
            {
                threerandomresult();
                srednee_max += massY_result.Max();
                srednee_min += massY_result.Min();

                for (int j = 0; j < 5; j++)
                {
                    massY[j] += massY_result[j];
                }
            }

            srednee_max /= repeat;
            srednee_min /= repeat;

            for (int i = 0; i < 5; i++)
            {
                massY[i] /= repeat;
            }

            textBox6.Text = Convert.ToString(srednee_max);
            textBox5.Text = Convert.ToString(srednee_min);

            chart1.Series[2].Points.Clear();
            chart1.Series[2].Points.DataBindXY(massX, massY);
        }

        public void onerandomresult()
        {
            iarray = random.MethodOne(arraysize);

            Array.Copy(iarray, array1, arraysize);
            Array.Copy(iarray, array2, arraysize);
            Array.Copy(iarray, array3, arraysize);
            Array.Copy(iarray, array4, arraysize);
            Array.Copy(iarray, array5, arraysize);
            
            thread[0] = new Thread(ThreadFunction1);
            thread[1] = new Thread(ThreadFunction2);
            thread[2] = new Thread(ThreadFunction3);
            thread[3] = new Thread(ThreadFunction4);
            thread[4] = new Thread(ThreadFunction5);

            for(int i = 0; i < 5; i++)
            {
                thread[i].Start();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Join();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Abort();
            }
        }

        private void tworandomresult()
        {
            iarray = random.MethodTwo(arraysize);

            Array.Copy(iarray, array1, arraysize);
            Array.Copy(iarray, array2, arraysize);
            Array.Copy(iarray, array3, arraysize);
            Array.Copy(iarray, array4, arraysize);
            Array.Copy(iarray, array5, arraysize);

            thread[0] = new Thread(ThreadFunction1);
            thread[1] = new Thread(ThreadFunction2);
            thread[2] = new Thread(ThreadFunction3);
            thread[3] = new Thread(ThreadFunction4);
            thread[4] = new Thread(ThreadFunction5);

            for (int i = 0; i < 5; i++)
            {
                thread[i].Start();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Join();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Abort();
            }
        }

        private void threerandomresult()
        {
            iarray = random.MethodThree(arraysize);

            Array.Copy(iarray, array1, arraysize);
            Array.Copy(iarray, array2, arraysize);
            Array.Copy(iarray, array3, arraysize);
            Array.Copy(iarray, array4, arraysize);
            Array.Copy(iarray, array5, arraysize);

            thread[0] = new Thread(ThreadFunction1);
            thread[1] = new Thread(ThreadFunction2);
            thread[2] = new Thread(ThreadFunction3);
            thread[3] = new Thread(ThreadFunction4);
            thread[4] = new Thread(ThreadFunction5);

            for (int i = 0; i < 5; i++)
            {
                thread[i].Start();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Join();
            }
            for (int i = 0; i < 5; i++)
            {
                thread[i].Abort();
            }
        }

        private void ThreadFunction5()
        {
            massY_result[4] = methods.MethodFive(array5);
        }

        private void ThreadFunction4()
        {
            massY_result[3] = methods.MethodFour(array4);
        }

        private void ThreadFunction3()
        {
            massY_result[2] = methods.MethodThree(array3);
        }

        private void ThreadFunction2()
        {
            massY_result[1] = methods.MethodTwo(array2);
        }

        private void ThreadFunction1()
        {
            massY_result[0] = methods.MethodOne(array1);
        }
    }
}
