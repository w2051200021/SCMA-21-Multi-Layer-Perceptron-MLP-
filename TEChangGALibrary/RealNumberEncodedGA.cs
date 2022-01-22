using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COP;

namespace TEChangGALibrary
{
    public class RealNumberEncodedGA : GenericGASolver<double>
    {
        int numberOfCuts;
        int numberOfVariables;
        double degreeOfNonUniformity = 0.8;
        double[] lowerBounds;
        double[] upperBounds;

        RealNumberCrossoverOperator crossoverMode = RealNumberCrossoverOperator.Linear;
        RealNumberMutationOperator mutationMode = RealNumberMutationOperator.Dynamic;

        #region PROPERTIES

        [
            Category("Operation Mode"),
            Description("The crossover operations for real number encoded GA, including Large Value Divided (LVD)," +
            "Small Value Divided (SVD), Middle and One End Segments (MOES), Two End Segments (TES) and Forward and Backward Middle Segment (FBMS).")
        ]
        public RealNumberCrossoverOperator CrossoverMode
        {
            get => crossoverMode;
            set
            {
                crossoverMode = value;
                OnParameterChanged();
            }
        }
        [
            Category("Operation Mode"),
            Description("The mutation operations for real number encoded GA.")
        ]
        public RealNumberMutationOperator MutationMode
        {
            get => mutationMode;
            set
            {
                mutationMode = value;
                OnParameterChanged();
            }
        }
        [
            Category("Operation Mode"),
            Description("Degree of non-uniformity of the dynamic mutation operator.")
        ]
        public double DegreeOfNonUniformity
        {
            get => degreeOfNonUniformity;
            set
            {
                if (value > 0)
                {
                    degreeOfNonUniformity = value;
                    OnParameterChanged();
                }
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="lowerBounds"></param>
        /// <param name="upperBounds"></param>
        /// <param name="optimizationType"></param>
        /// <param name="objectiveFunction"></param>
        /// <param name="hostPanelForGAMonitor"></param>
        public RealNumberEncodedGA(int numberOfVariables, double[] lowerBounds, double[] upperBounds, OptimizationType optimizationType, ObjectiveFunction<double> objectiveFunction, Panel hostPanelForGAMonitor = null) :
            base(numberOfVariables, optimizationType, objectiveFunction, hostPanelForGAMonitor)
        {
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;
            this.numberOfVariables = numberOfVariables;

            numberOfCuts = Math.Min(numberOfVariables, 2);
        }


        public override void InitializePopulation()
        {
            for(int p = 0; p < populationSize; p++)
                for(int i = 0; i < numberOfGenes; i++)
                {
                    chromosomes[p][i] =  randomizer.NextDouble() * (upperBounds[i] - lowerBounds[i]) + lowerBounds[i];
                }
        }

        public override void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            int cutPos1 = randomizer.Next(numberOfGenes);
            int cutPos2 = randomizer.Next(numberOfGenes);
            int temp = 0;

            if (cutPos1 > cutPos2)
            {
                temp = cutPos1;
                cutPos1 = cutPos2;
                cutPos2 = temp;
            }
            switch (crossoverMode)
            {
                case RealNumberCrossoverOperator.Convex:
                    double alpha = randomizer.NextDouble();
                    double beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {                   
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                            chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;

                case RealNumberCrossoverOperator.Affine:
                    alpha = 3 * randomizer.NextDouble() - 1.5;
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                            chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }

                        if (chromosomes[child1][i] > upperBounds[i]) chromosomes[child1][i] = upperBounds[i];
                        else if (chromosomes[child1][i] < lowerBounds[i]) chromosomes[child1][i] = lowerBounds[i];

                        if (chromosomes[child2][i] > upperBounds[i]) chromosomes[child2][i] = upperBounds[i];
                        else if (chromosomes[child2][i] < lowerBounds[i]) chromosomes[child2][i] = lowerBounds[i];
                    }
                    break;

                case RealNumberCrossoverOperator.Linear:
                    alpha = 3 * randomizer.NextDouble() - 1.5;
                    beta = 3 * randomizer.NextDouble() - 1.5;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                            chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }

                        if (chromosomes[child1][i] > upperBounds[i]) chromosomes[child1][i] = upperBounds[i];
                        else if (chromosomes[child1][i] < lowerBounds[i]) chromosomes[child1][i] = lowerBounds[i];

                        if (chromosomes[child2][i] > upperBounds[i]) chromosomes[child2][i] = upperBounds[i];
                        else if (chromosomes[child2][i] < lowerBounds[i]) chromosomes[child2][i] = lowerBounds[i];
                    }
                    break;

                case RealNumberCrossoverOperator.LVD:
                    alpha = randomizer.NextDouble();
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            if (chromosomes[father][i] > chromosomes[mother][i])
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[father][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[father][i];
                            }
                            else
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[mother][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[mother][i];
                            }

                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;

                case RealNumberCrossoverOperator.SVD:
                    alpha = randomizer.NextDouble();
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            if (chromosomes[father][i] > chromosomes[mother][i])
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[mother][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[mother][i];
                            }
                            else
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[father][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[father][i];
                            }

                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;

                case RealNumberCrossoverOperator.MOES:
                    alpha = randomizer.NextDouble();
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                            double threshold = randomizer.NextDouble();
                            if (threshold > 0.5)
                            {
                                if (chromosomes[father][i] > chromosomes[mother][i])
                                {
                                    chromosomes[child2][i] = alpha * chromosomes[father][i] + beta * upperBounds[i];
                                }
                                else
                                {
                                    chromosomes[child2][i] = alpha * chromosomes[mother][i] + beta * upperBounds[i];
                                }
                            }
                            else
                            {
                                if (chromosomes[father][i] > chromosomes[mother][i])
                                {
                                    chromosomes[child2][i] = alpha * chromosomes[mother][i] + beta * lowerBounds[i];
                                }
                                else
                                {
                                    chromosomes[child2][i] = alpha * chromosomes[father][i] + beta * lowerBounds[i];
                                }
                            }
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;

                case RealNumberCrossoverOperator.TES:
                    alpha = randomizer.NextDouble();
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            if (chromosomes[father][i] > chromosomes[mother][i])
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[mother][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[father][i];
                            }
                            else
                            {
                                chromosomes[child1][i] = alpha * lowerBounds[i] + beta * chromosomes[father][i];
                                chromosomes[child2][i] = beta * upperBounds[i] + alpha * chromosomes[mother][i];
                            }

                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;

                case RealNumberCrossoverOperator.FBMS:
                    alpha = randomizer.NextDouble();
                    beta = 1.0 - alpha;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if (i <= cutPos2)
                        {
                            chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                            chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }
                    break;
            }
        }


        public override void MutateAParent(int parentID, int childID, bool[] mutatedFlag)
        {
            double threshold = randomizer.NextDouble();
            for (int i = 0; i < numberOfVariables; i++)
            {
                if (mutatedFlag[i])
                {
                    if (threshold > 0.5)
                    {
                        chromosomes[childID][i] = chromosomes[parentID][i] + randomizer.NextDouble() * (upperBounds[i] - chromosomes[parentID][i]) * Math.Pow(1 - iterationID / iterationLimit, degreeOfNonUniformity);
                    }
                    else
                    {
                        chromosomes[childID][i] = chromosomes[parentID][i] - randomizer.NextDouble() * (chromosomes[parentID][i] - lowerBounds[i]) * Math.Pow(1 - iterationID / iterationLimit, degreeOfNonUniformity);
                    }
                }
                else
                {
                    chromosomes[childID][i] = chromosomes[parentID][i];
                }
            }

        }
    }

    public enum RealNumberCrossoverOperator
    {
        Convex, Affine, Linear, LVD, SVD, MOES, TES, FBMS
    }

    public enum RealNumberMutationOperator
    {
        Dynamic
    }
}
