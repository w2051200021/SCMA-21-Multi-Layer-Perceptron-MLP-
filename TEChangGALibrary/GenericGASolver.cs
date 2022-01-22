using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEChangGALibrary
{
    /// <summary>
    /// A template class for a generic genetic algorithm solver. It is used to be inheritted by the 
    /// specific GAsolver, e.g., BinaryGA.
    /// </summary>
    /// <typeparam name="T"> Data type of each chromosome. </typeparam>
    public class GenericGASolver<T>
    {
        // This is a template class,
        // For example, List<GenericFuzzySet>

        #region DATAFIELDS (protected: let the derived class to access them)
        /// <summary>
        /// A random number generator.
        /// </summary>
        protected Random randomizer = new Random();
        /// <summary>
        /// A monitor that we used to control the GUI items of GAMonitor.
        /// </summary>
        protected GAMonitor<T> theMonitor = null;

        /// <summary>
        /// A jagged array T[population size][number of variables] contains the encoded solutions in GA with type T, e.g. byte.
        /// </summary>
        protected T[][] chromosomes;
        /// <summary>
        /// An array that contains the objectives of each chromosome.
        /// </summary>
        protected double[] objectives;
        /// <summary>
        /// An array that contains the fitness of each chromosome.
        /// </summary>
        protected double[] fitnessValues;


        /// <summary>
        /// The chromosome that has the best objective value so far.
        /// </summary>
        protected T[] soFarTheBestSolution;
        /// <summary>
        /// The best objectvie value so far.
        /// </summary>
        protected double soFarTheBestObjectiveValue;
        /// <summary>
        /// The best objective value in the current iteration.
        /// </summary>
        protected double iterationBestObjective;
        /// <summary>
        /// The average obejective value in the current iteration.
        /// </summary>
        protected double iterationAverageObjective;
        /// <summary>
        /// An bool variable used to check whether the best solution is updated.
        /// </summary>
        protected bool soFarTheBestIsUpdated;
        /// <summary>
        /// An integer index used to recored the position of the best solution.
        /// </summary>
        protected int bestID;

        /// <summary>
        /// An index array that repeatly used in most of the calculation, including crossover, mutation
        /// and even selection.
        /// </summary>
        protected int[] indices;
        /// <summary>
        /// A jagged bool array repeatly used for recording the position of mutated genes.
        /// </summary>
        protected bool[][] mutatedGenes;

        /// <summary>
        /// A jagged array repeatly used in gene-wise copy during selection to store the selected chromosomes.
        /// </summary>
        protected T[][] selectedChromosomes;
        /// <summary>
        /// An array repeatly used in gene-wise copy during selection to store the objective value of 
        /// selected chromosomes. 
        /// </summary>
        protected double[] selectedObjectives;

        /// <summary>
        /// The number of jobs in the given problem.
        /// </summary>
        protected int numberOfJobs;
        /// <summary>
        /// The number of genes corresponds to the given problem and type of encoding. In binary encoded GA,
        /// it should be square of number of jobs.
        /// </summary>
        protected int numberOfGenes;

        /// <summary>
        /// Total number of chromosomes, including parents, crossover and mutated children. 
        /// </summary>
        protected int totalNumberOfChromosomes;
        /// <summary>
        /// The optimization type of the given problem.
        /// </summary>
        protected OptimizationType optimizationType = OptimizationType.Minimization;
        /// <summary>
        /// The objective function in the given problem.
        /// </summary>
        protected ObjectiveFunction<T> objectiveFunction = null;
        /// <summary>
        /// A ratio related to lower bound of the fitness value.
        /// </summary>
        protected double leastFitnessFraction = 0.1;

        /// <summary>
        /// The number of parent chromosomes in each generation. 
        /// </summary>
        protected int populationSize = 10; 
        /// <summary>
        /// A ratio related to the number of crossover children. Obviously, the higher it is, the more children we get. 
        /// </summary>
        protected double crossoverRate = 0.8;
        /// <summary>
        /// A ratio related to the number of mutated genes.
        /// </summary>
        protected double mutationRate = 0.05;
        /// <summary>
        /// A ratio related to the number of muatated chromosomes.
        /// </summary>
        protected double populationMutationRate = 0.8;
        /// <summary>
        /// Type of mutation, including gene-number based and population number based mutation.
        /// </summary>
        MutationMode mutationType = MutationMode.GeneNumberBased;
        /// <summary>
        /// Type of selection, including deterministic and stochastic selection.
        /// </summary>
        SelectionMode selectionType = SelectionMode.Deterministic;
        /// <summary>
        /// A double array repeatly used to recored the relative probability in stochastic selection. 
        /// </summary>
        protected double[] rouletteWheel;

        /// <summary>
        /// The maximal number of iteration in GA.
        /// </summary>
        protected int iterationLimit = 50;
        /// <summary>
        /// An index used to record the current state of iteration.
        /// </summary>
        protected int iterationID;
        /// <summary>
        /// Number of crossovered children in each generation.
        /// </summary>
        protected int numberOfCrossoverChildren;
        /// <summary>
        /// Number of mutated children in each generation.
        /// </summary>
        protected int numberOfMutatedChildern;

        StringBuilder sb;
        #endregion

        #region EVENTS
        /// <summary>
        /// ...
        /// </summary>
        public event EventHandler AfterInitialization;

        public event EventHandler AfterReset;

        /// <summary>
        /// ...
        /// </summary>
        public event EventHandler AfterRunOneIteration;
        /// <summary>
        /// ...
        /// </summary>
        public event EventHandler SoFarTheBestSolutionUpdated;

        public event EventHandler ParameterChanged;

        /// <summary>
        /// Fire the AfterInitialization event.
        /// </summary>
        protected void OnAfterInitializatioin()
        {
            if (AfterInitialization != null) AfterInitialization(this, null);
        }

        /// <summary>
        /// Fire the OneIterationCompleted event.
        /// </summary>
        protected void OnAfterRunOneIteration()
        {
            if (AfterRunOneIteration != null) AfterRunOneIteration(this, null);
        }

        /// <summary>
        /// Fire the SoFarTheBestSolutionUpdated event.
        /// </summary>
        protected void OnSoFarTheBestSolutionUpdated()
        {
            if (SoFarTheBestSolutionUpdated != null) SoFarTheBestSolutionUpdated(this, null);
        }

        protected void OnParameterChanged()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }
        #endregion



        #region PROPERTIES
        /// <summary>
        /// ...
        /// </summary>
        [Browsable(false)]
        public Button RunToEndButton
        {
            get
            {
                if (theMonitor == null) return null;
                else return theMonitor.btn_runToEnd;
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Parameters of the Genetic Algorithm"),
            Description("The total number of the chromosomes in the genetic algorithm.")
        ]
        public int PopulationSize 
        { 
            get => populationSize;
            set
            {
                if (value > 1)
                {
                    populationSize = value;
                    OnParameterChanged();
                }
            } 
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Parameters of the Genetic Algorithm"),
            Description("The probability that a chromosome crossovers with another crossover.")
        ]
        public double CrossoverRate 
        { 
            get => crossoverRate; 
            set
            {
                if (value >= 0 & value <= 1)
                {
                    crossoverRate = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Parameters of the Genetic Algorithm"),
            Description("The probability that a gene mutates.")
        ]
        public double MutationRate 
        { 
            get => mutationRate;
            set
            {
                if (value >= 0 & value <= 1)
                {
                    mutationRate = value;
                    OnParameterChanged();
                }
            }  
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Parameters of the Genetic Algorithm"),
            Description("The probability that a chromosome mutates. (Only used in population number based mutation.)")
        ]
        public double PopulationMutationRate
        {
            get => populationMutationRate;
            set
            {
                if (value >= 0 & value <= 1)
                {
                    populationMutationRate = value;
                    OnParameterChanged();
                }
            }
        }


        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Parameters of the Genetic Algorithm"),
            Description("A ratio related to lower bound of the fitness value.")
        ]
        public double LeastFitnessFraction
        {
            get => leastFitnessFraction;
            set
            {
                if (value > 0 & value < 0.5)
                {
                    leastFitnessFraction = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Operation Mode"),
            Description("The type of mutation, including 'gene-number based' and 'population-number based' mutation. " +
                        "Not used in permutation GA"),
        ]
        public MutationMode MutationType
        {
            get => mutationType;
            set
            {
                mutationType = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Operation Mode"),
            Description("The type of selection, including 'deterministic' and 'stochastic' selection.")
        ]
        public SelectionMode SelectionType
        {
            get => selectionType;
            set
            {
                selectionType = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        [
            Category("Stopping Criteria"),
            Description("The maximal number of iterations.")
        ]
        public int MaxIteration
        {
            get => iterationLimit;
            set
            {
                if (value > 0)
                {
                    iterationLimit = value;
                    OnParameterChanged();
                }
            }
        }

        [
            Browsable(false)    
        ]
        public GAMonitor<T> TheMonitor { get => theMonitor;}
        [
            Browsable(false)
        ]
        public T[][] Chromosomes { get => chromosomes;}
        [
            Browsable(false)
        ]
        public double[] Objectives { get => objectives;}
        [
            Browsable(false)
        ]
        public T[] SoFarTheBestSolution { get => soFarTheBestSolution;}
        [
            Browsable(false)
        ]
        public double SoFarTheBestObjectiveValue { get => soFarTheBestObjectiveValue;}
        [
            Browsable(false)
        ]
        public double IterationBestObjective { get => iterationBestObjective;}
        [
            Browsable(false)
        ]
        public double IterationAverageObjective { get => iterationAverageObjective;}
        [
            Browsable(false)
        ]
        public int IterationID { get => iterationID;}
        [
            Browsable(false)
        ]
        public int NumberOfCrossoverChildren { get => numberOfCrossoverChildren;}
        [
            Browsable(false)
        ]
        public int TotalNumberOfChromosomes { get => totalNumberOfChromosomes;}
        #endregion



        #region CONSTRUCTOR
        /// <summary>
        /// A Generic GA Solver.
        /// </summary>
        /// <param name="numberOfVariables"> Number of variables (genes) </param>
        /// <param name="optimizationType"> Type of optimization </param>
        /// <param name="objectiveFunction"> The objective function corresponds to the problem </param>
        /// <param name="hostPanelForMonitor"> The panel used to contain the monitor </param>
        public GenericGASolver(int numberOfVariables, OptimizationType optimizationType, 
                               ObjectiveFunction<T> objectiveFunction, Panel hostPanelForMonitor = null)
        {
            numberOfGenes = numberOfVariables;
            this.optimizationType = optimizationType;
            this.objectiveFunction = objectiveFunction;

            if (hostPanelForMonitor != null)
            {
                // create monitor object and add it to the host panel
                theMonitor = new GAMonitor<T>(this);
                hostPanelForMonitor.Controls.Clear();
                hostPanelForMonitor.Controls.Add(theMonitor);
                theMonitor.Dock = DockStyle.Fill;
                theMonitor.pg_GA.SelectedObject = this;
                theMonitor.btn_reset.BackColor = Color.Cornsilk;

                if(typeof(T) == typeof(int))
                {
                    theMonitor.tb_shortestTime.Visible = false;
                    theMonitor.lsb_violation.Visible = false;
                    theMonitor.label3.Visible = false;
                    theMonitor.label4.Visible = false;
                }
            }

            soFarTheBestSolution = new T[numberOfVariables];

        }
        #endregion

        #region HELPING FUNCTIONS
        /// <summary>
        /// A function that helps to search the extreme value.
        /// </summary>
        /// <param name="objectives"> A double array we wanted to search. </param>
        /// <param name="findMax"> If true, find the maximum, otherwise, find the minimum. </param>
        /// <returns></returns>
        public double findExtremeValue(double[] objectives, bool findMax)
        {
            // Find the Max/Min value of a given double array
            double extremeValue;
            if (findMax == true)
            {
                extremeValue = double.MinValue;
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    extremeValue = objectives[i] > extremeValue ? objectives[i] : extremeValue;
                }
            }
            else
            {
                extremeValue = double.MaxValue;
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    extremeValue = objectives[i] < extremeValue ? objectives[i] : extremeValue;
                }
            }
            return extremeValue;
        }

        /// <summary>
        /// Transform the objective value to the fitness value.
        /// </summary>
        public void setFitnessFromObjectives()
        {
            // transfer objective values to fitness values
            totalNumberOfChromosomes = populationSize + numberOfCrossoverChildren + numberOfMutatedChildern;
            double objMax = findExtremeValue(objectives, true);
            double objMin = findExtremeValue(objectives, false);
            double minFitness = Math.Max(leastFitnessFraction * (objMax - objMin), Math.Pow(10, -5));

            if (optimizationType == OptimizationType.Maximization)
            {
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    fitnessValues[i] = minFitness + (objectives[i] - objMin);
                }
            }
            else
            {
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    fitnessValues[i] = minFitness + (objMax - objectives[i]);
                }
            }
        }

        /// <summary>
        /// Shuffle an array with am upper limit.
        /// </summary>
        /// <param name="array"> An int array we want to shuffle.  </param>
        /// <param name="limit"> The upper limit of the shuffle. </param>
        public void ShuffleAnArray(int[] array, int limit)
        {
            // Implementation of Fisher–Yates shuffle
            // Shuffle indexes for 0 to limit - 1
            for (int i = limit - 1; i >= 0; i--)
            {
                int randomIndex = (int)Math.Floor((double)randomizer.Next(i + 1));
                int selectedIndex = array[randomIndex];

                array[randomIndex] = array[i];
                array[i] = selectedIndex;
            }
        }


        /// <summary>
        /// Reset everything of the GA.
        /// </summary>
        public void Reset()
        {
            // Variable reset
            iterationID = 1;

            if (typeof(T) == typeof(Int32))
            {
                numberOfJobs = numberOfGenes;
            }
            else numberOfJobs = (int)Math.Sqrt(numberOfGenes);

            numberOfCrossoverChildren = numberOfMutatedChildern = 0;
            if (optimizationType == OptimizationType.Maximization) soFarTheBestObjectiveValue = double.MinValue;
            else soFarTheBestObjectiveValue = double.MaxValue;

            // Memory reallocation
            int ThreeTimeSize = populationSize * 3; // Population & Children & Mutation
            chromosomes = new T[ThreeTimeSize][];  
            objectives = new double[ThreeTimeSize];
            for(int r = 0; r < ThreeTimeSize; r++)
            {
                chromosomes[r] = new T[numberOfGenes];
            }
            indices = new int[ThreeTimeSize];
            fitnessValues = new double[ThreeTimeSize];
            rouletteWheel = new double[ThreeTimeSize];
            mutatedGenes = new bool[populationSize][];
            selectedChromosomes = new T[populationSize][];
            selectedObjectives = new double[populationSize];
            for (int r = 0; r < populationSize; r++)
            {
                mutatedGenes[r] = new bool[numberOfGenes];
                selectedChromosomes[r] = new T[numberOfGenes];
            }

            // Set initial solution
            InitializePopulation();

            // Fire AfterInitializationEvent

            // Evaluate objectives of the new population
            for(int i = 0; i < populationSize; i++)
            {
                objectives[i] = objectiveFunction(chromosomes[i]);
            }

            UpdateSoFarTheBestSolutionAndObjective();

            AfterReset(this, null);

        }

        /// <summary>
        /// Initializa the population, overriden in each specific GA.
        /// </summary>
        public virtual void InitializePopulation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Run one iteration, including crossover, mutation and selection.
        /// </summary>
        public void RunOneIteration()
        {
            
            PerformCrossoverOperation();
            PerformMutationOperation();
            UpdateSoFarTheBestSolutionAndObjective();
            PerformSelectionOperation();


            AfterRunOneIteration(this, null);

            iterationID++;
        }

        private void UpdateSoFarTheBestSolutionAndObjective()
        {
            // Loop thourgh objective array and parnets and children chromosomes
            // find the iteration best solution id first
            // check whether its value is better than the current best objective
            // if it does, the update the best objective and "gene-wise copy" the iteration best
            // chromosomes to so-far-the-best-solution
            // Calculate "iterationBestObjective" and "iterationAverageObjective"
            totalNumberOfChromosomes = populationSize + numberOfCrossoverChildren + numberOfMutatedChildern;
            for (int i = 0; i < totalNumberOfChromosomes; i++)
            {
                indices[i] = i;
            }
            bestID = 0;
                       
            if(optimizationType == OptimizationType.Minimization)
            {
                // Minimization problem
                iterationAverageObjective = 0;
                iterationBestObjective = double.MaxValue;
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    if (objectives[i] < iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        bestID = i;
                    }
                    iterationAverageObjective += objectives[i];
                }
                iterationAverageObjective /= totalNumberOfChromosomes;

                if (iterationBestObjective <= soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjective;

                    // Gene-wise copy to soFarTheBestSoution
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        soFarTheBestSolution[j] = chromosomes[bestID][j];
                    }
                    OnSoFarTheBestSolutionUpdated();
                }
                
            }
            else
            {
                // Maximization problem
                iterationAverageObjective = 0;
                iterationBestObjective = double.MinValue;
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    if (objectives[i] > iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        bestID = i;
                    }
                    iterationAverageObjective += objectives[i];
                }
                iterationAverageObjective /= totalNumberOfChromosomes;

                if (iterationBestObjective < soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjective;

                    // Gene-wise copy to soFarTheBestSoution
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        soFarTheBestSolution[j] = chromosomes[bestID][j];
                    }
                    OnSoFarTheBestSolutionUpdated();
                }

            }
            

        }

        private void PerformCrossoverOperation()
        {
            numberOfCrossoverChildren = (int)( populationSize * crossoverRate ); // decide the number of crossovered children
            if (numberOfCrossoverChildren % 2 == 1) numberOfCrossoverChildren--; // make the number even

            for (int i = 0; i < populationSize; i++) indices[i] = i;
            ShuffleAnArray(indices, populationSize);

            int father, mother, child1 = populationSize, child2 = populationSize + 1;
            for (int i = 0; i < numberOfCrossoverChildren; i += 2)
            {
                father = indices[i];
                mother = indices[i + 1];
                CrossoverAPairParent(father, mother, child1, child2);
                
                objectives[child1] = objectiveFunction(chromosomes[child1]);
                objectives[child2] = objectiveFunction(chromosomes[child2]);

                child1 += 2;
                child2 += 2;
            }

        }

        /// <summary>
        /// Crossover a pair of parents, overriden in each specific GA.
        /// </summary>
        /// <param name="father"></param>
        /// <param name="mother"></param>
        /// <param name="child1"></param>
        /// <param name="child2"></param>
        public virtual void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Perform a mutaion operation.
        /// </summary>
        public void PerformMutationOperation()
        {
            // Initialization
            for (int i = 0; i < populationSize; i++)
            {
                indices[i] = 0;
                for (int j = 0; j < numberOfGenes; j++)
                {
                    mutatedGenes[i][j] = false;
                }
            }

            if (typeof(T) == typeof(Int32))
            {
                int limit = populationSize * numberOfGenes;
                numberOfMutatedChildern = (int)(populationSize * populationMutationRate);
                for (int i = 0; i < populationSize; i++) indices[i] = i;
                ShuffleAnArray(indices, populationSize);

                int childID = populationSize + numberOfCrossoverChildren;
                for (int i = 0; i < numberOfMutatedChildern; i++)
                {
                    MutateAParent(indices[i], childID, mutatedGenes[indices[i]]);
                    objectives[childID] = objectiveFunction(chromosomes[childID]);
                    childID++;
                }
            }
            else
            {
                if (mutationType == MutationMode.GeneNumberBased)
                {
                    // Take a use of selected chromosomes
                    // Total number of genes x mutation rate = number of mutated genes
                    // (might not be equal to # of chromosome!)

                    int limit = populationSize * numberOfGenes;
                    int numberOfMutatedGenes = (int)(mutationRate * limit);


                    for (int i = 0; i < numberOfMutatedGenes; i++)
                    {
                        int serialPos = randomizer.Next(limit);
                        int parentID, geneID;
                        parentID = serialPos / numberOfGenes;
                        geneID = serialPos % numberOfGenes;
                        indices[parentID] = int.MinValue;
                        mutatedGenes[parentID][geneID] = true;
                    }
                    numberOfMutatedChildern = 0;
                    int childID = populationSize + numberOfCrossoverChildren;
                    for (int i = 0; i < populationSize; i++)
                    {
                        if (indices[i] == int.MinValue)
                        {
                            MutateAParent(i, childID, mutatedGenes[i]);
                            objectives[childID] = objectiveFunction(chromosomes[childID]);
                            childID++;
                            numberOfMutatedChildern++;
                        }
                    }
                }
                else
                {
                    int limit = populationSize * numberOfGenes;
                    numberOfMutatedChildern = (int)(populationSize * populationMutationRate);
                    for (int i = 0; i < populationSize; i++) indices[i] = i;
                    ShuffleAnArray(indices, populationSize);

                    for (int i = 0; i < numberOfMutatedChildern; i++)
                    {
                        for (int j = 0; j < numberOfGenes; j++)
                        {
                            double p = randomizer.NextDouble();
                            if (p < mutationRate)
                            {
                                mutatedGenes[indices[i]][j] = true;
                            }
                        }
                    }
                    int childID = populationSize + numberOfCrossoverChildren;
                    for (int i = 0; i < numberOfMutatedChildern; i++)
                    {
                        MutateAParent(indices[i], childID, mutatedGenes[indices[i]]);
                        objectives[childID] = objectiveFunction(chromosomes[childID]);
                        childID++;
                    }

                }
            }
            

            totalNumberOfChromosomes = populationSize + numberOfCrossoverChildren + numberOfMutatedChildern;

        }

        /// <summary>
        /// Perform mutation operation on a specific parent and generate a mutated child.
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="childID"></param>
        /// <param name="mutatedFlag"></param>
        public virtual void MutateAParent(int parentID, int childID, bool[] mutatedFlag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Perform the chromosome selection, whether "Deterministic" or "Stochastic".
        /// </summary>
        public void PerformSelectionOperation()
        {
            // Calculate the fitness for all chromosomes
            setFitnessFromObjectives();

            totalNumberOfChromosomes = populationSize + numberOfCrossoverChildren + numberOfMutatedChildern;
            if (selectionType == SelectionMode.Deterministic)
            {
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    indices[i] = i;
                }
                Array.Sort(fitnessValues, indices, 0, totalNumberOfChromosomes); // From ascending to descending
                Array.Reverse(indices, 0, totalNumberOfChromosomes);
            }
            else
            {
                // Stochastic selection
                // use fitness as relative probabilities for each chromosome and to 
                // spin roullet wheel "populationSize" times to set the first populationSize indices
                
                rouletteWheel[0] = fitnessValues[0];
                for (int i = 0; i < totalNumberOfChromosomes; i++)
                {
                    indices[i] = i;
                    if (i > 0) rouletteWheel[i] = rouletteWheel[i - 1] + fitnessValues[i];
                }

                for (int i = 0; i < populationSize; i++)
                {
                    double s = randomizer.NextDouble() * rouletteWheel[totalNumberOfChromosomes - 1];
                    for(int j = 0; j < totalNumberOfChromosomes - 1; j++)
                    {
                        if(s < rouletteWheel[j])
                        {
                            indices[i] = j;
                            break;
                        }
                    }
                }
            }


            // Gene-wise copy genes from selected chromosomes to temperary array
            // To prevent the current indices from being crushed (otherwise, design some algorithm ...)
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    selectedChromosomes[i][j] = chromosomes[indices[i]][j];
                }
                selectedObjectives[i] = objectives[indices[i]];
            }

            // Gene-wise copy genes back to our population
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = selectedChromosomes[i][j];
                }
                objectives[i] = selectedObjectives[i];
            }

        }


        /// <summary>
        /// Rather than run a single iteration, run to the user defined limiting iterations.
        /// </summary>
        public void RunToEnd()
        {
            while (iterationID <= iterationLimit)
            {
                RunOneIteration();
            }

        }

        #endregion
    }

    /// <summary>
    /// The optimization type.
    /// </summary>
    public enum OptimizationType 
    { 
        /// <summary>
        /// The minimization problem.
        /// </summary>
        Minimization, 
        
        /// <summary>
        /// The maximization problem.
        /// </summary>
        Maximization }

    /// <summary>
    /// The mutation operation mode
    /// </summary>
    public enum MutationMode 
    { 
        /// <summary>
        /// The mutation rate is based on the number of genes.
        /// </summary>
        GeneNumberBased, 
        
        /// <summary>
        /// The mutation rate is based on the number of population.
        /// </summary>
        PopulationSizeBased 
    }

    /// <summary>
    /// The selection mode.
    /// </summary>
    public enum SelectionMode 
    {
        /// <summary>
        /// Select the top N chromosomes.
        /// </summary>
        Deterministic,

        /// <summary>
        /// Select by relative probability (fitness)
        /// </summary>
        Stochastic
    }

    /// <summary>
    /// A delegation for objective function (in order to send a function as a parameter)
    /// </summary>
    /// <typeparam name="T"> Data type of chromosomes, e.g. binary, real, ... </typeparam>
    /// <param name="aSolution"> A single chromosome. </param>
    /// <returns> objective value </returns>
    public delegate double ObjectiveFunction<T>(T[] aSolution);
}
