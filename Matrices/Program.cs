using System;

namespace Matrices {
    class Program {
        static void Main(string[] args) {

            Tuple<int, int> d = dimensions();
            int[,] m1 = CreateMatrix(d.Item1, d.Item2);

            Tuple<int, int> d2 = dimensions();
            int[,] m2 = CreateMatrix(d2.Item1, d2.Item2);

            WriteMatrix(Sum(m1, m2));

        }

        static Tuple<int, int> dimensions() {

            Console.Write("Rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Columns: ");
            int cols = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            return Tuple.Create(rows, cols);
        }

        static int[,] CreateMatrix(int rows, int cols) {

            int[,] m = new int[rows, cols];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write("Row {0} and Column {1}: ", (i + 1), (j + 1));
                    m[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }

            return m;
        }

        static void WriteMatrix(int[,] m) {
            for (int i = 0; i < m.GetLength(0); i++) {
                for (int j = 0; j < m.GetLength(1); j++) {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] Sum(int[,] m1, int[,] m2) {

            Console.WriteLine("Sum:");

            int[,] sum = new int[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++) {
                for (int j = 0; j < m1.GetLength(1); j++) {
                    sum[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return sum;
        }

        static int[,] Diff(int[,] m1, int[,] m2) {

            Console.WriteLine("Difference:");

            int[,] difference = new int[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++) {
                for (int j = 0; j < m1.GetLength(1); j++) {
                    difference[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return difference;
        }

        static int[,] Multiply(int[,] m1, int[,] m2) {

            Console.WriteLine("Multiplay:");

            int[,] e = new int[m1.GetLength(0), m2.GetLength(1)];

            if (m1.GetLength(1) == m2.GetLength(0)) {
                for (int c = 0; c < m2.GetLength(1); c++) {
                    for (int i = 0; i < m1.GetLength(0); i++) {
                        for (int j = 0; j < m1.GetLength(1); j++) {
                            e[i, c] += m1[i, j] * m2[j, c];
                        }
                    }
                }
            } else {
                Console.WriteLine("Cannot multiply");
            }

            return e;
        }
    }
}
