
namespace R09622009TEChangAss011
{
    partial class MainForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tp_dataset = new System.Windows.Forms.TabPage();
            this.lb_outputD = new System.Windows.Forms.Label();
            this.lb_inputD = new System.Windows.Forms.Label();
            this.lb_sampleSize = new System.Windows.Forms.Label();
            this.lb_dataset = new System.Windows.Forms.Label();
            this.dgv_dataset = new System.Windows.Forms.DataGridView();
            this.btn_loadADataset = new System.Windows.Forms.Button();
            this.tp_MLP = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gb_hiddenLayer = new System.Windows.Forms.GroupBox();
            this.lb_weights = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbLayers = new System.Windows.Forms.ListBox();
            this.numUDNeurons = new System.Windows.Forms.NumericUpDown();
            this.numUDLayers = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_NN = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.btn_ResetNN = new System.Windows.Forms.Button();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.btn_TrainAnEpochNN = new System.Windows.Forms.Button();
            this.btn_TrainToEndNN = new System.Windows.Forms.Button();
            this.prg_NN = new System.Windows.Forms.PropertyGrid();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.lb_NNTrainRMSE = new System.Windows.Forms.Label();
            this.lb_NNTrainAcc = new System.Windows.Forms.Label();
            this.dgv_NNTrainConfusion = new System.Windows.Forms.DataGridView();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.lb_NNTestRMSE = new System.Windows.Forms.Label();
            this.lb_NNTestAcc = new System.Windows.Forms.Label();
            this.dgv_NNTestConfusion = new System.Windows.Forms.DataGridView();
            this.tp_GA = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.btn_ResetGA = new System.Windows.Forms.Button();
            this.splitContainer14 = new System.Windows.Forms.SplitContainer();
            this.btn_runOneIterationGA = new System.Windows.Forms.Button();
            this.btn_runToEndGA = new System.Windows.Forms.Button();
            this.prg_GA = new System.Windows.Forms.PropertyGrid();
            this.splitContainer15 = new System.Windows.Forms.SplitContainer();
            this.splitContainer16 = new System.Windows.Forms.SplitContainer();
            this.lb_GATrainRMSE = new System.Windows.Forms.Label();
            this.lb_GATrainAcc = new System.Windows.Forms.Label();
            this.dgv_GATrainConfusion = new System.Windows.Forms.DataGridView();
            this.splitContainer17 = new System.Windows.Forms.SplitContainer();
            this.lb_GATestAcc = new System.Windows.Forms.Label();
            this.lb_GATestRMSE = new System.Windows.Forms.Label();
            this.dgv_GATestConfusion = new System.Windows.Forms.DataGridView();
            this.tp_PSO = new System.Windows.Forms.TabPage();
            this.splitContainer18 = new System.Windows.Forms.SplitContainer();
            this.splitContainer19 = new System.Windows.Forms.SplitContainer();
            this.splitContainer20 = new System.Windows.Forms.SplitContainer();
            this.btn_ResetPSO = new System.Windows.Forms.Button();
            this.splitContainer21 = new System.Windows.Forms.SplitContainer();
            this.btn_runOneIterationPSO = new System.Windows.Forms.Button();
            this.btn_runToEndPSO = new System.Windows.Forms.Button();
            this.prg_PSO = new System.Windows.Forms.PropertyGrid();
            this.splitContainer22 = new System.Windows.Forms.SplitContainer();
            this.splitContainer23 = new System.Windows.Forms.SplitContainer();
            this.lb_PSOTrainRMSE = new System.Windows.Forms.Label();
            this.lb_PSOTrainAcc = new System.Windows.Forms.Label();
            this.dgv_PSOTrainConfusion = new System.Windows.Forms.DataGridView();
            this.splitContainer24 = new System.Windows.Forms.SplitContainer();
            this.lb_PSOTestAcc = new System.Windows.Forms.Label();
            this.lb_PSOTestRMSE = new System.Windows.Forms.Label();
            this.dgv_PSOTestConfusion = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chtOptResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MLPPrintDoc = new System.Drawing.Printing.PrintDocument();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tpNNStructure = new System.Windows.Forms.TabPage();
            this.tpWeight = new System.Windows.Forms.TabPage();
            this.rtbWeights = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tp_dataset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataset)).BeginInit();
            this.tp_MLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gb_hiddenLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNeurons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLayers)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tp_NN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NNTrainConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NNTestConfusion)).BeginInit();
            this.tp_GA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).BeginInit();
            this.splitContainer14.Panel1.SuspendLayout();
            this.splitContainer14.Panel2.SuspendLayout();
            this.splitContainer14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).BeginInit();
            this.splitContainer15.Panel1.SuspendLayout();
            this.splitContainer15.Panel2.SuspendLayout();
            this.splitContainer15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).BeginInit();
            this.splitContainer16.Panel1.SuspendLayout();
            this.splitContainer16.Panel2.SuspendLayout();
            this.splitContainer16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GATrainConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).BeginInit();
            this.splitContainer17.Panel1.SuspendLayout();
            this.splitContainer17.Panel2.SuspendLayout();
            this.splitContainer17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GATestConfusion)).BeginInit();
            this.tp_PSO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer18)).BeginInit();
            this.splitContainer18.Panel1.SuspendLayout();
            this.splitContainer18.Panel2.SuspendLayout();
            this.splitContainer18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer19)).BeginInit();
            this.splitContainer19.Panel1.SuspendLayout();
            this.splitContainer19.Panel2.SuspendLayout();
            this.splitContainer19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).BeginInit();
            this.splitContainer20.Panel1.SuspendLayout();
            this.splitContainer20.Panel2.SuspendLayout();
            this.splitContainer20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer21)).BeginInit();
            this.splitContainer21.Panel1.SuspendLayout();
            this.splitContainer21.Panel2.SuspendLayout();
            this.splitContainer21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer22)).BeginInit();
            this.splitContainer22.Panel1.SuspendLayout();
            this.splitContainer22.Panel2.SuspendLayout();
            this.splitContainer22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer23)).BeginInit();
            this.splitContainer23.Panel1.SuspendLayout();
            this.splitContainer23.Panel2.SuspendLayout();
            this.splitContainer23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PSOTrainConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer24)).BeginInit();
            this.splitContainer24.Panel1.SuspendLayout();
            this.splitContainer24.Panel2.SuspendLayout();
            this.splitContainer24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PSOTestConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtOptResult)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tpWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1318, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.printToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem.Text = "Open ...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.printToolStripMenuItem.Text = "Print ...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 672);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1318, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1318, 645);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tp_dataset);
            this.tabControl2.Controls.Add(this.tp_MLP);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(418, 645);
            this.tabControl2.TabIndex = 0;
            // 
            // tp_dataset
            // 
            this.tp_dataset.BackColor = System.Drawing.SystemColors.Control;
            this.tp_dataset.Controls.Add(this.lb_outputD);
            this.tp_dataset.Controls.Add(this.lb_inputD);
            this.tp_dataset.Controls.Add(this.lb_sampleSize);
            this.tp_dataset.Controls.Add(this.lb_dataset);
            this.tp_dataset.Controls.Add(this.dgv_dataset);
            this.tp_dataset.Controls.Add(this.btn_loadADataset);
            this.tp_dataset.Location = new System.Drawing.Point(4, 28);
            this.tp_dataset.Name = "tp_dataset";
            this.tp_dataset.Padding = new System.Windows.Forms.Padding(3);
            this.tp_dataset.Size = new System.Drawing.Size(410, 613);
            this.tp_dataset.TabIndex = 0;
            this.tp_dataset.Text = "Dataset";
            // 
            // lb_outputD
            // 
            this.lb_outputD.AutoSize = true;
            this.lb_outputD.Location = new System.Drawing.Point(6, 123);
            this.lb_outputD.Name = "lb_outputD";
            this.lb_outputD.Size = new System.Drawing.Size(148, 19);
            this.lb_outputD.TabIndex = 5;
            this.lb_outputD.Text = "Output Dimension : ";
            // 
            // lb_inputD
            // 
            this.lb_inputD.AutoSize = true;
            this.lb_inputD.Location = new System.Drawing.Point(6, 104);
            this.lb_inputD.Name = "lb_inputD";
            this.lb_inputD.Size = new System.Drawing.Size(135, 19);
            this.lb_inputD.TabIndex = 4;
            this.lb_inputD.Text = "Input Dimension : ";
            // 
            // lb_sampleSize
            // 
            this.lb_sampleSize.AutoSize = true;
            this.lb_sampleSize.Location = new System.Drawing.Point(6, 85);
            this.lb_sampleSize.Name = "lb_sampleSize";
            this.lb_sampleSize.Size = new System.Drawing.Size(131, 19);
            this.lb_sampleSize.TabIndex = 3;
            this.lb_sampleSize.Text = "Number of data : ";
            // 
            // lb_dataset
            // 
            this.lb_dataset.AutoSize = true;
            this.lb_dataset.Location = new System.Drawing.Point(6, 66);
            this.lb_dataset.Name = "lb_dataset";
            this.lb_dataset.Size = new System.Drawing.Size(72, 19);
            this.lb_dataset.TabIndex = 2;
            this.lb_dataset.Text = "Dataset : ";
            // 
            // dgv_dataset
            // 
            this.dgv_dataset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dataset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_dataset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dataset.Location = new System.Drawing.Point(6, 150);
            this.dgv_dataset.Name = "dgv_dataset";
            this.dgv_dataset.ReadOnly = true;
            this.dgv_dataset.RowHeadersVisible = false;
            this.dgv_dataset.RowHeadersWidth = 51;
            this.dgv_dataset.RowTemplate.Height = 27;
            this.dgv_dataset.Size = new System.Drawing.Size(396, 475);
            this.dgv_dataset.TabIndex = 1;
            // 
            // btn_loadADataset
            // 
            this.btn_loadADataset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loadADataset.Location = new System.Drawing.Point(6, 6);
            this.btn_loadADataset.Name = "btn_loadADataset";
            this.btn_loadADataset.Size = new System.Drawing.Size(396, 57);
            this.btn_loadADataset.TabIndex = 0;
            this.btn_loadADataset.Text = "Load a dataset";
            this.btn_loadADataset.UseVisualStyleBackColor = true;
            this.btn_loadADataset.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // tp_MLP
            // 
            this.tp_MLP.BackColor = System.Drawing.SystemColors.Control;
            this.tp_MLP.Controls.Add(this.splitContainer3);
            this.tp_MLP.Location = new System.Drawing.Point(4, 25);
            this.tp_MLP.Name = "tp_MLP";
            this.tp_MLP.Padding = new System.Windows.Forms.Padding(3);
            this.tp_MLP.Size = new System.Drawing.Size(410, 616);
            this.tp_MLP.TabIndex = 1;
            this.tp_MLP.Text = "Operations";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gb_hiddenLayer);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer3.Size = new System.Drawing.Size(404, 610);
            this.splitContainer3.SplitterDistance = 106;
            this.splitContainer3.TabIndex = 9;
            // 
            // gb_hiddenLayer
            // 
            this.gb_hiddenLayer.Controls.Add(this.lb_weights);
            this.gb_hiddenLayer.Controls.Add(this.label2);
            this.gb_hiddenLayer.Controls.Add(this.label1);
            this.gb_hiddenLayer.Controls.Add(this.lsbLayers);
            this.gb_hiddenLayer.Controls.Add(this.numUDNeurons);
            this.gb_hiddenLayer.Controls.Add(this.numUDLayers);
            this.gb_hiddenLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_hiddenLayer.Location = new System.Drawing.Point(0, 0);
            this.gb_hiddenLayer.Name = "gb_hiddenLayer";
            this.gb_hiddenLayer.Size = new System.Drawing.Size(404, 106);
            this.gb_hiddenLayer.TabIndex = 7;
            this.gb_hiddenLayer.TabStop = false;
            this.gb_hiddenLayer.Text = "Setting on Hidden Layer";
            // 
            // lb_weights
            // 
            this.lb_weights.AutoSize = true;
            this.lb_weights.Location = new System.Drawing.Point(123, 91);
            this.lb_weights.Name = "lb_weights";
            this.lb_weights.Size = new System.Drawing.Size(151, 19);
            this.lb_weights.TabIndex = 9;
            this.lb_weights.Text = "Number of weights :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of neurons :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of hidden layers :";
            // 
            // lsbLayers
            // 
            this.lsbLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbLayers.FormattingEnabled = true;
            this.lsbLayers.ItemHeight = 19;
            this.lsbLayers.Items.AddRange(new object[] {
            "4"});
            this.lsbLayers.Location = new System.Drawing.Point(12, 26);
            this.lsbLayers.Name = "lsbLayers";
            this.lsbLayers.Size = new System.Drawing.Size(105, 42);
            this.lsbLayers.TabIndex = 0;
            this.lsbLayers.SelectedIndexChanged += new System.EventHandler(this.lsbLayers_SelectedIndexChanged);
            // 
            // numUDNeurons
            // 
            this.numUDNeurons.Location = new System.Drawing.Point(320, 57);
            this.numUDNeurons.Name = "numUDNeurons";
            this.numUDNeurons.Size = new System.Drawing.Size(73, 27);
            this.numUDNeurons.TabIndex = 6;
            this.numUDNeurons.ValueChanged += new System.EventHandler(this.numUDNeurons_ValueChanged);
            // 
            // numUDLayers
            // 
            this.numUDLayers.Location = new System.Drawing.Point(320, 24);
            this.numUDLayers.Name = "numUDLayers";
            this.numUDLayers.Size = new System.Drawing.Size(73, 27);
            this.numUDLayers.TabIndex = 5;
            this.numUDLayers.ValueChanged += new System.EventHandler(this.numUDLayers_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_NN);
            this.tabControl1.Controls.Add(this.tp_GA);
            this.tabControl1.Controls.Add(this.tp_PSO);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_NN
            // 
            this.tp_NN.BackColor = System.Drawing.SystemColors.Control;
            this.tp_NN.Controls.Add(this.splitContainer4);
            this.tp_NN.Location = new System.Drawing.Point(4, 28);
            this.tp_NN.Name = "tp_NN";
            this.tp_NN.Padding = new System.Windows.Forms.Padding(3);
            this.tp_NN.Size = new System.Drawing.Size(396, 468);
            this.tp_NN.TabIndex = 0;
            this.tp_NN.Text = "Multi-Layer Perceptron";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer9);
            this.splitContainer4.Size = new System.Drawing.Size(390, 462);
            this.splitContainer4.SplitterDistance = 266;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.prg_NN);
            this.splitContainer6.Size = new System.Drawing.Size(390, 266);
            this.splitContainer6.SplitterDistance = 61;
            this.splitContainer6.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.btn_ResetNN);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(390, 61);
            this.splitContainer7.SplitterDistance = 130;
            this.splitContainer7.TabIndex = 0;
            // 
            // btn_ResetNN
            // 
            this.btn_ResetNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ResetNN.Location = new System.Drawing.Point(0, 0);
            this.btn_ResetNN.Name = "btn_ResetNN";
            this.btn_ResetNN.Size = new System.Drawing.Size(130, 61);
            this.btn_ResetNN.TabIndex = 1;
            this.btn_ResetNN.Text = "Reset";
            this.btn_ResetNN.UseVisualStyleBackColor = true;
            this.btn_ResetNN.Click += new System.EventHandler(this.btnResetNN_Click);
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.btn_TrainAnEpochNN);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.btn_TrainToEndNN);
            this.splitContainer8.Size = new System.Drawing.Size(256, 61);
            this.splitContainer8.SplitterDistance = 127;
            this.splitContainer8.TabIndex = 0;
            // 
            // btn_TrainAnEpochNN
            // 
            this.btn_TrainAnEpochNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TrainAnEpochNN.Location = new System.Drawing.Point(0, 0);
            this.btn_TrainAnEpochNN.Name = "btn_TrainAnEpochNN";
            this.btn_TrainAnEpochNN.Size = new System.Drawing.Size(127, 61);
            this.btn_TrainAnEpochNN.TabIndex = 2;
            this.btn_TrainAnEpochNN.Text = "Train An Epoch";
            this.btn_TrainAnEpochNN.UseVisualStyleBackColor = true;
            this.btn_TrainAnEpochNN.Click += new System.EventHandler(this.btnNNTrainAnEpoch_Click);
            // 
            // btn_TrainToEndNN
            // 
            this.btn_TrainToEndNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TrainToEndNN.Location = new System.Drawing.Point(0, 0);
            this.btn_TrainToEndNN.Name = "btn_TrainToEndNN";
            this.btn_TrainToEndNN.Size = new System.Drawing.Size(125, 61);
            this.btn_TrainToEndNN.TabIndex = 3;
            this.btn_TrainToEndNN.Text = "Train To End";
            this.btn_TrainToEndNN.UseVisualStyleBackColor = true;
            this.btn_TrainToEndNN.Click += new System.EventHandler(this.btnNNTrainToEnd_Click);
            // 
            // prg_NN
            // 
            this.prg_NN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prg_NN.Location = new System.Drawing.Point(0, 0);
            this.prg_NN.Name = "prg_NN";
            this.prg_NN.Size = new System.Drawing.Size(390, 201);
            this.prg_NN.TabIndex = 4;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.splitContainer10);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.splitContainer11);
            this.splitContainer9.Size = new System.Drawing.Size(390, 192);
            this.splitContainer9.SplitterDistance = 195;
            this.splitContainer9.TabIndex = 0;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.lb_NNTrainRMSE);
            this.splitContainer10.Panel1.Controls.Add(this.lb_NNTrainAcc);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.dgv_NNTrainConfusion);
            this.splitContainer10.Size = new System.Drawing.Size(195, 192);
            this.splitContainer10.SplitterDistance = 37;
            this.splitContainer10.TabIndex = 0;
            // 
            // lb_NNTrainRMSE
            // 
            this.lb_NNTrainRMSE.AutoSize = true;
            this.lb_NNTrainRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_NNTrainRMSE.Location = new System.Drawing.Point(5, 8);
            this.lb_NNTrainRMSE.Name = "lb_NNTrainRMSE";
            this.lb_NNTrainRMSE.Size = new System.Drawing.Size(123, 19);
            this.lb_NNTrainRMSE.TabIndex = 12;
            this.lb_NNTrainRMSE.Text = "Training RMSE : ";
            // 
            // lb_NNTrainAcc
            // 
            this.lb_NNTrainAcc.AutoSize = true;
            this.lb_NNTrainAcc.Location = new System.Drawing.Point(5, 24);
            this.lb_NNTrainAcc.Name = "lb_NNTrainAcc";
            this.lb_NNTrainAcc.Size = new System.Drawing.Size(138, 19);
            this.lb_NNTrainAcc.TabIndex = 11;
            this.lb_NNTrainAcc.Text = "Training accuracy :";
            // 
            // dgv_NNTrainConfusion
            // 
            this.dgv_NNTrainConfusion.AllowUserToAddRows = false;
            this.dgv_NNTrainConfusion.AllowUserToDeleteRows = false;
            this.dgv_NNTrainConfusion.AllowUserToResizeColumns = false;
            this.dgv_NNTrainConfusion.AllowUserToResizeRows = false;
            this.dgv_NNTrainConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NNTrainConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_NNTrainConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NNTrainConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NNTrainConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_NNTrainConfusion.Name = "dgv_NNTrainConfusion";
            this.dgv_NNTrainConfusion.ReadOnly = true;
            this.dgv_NNTrainConfusion.RowHeadersVisible = false;
            this.dgv_NNTrainConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_NNTrainConfusion.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_NNTrainConfusion.RowTemplate.Height = 27;
            this.dgv_NNTrainConfusion.Size = new System.Drawing.Size(195, 151);
            this.dgv_NNTrainConfusion.TabIndex = 12;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            this.splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.lb_NNTestRMSE);
            this.splitContainer11.Panel1.Controls.Add(this.lb_NNTestAcc);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.dgv_NNTestConfusion);
            this.splitContainer11.Size = new System.Drawing.Size(191, 192);
            this.splitContainer11.SplitterDistance = 37;
            this.splitContainer11.TabIndex = 0;
            // 
            // lb_NNTestRMSE
            // 
            this.lb_NNTestRMSE.AutoSize = true;
            this.lb_NNTestRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_NNTestRMSE.Location = new System.Drawing.Point(3, 8);
            this.lb_NNTestRMSE.Name = "lb_NNTestRMSE";
            this.lb_NNTestRMSE.Size = new System.Drawing.Size(116, 19);
            this.lb_NNTestRMSE.TabIndex = 13;
            this.lb_NNTestRMSE.Text = "Testing RMSE : ";
            // 
            // lb_NNTestAcc
            // 
            this.lb_NNTestAcc.AutoSize = true;
            this.lb_NNTestAcc.Location = new System.Drawing.Point(3, 24);
            this.lb_NNTestAcc.Name = "lb_NNTestAcc";
            this.lb_NNTestAcc.Size = new System.Drawing.Size(131, 19);
            this.lb_NNTestAcc.TabIndex = 8;
            this.lb_NNTestAcc.Text = "Testing accuracy :";
            // 
            // dgv_NNTestConfusion
            // 
            this.dgv_NNTestConfusion.AllowUserToAddRows = false;
            this.dgv_NNTestConfusion.AllowUserToDeleteRows = false;
            this.dgv_NNTestConfusion.AllowUserToResizeColumns = false;
            this.dgv_NNTestConfusion.AllowUserToResizeRows = false;
            this.dgv_NNTestConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NNTestConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_NNTestConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NNTestConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NNTestConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_NNTestConfusion.Name = "dgv_NNTestConfusion";
            this.dgv_NNTestConfusion.ReadOnly = true;
            this.dgv_NNTestConfusion.RowHeadersVisible = false;
            this.dgv_NNTestConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_NNTestConfusion.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_NNTestConfusion.RowTemplate.Height = 27;
            this.dgv_NNTestConfusion.Size = new System.Drawing.Size(191, 151);
            this.dgv_NNTestConfusion.TabIndex = 10;
            // 
            // tp_GA
            // 
            this.tp_GA.BackColor = System.Drawing.SystemColors.Control;
            this.tp_GA.Controls.Add(this.splitContainer5);
            this.tp_GA.Location = new System.Drawing.Point(4, 25);
            this.tp_GA.Name = "tp_GA";
            this.tp_GA.Size = new System.Drawing.Size(396, 471);
            this.tp_GA.TabIndex = 1;
            this.tp_GA.Text = "Genetic Algorithm";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer12);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer15);
            this.splitContainer5.Size = new System.Drawing.Size(390, 450);
            this.splitContainer5.SplitterDistance = 258;
            this.splitContainer5.TabIndex = 1;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            this.splitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.splitContainer13);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.prg_GA);
            this.splitContainer12.Size = new System.Drawing.Size(390, 258);
            this.splitContainer12.SplitterDistance = 58;
            this.splitContainer12.TabIndex = 0;
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.Controls.Add(this.btn_ResetGA);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.Controls.Add(this.splitContainer14);
            this.splitContainer13.Size = new System.Drawing.Size(390, 58);
            this.splitContainer13.SplitterDistance = 130;
            this.splitContainer13.TabIndex = 0;
            // 
            // btn_ResetGA
            // 
            this.btn_ResetGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ResetGA.Location = new System.Drawing.Point(0, 0);
            this.btn_ResetGA.Name = "btn_ResetGA";
            this.btn_ResetGA.Size = new System.Drawing.Size(130, 58);
            this.btn_ResetGA.TabIndex = 1;
            this.btn_ResetGA.Text = "Reset";
            this.btn_ResetGA.UseVisualStyleBackColor = true;
            this.btn_ResetGA.Click += new System.EventHandler(this.btn_ResetGA_Click);
            // 
            // splitContainer14
            // 
            this.splitContainer14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer14.Location = new System.Drawing.Point(0, 0);
            this.splitContainer14.Name = "splitContainer14";
            // 
            // splitContainer14.Panel1
            // 
            this.splitContainer14.Panel1.Controls.Add(this.btn_runOneIterationGA);
            // 
            // splitContainer14.Panel2
            // 
            this.splitContainer14.Panel2.Controls.Add(this.btn_runToEndGA);
            this.splitContainer14.Size = new System.Drawing.Size(256, 58);
            this.splitContainer14.SplitterDistance = 127;
            this.splitContainer14.TabIndex = 0;
            // 
            // btn_runOneIterationGA
            // 
            this.btn_runOneIterationGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_runOneIterationGA.Location = new System.Drawing.Point(0, 0);
            this.btn_runOneIterationGA.Name = "btn_runOneIterationGA";
            this.btn_runOneIterationGA.Size = new System.Drawing.Size(127, 58);
            this.btn_runOneIterationGA.TabIndex = 2;
            this.btn_runOneIterationGA.Text = "Run One Iteration";
            this.btn_runOneIterationGA.UseVisualStyleBackColor = true;
            this.btn_runOneIterationGA.Click += new System.EventHandler(this.btn_runOneIterationGA_Click);
            // 
            // btn_runToEndGA
            // 
            this.btn_runToEndGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_runToEndGA.Location = new System.Drawing.Point(0, 0);
            this.btn_runToEndGA.Name = "btn_runToEndGA";
            this.btn_runToEndGA.Size = new System.Drawing.Size(125, 58);
            this.btn_runToEndGA.TabIndex = 3;
            this.btn_runToEndGA.Text = "Run To End";
            this.btn_runToEndGA.UseVisualStyleBackColor = true;
            this.btn_runToEndGA.Click += new System.EventHandler(this.btn_runToEndGA_Click);
            // 
            // prg_GA
            // 
            this.prg_GA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prg_GA.Location = new System.Drawing.Point(0, 0);
            this.prg_GA.Name = "prg_GA";
            this.prg_GA.Size = new System.Drawing.Size(390, 196);
            this.prg_GA.TabIndex = 4;
            // 
            // splitContainer15
            // 
            this.splitContainer15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer15.Location = new System.Drawing.Point(0, 0);
            this.splitContainer15.Name = "splitContainer15";
            // 
            // splitContainer15.Panel1
            // 
            this.splitContainer15.Panel1.Controls.Add(this.splitContainer16);
            // 
            // splitContainer15.Panel2
            // 
            this.splitContainer15.Panel2.Controls.Add(this.splitContainer17);
            this.splitContainer15.Size = new System.Drawing.Size(390, 188);
            this.splitContainer15.SplitterDistance = 195;
            this.splitContainer15.TabIndex = 0;
            // 
            // splitContainer16
            // 
            this.splitContainer16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer16.Location = new System.Drawing.Point(0, 0);
            this.splitContainer16.Name = "splitContainer16";
            this.splitContainer16.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer16.Panel1
            // 
            this.splitContainer16.Panel1.Controls.Add(this.lb_GATrainRMSE);
            this.splitContainer16.Panel1.Controls.Add(this.lb_GATrainAcc);
            // 
            // splitContainer16.Panel2
            // 
            this.splitContainer16.Panel2.Controls.Add(this.dgv_GATrainConfusion);
            this.splitContainer16.Size = new System.Drawing.Size(195, 188);
            this.splitContainer16.SplitterDistance = 34;
            this.splitContainer16.TabIndex = 0;
            // 
            // lb_GATrainRMSE
            // 
            this.lb_GATrainRMSE.AutoSize = true;
            this.lb_GATrainRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_GATrainRMSE.Location = new System.Drawing.Point(5, 8);
            this.lb_GATrainRMSE.Name = "lb_GATrainRMSE";
            this.lb_GATrainRMSE.Size = new System.Drawing.Size(123, 19);
            this.lb_GATrainRMSE.TabIndex = 12;
            this.lb_GATrainRMSE.Text = "Training RMSE : ";
            // 
            // lb_GATrainAcc
            // 
            this.lb_GATrainAcc.AutoSize = true;
            this.lb_GATrainAcc.Location = new System.Drawing.Point(5, 24);
            this.lb_GATrainAcc.Name = "lb_GATrainAcc";
            this.lb_GATrainAcc.Size = new System.Drawing.Size(138, 19);
            this.lb_GATrainAcc.TabIndex = 11;
            this.lb_GATrainAcc.Text = "Training accuracy :";
            // 
            // dgv_GATrainConfusion
            // 
            this.dgv_GATrainConfusion.AllowUserToAddRows = false;
            this.dgv_GATrainConfusion.AllowUserToDeleteRows = false;
            this.dgv_GATrainConfusion.AllowUserToResizeColumns = false;
            this.dgv_GATrainConfusion.AllowUserToResizeRows = false;
            this.dgv_GATrainConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GATrainConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_GATrainConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GATrainConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GATrainConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_GATrainConfusion.Name = "dgv_GATrainConfusion";
            this.dgv_GATrainConfusion.ReadOnly = true;
            this.dgv_GATrainConfusion.RowHeadersVisible = false;
            this.dgv_GATrainConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_GATrainConfusion.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_GATrainConfusion.RowTemplate.Height = 27;
            this.dgv_GATrainConfusion.Size = new System.Drawing.Size(195, 150);
            this.dgv_GATrainConfusion.TabIndex = 12;
            // 
            // splitContainer17
            // 
            this.splitContainer17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer17.Location = new System.Drawing.Point(0, 0);
            this.splitContainer17.Name = "splitContainer17";
            this.splitContainer17.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer17.Panel1
            // 
            this.splitContainer17.Panel1.Controls.Add(this.lb_GATestAcc);
            this.splitContainer17.Panel1.Controls.Add(this.lb_GATestRMSE);
            // 
            // splitContainer17.Panel2
            // 
            this.splitContainer17.Panel2.Controls.Add(this.dgv_GATestConfusion);
            this.splitContainer17.Size = new System.Drawing.Size(191, 188);
            this.splitContainer17.SplitterDistance = 34;
            this.splitContainer17.TabIndex = 0;
            // 
            // lb_GATestAcc
            // 
            this.lb_GATestAcc.AutoSize = true;
            this.lb_GATestAcc.Location = new System.Drawing.Point(3, 24);
            this.lb_GATestAcc.Name = "lb_GATestAcc";
            this.lb_GATestAcc.Size = new System.Drawing.Size(131, 19);
            this.lb_GATestAcc.TabIndex = 8;
            this.lb_GATestAcc.Text = "Testing accuracy :";
            // 
            // lb_GATestRMSE
            // 
            this.lb_GATestRMSE.AutoSize = true;
            this.lb_GATestRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_GATestRMSE.Location = new System.Drawing.Point(3, 8);
            this.lb_GATestRMSE.Name = "lb_GATestRMSE";
            this.lb_GATestRMSE.Size = new System.Drawing.Size(116, 19);
            this.lb_GATestRMSE.TabIndex = 13;
            this.lb_GATestRMSE.Text = "Testing RMSE : ";
            // 
            // dgv_GATestConfusion
            // 
            this.dgv_GATestConfusion.AllowUserToAddRows = false;
            this.dgv_GATestConfusion.AllowUserToDeleteRows = false;
            this.dgv_GATestConfusion.AllowUserToResizeColumns = false;
            this.dgv_GATestConfusion.AllowUserToResizeRows = false;
            this.dgv_GATestConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GATestConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_GATestConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GATestConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GATestConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_GATestConfusion.Name = "dgv_GATestConfusion";
            this.dgv_GATestConfusion.ReadOnly = true;
            this.dgv_GATestConfusion.RowHeadersVisible = false;
            this.dgv_GATestConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_GATestConfusion.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_GATestConfusion.RowTemplate.Height = 27;
            this.dgv_GATestConfusion.Size = new System.Drawing.Size(191, 150);
            this.dgv_GATestConfusion.TabIndex = 10;
            // 
            // tp_PSO
            // 
            this.tp_PSO.BackColor = System.Drawing.SystemColors.Control;
            this.tp_PSO.Controls.Add(this.splitContainer18);
            this.tp_PSO.Location = new System.Drawing.Point(4, 25);
            this.tp_PSO.Name = "tp_PSO";
            this.tp_PSO.Size = new System.Drawing.Size(396, 471);
            this.tp_PSO.TabIndex = 2;
            this.tp_PSO.Text = "Particle Swarm Optimization";
            // 
            // splitContainer18
            // 
            this.splitContainer18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer18.Location = new System.Drawing.Point(3, 3);
            this.splitContainer18.Name = "splitContainer18";
            this.splitContainer18.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer18.Panel1
            // 
            this.splitContainer18.Panel1.Controls.Add(this.splitContainer19);
            // 
            // splitContainer18.Panel2
            // 
            this.splitContainer18.Panel2.Controls.Add(this.splitContainer22);
            this.splitContainer18.Size = new System.Drawing.Size(390, 452);
            this.splitContainer18.SplitterDistance = 259;
            this.splitContainer18.TabIndex = 2;
            // 
            // splitContainer19
            // 
            this.splitContainer19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer19.Location = new System.Drawing.Point(0, 0);
            this.splitContainer19.Name = "splitContainer19";
            this.splitContainer19.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer19.Panel1
            // 
            this.splitContainer19.Panel1.Controls.Add(this.splitContainer20);
            // 
            // splitContainer19.Panel2
            // 
            this.splitContainer19.Panel2.Controls.Add(this.prg_PSO);
            this.splitContainer19.Size = new System.Drawing.Size(390, 259);
            this.splitContainer19.SplitterDistance = 58;
            this.splitContainer19.TabIndex = 0;
            // 
            // splitContainer20
            // 
            this.splitContainer20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer20.Location = new System.Drawing.Point(0, 0);
            this.splitContainer20.Name = "splitContainer20";
            // 
            // splitContainer20.Panel1
            // 
            this.splitContainer20.Panel1.Controls.Add(this.btn_ResetPSO);
            // 
            // splitContainer20.Panel2
            // 
            this.splitContainer20.Panel2.Controls.Add(this.splitContainer21);
            this.splitContainer20.Size = new System.Drawing.Size(390, 58);
            this.splitContainer20.SplitterDistance = 130;
            this.splitContainer20.TabIndex = 0;
            // 
            // btn_ResetPSO
            // 
            this.btn_ResetPSO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ResetPSO.Location = new System.Drawing.Point(0, 0);
            this.btn_ResetPSO.Name = "btn_ResetPSO";
            this.btn_ResetPSO.Size = new System.Drawing.Size(130, 58);
            this.btn_ResetPSO.TabIndex = 1;
            this.btn_ResetPSO.Text = "Reset";
            this.btn_ResetPSO.UseVisualStyleBackColor = true;
            this.btn_ResetPSO.Click += new System.EventHandler(this.btn_ResetPSO_Click);
            // 
            // splitContainer21
            // 
            this.splitContainer21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer21.Location = new System.Drawing.Point(0, 0);
            this.splitContainer21.Name = "splitContainer21";
            // 
            // splitContainer21.Panel1
            // 
            this.splitContainer21.Panel1.Controls.Add(this.btn_runOneIterationPSO);
            // 
            // splitContainer21.Panel2
            // 
            this.splitContainer21.Panel2.Controls.Add(this.btn_runToEndPSO);
            this.splitContainer21.Size = new System.Drawing.Size(256, 58);
            this.splitContainer21.SplitterDistance = 127;
            this.splitContainer21.TabIndex = 0;
            // 
            // btn_runOneIterationPSO
            // 
            this.btn_runOneIterationPSO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_runOneIterationPSO.Location = new System.Drawing.Point(0, 0);
            this.btn_runOneIterationPSO.Name = "btn_runOneIterationPSO";
            this.btn_runOneIterationPSO.Size = new System.Drawing.Size(127, 58);
            this.btn_runOneIterationPSO.TabIndex = 2;
            this.btn_runOneIterationPSO.Text = "Run One Iteration";
            this.btn_runOneIterationPSO.UseVisualStyleBackColor = true;
            this.btn_runOneIterationPSO.Click += new System.EventHandler(this.btn_runOneIterationPSO_Click);
            // 
            // btn_runToEndPSO
            // 
            this.btn_runToEndPSO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_runToEndPSO.Location = new System.Drawing.Point(0, 0);
            this.btn_runToEndPSO.Name = "btn_runToEndPSO";
            this.btn_runToEndPSO.Size = new System.Drawing.Size(125, 58);
            this.btn_runToEndPSO.TabIndex = 3;
            this.btn_runToEndPSO.Text = "Run To End";
            this.btn_runToEndPSO.UseVisualStyleBackColor = true;
            this.btn_runToEndPSO.Click += new System.EventHandler(this.btn_runToEndPSO_Click);
            // 
            // prg_PSO
            // 
            this.prg_PSO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prg_PSO.Location = new System.Drawing.Point(0, 0);
            this.prg_PSO.Name = "prg_PSO";
            this.prg_PSO.Size = new System.Drawing.Size(390, 197);
            this.prg_PSO.TabIndex = 4;
            // 
            // splitContainer22
            // 
            this.splitContainer22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer22.Location = new System.Drawing.Point(0, 0);
            this.splitContainer22.Name = "splitContainer22";
            // 
            // splitContainer22.Panel1
            // 
            this.splitContainer22.Panel1.Controls.Add(this.splitContainer23);
            // 
            // splitContainer22.Panel2
            // 
            this.splitContainer22.Panel2.Controls.Add(this.splitContainer24);
            this.splitContainer22.Size = new System.Drawing.Size(390, 189);
            this.splitContainer22.SplitterDistance = 195;
            this.splitContainer22.TabIndex = 0;
            // 
            // splitContainer23
            // 
            this.splitContainer23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer23.Location = new System.Drawing.Point(0, 0);
            this.splitContainer23.Name = "splitContainer23";
            this.splitContainer23.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer23.Panel1
            // 
            this.splitContainer23.Panel1.Controls.Add(this.lb_PSOTrainRMSE);
            this.splitContainer23.Panel1.Controls.Add(this.lb_PSOTrainAcc);
            // 
            // splitContainer23.Panel2
            // 
            this.splitContainer23.Panel2.Controls.Add(this.dgv_PSOTrainConfusion);
            this.splitContainer23.Size = new System.Drawing.Size(195, 189);
            this.splitContainer23.SplitterDistance = 35;
            this.splitContainer23.TabIndex = 0;
            // 
            // lb_PSOTrainRMSE
            // 
            this.lb_PSOTrainRMSE.AutoSize = true;
            this.lb_PSOTrainRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_PSOTrainRMSE.Location = new System.Drawing.Point(5, 8);
            this.lb_PSOTrainRMSE.Name = "lb_PSOTrainRMSE";
            this.lb_PSOTrainRMSE.Size = new System.Drawing.Size(123, 19);
            this.lb_PSOTrainRMSE.TabIndex = 12;
            this.lb_PSOTrainRMSE.Text = "Training RMSE : ";
            // 
            // lb_PSOTrainAcc
            // 
            this.lb_PSOTrainAcc.AutoSize = true;
            this.lb_PSOTrainAcc.Location = new System.Drawing.Point(5, 24);
            this.lb_PSOTrainAcc.Name = "lb_PSOTrainAcc";
            this.lb_PSOTrainAcc.Size = new System.Drawing.Size(138, 19);
            this.lb_PSOTrainAcc.TabIndex = 11;
            this.lb_PSOTrainAcc.Text = "Training accuracy :";
            // 
            // dgv_PSOTrainConfusion
            // 
            this.dgv_PSOTrainConfusion.AllowUserToAddRows = false;
            this.dgv_PSOTrainConfusion.AllowUserToDeleteRows = false;
            this.dgv_PSOTrainConfusion.AllowUserToResizeColumns = false;
            this.dgv_PSOTrainConfusion.AllowUserToResizeRows = false;
            this.dgv_PSOTrainConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PSOTrainConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_PSOTrainConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PSOTrainConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PSOTrainConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_PSOTrainConfusion.Name = "dgv_PSOTrainConfusion";
            this.dgv_PSOTrainConfusion.ReadOnly = true;
            this.dgv_PSOTrainConfusion.RowHeadersVisible = false;
            this.dgv_PSOTrainConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_PSOTrainConfusion.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_PSOTrainConfusion.RowTemplate.Height = 27;
            this.dgv_PSOTrainConfusion.Size = new System.Drawing.Size(195, 150);
            this.dgv_PSOTrainConfusion.TabIndex = 12;
            // 
            // splitContainer24
            // 
            this.splitContainer24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer24.Location = new System.Drawing.Point(0, 0);
            this.splitContainer24.Name = "splitContainer24";
            this.splitContainer24.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer24.Panel1
            // 
            this.splitContainer24.Panel1.Controls.Add(this.lb_PSOTestAcc);
            this.splitContainer24.Panel1.Controls.Add(this.lb_PSOTestRMSE);
            // 
            // splitContainer24.Panel2
            // 
            this.splitContainer24.Panel2.Controls.Add(this.dgv_PSOTestConfusion);
            this.splitContainer24.Size = new System.Drawing.Size(191, 189);
            this.splitContainer24.SplitterDistance = 35;
            this.splitContainer24.TabIndex = 0;
            // 
            // lb_PSOTestAcc
            // 
            this.lb_PSOTestAcc.AutoSize = true;
            this.lb_PSOTestAcc.Location = new System.Drawing.Point(3, 24);
            this.lb_PSOTestAcc.Name = "lb_PSOTestAcc";
            this.lb_PSOTestAcc.Size = new System.Drawing.Size(131, 19);
            this.lb_PSOTestAcc.TabIndex = 8;
            this.lb_PSOTestAcc.Text = "Testing accuracy :";
            // 
            // lb_PSOTestRMSE
            // 
            this.lb_PSOTestRMSE.AutoSize = true;
            this.lb_PSOTestRMSE.BackColor = System.Drawing.Color.Transparent;
            this.lb_PSOTestRMSE.Location = new System.Drawing.Point(3, 8);
            this.lb_PSOTestRMSE.Name = "lb_PSOTestRMSE";
            this.lb_PSOTestRMSE.Size = new System.Drawing.Size(116, 19);
            this.lb_PSOTestRMSE.TabIndex = 13;
            this.lb_PSOTestRMSE.Text = "Testing RMSE : ";
            // 
            // dgv_PSOTestConfusion
            // 
            this.dgv_PSOTestConfusion.AllowUserToAddRows = false;
            this.dgv_PSOTestConfusion.AllowUserToDeleteRows = false;
            this.dgv_PSOTestConfusion.AllowUserToResizeColumns = false;
            this.dgv_PSOTestConfusion.AllowUserToResizeRows = false;
            this.dgv_PSOTestConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PSOTestConfusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_PSOTestConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PSOTestConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PSOTestConfusion.Location = new System.Drawing.Point(0, 0);
            this.dgv_PSOTestConfusion.Name = "dgv_PSOTestConfusion";
            this.dgv_PSOTestConfusion.ReadOnly = true;
            this.dgv_PSOTestConfusion.RowHeadersVisible = false;
            this.dgv_PSOTestConfusion.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_PSOTestConfusion.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_PSOTestConfusion.RowTemplate.Height = 27;
            this.dgv_PSOTestConfusion.Size = new System.Drawing.Size(191, 150);
            this.dgv_PSOTestConfusion.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chtOptResult);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer2.Size = new System.Drawing.Size(896, 645);
            this.splitContainer2.SplitterDistance = 180;
            this.splitContainer2.TabIndex = 0;
            // 
            // chtOptResult
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.Title = "Epoch (Iteration)";
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.Title = "RMSE";
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chtOptResult.ChartAreas.Add(chartArea1);
            this.chtOptResult.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chtOptResult.Legends.Add(legend1);
            this.chtOptResult.Location = new System.Drawing.Point(0, 0);
            this.chtOptResult.Name = "chtOptResult";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.SystemColors.MenuHighlight;
            series1.Legend = "Legend1";
            series1.Name = "Train";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Tomato;
            series2.Legend = "Legend1";
            series2.Name = "Test";
            this.chtOptResult.Series.Add(series1);
            this.chtOptResult.Series.Add(series2);
            this.chtOptResult.Size = new System.Drawing.Size(896, 180);
            this.chtOptResult.TabIndex = 0;
            this.chtOptResult.Text = "chart1";
            // 
            // MLPPrintDoc
            // 
            this.MLPPrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MLPPrintDoc_PrintPage);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tpNNStructure);
            this.tabControl3.Controls.Add(this.tpWeight);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(896, 461);
            this.tabControl3.TabIndex = 0;
            // 
            // tpNNStructure
            // 
            this.tpNNStructure.BackColor = System.Drawing.SystemColors.Control;
            this.tpNNStructure.Location = new System.Drawing.Point(4, 28);
            this.tpNNStructure.Name = "tpNNStructure";
            this.tpNNStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tpNNStructure.Size = new System.Drawing.Size(888, 429);
            this.tpNNStructure.TabIndex = 0;
            this.tpNNStructure.Text = "Network Structure";
            this.tpNNStructure.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            // 
            // tpWeight
            // 
            this.tpWeight.BackColor = System.Drawing.SystemColors.Control;
            this.tpWeight.Controls.Add(this.rtbWeights);
            this.tpWeight.Location = new System.Drawing.Point(4, 28);
            this.tpWeight.Name = "tpWeight";
            this.tpWeight.Padding = new System.Windows.Forms.Padding(3);
            this.tpWeight.Size = new System.Drawing.Size(888, 429);
            this.tpWeight.TabIndex = 1;
            this.tpWeight.Text = "Weights";
            // 
            // rtbWeights
            // 
            this.rtbWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbWeights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWeights.Location = new System.Drawing.Point(6, 6);
            this.rtbWeights.Name = "rtbWeights";
            this.rtbWeights.Size = new System.Drawing.Size(874, 417);
            this.rtbWeights.TabIndex = 0;
            this.rtbWeights.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 694);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "SCMA-21 Multi-Layer Perceptron (MLP) (Ass011)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tp_dataset.ResumeLayout(false);
            this.tp_dataset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataset)).EndInit();
            this.tp_MLP.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.gb_hiddenLayer.ResumeLayout(false);
            this.gb_hiddenLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNeurons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLayers)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tp_NN.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel1.PerformLayout();
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NNTrainConfusion)).EndInit();
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel1.PerformLayout();
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NNTestConfusion)).EndInit();
            this.tp_GA.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            this.splitContainer14.Panel1.ResumeLayout(false);
            this.splitContainer14.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).EndInit();
            this.splitContainer14.ResumeLayout(false);
            this.splitContainer15.Panel1.ResumeLayout(false);
            this.splitContainer15.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).EndInit();
            this.splitContainer15.ResumeLayout(false);
            this.splitContainer16.Panel1.ResumeLayout(false);
            this.splitContainer16.Panel1.PerformLayout();
            this.splitContainer16.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).EndInit();
            this.splitContainer16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GATrainConfusion)).EndInit();
            this.splitContainer17.Panel1.ResumeLayout(false);
            this.splitContainer17.Panel1.PerformLayout();
            this.splitContainer17.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).EndInit();
            this.splitContainer17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GATestConfusion)).EndInit();
            this.tp_PSO.ResumeLayout(false);
            this.splitContainer18.Panel1.ResumeLayout(false);
            this.splitContainer18.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer18)).EndInit();
            this.splitContainer18.ResumeLayout(false);
            this.splitContainer19.Panel1.ResumeLayout(false);
            this.splitContainer19.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer19)).EndInit();
            this.splitContainer19.ResumeLayout(false);
            this.splitContainer20.Panel1.ResumeLayout(false);
            this.splitContainer20.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).EndInit();
            this.splitContainer20.ResumeLayout(false);
            this.splitContainer21.Panel1.ResumeLayout(false);
            this.splitContainer21.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer21)).EndInit();
            this.splitContainer21.ResumeLayout(false);
            this.splitContainer22.Panel1.ResumeLayout(false);
            this.splitContainer22.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer22)).EndInit();
            this.splitContainer22.ResumeLayout(false);
            this.splitContainer23.Panel1.ResumeLayout(false);
            this.splitContainer23.Panel1.PerformLayout();
            this.splitContainer23.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer23)).EndInit();
            this.splitContainer23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PSOTrainConfusion)).EndInit();
            this.splitContainer24.Panel1.ResumeLayout(false);
            this.splitContainer24.Panel1.PerformLayout();
            this.splitContainer24.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer24)).EndInit();
            this.splitContainer24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PSOTestConfusion)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtOptResult)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tpWeight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid prg_NN;
        private System.Windows.Forms.Button btn_TrainToEndNN;
        private System.Windows.Forms.Button btn_TrainAnEpochNN;
        private System.Windows.Forms.Button btn_ResetNN;
        private System.Windows.Forms.ListBox lsbLayers;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtOptResult;
        private System.Windows.Forms.NumericUpDown numUDNeurons;
        private System.Windows.Forms.NumericUpDown numUDLayers;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument MLPPrintDoc;
        private System.Windows.Forms.Label lb_NNTestAcc;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_NN;
        private System.Windows.Forms.DataGridView dgv_NNTestConfusion;
        private System.Windows.Forms.GroupBox gb_hiddenLayer;
        private System.Windows.Forms.Label lb_weights;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lb_NNTrainAcc;
        private System.Windows.Forms.DataGridView dgv_NNTrainConfusion;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tp_dataset;
        private System.Windows.Forms.Label lb_outputD;
        private System.Windows.Forms.Label lb_inputD;
        private System.Windows.Forms.Label lb_sampleSize;
        private System.Windows.Forms.Label lb_dataset;
        private System.Windows.Forms.DataGridView dgv_dataset;
        private System.Windows.Forms.Button btn_loadADataset;
        private System.Windows.Forms.TabPage tp_MLP;
        private System.Windows.Forms.Label lb_NNTrainRMSE;
        private System.Windows.Forms.Label lb_NNTestRMSE;
        private System.Windows.Forms.TabPage tp_GA;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer12;
        private System.Windows.Forms.SplitContainer splitContainer13;
        private System.Windows.Forms.Button btn_ResetGA;
        private System.Windows.Forms.SplitContainer splitContainer14;
        private System.Windows.Forms.Button btn_runOneIterationGA;
        private System.Windows.Forms.Button btn_runToEndGA;
        private System.Windows.Forms.PropertyGrid prg_GA;
        private System.Windows.Forms.SplitContainer splitContainer15;
        private System.Windows.Forms.SplitContainer splitContainer16;
        private System.Windows.Forms.Label lb_GATrainRMSE;
        private System.Windows.Forms.Label lb_GATrainAcc;
        private System.Windows.Forms.DataGridView dgv_GATrainConfusion;
        private System.Windows.Forms.SplitContainer splitContainer17;
        private System.Windows.Forms.Label lb_GATestAcc;
        private System.Windows.Forms.Label lb_GATestRMSE;
        private System.Windows.Forms.DataGridView dgv_GATestConfusion;
        private System.Windows.Forms.TabPage tp_PSO;
        private System.Windows.Forms.SplitContainer splitContainer18;
        private System.Windows.Forms.SplitContainer splitContainer19;
        private System.Windows.Forms.SplitContainer splitContainer20;
        private System.Windows.Forms.Button btn_ResetPSO;
        private System.Windows.Forms.SplitContainer splitContainer21;
        private System.Windows.Forms.Button btn_runOneIterationPSO;
        private System.Windows.Forms.Button btn_runToEndPSO;
        private System.Windows.Forms.PropertyGrid prg_PSO;
        private System.Windows.Forms.SplitContainer splitContainer22;
        private System.Windows.Forms.SplitContainer splitContainer23;
        private System.Windows.Forms.Label lb_PSOTrainRMSE;
        private System.Windows.Forms.Label lb_PSOTrainAcc;
        private System.Windows.Forms.DataGridView dgv_PSOTrainConfusion;
        private System.Windows.Forms.SplitContainer splitContainer24;
        private System.Windows.Forms.Label lb_PSOTestAcc;
        private System.Windows.Forms.Label lb_PSOTestRMSE;
        private System.Windows.Forms.DataGridView dgv_PSOTestConfusion;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tpNNStructure;
        private System.Windows.Forms.TabPage tpWeight;
        private System.Windows.Forms.RichTextBox rtbWeights;
    }
}

