using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kraskal_Algorithm
{
    class KruskalAlgorithm
    {
        class Edge
        {
            public int i = 0;
            public int j = 0;
        }

        static List<Edge> edges = new List<Edge>();
        static int amount; //loops amount
        static Graph ostov;
        static int start;
        static bool[] visited;

        public static Graph Go(Graph graph, DataGridView grid)
        {
            visited = new bool[Control.VertexCount];
            ostov = new Graph();
            GraphGrid.WriteMatrix(ostov, grid);

            int edgeCount = 0;

            for (int i = 0; i < Control.VertexCount; i++)
                for (int j = 0; j < Control.VertexCount; j++)
                {
                    ostov.Matrix[i, j] = 0;
                    if (graph.Matrix[i, j] > 0)
                        edgeCount++;
                }

            edgeCount /= 2;
            int row = 0;
            int column = 0;

            //Algorithm
            while (edges.Count / 2 < edgeCount)
            {
                Edge edge1 = new Edge();
                Edge edge2 = new Edge();
                int min = Int32.MaxValue;

                for (int i = 0; i < Control.VertexCount; i++)
                {
                    for (int j = 0; j < Control.VertexCount; j++)
                    {
                        if (graph.Matrix[i, j] > 0)
                        {
                            if (graph.Matrix[i, j] <= min && !CheckEdge(edges, i, j))
                            {
                                min = Convert.ToInt32(graph.Matrix[i, j]);
                                row = i; column = j;
                            }
                        }

                    }
                }
                edge1.i = row;
                edge1.j = column;
                edge2.j = row;
                edge2.i = column;
                edges.Add(edge1);
                edges.Add(edge2);

                ostov.Matrix[row, column] = graph.Matrix[row, column];
                ostov.Matrix[column, row] = graph.Matrix[column, row];

                if (CheckLoop())
                {
                    ostov.Matrix[row, column] = 0;
                    ostov.Matrix[column, row] = 0;
                }
            }

            edges.Clear();
            return ostov;
        }

        private static bool CheckLoop()
        {
            amount = 0;          
            for (int i = 0; i < Control.VertexCount; i++)
            {
                for (int j = 0; j < visited.Length; j++)
                    visited[j] = false;
                start = i;
                if (visited[i] == false)
                    DFS(i, i);
            }
            return amount > 0;
        }

        private static void DFS(int i, int prev)
        {          
            visited[i] = true;
            for (int r = 0; r < Control.VertexCount; r++)
            {
                if (r != i && ostov.Matrix[i, r] != 0)
                {
                    if (visited[r] == false) 
                        DFS(r, i);
                    else if (visited[r] == true && r == start && r != prev)
                        amount++;
                }
            }
        }

        private static bool CheckEdge(List<Edge> edges, int i, int j)
        {
            if (edges.Count > 0)
            {
                Edge edge;
                for (int r = 0; r < edges.Count; r++)
                {
                    edge = edges.ElementAt(r);
                    if (edge.i == i && edge.j == j)
                        return true;
                }               
            }

            return false;
        }
    }
}
