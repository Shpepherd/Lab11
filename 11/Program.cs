using System;
namespace Lab_11
{
    public class Program
    {
        public abstract class Array
        {
            internal int N;
            internal int[] Arr;
            public void Init()
            {

                this.Arr = new int[this.N];
                Random r = new Random();
                for (int i = 0; i < N; i++)
                    this.Arr[i] = r.Next(0, 100);
            }
            public abstract int Calc();
            public abstract void Processing();
        }

        public class Vector : Array
        {
            public Vector(int n)
            {
                this.Arr = new int[n];
                this.N = n;
                for (int i = 0; i < n; i++)
                {
                    this.Arr[i] = i + 1;
                }
            }
            public Vector()
            {
                this.N = 0;
            }
            new public void Init()
            {
                Random r = new Random();
                this.Arr = new int[this.N];
                for (int j = 0; j < this.N; j++)
                    this.Arr[j] = r.Next(0, 100);
            }
            public override int Calc()
            {
                int[] max = new int[3];
                int j = 0;
                foreach (int i in this.Arr)
                {
                    j = 0;
                    while (j < max.Length)
                    {
                        if (i > max[j])
                        {
                            if (j + 1 < max.Length)
                            {
                                if (j + 2 < max.Length)
                                    max[j + 2] = max[j + 1];
                                max[j + 1] = max[j];
                            }
                            max[j] = i;
                            j = max.Length;

                        }
                        else if (i == max[j])
                            j = max.Length;
                        j++;
                    }
                }
                return max[2];
            }
            public override void Processing()
            {
                int max2 = this.Calc();
                int[] Modified = new int[this.N];
                for (int i = 0; i < this.N; i++)
                {
                    if (this.Arr[i] > max2)
                    {
                        Modified[i] = max2;
                    }
                    else Modified[i] = this.Arr[i];
                }
            }
        }
        public class Matrix : Array
        {
            public int M;
            new public int[,] Arr;
            public Matrix(int height, int length)
            {
                this.M = height;
                this.N = length;
                this.Arr = new int[this.M, this.N];
                for (int i = 0; i < this.M; i++)
                {
                    for (int j = 0; j < this.N; j++)
                    {
                        this.Arr[i, j] = 2;
                    }
                }
            }
            public Matrix()
            {
                this.M = 0;
                this.N = 0;
            }
            new public void Init()
            {
                Random r = new Random();
                this.Arr = new int[M, N];
                for (int i = 0; i < this.M; i++)
                {
                    for (int j = 0; j < this.N; j++)
                        this.Arr[i, j] = r.Next(-20, 10);
                }
            }
            public override int Calc()
            {
                int product = 1;
                for (int i = 0; i < this.M; i++)
                    for (int j = 0; j < this.N; j++)
                        if (this.Arr[i, j] != 0 && this.Arr[i, j] >= -2 && this.Arr[i, j] <= 2)
                            product *= this.Arr[i, j];
                if (product < 0)
                    return -product;
                else return product;
            }
            public override void Processing()
            {
                double P = this.Calc();
                double sum = 0;
                for (int i = 0; i < this.M; i++)
                {
                    for (int j = 0; j < this.N; j++)
                    {
                        sum += this.Arr[i, j];
                    }
                }
                sum /= this.N * this.M;
                for (int i = 0; i < this.M; i++)
                {
                    for (int j = 0; j < this.N; j++)
                    {
                        if (this.Arr[i, j] > sum)
                            this.Arr[i, j] = (int)Math.Pow(this.Arr[i, j], P);
                    }
                }
            }

        }
        public static void Main()
        {
            Matrix M = new Matrix();
            Vector V = new Vector();
            bool MExists = false, VExists = false;
            short item;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите одно из действий: ");
                short k0 = 0;
                short k1 = 2;
                do
                {
                    Console.WriteLine("0. Выход из программы;");
                    Console.WriteLine("1. Создание новой матрицы;");
                    Console.WriteLine("2. Создание нового вектора;");
                    if (MExists)
                    {

                        Console.WriteLine("3. Вычислить показатель матрицы;");
                        Console.WriteLine("4. Обработать матрицу;");
                        Console.WriteLine("5. Вывести матрицу;");
                        k0 = 3;
                        k1 = 5;
                    }
                    if (VExists)
                    {
                        Console.WriteLine("6. Вычислить показатель вектора;");
                        Console.WriteLine("7. Обработать вектор;");
                        Console.WriteLine("8. Вывести вектор;");
                        if (MExists)
                        {
                            k0 = 3;
                            k1 = 8;
                        }
                        else
                        {
                            k0 = 6;
                            k1 = 8;
                        }
                    }

                    item = 0;
                    try
                    {
                        item = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Необходимо вводить целые числа от 0 до {0}.", k0);
                        Console.WriteLine("Нажмите любую клавишу:");
                        Console.ReadKey();
                    }
                }
                while (!(item >= k0 && item <= k1) && !(item >= 0 && item <= 2));
                switch (item)
                {
                    case 1:
                        {
                            try
                            {
                                Console.WriteLine("Введите ширину матрицы: ");
                                M.N = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите высоту матрицы: ");
                                M.M = Convert.ToInt32(Console.ReadLine());
                                M.Arr = new int[M.N, M.M];
                                M.Init();
                                MExists = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Необходимо вводить целые числа.");
                                Console.WriteLine("Нажмите любую клавишу:");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Введите ширину вектора: ");
                                V.N = Convert.ToInt32(Console.ReadLine());
                                V.Arr = new int[V.N];
                                V.Init();
                                VExists = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Необходимо вводить целые числа.");
                                Console.WriteLine("Нажмите любую клавишу:");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Показатель матрицы: {0}", M.Calc());
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            M.Processing();
                            Console.WriteLine("Матрица обработана.");
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Матрица: ");
                            for (int i = 0; i < M.M; i++)
                            {
                                for (int j = 0; j < M.N; j++)
                                {
                                    Console.Write("{0} ", M.Arr[i, j]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Показатель вектора: {0}", V.Calc());
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            V.Processing();
                            Console.WriteLine("Вектор обработан.");
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Вектор: ");
                            for (int i = 0; i < V.N; i++)
                            {
                                Console.Write("{0} ", V.Arr[i]);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую клавишу:");
                            Console.ReadKey();
                            break;
                        }
                }
                if (item == 0)
                    break;
            }
            while (true);
        }
    }
}
