namespace Kraskal_Algorithm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridGraph = new System.Windows.Forms.DataGridView();
            this.dataGridSkeleton = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.numericVertices = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGraphGeneration = new System.Windows.Forms.Button();
            this.buttonCreateSkeleton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericFrom = new System.Windows.Forms.NumericUpDown();
            this.numericTo = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonToCount = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSkeleton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVertices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridGraph
            // 
            this.dataGridGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridGraph.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridGraph.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGraph.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridGraph.Location = new System.Drawing.Point(153, 24);
            this.dataGridGraph.Name = "dataGridGraph";
            this.dataGridGraph.Size = new System.Drawing.Size(360, 360);
            this.dataGridGraph.TabIndex = 0;
            // 
            // dataGridSkeleton
            // 
            this.dataGridSkeleton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridSkeleton.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridSkeleton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridSkeleton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSkeleton.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridSkeleton.Location = new System.Drawing.Point(531, 24);
            this.dataGridSkeleton.Name = "dataGridSkeleton";
            this.dataGridSkeleton.Size = new System.Drawing.Size(360, 360);
            this.dataGridSkeleton.TabIndex = 1;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(25, 74);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // numericVertices
            // 
            this.numericVertices.Location = new System.Drawing.Point(67, 48);
            this.numericVertices.Name = "numericVertices";
            this.numericVertices.Size = new System.Drawing.Size(55, 20);
            this.numericVertices.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New graph creation";
            // 
            // buttonGraphGeneration
            // 
            this.buttonGraphGeneration.Location = new System.Drawing.Point(7, 269);
            this.buttonGraphGeneration.Name = "buttonGraphGeneration";
            this.buttonGraphGeneration.Size = new System.Drawing.Size(105, 23);
            this.buttonGraphGeneration.TabIndex = 5;
            this.buttonGraphGeneration.Text = "Graph generation";
            this.buttonGraphGeneration.UseVisualStyleBackColor = true;
            this.buttonGraphGeneration.Click += new System.EventHandler(this.buttonGraphGeneration_Click);
            // 
            // buttonCreateSkeleton
            // 
            this.buttonCreateSkeleton.Location = new System.Drawing.Point(8, 298);
            this.buttonCreateSkeleton.Name = "buttonCreateSkeleton";
            this.buttonCreateSkeleton.Size = new System.Drawing.Size(101, 23);
            this.buttonCreateSkeleton.TabIndex = 6;
            this.buttonCreateSkeleton.Text = "Create skeleton";
            this.buttonCreateSkeleton.UseVisualStyleBackColor = true;
            this.buttonCreateSkeleton.Click += new System.EventHandler(this.buttonCreateSkeleton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Random generation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "to";
            // 
            // numericFrom
            // 
            this.numericFrom.Location = new System.Drawing.Point(45, 206);
            this.numericFrom.Name = "numericFrom";
            this.numericFrom.Size = new System.Drawing.Size(55, 20);
            this.numericFrom.TabIndex = 10;
            // 
            // numericTo
            // 
            this.numericTo.Location = new System.Drawing.Point(45, 233);
            this.numericTo.Name = "numericTo";
            this.numericTo.Size = new System.Drawing.Size(55, 20);
            this.numericTo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vertices";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Vertex value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Skeletons:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Graph";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(542, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Smallest skeleton";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 359);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 20);
            this.textBox1.TabIndex = 18;
            // 
            // buttonToCount
            // 
            this.buttonToCount.Location = new System.Drawing.Point(7, 330);
            this.buttonToCount.Name = "buttonToCount";
            this.buttonToCount.Size = new System.Drawing.Size(75, 23);
            this.buttonToCount.TabIndex = 19;
            this.buttonToCount.Text = "To count";
            this.buttonToCount.UseVisualStyleBackColor = true;
            this.buttonToCount.Click += new System.EventHandler(this.buttonToCount_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(163, 356);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 403);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonToCount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericTo);
            this.Controls.Add(this.numericFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCreateSkeleton);
            this.Controls.Add(this.buttonGraphGeneration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericVertices);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridSkeleton);
            this.Controls.Add(this.dataGridGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSkeleton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVertices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridGraph;
        private System.Windows.Forms.DataGridView dataGridSkeleton;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.NumericUpDown numericVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGraphGeneration;
        private System.Windows.Forms.Button buttonCreateSkeleton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericFrom;
        private System.Windows.Forms.NumericUpDown numericTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonToCount;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

