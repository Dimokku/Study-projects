using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kraskal_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GraphGrid.MatrixGraph = dataGridGraph;
            GraphGrid.MatrixSkeleton = dataGridSkeleton;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {       
            Control.VertexCount = Convert.ToInt32(numericVertices.Value);
            GraphGrid.CreateMatrix(dataGridGraph);
        }

        private void buttonGraphGeneration_Click(object sender, EventArgs e)
        {
            Control.MinLength = Convert.ToInt32(numericFrom.Value);
            Control.MaxLength = Convert.ToInt32(numericTo.Value);
            Control.VertexCount = Convert.ToInt32(numericVertices.Value);
            GraphGrid.Generate();
        }

        private void buttonCreateSkeleton_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            GraphGrid.CreateMatrix(dataGridSkeleton);
            GraphGrid.FixGraph(dataGridGraph);
            GraphGrid.WriteMatrix(graph, dataGridGraph);
            Graph ostov = KruskalAlgorithm.Go(graph, dataGridSkeleton);
            GraphGrid.WriteTable(ostov, dataGridSkeleton);

        }

        private void buttonToCount_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            GraphGrid.FixGraph(dataGridGraph);
            GraphGrid.WriteMatrix(graph, dataGridGraph);
            Control.Progress = progressBar1;
            textBox1.Text = Convert.ToString(Control.GetOstovCount(graph));
            progressBar1.Value = 0;
        }
    }
}
