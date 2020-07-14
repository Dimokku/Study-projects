using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kraskal_Algorithm
{
    static class GraphGrid
    {
        public static DataGridView MatrixGraph { get; set; }
        public static DataGridView MatrixSkeleton { get; set; }

        public static Random rnd;

        //Write data into matrix from table
        public static void WriteMatrix(Graph graph, DataGridView grid)
        {
            graph.Update(grid);
        }

        //Write data into table from matrix
        public static void WriteTable(Graph graph, DataGridView grid)
        {
            for (int i = 0; i < Control.VertexCount; i++)
            {
                for (int j = 0; j < Control.VertexCount; j++)
                {
                    if (graph.Matrix[i, j] == 0)
                        grid.Rows[i].Cells[j].Value = '0';
                    if (i != j)
                    {
                        grid.Rows[i].Cells[j].Value = graph.Matrix[i, j];
                        if (graph.Matrix[i,j] == 0)
                            grid.Rows[i].Cells[j].Value = '0';
                    }
                }
            }
        }

        public static void CreateMatrix(DataGridView grid)
        {
            try
            {
                grid.Width = 360;
                grid.Height = 360;
                grid.ColumnCount = Control.VertexCount;
                grid.RowCount = Control.VertexCount;

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    grid.Columns[i].Width = 25;
                    grid.Rows[i].Height = 25;
                }

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    grid.Columns[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
            catch(Exception)
            {
                if (Control.VertexCount == 0)
                    MessageBox.Show("Размер матрицы не может быть меньше 1");
            }
        }

        public static void Generate()
        {
            rnd = new Random();
            for(int i = 0; i < Control.VertexCount; i++)
            {
                for (int j = 0; j < Control.VertexCount; j++)
                {
                    if (i == j)
                        MatrixGraph.Rows[i].Cells[j].Value = '0';
                    else
                    {
                        MatrixGraph.Rows[i].Cells[j].Value = rnd.Next(Control.MinLength, Control.MaxLength + 1);
                        MatrixGraph.Rows[j].Cells[i].Value = MatrixGraph.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        public static void FixGraph(DataGridView grid)
        {
            for (int i = 0; i < Control.VertexCount; i++)
            {
                for (int j = 0; j < Control.VertexCount; j++)
                {
                    if (i == j)
                        MatrixGraph.Rows[i].Cells[j].Value = '0';
                    else
                    {
                        MatrixGraph.Rows[i].Cells[j].Value = MatrixGraph.Rows[j].Cells[i].Value;
                    }
                }
            }
        }
    }
}
