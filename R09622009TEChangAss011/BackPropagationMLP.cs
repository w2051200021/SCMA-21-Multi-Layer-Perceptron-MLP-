using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss011
{
    class BackPropagationMLP
    {
        #region DATAFIELDS
        int seed = 2;      // A random seed
        Random randomizer; // A randomizer
        
        double[][] x;     // neuron values 
        double[][][] w;   // weights 
        double[][][] dw;  // Record the updated value of w for momentum term
        double[][] e;     // epsilon; partial derivative of error with respect to net value. 
        double wMin;
        double wMax;

        int[] n;              // numbers of neuron on each layer 
        int numberOfLayers;   // number of neuron layers (including the input layer) 
        int numberOfData;   // number of instances on the data set 
        int numberOfTrainingData;  // number of instances that are serving as training data 
        int numberOfTestingData;
        
        int inputDimension;        // dimension of input vector 
        double[,] originalInputs;   // original instances of input vectors (without normalization) 
        double[,] inputs;           // normalized input vectors 
        double[] inputMax;          // upper bounds on all components of input vectors 
        double[] inputMin;          // lower bounds on all components of input vectors 
        int inputWidth;            // dimension in width for a "two-dimensional" input vector 

        int targetDimension;       // dimension of target vector 
        double[,] originalTargets;  // original instances of target vectors (without normalization) 
        double[,] targets;          // normalized target vectors 
        double[] targetMax;         // upper bounds on all components of target vectors 
        double[] targetMin;         // lower bounds on all components of target vectors. 

        int[] dataIndices;     // array of shuffled indices of data instances; the front portion is training vectors; 
                               // the rear portion is testing vectors 

        bool useMomentum = false;      // Use momentum term or not
        double momentumFactor = 0.2;  // Factor of momentum term

        double trainingRatio = 0.7;   // The portion of training data in the whole data
        double learningRate = 0.999;  // learning rate, specified by the user 
        double eta;                    // step size that specify the update amount on each weight 
        double initialEta = 0.5;      // initial step size, specified by the user 

        int epochID;             // Current epoch ID
        int epochLimit = 500;    // Limit of number of epochs

        double trainRMSE = 0.0;   // root mean squared error for an epoch of data training 
        double testRMSE = 0.0;

        int[,] confusionMatrix; // The table used to express the classification results

        ActivationFunction activation = ActivationFunction.Sigmoid;
        #endregion

        #region PROPERTIES
        [
            Description("The factor of reducing the eta epoch by epoch."),
            Category("Training Parameters")
        ]
        /// <summary> 
        /// The factor of reducing the eta epoch by epoch. That is 
        /// eta <-- LearningRate * eta 
        /// </summary> 
        public double LearningRate
        {
            get => learningRate; 
            set 
            {
                if (value > 0)
                {
                    learningRate = value;
                    OnParameterChanged();
                }
            }
        }

        [
            Description("Initialial value of the step size."),
            Category("Training Parameters")
        ]
        /// <summary> 
        /// Initialize variable of the eta (can be regarded as step size). 
        /// </summary> 
        public double InitialEta
        {
            get => initialEta;
            set
            {
                if (value > 0)
                {
                    initialEta = value;
                    OnParameterChanged();
                }
            }
            
        }

        [
            Description("The portion of dataset used for training."),
            Category("Training Parameters")
        ]
        public double TrainingRatio
        {
            get => trainingRatio;
            set
            {
                if (value > 0.5 & value < 0.95)
                {
                    trainingRatio = value;
                    OnParameterChanged();
                }
            }
        }
        [
            Description("Random seed for the randomizer."),
            Category("Training Parameters")
        ]
        public int Seed
        {
            get => seed;
            set
            {
                if (value > 0 & value < 1000)
                {
                    seed = value;
                    OnParameterChanged();
                }
            }
        }


        [
            Description("The maximal value of trainning epoch."),
            Category("Stopping Criteria")
        ]
        public int EpochLimit 
        { 
            get => epochLimit;
            set
            {
                if (value > 0)
                {
                    epochLimit = value;
                    OnParameterChanged();
                }
            }
        }

        [
            Description("The type of activation function in each neuron."),
            Category("Training Parameters")
        ]
        public ActivationFunction Activation 
        { 
            get => activation; 
            set
            { 
                activation = value;
                OnParameterChanged();
            }
        }

        [
            Description("Whether to use momentum term in training or not."),
            Category("Momentum Term")
        ]
        public bool UseMomentum
        {
            get => useMomentum;
            set 
            {
                useMomentum = value;
                OnParameterChanged();
            }
        }

        [
            Description("The factor of momentum factor. (If momentum term is used)"),
            Category("Momentum Term")
        ]
        public double MomentumFactor 
        { 
            get => momentumFactor;
            set
            {
                if (value >= 0.1 | value <= 1)
                {
                    momentumFactor = value;
                    OnParameterChanged();
                }
            }
        }

        [Browsable(false)]
        public int EpochID { get => epochID; }
        [Browsable(false)]
        public double TrainRMSE { get => trainRMSE; }
        [Browsable(false)]
        public double TestRMSE { get => testRMSE; }
        [Browsable(false)]
        public int NumberOfTrainingData { get => numberOfTrainingData; }
        [Browsable(false)]
        public int NumberOfTestingData { get => numberOfTestingData; }
        [Browsable(false)]
        public int TargetDimension { get => targetDimension; }
        [Browsable(false)]
        public int InputDimension { get => inputDimension; }
        [Browsable(false)]
        public double[,] OriginalInputs { get => originalInputs; }
        [Browsable(false)]
        public double[,] OriginalTargets { get => originalTargets; }
        [Browsable(false)]
        public int NumberOfData { get => numberOfData; }
        [Browsable(false)]
        public double[,] Inputs { get => inputs; }
        [Browsable(false)]
        public double[,] Targets { get => targets; }
        [Browsable(false)]
        public int NumberOfLayers { get => numberOfLayers; }
        [Browsable(false)]
        public int[] N { get => n; }
        [Browsable(false)]
        public double[][][] W { get => w; }

        #endregion



        #region EVENTS
        public event EventHandler AfterReset;

        public event EventHandler AfterRunOneEpoch;

        public event EventHandler SoFarTheBestSolutionUpdated;

        public event EventHandler ParameterChanged;

        public event EventHandler Draw;

        protected void OnAfterReset()
        {
            if (AfterReset != null) AfterReset(this, null);
        }

        protected void OnAfterRunOneEpoch()
        {
            if (AfterRunOneEpoch != null)
            {
                AfterRunOneEpoch(this, null);
            }
        }

        protected void OnSoFarTheBestSolutionUpdated()
        {
            if (SoFarTheBestSolutionUpdated != null) SoFarTheBestSolutionUpdated(this, null);
        }

        protected void OnParameterChanged()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }
        #endregion

        #region HELPING FUNCTIONS
        /// <summary> 
        /// Read in the data set from the given file stream. Configure the portions of training 
        /// and testing data subsets. Original data are stored, bounds on each component of 
        /// input vector and target vector are founds, and normalized data set is prepared. 
        /// </summary> 
        /// <param name="filePath">file path</param> 
        public void ReadInDataSet(string filePath)
        {          
            StreamReader sr = new StreamReader(filePath);
            char[] separators = new char[] { ',', ' ' };
            string s = sr.ReadLine();
            string[] items = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            numberOfData = Convert.ToInt32(items[0]);
            inputDimension = Convert.ToInt32(items[1]);
            targetDimension = Convert.ToInt32(items[2]);
            inputWidth = Convert.ToInt32(items[3]);
            dataIndices = new int[numberOfData];
          
            originalInputs = new double[numberOfData, inputDimension];
            inputs = new double[numberOfData, inputDimension];
            inputMax = new double[inputDimension];
            inputMin = new double[inputDimension];
            
            originalTargets = new double[numberOfData, targetDimension];
            targets = new double[numberOfData, targetDimension];
            targetMax = new double[targetDimension];
            targetMin = new double[targetDimension];

            for (int i = 0; i < inputDimension; i++)
            {
                inputMax[i] = double.MinValue;
                inputMin[i] = double.MaxValue;
            }
            for (int i = 0; i < targetDimension; i++)
            {
                targetMax[i] = double.MinValue;
                targetMin[i] = double.MaxValue;
            }
            for (int r = 0; r < numberOfData; r++)
            {
                s = sr.ReadLine();
                items = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                // Input vector (for normalization)
                for (int c = 0; c < inputDimension; c++)
                {
                    originalInputs[r, c] = double.Parse(items[c]);
                    if (originalInputs[r, c] > inputMax[c]) inputMax[c] = originalInputs[r, c];
                    else if (originalInputs[r, c] < inputMin[c]) inputMin[c] = originalInputs[r, c];
                }
                // Target part (for normalization)
                for (int c = 0; c < targetDimension; c++)
                {
                    originalTargets[r, c] = double.Parse(items[c + inputDimension]);
                    if (originalTargets[r, c] > targetMax[c]) targetMax[c] = originalTargets[r, c];
                    else if (originalTargets[r, c] < targetMin[c]) targetMin[c] = originalTargets[r, c];
                }
            }
            confusionMatrix = new int[targetDimension, targetDimension];
            sr.Close();

            randomizer = new Random(seed);
            // Do linear transformation from original to normalized data
            // Input vectors
            for (int c = 0; c < inputDimension; c++)
            {
                double inputRange = inputMax[c] - inputMin[c];
                for (int r = 0; r < numberOfData; r++)
                {
                    inputs[r, c] = (originalInputs[r, c] - inputMin[c]) / inputRange ;
                }
            }
            // Target vectors
            for (int c = 0; c < targetDimension; c++)
            {
                double targetRange = targetMax[c] - targetMin[c];
                for (int r = 0; r < numberOfData; r++)
                {
                    targets[r, c] = (originalTargets[r, c] - targetMin[c]) / targetRange;
                }
            }
        }


        /// <summary> 
        /// Configure the topology of the NN with the user specified numbers of hidden 
        /// neuorns and layers. 
        /// </summary> 
        /// <param name="hiddenNeuronNumbers">list of numbers of neurons of hidden layers</param> 
        private void ConfigureNeuralNetwork(int[] hiddenNeuronNumbers)
        {
            numberOfLayers = hiddenNeuronNumbers.Length + 2;
            n = new int[numberOfLayers];
            n[0] = inputDimension + 1;
            for (int i = 0; i < hiddenNeuronNumbers.Length; i++) n[i + 1] = hiddenNeuronNumbers[i] + 1;
            n[numberOfLayers - 1] = targetDimension + 1;

            x = new double[numberOfLayers][];
            e = new double[numberOfLayers][];
            w = new double[numberOfLayers][][];

            if (useMomentum) dw = new double[numberOfLayers][][];

            // l -> the l-th layer
            // k -> the k-th neuron in the l-th layer
            // i -> the i-th neuron in th (l - 1)th layer
            for (int l = 0; l < numberOfLayers; l++)
            {
                x[l] = new double[n[l]];
                if (l > 0)
                {
                    // There is no weight and epsilon (partial derivative of E) in the 0-th layer
                    e[l] = new double[n[l]];
                    w[l] = new double[n[l]][];

                    if (useMomentum) dw[l] = new double[n[l]][];

                    // n[l - 1]: the number of neurons in the (l - 1)th layer
                    for (int k = 1; k < n[l]; k++)
                    {
                        w[l][k] = new double[n[l - 1]];
                        if (useMomentum) dw[l][k] = new double[n[l - 1]];
                    }
                }
            }

        }

        public void DrawMLP(Graphics g, Rectangle bounds)
        {
            if (n == null) return;

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0);

            int boxWidth = bounds.Height / 10;
            if (boxWidth < 10) boxWidth = 10;
            
            // Define the box area where we used to place a node
            Rectangle box = new Rectangle(0, 0, boxWidth, boxWidth);

            // Average width for each node
            int w = bounds.Width / n.Length;
            int xOff = w / 2;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font font = new Font("Arial", 10);

            Pen pen = new Pen(Color.Gray, 1);

            Rectangle dot = new Rectangle(0, 0, 5, 5);
            for (int l = 0; l < n.Length; l++)
            {
                int h = bounds.Height / n[l];
                int yOff = h / 2;
                int xx = xOff + w * l;

                for (int k = 0; k < n[l]; k++)
                {
                    int y = yOff + k * h;
                    if (k == 0)
                    {
                        if (l < n.Length - 1)
                        {
                            dot.X = xx - 2;
                            dot.Y = y - 2;
                            g.FillRectangle(Brushes.Red, dot);

                            for (int i = 1; i < n[l + 1]; i++)
                            {
                                p1.X = xx + 2;
                                p1.Y = y + 2;
                                p2.X = p1.X + w;
                                p2.Y = (bounds.Height / n[l + 1]) / 2 + i * (bounds.Height / n[l + 1]);
                                pen.Width = (float)GetLineWidth(this.w[l + 1][i][k]);
                                g.DrawLine(pen, p1, p2);
                            }
                        }
                    }
                    else
                    {
                        if (l < n.Length - 1)
                        {
                            for (int i = 1; i < n[l + 1]; i++)
                            {
                                p1.X = xx + 2;
                                p1.Y = y + 2;
                                p2.X = p1.X + w;
                                p2.Y = (bounds.Height / n[l + 1]) / 2 + i * (bounds.Height / n[l + 1]);
                                pen.Width = (float)GetLineWidth(this.w[l + 1][i][k]);
                                g.DrawLine(pen, p1, p2);
                                
                            }
                        }
                        box.X = xx - boxWidth / 2;
                        box.Y = y - boxWidth / 2;
                        g.FillEllipse(Brushes.White, box);
                        g.DrawEllipse(Pens.Black, box);
                        g.DrawString($"x{Subcript(l)}{Subcript(k)}", font, Brushes.Black, box, sf);
                    }
                }
            }
        }

        public string Subcript(int number)
        {
            string input = $"{number}";
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '0':
                        result += "\u2080";
                        break;
                    case '1':
                        result += "\u2081";
                        break;
                    case '2':
                        result += "\u2082";
                        break;
                    case '3':
                        result += "\u2083";
                        break;
                    case '4':
                        result += "\u2084";
                        break;
                    case '5':
                        result += "\u2085";
                        break;
                    case '6':
                        result += "\u2086";
                        break;
                    case '7':
                        result += "\u2087";
                        break;
                    case '8':
                        result += "\u2088";
                        break;
                    case '9':
                        result += "\u2089";
                        break;
                }
            }
            return result;
        }
        public double GetLineWidth(double w)
        {
            if (Math.Abs(wMin) > wMax)
            {
                return 1 + 6 * Math.Pow(w / wMin, 4);
            }
            else
            {
                return 1 + 6 * Math.Pow(w / wMax, 4);
            }
        }

        /// <summary> 
        /// Randomly shuffle the orders of the data in the data set. 
        /// </summary> 
        private void ShuffleIndicesArray(int limit)
        {
            // Implementation of Fisher–Yates shuffle
            // Shuffle indexes for 0 to limit - 1
            for (int i = limit - 1; i >= 0; i--)
            {
                int randomIndex = (int)Math.Floor((double)randomizer.Next(i + 1));
                int selectedIndex = dataIndices[randomIndex];

                dataIndices[randomIndex] = dataIndices[i];
                dataIndices[i] = selectedIndex;
            }
        }


        /// <summary> 
        /// Randomly set values of weights between [-1,1] and randomly shuffle the orders of all 
        /// the datum in the data set. Reset value of initial eta and root mean square to 0.0. 
        /// </summary> 
        public void ResetWeightsAndInitialCondition(int[] hiddenNeuronNumbers)
        {
            epochID = 1;

            ConfigureNeuralNetwork(hiddenNeuronNumbers);
            numberOfTrainingData = (int) (trainingRatio * numberOfData);
            numberOfTestingData = numberOfData - numberOfTrainingData;

            // Shuffle data indices
            for (int i = 0; i < numberOfData; i++) dataIndices[i] = i;
            ShuffleIndicesArray(numberOfData);

            // Initialize weight values
            wMin = double.MaxValue;
            wMax = double.MinValue;
            for (int l = 1; l < w.Length; l++)
            {
                for (int k = 1; k < w[l].Length; k++)
                {
                    for (int i = 0; i < w[l][k].Length; i++)
                    {
                        w[l][k][i] = randomizer.NextDouble() * 2 - 1.0;
                        if (useMomentum) dw[l][k][i] = 0.0f;

                        if (w[l][k][i] < wMin) wMin = w[l][k][i];
                        else if (w[l][k][i] > wMax) wMax = w[l][k][i];
                    }
                    x[l - 1][0] = 1.0f;
                }
            }

            eta = initialEta;
            trainRMSE = 0.0f;
            testRMSE = 0.0f;

            OnAfterReset();
        }

        public double ActivateNetValue(double netValue)
        {
            double value = 0.0f;
            switch (activation)
            {
                case ActivationFunction.Sigmoid:
                    value =  1 / (1 + Math.Exp(-netValue));
                    break;

                case ActivationFunction.Tanh:
                    value = (Math.Exp(netValue) - Math.Exp(-netValue)) / (Math.Exp(netValue) + Math.Exp(-netValue));
                    break;
            }
            return value; 
        }

        public double DifferentiateActivationFunction(double x)
        {
            double value = 0.0f;
            switch (activation)
            {
                case ActivationFunction.Sigmoid:
                    value = x * (1 - x);
                    break;

                case ActivationFunction.Tanh:
                    //value = (1 + x) * (1 - x);
                    value = 1 - Math.Pow(x, 2);
                    break;
            }
            return value;
        }

        /// <summary> 
        /// Sequentially loop through each training datum of the training data whose indices are 
        /// randomly shuffled in vectorIndices[] array, to perform on-line training of the NN. 
        /// </summary> 
        public void TrainAnEpoch()
        {
            double v;

            // Loop through each training data
            // N -> the N-th training data
            // l -> the l-th layer
            // k -> the k-th neuron in the l-th layer
            // i -> the i-th neuron in th (l - 1)th layer
            for (int N = 0; N < numberOfTrainingData; N++)
            {
                // forward computing for all neuron values. 
                for (int l = 0; l < numberOfLayers; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        if (l == 0) x[l][k] = inputs[dataIndices[N], k - 1];
                        else
                        {
                            v = 0.0f;
                            for (int i = 0; i < n[l - 1]; i++)
                            {
                                v += w[l][k][i] * x[l - 1][i];
                            }
                            x[l][k] = ActivateNetValue(v);
                        }
                    }
                }
                // compute the epsilon values for neurons on the output layer 
                // and backward computing for the epsilon values 
                for (int l = numberOfLayers - 1; l > 0; l--)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        if (l == numberOfLayers - 1)
                        {
                            e[l][k] = -2 * (targets[dataIndices[N], k - 1] - x[l][k]) * DifferentiateActivationFunction(x[l][k]);
                        }
                        else
                        {
                            for (int i = 1; i < n[l + 1]; i++)
                            {
                                e[l][k] += e[l + 1][i] * w[l + 1][i][k];
                            }
                            e[l][k] *= DifferentiateActivationFunction(x[l][k]);
                        }
                    }
                }
                // update weights for all weights by using epsilon and neuron values. 
                for (int l = 1; l < numberOfLayers; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        for (int i = 0; i < n[l - 1]; i++)
                        {
                            if (useMomentum)
                            {
                                w[l][k][i] += -eta * e[l][k] * x[l - 1][i] + momentumFactor * dw[l][k][i];
                                dw[l][k][i] = -eta * e[l][k] * x[l - 1][i];
                            }
                            else
                            {
                                w[l][k][i] += -eta * e[l][k] * x[l - 1][i];
                            }

                            if (w[l][k][i] < wMin) wMin = w[l][k][i];
                            else if (w[l][k][i] > wMax) wMax = w[l][k][i];
                        }
                    }
                }
            }

            trainRMSE = ComputRMSE(w, true);

            testRMSE = ComputRMSE(w, false);

            OnAfterRunOneEpoch();

            // At the end of the epoch, update step size (learning rate) of the updating amount 
            eta = eta * learningRate;
            epochID++;
        }

        public double ComputRMSE(double[][][] w, bool useTrainingData = true)
        {
            // Compute RMSE
            int start, end;
            double v, errorSquareSum = 0.0, RMSE;
            if (useTrainingData)
            {
                start = 0;
                end = numberOfTrainingData;
            }
            else
            {
                start = numberOfTrainingData;
                end = numberOfData;
            }

            for (int N = start; N < end; N++)
            {
                for (int l = 0; l < numberOfLayers; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        if (l == 0) x[l][k] = inputs[dataIndices[N], k - 1];
                        else
                        {
                            v = 0.0;
                            for (int i = 0; i < n[l - 1]; i++)
                            {
                                v += w[l][k][i] * x[l - 1][i];
                            }
                            x[l][k] = ActivateNetValue(v);
                        }
                    }
                }

                for (int k = 1; k < n[numberOfLayers - 1]; k++)
                {
                    errorSquareSum += Math.Pow(targets[dataIndices[N], k - 1] - x[numberOfLayers - 1][k], 2);
                }
            }
            RMSE = Math.Pow(errorSquareSum / ((end - start) * (n[numberOfLayers - 1] - 1)), 0.5);
            return RMSE;
        }

        public void TrainToEnd()
        {
            while (epochID <= epochLimit)
            {
                TrainAnEpoch();
            }
        }

        /// <summary> 
        /// Compute the output vector for an input vector. Both vectors are in the raw 
        /// format. The input vector is subject to scaling first before forward computing. 
        /// Output vector is then scaled back to raw format for recognition. 
        /// </summary> 
        /// <param name="input">input vector in raw format</param> 
        /// <returns>output vector in raw format</returns> 
        //public double[] ComputeResults(double[] input)
        //{
        //    double[] results = null;
        //    double v;
        //    results = new double[targetDimension];
        //    //… 
        //    return results;
        //}

        public double TrainingClassification(double[][][]w, out int[,] outConfusionMatrix)
        {
            for (int i = 0; i < targetDimension; i++)
                for (int j = 0; j < targetDimension; j++)
                    confusionMatrix[i, j] = 0;

            int successedCount = 0;
            double v;
            for (int N = 0; N < numberOfTrainingData; N++)
            {
                for (int l = 0; l < numberOfLayers; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        if (l == 0) x[l][k] = inputs[dataIndices[N], k - 1];
                        else
                        {
                            v = 0.0f;
                            for (int i = 0; i < n[l - 1]; i++)
                            {
                                v += w[l][k][i] * x[l - 1][i];
                            }
                            x[l][k] = ActivateNetValue(v);
                        }
                    }
                }

                int classID = 0;
                int predictedClassID = 0;
                double value = targets[dataIndices[N], 0];
                double predictedValue = x[numberOfLayers - 1][1];
                for (int k = 2; k < n[numberOfLayers - 1]; k++)
                {
                    if (targets[dataIndices[N], k - 1] > value)
                    {
                        classID = k - 1;
                        value = targets[dataIndices[N], k - 1];
                    }
                    if (x[numberOfLayers - 1][k] > predictedValue)
                    {
                        predictedClassID = k - 1;
                        predictedValue = x[numberOfLayers - 1][k];
                    }
                }

                this.confusionMatrix[predictedClassID, classID] += 1;
                if (predictedClassID == classID) successedCount += 1;
            }

            outConfusionMatrix = this.confusionMatrix;

            return successedCount;
        }

        /// <summary> 
        /// If the data set is a classification data set, test the data to generate confusing table. 
        /// The index of the largest component of the target vector is the targeted class id. 
        /// The index of the largest component of the computed output vector is the resulting class id. 
        /// If both the targeted class id and the resulting class id are the same, then the test 
        /// data is correctly classified. 
        /// </summary> 
        /// <param name="confusingTable">generated confusing table</param> 
        /// <returns>the ratio between the number of correctly classified testing data and the total number of testing data.</returns> 
        public double TestingClassification(double[][][] w, out int[,] outConfusionMatrix)
        {
            for (int i = 0; i < targetDimension; i++)
                for (int j = 0; j < targetDimension; j++)
                    confusionMatrix[i, j] = 0;

            int successedCount = 0;
            double v;
            for (int N = numberOfTrainingData; N < numberOfData; N++)
            {
                for (int l = 0; l < numberOfLayers; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        if (l == 0) x[l][k] = inputs[dataIndices[N], k - 1];
                        else
                        {
                            v = 0.0f;
                            for (int i = 0; i < n[l - 1]; i++)
                            {
                                v += w[l][k][i] * x[l - 1][i];
                            }
                            x[l][k] = ActivateNetValue(v);
                        }
                    }
                }

                int classID = 0;
                int predictedClassID = 0;
                double value = targets[dataIndices[N], 0];
                double predictedValue = x[numberOfLayers - 1][1];
                for (int k = 2; k < n[numberOfLayers - 1]; k++)
                {
                    if (targets[dataIndices[N], k - 1] > value)
                    {
                        classID = k - 1;
                        value = targets[dataIndices[N], k - 1];
                    }
                    if (x[numberOfLayers - 1][k] > predictedValue)
                    {
                        predictedClassID = k - 1;
                        predictedValue = x[numberOfLayers - 1][k];
                    }
                }

                this.confusionMatrix[predictedClassID, classID] += 1;
                if (predictedClassID == classID) successedCount += 1;
            }

            outConfusionMatrix = this.confusionMatrix;

            return successedCount;
        }

        #endregion
    }
    public enum ActivationFunction
    {
        Sigmoid, Tanh
    }
}
