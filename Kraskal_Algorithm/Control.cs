using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kraskal_Algorithm
{
    class Control
    {
        public static int VertexCount { get; set; }
        public static int MinLength { get; set; }
        public static int MaxLength { get; set; }
        public static ProgressBar Progress { get; set; }

        public static int GetOstovCount(Graph graph)
        {
            if (VertexCount == 1 || VertexCount == 0)
                return 0;

            int[,] KirchhoffMatrix = new int[VertexCount, VertexCount];
            for (int i = 0; i < VertexCount; i++)
                for (int j = 0; j < VertexCount; j++)
                    KirchhoffMatrix[i, j] = 0;


            int row = 0;
            int column = 0;
            int neighbors = 0;

            for (int i = 0; i < VertexCount; i++)
            {                
                for (int j = 0; j < VertexCount; j++)
                {
                    if (graph.Matrix[i, j] != 0 && graph.Matrix != null)
                    {
                        KirchhoffMatrix[i, j] = -1;
                        neighbors++;
                    }
                }
                row = i;
                column = row;
                KirchhoffMatrix[row, column] = neighbors;
                neighbors = 0;                           
            }

            int[,] B = new int[VertexCount, VertexCount];

            int determinant = FindDeterminant(KirchhoffMatrix, VertexCount);
            FindAlgAddition(KirchhoffMatrix, VertexCount, B);

            return B[0, 0] < 0 ? B[0, 0] * (-1) : B[0, 0];
        }

        static void FindAlgAddition(int[,] A, int size, int[,] B)
        {
            int i, j;

            // находим определитель матрицы A
            int det = FindDeterminant(A, size);

            if (det > 0) // это для знака алгебраического дополнения
                det = -1;
            else
                det = 1;
            int[,] minor = new int[size - 1, size - 1];

            for (j = 0; j < size; j++)
            {
                int progress = Progress.Maximum / size;
                Progress.Value = Progress.Value + progress;
                for (i = 0; i < size; i++)
                {
                    // получаем алгебраическое дополнение
                    GetMinor(A, minor, j, i, size);
                    if ((i + j) % 2 == 0)
                        B[j, i] = -det * FindDeterminant(minor, size - 1);
                    else
                        B[j, i] = det * FindDeterminant(minor, size - 1);
                }
            }
        }

        static int GetMinor(int[,] A, int[,] B, int x, int y, int size)
        {
            int xCount = 0, yCount = 0;
            int i, j;
            for (i = 0; i < size; i++)
            {
                if (i != x)
                {
                    yCount = 0;
                    for (j = 0; j < size; j++)
                    {
                        if (j != y)
                        {
                            B[xCount, yCount] = A[i, j];
                            yCount++;
                        }
                    }
                    xCount++;
                }
            }
            return 0;
        }

        static int FindDeterminant(int[,] A, int size)
        {
            // останавливаем рекурсию, если матрица
            // состоит из одного элемента
            if (size == 1)
            {
                return A[0, 0];
            }
            else
            {
                int det = 0;
                int i;
                int[,] Minor = new int[size - 1, size - 1];
                for (i = 0; i < size; i++)
                {
                    GetMinor(A, Minor, 0, i, size);
                    // Рекурсия
                    det += (int)Math.Pow(-1, i) * A[0, i] * FindDeterminant(Minor, size - 1);
                }
                return det;
            }
        }
    }
}
