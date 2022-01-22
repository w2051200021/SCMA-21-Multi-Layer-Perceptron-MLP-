
namespace TEChangGALibrary
{
    partial class BFMonitor
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
            this.lsb_BrutalForce = new System.Windows.Forms.ListBox();
            this.btn_brutalForce = new System.Windows.Forms.Button();
            this.lb_bestSolution = new System.Windows.Forms.Label();
            this.lb_shortestTime = new System.Windows.Forms.Label();
            this.gb_BF = new System.Windows.Forms.GroupBox();
            this.lb_numberOfCombinations = new System.Windows.Forms.Label();
            this.gb_BF.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsb_BrutalForce
            // 
            this.lsb_BrutalForce.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsb_BrutalForce.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsb_BrutalForce.FormattingEnabled = true;
            this.lsb_BrutalForce.HorizontalScrollbar = true;
            this.lsb_BrutalForce.ItemHeight = 22;
            this.lsb_BrutalForce.Location = new System.Drawing.Point(40, 141);
            this.lsb_BrutalForce.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsb_BrutalForce.Name = "lsb_BrutalForce";
            this.lsb_BrutalForce.ScrollAlwaysVisible = true;
            this.lsb_BrutalForce.Size = new System.Drawing.Size(1253, 774);
            this.lsb_BrutalForce.TabIndex = 0;
            // 
            // btn_brutalForce
            // 
            this.btn_brutalForce.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_brutalForce.Location = new System.Drawing.Point(40, 30);
            this.btn_brutalForce.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_brutalForce.Name = "btn_brutalForce";
            this.btn_brutalForce.Size = new System.Drawing.Size(182, 86);
            this.btn_brutalForce.TabIndex = 1;
            this.btn_brutalForce.Text = "Show All Combinations\r\n";
            this.btn_brutalForce.UseVisualStyleBackColor = true;
            this.btn_brutalForce.Click += new System.EventHandler(this.btn_brutalForce_Click);
            // 
            // lb_bestSolution
            // 
            this.lb_bestSolution.AutoSize = true;
            this.lb_bestSolution.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_bestSolution.Location = new System.Drawing.Point(239, 61);
            this.lb_bestSolution.Name = "lb_bestSolution";
            this.lb_bestSolution.Size = new System.Drawing.Size(152, 22);
            this.lb_bestSolution.TabIndex = 2;
            this.lb_bestSolution.Text = "The Best Solution:";
            // 
            // lb_shortestTime
            // 
            this.lb_shortestTime.AutoSize = true;
            this.lb_shortestTime.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_shortestTime.Location = new System.Drawing.Point(239, 91);
            this.lb_shortestTime.Name = "lb_shortestTime";
            this.lb_shortestTime.Size = new System.Drawing.Size(210, 22);
            this.lb_shortestTime.TabIndex = 3;
            this.lb_shortestTime.Text = "The Shortest Setup Time:";
            // 
            // gb_BF
            // 
            this.gb_BF.Controls.Add(this.lb_numberOfCombinations);
            this.gb_BF.Controls.Add(this.lb_shortestTime);
            this.gb_BF.Controls.Add(this.lsb_BrutalForce);
            this.gb_BF.Controls.Add(this.lb_bestSolution);
            this.gb_BF.Controls.Add(this.btn_brutalForce);
            this.gb_BF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_BF.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_BF.Location = new System.Drawing.Point(0, 0);
            this.gb_BF.Name = "gb_BF";
            this.gb_BF.Size = new System.Drawing.Size(1342, 947);
            this.gb_BF.TabIndex = 4;
            this.gb_BF.TabStop = false;
            this.gb_BF.Text = "The Brutal Force Method";
            // 
            // lb_numberOfCombinations
            // 
            this.lb_numberOfCombinations.AutoSize = true;
            this.lb_numberOfCombinations.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_numberOfCombinations.Location = new System.Drawing.Point(239, 30);
            this.lb_numberOfCombinations.Name = "lb_numberOfCombinations";
            this.lb_numberOfCombinations.Size = new System.Drawing.Size(261, 22);
            this.lb_numberOfCombinations.TabIndex = 4;
            this.lb_numberOfCombinations.Text = "Total Number of Combinations:";
            // 
            // BFMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_BF);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BFMonitor";
            this.Size = new System.Drawing.Size(1342, 947);
            this.gb_BF.ResumeLayout(false);
            this.gb_BF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lsb_BrutalForce;
        private System.Windows.Forms.GroupBox gb_BF;
        public System.Windows.Forms.Label lb_numberOfCombinations;
        public System.Windows.Forms.Button btn_brutalForce;
        public System.Windows.Forms.Label lb_bestSolution;
        public System.Windows.Forms.Label lb_shortestTime;
    }
}
