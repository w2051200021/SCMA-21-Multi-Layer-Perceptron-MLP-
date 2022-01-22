using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOLibrary
{
    public class ParticleSwarmOptimizer
    {
        #region DATA FIELDS
        OptimizationType optimizationType = OptimizationType.Minimization;
        COPObjectvieFunction objectiveFunction;

        Random randomizer = new Random();
        int numberOfVariables;
        int numberOfParticles = 10;
        double[][] positions;
        double[][] selfBestPositions; // particular for PSO
        double[] objectives;
        double[] selfBestObjectives; // particular for PSO
        double[] soFarTheBestPosition;
        double soFarTheBestObjectiveValue;
        double iterationAverageObjective;
        double iterationBestObjective;
        double[] lowerBounds, upperBounds;
        double congnitionFactor = 0.5; // particular for PSO
        double socialFactor = 0.5; // particular for PSO

        int iterationID = 0;
        int iterationLimit = 50;


        #endregion

        #region PROPERTIES

        [
            Category("Parameters of the Particle Swarm Optimization System"),
            Description("Population size of the particles.")
        ]
        public int NumberOfParticles
        {
            get => numberOfParticles;
            set
            {
                if (value > 0)
                {
                    numberOfParticles = value;
                    OnParameterChanged();
                }
            }
        }
        [
            Category("Parameters of the Particle Swarm Optimization System"),
            Description("Larger congnition factor makes particle movement more depends on its own search experience.")
        ]
        public double CongnitionFactor
        {
            get => congnitionFactor;
            set
            {
                if (value > 0)
                {
                    congnitionFactor = value;
                    OnParameterChanged();
                }
            }
        }
        [
            Category("Parameters of the Particle Swarm Optimization System"),
            Description("Larger social factor makes particles' movement more dependes on the swarm search experience.")
        ]
        public double SocialFactor
        {
            get => socialFactor;
            set
            {
                if (value > 0)
                {
                    socialFactor = value;
                    OnParameterChanged();
                }
            }
        }
        [
            Category("Stopping Criteria"),
            Description("Stopping criteria of the system.")
        ]
        public int IterationLimit
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
        public double[][] Positions { get => positions; }
        [
            Browsable(false)
        ]
        public double[] Objectives { get => objectives; }
        [
            Browsable(false)
        ]
        public int IterationID { get => iterationID; }
        [
            Browsable(false)
        ]
        public double[] SoFarTheBestPosition { get => soFarTheBestPosition; }
        [
            Browsable(false)
        ]
        public double SoFarTheBestObjectiveValue { get => soFarTheBestObjectiveValue; }
        [
            Browsable(false)
        ]
        public double IterationAverageObjective { get => iterationAverageObjective; }
        [
            Browsable(false)
        ]
        public double IterationBestObjective { get => iterationBestObjective; }
        #endregion

        #region EVENTS
        public event EventHandler AfterReset;
        public event EventHandler SoFarTheBestSolutionUpdated;
        public event EventHandler AfterRunOneIteration;
        public event EventHandler ParameterChanged;

        protected void OnParameterChanged()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }

        protected void OnSoFarTheBestSolutionUpdated()
        {
            if (SoFarTheBestSolutionUpdated != null) SoFarTheBestSolutionUpdated(this, null);
        }
        #endregion

        #region CONSTRUCTOR
        //public ParticleSwarmOptimizer(COP.COPBenchmark theProblem)
        //{
        //    numberOfVariables = theProblem.Dimension;
        //    lowerBounds = theProblem.LowerBound;
        //    upperBounds = theProblem.UpperBound;
        //    optimizationType = theProblem.OptimizationGoal;
        //    objectiveFunction = theProblem.GetObjectiveValue;

        //    soFarTheBestPosition = new double[numberOfVariables];
        //}

        public ParticleSwarmOptimizer(int numberOfVariables, double[] lowerBounds, double[] upperBounds,
                                      OptimizationType optimizationType, COPObjectvieFunction objectiveFunction)
        {
            this.numberOfVariables = numberOfVariables;
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;
            this.optimizationType = optimizationType;
            this.objectiveFunction = objectiveFunction;

            soFarTheBestPosition = new double[numberOfVariables];
        }

        #endregion

        #region UI FUNCTIONS
        public void Reset()
        {
            iterationID = 1;
            // Re-allocate memories
            positions = new double[numberOfParticles][];
            selfBestPositions = new double[numberOfParticles][];

            for (int i = 0; i < numberOfParticles; i++)
            {
                positions[i] = new double[numberOfVariables];
                selfBestPositions[i] = new double[numberOfVariables];
            }
            objectives = new double[numberOfParticles];
            selfBestObjectives = new double[numberOfParticles];


            if (optimizationType == OptimizationType.Minimization) soFarTheBestObjectiveValue = double.MaxValue;
            else soFarTheBestObjectiveValue = double.MinValue;

            // Randomly assign initial positions 
            for (int i = 0; i < numberOfParticles; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    positions[i][j] = lowerBounds[j] + randomizer.NextDouble() * (upperBounds[j] - lowerBounds[j]);
                }
                if (optimizationType == OptimizationType.Minimization) selfBestObjectives[i] = double.MaxValue;
                else selfBestObjectives[i] = double.MinValue;
            }

            // Evaluate objective values of the greedy searched population
            for (int i = 0; i < numberOfParticles; i++)
            {
                objectives[i] = objectiveFunction(positions[i]);
            }

            UpdateSoFarTheBestSolutions();

            AfterReset(this, null);
        }


        public void RunOneIteration()
        {
            MoveAllParticalsToNewPositions();
            UpdateSoFarTheBestSolutions();

            AfterRunOneIteration(this, null);

            iterationID++;
        }



        private void MoveAllParticalsToNewPositions()
        {
            // Evaluate the obejectives of all new positions and update
            // self best positions and objectives if new position is better.
            // Calculate iteration average and iteration best ID.
            // Update so-far the best solution and objective if iteration best solution
            // is better than the it.

            for (int i = 0; i < numberOfParticles; i++)
            {
                double alpha = congnitionFactor * randomizer.NextDouble();
                double beta = socialFactor * randomizer.NextDouble();
                for (int j = 0; j < numberOfVariables; j++)
                {
                    positions[i][j] += alpha * (selfBestPositions[i][j] - positions[i][j]) + beta * (soFarTheBestPosition[j] - positions[i][j]);
                    if (positions[i][j] > upperBounds[j]) positions[i][j] = upperBounds[j];
                    else if (positions[i][j] < lowerBounds[j]) positions[i][j] = lowerBounds[j];
                }
                objectives[i] = objectiveFunction(positions[i]);
            }


        }

        private void UpdateSoFarTheBestSolutions()
        {
            // Use the two factors, so-far the best position and self best position to
            // set new positions for all particles

            int bestID = 0;

            if (optimizationType == OptimizationType.Minimization)
            {
                // Minimization problem
                iterationAverageObjective = 0;
                iterationBestObjective = double.MaxValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    // Update local best position for each particle
                    if (objectives[i] < selfBestObjectives[i])
                    {
                        selfBestObjectives[i] = objectives[i];
                        for (int j = 0; j < numberOfVariables; j++) selfBestPositions[i][j] = positions[i][j];
                    }

                    // Update the best solution so far
                    if (objectives[i] < iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        bestID = i;
                    }
                    iterationAverageObjective += objectives[i];
                }
                iterationAverageObjective /= numberOfParticles;

                if (iterationBestObjective <= soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjective;
                    // Variable-wise copy to soFarTheBestSoution
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        soFarTheBestPosition[j] = positions[bestID][j];
                    }
                    OnSoFarTheBestSolutionUpdated();
                }
            }
            else
            {
                // Maximization problem
                iterationAverageObjective = 0;
                iterationBestObjective = double.MinValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    // Update local best position for each particle
                    if (objectives[i] < selfBestObjectives[i])
                    {
                        selfBestObjectives[i] = objectives[i];
                        for (int j = 0; j < numberOfVariables; j++) selfBestPositions[i][j] = positions[i][j];
                    }

                    // Update the best solution so far
                    if (objectives[i] > iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        bestID = i;
                    }
                    iterationAverageObjective += objectives[i];
                }
                iterationAverageObjective /= numberOfParticles;

                if (iterationBestObjective < soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjective;

                    // Variable-wise copy to soFarTheBestSoution
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        soFarTheBestPosition[j] = positions[bestID][j];
                    }
                    OnSoFarTheBestSolutionUpdated();
                }
            }
        }

        public void RunToEnd()
        {
            while (iterationID <= iterationLimit)
            {
                RunOneIteration();
            }
        }
        #endregion


    }

    public delegate double COPObjectvieFunction(double[] aSolution);

    public enum OptimizationType
    {
        Minimization, Maximization
    }
}
