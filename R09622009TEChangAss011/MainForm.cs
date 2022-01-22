using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TEChangGALibrary;
using PSOLibrary;

namespace R09622009TEChangAss011
{
    public partial class MainForm : Form
    {
       
        BackPropagationMLP MLP;
        RealNumberEncodedGA GA;
        ParticleSwarmOptimizer PSO;

        double[] lowerBounds;
        double[] upperBounds;
        double[][][] w_GA;
        double[][][] w_PSO;
        StringBuilder sb;

        public MainForm()
        {
            InitializeComponent();

            // Initialize the user interface items
            sb = new StringBuilder();
            lsbLayers.SelectedIndex = 0;
            numUDLayers.Maximum = 10;
            numUDLayers.Minimum = 1;
            numUDLayers.Value = lsbLayers.Items.Count;
            numUDNeurons.Maximum = 100;
            numUDNeurons.Minimum = 1;
            numUDNeurons.Value = int.Parse(lsbLayers.SelectedItem.ToString());

            btn_ResetNN.Enabled = btn_TrainAnEpochNN.Enabled
                               = btn_TrainToEndNN.Enabled
                               = btn_ResetGA.Enabled
                               = btn_runOneIterationGA.Enabled
                               = btn_runToEndGA.Enabled
                               = btn_ResetPSO.Enabled
                               = btn_runOneIterationPSO.Enabled
                               = btn_runToEndPSO.Enabled
                               = false;

            chtOptResult.Legends[0].Enabled = false;
        }

        #region INITIALIZATIONS
        public void InitializeMLP()
        {
            MLP = new BackPropagationMLP();
            prg_NN.SelectedObject = MLP;
            MLP.AfterReset += AfterReset;
            MLP.AfterRunOneEpoch += AfterRunOneEpoch;
            MLP.ParameterChanged += ParameterChangedNN;
        }

        public void InitializeGA()
        {
            int numberOfWeights = CalculateNumberOfWeight();
            lowerBounds = new double[numberOfWeights];
            upperBounds = new double[numberOfWeights];

            for (int i = 0; i < numberOfWeights; i++)
            {
                lowerBounds[i] = -10;
                upperBounds[i] = 10;
            }

            GA = new RealNumberEncodedGA(numberOfWeights, lowerBounds, upperBounds, TEChangGALibrary.OptimizationType.Minimization, GetTrainErrorValueForGA);
            
            prg_GA.SelectedObject = GA;
            GA.AfterReset += AfterReset;
            GA.AfterRunOneIteration += AfterRunOneIterationGA;
            GA.ParameterChanged += ParameterChangedGA;
        }

        public void InitializePSO()
        {
            int numberOfWeights = CalculateNumberOfWeight();
            lowerBounds = new double[numberOfWeights];
            upperBounds = new double[numberOfWeights];

            for (int i = 0; i < numberOfWeights; i++)
            {
                lowerBounds[i] = -10;
                upperBounds[i] = 10;
            }

            PSO = new ParticleSwarmOptimizer(numberOfWeights, lowerBounds, upperBounds, PSOLibrary.OptimizationType.Minimization, GetTrainErrorValueForPSO);

            prg_PSO.SelectedObject = PSO;
            PSO.AfterReset += AfterReset;
            PSO.AfterRunOneIteration += AfterRunOneIterationPSO;
            PSO.ParameterChanged += ParameterChangedPSO;
        }
        #endregion

        #region OPERATION EVENTS
        private void AfterReset(object sender, EventArgs e)
        {
            foreach (Series s in chtOptResult.Series) s.Points.Clear();
        }
        private void AfterRunOneEpoch(object sender, EventArgs e)
        {
            chtOptResult.Series[0].Points.AddXY(MLP.EpochID, MLP.TrainRMSE);
            chtOptResult.Series[1].Points.AddXY(MLP.EpochID, MLP.TestRMSE);

            chtOptResult.Update();

            if (MLP.EpochID == MLP.EpochLimit)
            {
                btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
                btn_ResetNN.BackColor = Color.Cornsilk;
                btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = SystemColors.Control;
            }

            if (btn_runOneIterationGA.Enabled)
            {
                btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
                btn_ResetGA.BackColor = Color.Cornsilk;
                btn_runToEndGA.BackColor = btn_runToEndGA.BackColor = SystemColors.Control;
            }

            if (btn_runOneIterationPSO.Enabled)
            {
                btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;
                btn_ResetPSO.BackColor = Color.Cornsilk;
                btn_runToEndPSO.BackColor = btn_runToEndPSO.BackColor = SystemColors.Control;
            }
        }
        private void AfterRunOneIterationGA(object sender, EventArgs e)
        {
            chtOptResult.Series[0].Points.AddXY(GA.IterationID, GetTrainErrorValueForGA(GA.SoFarTheBestSolution));
            chtOptResult.Series[1].Points.AddXY(GA.IterationID, GetTestErrorValueForGA(GA.SoFarTheBestSolution));

            chtOptResult.Update();
            //splitContainer2.Panel2.Update();

            if (GA.IterationID == GA.MaxIteration)
            {
                btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
                btn_ResetGA.BackColor = Color.Cornsilk;
                btn_runOneIterationGA.BackColor = btn_runToEndGA.BackColor = SystemColors.Control;
            }

            if (btn_TrainAnEpochNN.Enabled)
            {
                btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
                btn_ResetNN.BackColor = Color.Cornsilk;
                btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = SystemColors.Control;
            }

            if (btn_runOneIterationPSO.Enabled)
            {
                btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;
                btn_ResetPSO.BackColor = Color.Cornsilk;
                btn_runToEndPSO.BackColor = btn_runToEndPSO.BackColor = SystemColors.Control;
            }
        }
        private void AfterRunOneIterationPSO(object sender, EventArgs e)
        {
            chtOptResult.Series[0].Points.AddXY(PSO.IterationID, GetTrainErrorValueForPSO(PSO.SoFarTheBestPosition));
            chtOptResult.Series[1].Points.AddXY(PSO.IterationID, GetTestErrorValueForPSO(PSO.SoFarTheBestPosition));

            chtOptResult.Update();
            //splitContainer2.Panel2.Update();

            if (PSO.IterationID == PSO.IterationLimit)
            {
                btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;
                btn_ResetPSO.BackColor = Color.Cornsilk;
                btn_runOneIterationPSO.BackColor = btn_runToEndPSO.BackColor = SystemColors.Control;
            }

            if (btn_TrainAnEpochNN.Enabled)
            {
                btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
                btn_ResetNN.BackColor = Color.Cornsilk;
                btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = SystemColors.Control;
            }

            if (btn_runOneIterationGA.Enabled)
            {
                btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
                btn_ResetGA.BackColor = Color.Cornsilk;
                btn_runToEndGA.BackColor = btn_runToEndGA.BackColor = SystemColors.Control;
            }
        }

        public void ParameterChangedNN(object sender, EventArgs e)
        {
            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
            btn_ResetNN.BackColor = Color.Cornsilk;
            btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = SystemColors.Control;
        }
        public void ParameterChangedGA(object sender, EventArgs e)
        {
            btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
            btn_ResetGA.BackColor = Color.Cornsilk;
            btn_runToEndGA.BackColor = btn_runToEndGA.BackColor = SystemColors.Control;
        }
        public void ParameterChangedPSO(object sender, EventArgs e)
        {
            btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;
            btn_ResetPSO.BackColor = Color.Cornsilk;
            btn_runOneIterationPSO.BackColor = btn_runToEndPSO.BackColor = SystemColors.Control;
        }
        #endregion



        #region CLICK EVENTS
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (MLP == null)
                {
                    InitializeMLP();
                }

                MLP.ReadInDataSet(dlg.FileName);
                // UI
                chtOptResult.Legends[0].Enabled = true;
                lb_weights.Text = $"Number of weights : {CalculateNumberOfWeight()}";
                btn_ResetNN.Enabled = btn_ResetGA.Enabled = btn_ResetPSO.Enabled = true;
                btn_ResetNN.BackColor = btn_ResetGA.BackColor = btn_ResetPSO.BackColor = Color.Cornsilk;

                lb_dataset.Text = "Dataset : " + Path.GetFileName(dlg.FileName);
                lb_sampleSize.Text = $"Number of data : {MLP.NumberOfData}";
                lb_inputD.Text = $"Input dimension : {MLP.InputDimension}";
                lb_outputD.Text = $"Output dimension : {MLP.TargetDimension}";

                dgv_dataset.Columns.Clear();
                dgv_dataset.Rows.Clear();
                dgv_dataset.Columns.Add($"ID", $"ID");
                for (int i = 0; i < MLP.InputDimension; i++)
                {
                    dgv_dataset.Columns.Add($"x{i}", $"x{i}");
                }
                for (int i = 0; i < MLP.TargetDimension; i++)
                {
                    dgv_dataset.Columns.Add($"y{i}", $"y{i}");
                }

                for (int i = 0; i < MLP.NumberOfData; i++) // i for number of rows
                {
                    dgv_dataset.Rows.Add();
                    dgv_dataset.Rows[i].Cells[0].Value = $"{i + 1}";
                    for (int j = 0; j < MLP.InputDimension; j++)
                    {
                        dgv_dataset.Rows[i].Cells[j + 1].Value = MLP.OriginalInputs[i, j];
                    }
                    for (int j = 0; j < MLP.TargetDimension; j++)
                    {
                        dgv_dataset.Rows[i].Cells[j + MLP.InputDimension + 1].Value = MLP.OriginalTargets[i, j];
                    }
                }

                ResetUI();

            }
        }

        public void ResetUI()
        {
            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled
                                      = btn_runOneIterationGA.Enabled
                                      = btn_runToEndGA.Enabled
                                      = btn_runOneIterationPSO.Enabled
                                      = btn_runToEndPSO.Enabled
                                      = false;

            lb_NNTrainRMSE.Text = "Training RMSE :";
            lb_NNTestRMSE.Text = "Testing RMSE :";
            lb_NNTrainAcc.Text = "Training accuracy :";
            lb_NNTestAcc.Text = "Training accuracy :";
            dgv_NNTrainConfusion.Columns.Clear();
            dgv_NNTrainConfusion.Rows.Clear();
            dgv_NNTestConfusion.Columns.Clear();
            dgv_NNTestConfusion.Rows.Clear();

            w_GA = null;
            lb_GATrainRMSE.Text = "Training RMSE :";
            lb_GATestRMSE.Text = "Testing RMSE :";
            lb_GATrainAcc.Text = "Training accuracy :";
            lb_GATestAcc.Text = "Training accuracy :";
            dgv_GATrainConfusion.Columns.Clear();
            dgv_GATrainConfusion.Rows.Clear();
            dgv_GATestConfusion.Columns.Clear();
            dgv_GATestConfusion.Rows.Clear();

            w_PSO = null;
            lb_PSOTrainRMSE.Text = "Training RMSE :";
            lb_PSOTestRMSE.Text = "Testing RMSE :";
            lb_PSOTrainAcc.Text = "Training accuracy :";
            lb_PSOTestAcc.Text = "Training accuracy :";
            dgv_PSOTrainConfusion.Columns.Clear();
            dgv_PSOTrainConfusion.Rows.Clear();
            dgv_PSOTestConfusion.Columns.Clear();
            dgv_PSOTestConfusion.Rows.Clear();

            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
            btn_ResetNN.BackColor = Color.Cornsilk;
            btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = SystemColors.Control;

            btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
            btn_ResetGA.BackColor = Color.Cornsilk;
            btn_runToEndGA.BackColor = btn_runToEndGA.BackColor = SystemColors.Control;

            btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;
            btn_ResetPSO.BackColor = Color.Cornsilk;
            btn_runOneIterationPSO.BackColor = btn_runToEndPSO.BackColor = SystemColors.Control;

        }

        private void btnResetNN_Click(object sender, EventArgs e)
        {
            int[] hiddenNeurons = new int[lsbLayers.Items.Count];
            for (int i = 0; i < hiddenNeurons.Length; i++)
            {
                hiddenNeurons[i] = int.Parse(lsbLayers.Items[i].ToString());
            }
            MLP.ResetWeightsAndInitialCondition(hiddenNeurons);
            ShowWeights();

            btn_ResetNN.BackColor = SystemColors.Control;
            btn_TrainAnEpochNN.BackColor = btn_TrainToEndNN.BackColor = Color.Cornsilk;
            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = true;

            lb_NNTrainRMSE.Text = "Training RMSE :";
            lb_NNTestRMSE.Text = "Testing RMSE :";
            lb_NNTrainAcc.Text = "Training accuracy :";
            lb_NNTestAcc.Text = "Training accuracy :";
            dgv_NNTrainConfusion.Columns.Clear();
            dgv_NNTrainConfusion.Rows.Clear();
            dgv_NNTestConfusion.Columns.Clear();
            dgv_NNTestConfusion.Rows.Clear();

            splitContainer2.Panel2.Refresh();
        }

        private void btn_ResetGA_Click(object sender, EventArgs e)
        {
            if (w_GA == null | GA == null)
            {
                int[] hiddenNeurons = new int[lsbLayers.Items.Count];
                for (int i = 0; i < hiddenNeurons.Length; i++)
                {
                    hiddenNeurons[i] = int.Parse(lsbLayers.Items[i].ToString());
                }
                MLP.ResetWeightsAndInitialCondition(hiddenNeurons);

                InitializeGA();
            }

            w_GA = new double[MLP.NumberOfLayers][][];
            for (int l = 0; l < MLP.NumberOfLayers; l++)
            {
                if (l > 0)
                {
                    w_GA[l] = new double[MLP.N[l]][];
                    for (int k = 1; k < MLP.N[l]; k++)
                    {
                        w_GA[l][k] = new double[MLP.N[l - 1]];
                    }
                }
            }
            GA.Reset();
            ShowWeights();

            btn_ResetGA.BackColor = SystemColors.Control;
            btn_runOneIterationGA.BackColor = btn_runToEndGA.BackColor = Color.Cornsilk;
            btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = true;

            lb_GATrainRMSE.Text = "Training RMSE :";
            lb_GATestRMSE.Text = "Testing RMSE :";
            lb_GATrainAcc.Text = "Training accuracy :";
            lb_GATestAcc.Text = "Training accuracy :";
            dgv_GATrainConfusion.Columns.Clear();
            dgv_GATrainConfusion.Rows.Clear();
            dgv_GATestConfusion.Columns.Clear();
            dgv_GATestConfusion.Rows.Clear();
            splitContainer2.Panel2.Refresh();
        }

        private void btn_ResetPSO_Click(object sender, EventArgs e)
        {
            if (w_PSO == null | PSO == null)
            {
                int[] hiddenNeurons = new int[lsbLayers.Items.Count];
                for (int i = 0; i < hiddenNeurons.Length; i++)
                {
                    hiddenNeurons[i] = int.Parse(lsbLayers.Items[i].ToString());
                }
                MLP.ResetWeightsAndInitialCondition(hiddenNeurons);

                InitializePSO();
            }

            w_PSO = new double[MLP.NumberOfLayers][][];
            for (int l = 0; l < MLP.NumberOfLayers; l++)
            {
                if (l > 0)
                {
                    w_PSO[l] = new double[MLP.N[l]][];
                    for (int k = 1; k < MLP.N[l]; k++)
                    {
                        w_PSO[l][k] = new double[MLP.N[l - 1]];
                    }
                }
            }
            PSO.Reset();
            ShowWeights();

            btn_ResetPSO.BackColor = SystemColors.Control;
            btn_runOneIterationPSO.BackColor = btn_runToEndPSO.BackColor = Color.Cornsilk;
            btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = true;

            lb_PSOTrainRMSE.Text = "Training RMSE :";
            lb_PSOTestRMSE.Text = "Testing RMSE :";
            lb_PSOTrainAcc.Text = "Training accuracy :";
            lb_PSOTestAcc.Text = "Training accuracy :";
            dgv_PSOTrainConfusion.Columns.Clear();
            dgv_PSOTrainConfusion.Rows.Clear();
            dgv_PSOTestConfusion.Columns.Clear();
            dgv_PSOTestConfusion.Rows.Clear();
            splitContainer2.Panel2.Refresh();
        }



        private void btnNNTrainAnEpoch_Click(object sender, EventArgs e)
        {
            MLP.TrainAnEpoch();
        }

        private void btn_runOneIterationGA_Click(object sender, EventArgs e)
        {
            GA.RunOneIteration();
        }
        private void btn_runOneIterationPSO_Click(object sender, EventArgs e)
        {
            PSO.RunOneIteration();
        }


        private void btnNNTrainToEnd_Click(object sender, EventArgs e)
        {
            MLP.TrainToEnd();
            tpNNStructure.Refresh();
            ShowWeights();

            int[,] confusionMatrix;
            double accuracy;

            // Display the results
            // Training
            accuracy = MLP.TrainingClassification(MLP.W, out confusionMatrix);
            lb_NNTrainAcc.Text = $"Training accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTrainingData, 3)} ({accuracy}/{MLP.NumberOfTrainingData})";
            lb_NNTrainRMSE.Text = $"Training RMSE : {Math.Round(MLP.TrainRMSE, 3)}";
            dgv_NNTrainConfusion.Columns.Clear();
            dgv_NNTrainConfusion.Rows.Clear();
            dgv_NNTrainConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_NNTrainConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_NNTrainConfusion.Rows.Add();
                dgv_NNTrainConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_NNTrainConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }


            // Testing
            accuracy = MLP.TestingClassification(MLP.W, out confusionMatrix);
            lb_NNTestAcc.Text = $"Testing accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTestingData, 3)} ({accuracy}/{MLP.NumberOfTestingData})";
            lb_NNTestRMSE.Text = $"Testing RMSE : {Math.Round(MLP.TestRMSE, 3)}";
            dgv_NNTestConfusion.Columns.Clear();
            dgv_NNTestConfusion.Rows.Clear();
            dgv_NNTestConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_NNTestConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_NNTestConfusion.Rows.Add();
                dgv_NNTestConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_NNTestConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }

            MessageBox.Show("The execution of back propagation of MLP is completed!", "Multi-Layer Perceptron (MLP)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_runToEndGA_Click(object sender, EventArgs e)
        {
            GA.RunToEnd();
            tpNNStructure.Refresh();
            ShowWeights();

            int[,] confusionMatrix;
            double accuracy;
            updateWeightsForGA(GA.SoFarTheBestSolution);

            // Display the results
            // Training
            accuracy = MLP.TrainingClassification(w_GA, out confusionMatrix);
            lb_GATrainAcc.Text = $"Training accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTrainingData, 3)} ({accuracy}/{MLP.NumberOfTrainingData})";
            lb_GATrainRMSE.Text = $"Training RMSE : {Math.Round(GetTrainErrorValueForGA(GA.SoFarTheBestSolution), 3)}";
            dgv_GATrainConfusion.Columns.Clear();
            dgv_GATrainConfusion.Rows.Clear();
            dgv_GATrainConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_GATrainConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_GATrainConfusion.Rows.Add();
                dgv_GATrainConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_GATrainConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }


            // Testing
            accuracy = MLP.TestingClassification(w_GA, out confusionMatrix);
            lb_GATestAcc.Text = $"Testing accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTestingData, 3)} ({accuracy}/{MLP.NumberOfTestingData})";
            lb_GATestRMSE.Text = $"Testing RMSE : {Math.Round(GetTestErrorValueForGA(GA.SoFarTheBestSolution), 3)}";
            dgv_GATestConfusion.Columns.Clear();
            dgv_GATestConfusion.Rows.Clear();
            dgv_GATestConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_GATestConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_GATestConfusion.Rows.Add();
                dgv_GATestConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_GATestConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }

            MessageBox.Show("The execution of genetic algorithm solver is completed!", "Genetic Algorithm (GA)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_runToEndPSO_Click(object sender, EventArgs e)
        {
            PSO.RunToEnd();
            tpNNStructure.Refresh();
            ShowWeights();

            int[,] confusionMatrix;
            double accuracy;
            updateWeightsForPSO(PSO.SoFarTheBestPosition);

            // Display the results
            // Training
            accuracy = MLP.TrainingClassification(w_PSO, out confusionMatrix);
            lb_PSOTrainAcc.Text = $"Training accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTrainingData, 3)} ({accuracy}/{MLP.NumberOfTrainingData})";
            lb_PSOTrainRMSE.Text = $"Training RMSE : {Math.Round(GetTrainErrorValueForPSO(PSO.SoFarTheBestPosition), 3)}";
            dgv_PSOTrainConfusion.Columns.Clear();
            dgv_PSOTrainConfusion.Rows.Clear();
            dgv_PSOTrainConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_PSOTrainConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_PSOTrainConfusion.Rows.Add();
                dgv_PSOTrainConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_PSOTrainConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }


            // Testing
            accuracy = MLP.TestingClassification(w_PSO, out confusionMatrix);
            lb_PSOTestAcc.Text = $"Testing accuracy : {Math.Round(((double)accuracy) / MLP.NumberOfTestingData, 3)} ({accuracy}/{MLP.NumberOfTestingData})";
            lb_PSOTestRMSE.Text = $"Testing RMSE : {Math.Round(GetTestErrorValueForPSO(PSO.SoFarTheBestPosition), 3)}";
            dgv_PSOTestConfusion.Columns.Clear();
            dgv_PSOTestConfusion.Rows.Clear();
            dgv_PSOTestConfusion.Columns.Add("True / \n Predicted", "True / \nPredicted");
            for (int i = 0; i < MLP.TargetDimension; i++)
            {
                dgv_PSOTestConfusion.Columns.Add($"Class{i + 1}", $"Class{i + 1}");
            }

            for (int i = 0; i < MLP.TargetDimension; i++) // i for number of rows
            {
                dgv_PSOTestConfusion.Rows.Add();
                dgv_PSOTestConfusion.Rows[i].Cells[0].Value = $"Class{i + 1}";
                for (int j = 0; j < MLP.TargetDimension; j++) // j for number of columns
                {
                    dgv_PSOTestConfusion.Rows[i].Cells[j + 1].Value = confusionMatrix[i, j];
                }
            }


            MessageBox.Show("The execution of particle swarm solver is completed!", "Particle Swarm Optimization (PSO)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void numUDLayers_ValueChanged(object sender, EventArgs e)
        {
            if (numUDLayers.Value > lsbLayers.Items.Count)
            {
                lsbLayers.Items.Add(4);
            }
            else if (numUDLayers.Value < lsbLayers.Items.Count)
            {
                int selectedIndex = lsbLayers.SelectedIndex;
                lsbLayers.Items.RemoveAt(lsbLayers.Items.Count - 1);
                if (lsbLayers.SelectedIndex == -1)
                {
                    lsbLayers.SelectedIndex = selectedIndex;
                }
            }
            w_GA = w_PSO = null;
            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
            btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
            btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;

            if (MLP != null) lb_weights.Text = $"Number of weights : {CalculateNumberOfWeight()}";
        }
        private void lsbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbLayers.SelectedIndex != -1)
                numUDNeurons.Value = int.Parse(lsbLayers.SelectedItem.ToString());
        }
        private void numUDNeurons_ValueChanged(object sender, EventArgs e)
        {
            int selectedIndex = lsbLayers.SelectedIndex;
            lsbLayers.Items[lsbLayers.SelectedIndex] = numUDNeurons.Value;
            lsbLayers.SelectedIndex = selectedIndex;

            w_GA = w_PSO = null;
            btn_TrainAnEpochNN.Enabled = btn_TrainToEndNN.Enabled = false;
            btn_runOneIterationGA.Enabled = btn_runToEndGA.Enabled = false;
            btn_runOneIterationPSO.Enabled = btn_runToEndPSO.Enabled = false;

            if (MLP != null) lb_weights.Text = $"Number of weights : {CalculateNumberOfWeight()}";
        }
        #endregion



        #region HELPING FUNCTIONS
        public int CalculateNumberOfWeight()
        {
            int totalWeights = 0;
            int[] hiddenNeurons = new int[lsbLayers.Items.Count];
            for (int i = 0; i < hiddenNeurons.Length; i++)
            {
                hiddenNeurons[i] = int.Parse(lsbLayers.Items[i].ToString());
            }

            for (int i = 0; i < hiddenNeurons.Length; i++)
            {
                if (i == 0) totalWeights += hiddenNeurons[i] * (MLP.InputDimension + 1);
                else totalWeights += hiddenNeurons[i] * (hiddenNeurons[i - 1] + 1);
            }
            totalWeights += (hiddenNeurons[hiddenNeurons.Length - 1] + 1) * MLP.TargetDimension;

            return totalWeights;
        }

        public void updateWeightsForGA(double[] aSolution)
        {
            int j = 0;
            for (int l = 1; l < w_GA.Length; l++)
            {
                for (int k = 1; k < w_GA[l].Length; k++)
                {
                    for (int i = 0; i < w_GA[l][k].Length; i++)
                    {
                        w_GA[l][k][i] = aSolution[j];
                        j++;
                    }
                }
            }
        }

        public void updateWeightsForPSO(double[] aSolution)
        {
            int j = 0;
            for (int l = 1; l < w_PSO.Length; l++)
            {
                for (int k = 1; k < w_PSO[l].Length; k++)
                {
                    for (int i = 0; i < w_PSO[l][k].Length; i++)
                    {
                        w_PSO[l][k][i] = aSolution[j];
                        j++;
                    }
                }
            }
        }

        public double GetTrainErrorValueForGA(double[] aSolution)
        {
            updateWeightsForGA(aSolution);
            return MLP.ComputRMSE(w_GA);
        }

        public double GetTestErrorValueForGA(double[] aSolution)
        {
            updateWeightsForGA(aSolution);
            return MLP.ComputRMSE(w_GA, false);
        }

        public double GetTrainErrorValueForPSO(double[] aSolution)
        {
            updateWeightsForPSO(aSolution);
            return MLP.ComputRMSE(w_PSO);
        }

        public double GetTestErrorValueForPSO(double[] aSolution)
        {
            updateWeightsForPSO(aSolution);
            return MLP.ComputRMSE(w_PSO, false);
        }
        #endregion

        public void ShowWeights()
        {
            sb.Clear();
            for (int l = 1; l < MLP.W.Length; l++)
            {
                sb.Append($"{MLP.W[l].Length - 1}\n");
                for (int k = 1; k < MLP.W[l].Length; k++)
                {
                    for (int i = 0; i < MLP.W[l][k].Length; i++)
                    {
                        sb.Append($"{Math.Round(MLP.W[l][k][i], 3)} "); 
                    }
                    sb.Append("\n");
                }
            }
            rtbWeights.Text = sb.ToString();
        }






        private void button1_Click(object sender, EventArgs e)
        {
            drawGraphics(splitContainer2.Panel2.CreateGraphics(), splitContainer2.Panel2.ClientRectangle);
            //drawGraphics(button1.CreateGraphics(), button1.ClientRectangle);
            drawGraphics(prg_NN.CreateGraphics(), prg_NN.ClientRectangle);
            drawGraphics(lsbLayers.CreateGraphics(), lsbLayers.ClientRectangle);
        }
        void drawGraphics(Graphics g, Rectangle bounds)
        {
            //Graphics g = splitContainer2.Panel2.CreateGraphics();
            Rectangle rect = new Rectangle(10, 10, bounds.Width / 2, bounds.Height / 2);
            Point p1 = new Point(10, 10);
            Point p2 = new Point(100, 50);
           
            g.FillEllipse(Brushes.Gold, rect);
            g.DrawEllipse(Pens.Red, rect);

            Pen pen = new Pen(Color.Cornsilk, bounds.Height / 20.0f);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawRectangle(Pens.Maroon, rect);
            g.DrawLine(pen, p1, p2);

            Font font = new Font("Arial", bounds.Height / 10.0f);

            g.DrawString("NTUGIIE", this.Font, Brushes.Green, 10, 10);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;      // horizontal wise
            sf.LineAlignment = StringAlignment.Center;  // vertical wise
            g.DrawString("Taiwan", font, Brushes.Black, rect, sf);
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (MLP != null)
            {
                MLP.DrawMLP(e.Graphics, e.ClipRectangle);
            }
        }

        private void MLPPrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            MLP.DrawMLP(e.Graphics, e.PageBounds);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = MLPPrintDoc;
            dlg.ShowDialog();
        }


    }
}
