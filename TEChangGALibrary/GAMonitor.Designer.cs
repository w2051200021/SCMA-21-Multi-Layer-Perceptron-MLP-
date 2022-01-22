
namespace TEChangGALibrary
{
    partial class GAMonitor<S>
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gb_buttons = new System.Windows.Forms.GroupBox();
            this.btn_runToEnd = new System.Windows.Forms.Button();
            this.btn_runOneIter = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.pg_GA = new System.Windows.Forms.PropertyGrid();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gb_BGA_result = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_best_obj = new System.Windows.Forms.TextBox();
            this.tb_shortestTime = new System.Windows.Forms.TextBox();
            this.lsb_violation = new System.Windows.Forms.ListBox();
            this.lsb_soFarTheBest = new System.Windows.Forms.ListBox();
            this.lsb_AGeneration = new System.Windows.Forms.ListBox();
            this.cht_GA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gb_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gb_BGA_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_GA)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1202, 907);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gb_buttons);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pg_GA);
            this.splitContainer2.Size = new System.Drawing.Size(221, 907);
            this.splitContainer2.SplitterDistance = 339;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // gb_buttons
            // 
            this.gb_buttons.Controls.Add(this.btn_runToEnd);
            this.gb_buttons.Controls.Add(this.btn_runOneIter);
            this.gb_buttons.Controls.Add(this.btn_reset);
            this.gb_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_buttons.Location = new System.Drawing.Point(0, 0);
            this.gb_buttons.Name = "gb_buttons";
            this.gb_buttons.Size = new System.Drawing.Size(221, 339);
            this.gb_buttons.TabIndex = 3;
            this.gb_buttons.TabStop = false;
            this.gb_buttons.Text = "Operations";
            // 
            // btn_runToEnd
            // 
            this.btn_runToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runToEnd.Location = new System.Drawing.Point(6, 196);
            this.btn_runToEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_runToEnd.Name = "btn_runToEnd";
            this.btn_runToEnd.Size = new System.Drawing.Size(201, 75);
            this.btn_runToEnd.TabIndex = 2;
            this.btn_runToEnd.Text = "Run To End";
            this.btn_runToEnd.UseVisualStyleBackColor = true;
            this.btn_runToEnd.Click += new System.EventHandler(this.btn_runToEnd_Click);
            // 
            // btn_runOneIter
            // 
            this.btn_runOneIter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runOneIter.Location = new System.Drawing.Point(6, 113);
            this.btn_runOneIter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_runOneIter.Name = "btn_runOneIter";
            this.btn_runOneIter.Size = new System.Drawing.Size(201, 75);
            this.btn_runOneIter.TabIndex = 1;
            this.btn_runOneIter.Text = "Run One Iteration";
            this.btn_runOneIter.UseVisualStyleBackColor = true;
            this.btn_runOneIter.Click += new System.EventHandler(this.btn_runOneIter_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reset.Location = new System.Drawing.Point(6, 30);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(201, 75);
            this.btn_reset.TabIndex = 0;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // pg_GA
            // 
            this.pg_GA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_GA.Location = new System.Drawing.Point(0, 0);
            this.pg_GA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_GA.Name = "pg_GA";
            this.pg_GA.Size = new System.Drawing.Size(221, 563);
            this.pg_GA.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gb_BGA_result);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cht_GA);
            this.splitContainer3.Size = new System.Drawing.Size(977, 907);
            this.splitContainer3.SplitterDistance = 494;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 1;
            // 
            // gb_BGA_result
            // 
            this.gb_BGA_result.Controls.Add(this.label4);
            this.gb_BGA_result.Controls.Add(this.label3);
            this.gb_BGA_result.Controls.Add(this.label2);
            this.gb_BGA_result.Controls.Add(this.label1);
            this.gb_BGA_result.Controls.Add(this.tb_best_obj);
            this.gb_BGA_result.Controls.Add(this.tb_shortestTime);
            this.gb_BGA_result.Controls.Add(this.lsb_violation);
            this.gb_BGA_result.Controls.Add(this.lsb_soFarTheBest);
            this.gb_BGA_result.Controls.Add(this.lsb_AGeneration);
            this.gb_BGA_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_BGA_result.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_BGA_result.Location = new System.Drawing.Point(0, 0);
            this.gb_BGA_result.Name = "gb_BGA_result";
            this.gb_BGA_result.Size = new System.Drawing.Size(977, 494);
            this.gb_BGA_result.TabIndex = 5;
            this.gb_BGA_result.TabStop = false;
            this.gb_BGA_result.Text = "Genetic Algorithm Solver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Shortest Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Constriant Violations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Generation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Best Objective Value";
            // 
            // tb_best_obj
            // 
            this.tb_best_obj.Location = new System.Drawing.Point(17, 54);
            this.tb_best_obj.Name = "tb_best_obj";
            this.tb_best_obj.ReadOnly = true;
            this.tb_best_obj.Size = new System.Drawing.Size(146, 27);
            this.tb_best_obj.TabIndex = 6;
            // 
            // tb_shortestTime
            // 
            this.tb_shortestTime.Location = new System.Drawing.Point(17, 250);
            this.tb_shortestTime.Name = "tb_shortestTime";
            this.tb_shortestTime.ReadOnly = true;
            this.tb_shortestTime.Size = new System.Drawing.Size(146, 27);
            this.tb_shortestTime.TabIndex = 5;
            // 
            // lsb_violation
            // 
            this.lsb_violation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsb_violation.FormattingEnabled = true;
            this.lsb_violation.HorizontalScrollbar = true;
            this.lsb_violation.ItemHeight = 19;
            this.lsb_violation.Location = new System.Drawing.Point(17, 301);
            this.lsb_violation.Name = "lsb_violation";
            this.lsb_violation.Size = new System.Drawing.Size(146, 175);
            this.lsb_violation.TabIndex = 4;
            // 
            // lsb_soFarTheBest
            // 
            this.lsb_soFarTheBest.FormattingEnabled = true;
            this.lsb_soFarTheBest.HorizontalScrollbar = true;
            this.lsb_soFarTheBest.ItemHeight = 19;
            this.lsb_soFarTheBest.Location = new System.Drawing.Point(17, 85);
            this.lsb_soFarTheBest.Name = "lsb_soFarTheBest";
            this.lsb_soFarTheBest.Size = new System.Drawing.Size(146, 137);
            this.lsb_soFarTheBest.TabIndex = 3;
            // 
            // lsb_AGeneration
            // 
            this.lsb_AGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsb_AGeneration.FormattingEnabled = true;
            this.lsb_AGeneration.HorizontalScrollbar = true;
            this.lsb_AGeneration.ItemHeight = 19;
            this.lsb_AGeneration.Location = new System.Drawing.Point(173, 54);
            this.lsb_AGeneration.Name = "lsb_AGeneration";
            this.lsb_AGeneration.ScrollAlwaysVisible = true;
            this.lsb_AGeneration.Size = new System.Drawing.Size(787, 422);
            this.lsb_AGeneration.TabIndex = 2;
            // 
            // cht_GA
            // 
            chartArea1.AxisX.Title = "Iteration";
            chartArea1.AxisY.Title = "Objective Value";
            chartArea1.Name = "ChartArea1";
            this.cht_GA.ChartAreas.Add(chartArea1);
            this.cht_GA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.cht_GA.Legends.Add(legend1);
            this.cht_GA.Location = new System.Drawing.Point(0, 0);
            this.cht_GA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cht_GA.Name = "cht_GA";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.LimeGreen;
            series1.Legend = "Legend1";
            series1.LegendText = "Iteration Average";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Orange;
            series2.Legend = "Legend1";
            series2.LegendText = "Iteration Best";
            series2.Name = "Series2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.LegendText = "So Far The Best";
            series3.Name = "Series3";
            this.cht_GA.Series.Add(series1);
            this.cht_GA.Series.Add(series2);
            this.cht_GA.Series.Add(series3);
            this.cht_GA.Size = new System.Drawing.Size(977, 408);
            this.cht_GA.TabIndex = 0;
            this.cht_GA.Text = "chart1";
            // 
            // GAMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GAMonitor";
            this.Size = new System.Drawing.Size(1202, 907);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gb_buttons.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.gb_BGA_result.ResumeLayout(false);
            this.gb_BGA_result.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_GA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.Button btn_runToEnd;
        public System.Windows.Forms.Button btn_runOneIter;
        public System.Windows.Forms.Button btn_reset;
        public System.Windows.Forms.PropertyGrid pg_GA;
        public System.Windows.Forms.DataVisualization.Charting.Chart cht_GA;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.ListBox lsb_AGeneration;
        private System.Windows.Forms.GroupBox gb_BGA_result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox lsb_violation;
        public System.Windows.Forms.ListBox lsb_soFarTheBest;
        public System.Windows.Forms.TextBox tb_best_obj;
        public System.Windows.Forms.TextBox tb_shortestTime;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_buttons;
    }
}
