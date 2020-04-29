namespace GASuccessCalculator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.nVariant = new System.Windows.Forms.NumericUpDown();
            this.tFormula = new System.Windows.Forms.TextBox();
            this.cPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.nVariant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // nVariant
            // 
            this.nVariant.Location = new System.Drawing.Point(12, 12);
            this.nVariant.Name = "nVariant";
            this.nVariant.Size = new System.Drawing.Size(120, 20);
            this.nVariant.TabIndex = 0;
            this.nVariant.ValueChanged += new System.EventHandler(this.RedrawPlot);
            // 
            // tFormula
            // 
            this.tFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tFormula.Location = new System.Drawing.Point(159, 12);
            this.tFormula.Name = "tFormula";
            this.tFormula.Size = new System.Drawing.Size(629, 20);
            this.tFormula.TabIndex = 1;
            this.tFormula.Text = "DAU / MAU";
            this.tFormula.TextChanged += new System.EventHandler(this.RedrawPlot);
            // 
            // cPlot
            // 
            this.cPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.cPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cPlot.Legends.Add(legend1);
            this.cPlot.Location = new System.Drawing.Point(12, 38);
            this.cPlot.Name = "cPlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Formula value";
            this.cPlot.Series.Add(series1);
            this.cPlot.Size = new System.Drawing.Size(776, 400);
            this.cPlot.TabIndex = 2;
            this.cPlot.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cPlot);
            this.Controls.Add(this.tFormula);
            this.Controls.Add(this.nVariant);
            this.Name = "MainForm";
            this.Text = "GASuccessCalculator";
            ((System.ComponentModel.ISupportInitialize)(this.nVariant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nVariant;
        private System.Windows.Forms.TextBox tFormula;
        private System.Windows.Forms.DataVisualization.Charting.Chart cPlot;
    }
}

