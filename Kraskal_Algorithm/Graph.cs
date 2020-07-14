using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kraskal_Algorithm
{
    class Graph
    {
        public int?[,] Matrix { get; set; }
        public void Update(DataGridView table)
        {
                Matrix = new int?[Control.VertexCount, Control.VertexCount];
                for (int i = 0; i < Control.VertexCount; i++)
                {
                    for (int j = 0; j < Control.VertexCount; j++)
                    {
                        if (Convert.ToString(table.Rows[i].Cells[j].Value) == "0" ||
                            table.Rows[i].Cells[j].Value == null)
                            Matrix[i, j] = 0;
                        else if (Convert.ToString(table.Rows[i].Cells[j].Value) != "0" &&
                            table.Rows[i].Cells[j].Value != null)
                            Matrix[i, j] = Convert.ToInt32(table.Rows[i].Cells[j].Value);
                    }
                }                    
        }
    }
}
