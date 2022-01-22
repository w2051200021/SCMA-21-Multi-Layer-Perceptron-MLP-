using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEChangGALibrary
{
    public enum BinaryCrossoverMode { OnePointCut, TwoPointCut, NPoints }

    // for N points cut, we need some fault proof mechanism

    public class BinaryGA : GenericGASolver<byte>
    {
        // Gene value is either 0 or 1 -> byte
        // For permutation GA -> int

        public int[] pos;
        protected BinaryCrossoverMode crossoverMode = BinaryCrossoverMode.OnePointCut;

        #region PROPERTIES
        [
            Category("Operation Mode"),
            Description("The crossover operations for binary representation.")
        ]
        public BinaryCrossoverMode CrossoverType 
        {
            set
            {
                crossoverMode = value;
                OnParameterChanged();
            }

            get => crossoverMode;
        } 

        #endregion
        

        /// <summary>
        /// Create a Binary GA Solver
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="optimizationType"></param>
        /// <param name="objectiveFunction"> The delegate of objective function. </param>
        public BinaryGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<byte> objectiveFunction, Panel hostPanelForGAMonitor = null) : 
            base(numberOfVariables, optimizationType, objectiveFunction, hostPanelForGAMonitor)
        {
            pos = new int[numberOfGenes]; // we would only allocate the memory once!

        }


        public override void InitializePopulation()
        {
            for(int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                    chromosomes[r][c] = (byte) randomizer.Next(2);
            }

        }

        public override void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            switch(CrossoverType)
            {
                case BinaryCrossoverMode.OnePointCut:
                    int cutPos = randomizer.Next(numberOfGenes);
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        // simple example of one point cut (just exchange the genes of parents)
                        chromosomes[child1][i] = cutPos > i ? chromosomes[father][i] : chromosomes[mother][i];
                        chromosomes[child2][i] = cutPos > i ? chromosomes[mother][i] : chromosomes[father][i];
                    }

                    break;

                case BinaryCrossoverMode.TwoPointCut:
                    int cutPos1 = randomizer.Next(numberOfGenes);
                    int cutPos2 = randomizer.Next(numberOfGenes);
                    int temp = 0;

                    if(cutPos1 > cutPos2)
                    {
                        temp = cutPos1;
                        cutPos1 = cutPos2;
                        cutPos2 = temp;
                    }
                    

                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(i < cutPos1)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else if(i < cutPos2)
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                            chromosomes[child2][i] = chromosomes[father][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        
                    }
                    break;

                case BinaryCrossoverMode.NPoints: 
                    int n = 1 + randomizer.Next(numberOfGenes / 2);
                    for(int i = 0; i < n; i++)
                    {
                        pos[i] = randomizer.Next(numberOfGenes);
                    }
                    Array.Sort(pos, 0, n); // sort the position

                    int currentPos = 0;
                    // Implementation of N-points-cut
                    for(int j = 0; j < n; j++)
                    {
                        for (int i = currentPos; i < numberOfGenes; i++)
                        {
                            if (i < pos[j])
                            {
                                if (j % 2 == 0)
                                {
                                    chromosomes[child1][i] = chromosomes[father][i];
                                    chromosomes[child2][i] = chromosomes[mother][i];
                                }
                                else
                                {
                                    chromosomes[child1][i] = chromosomes[mother][i];
                                    chromosomes[child2][i] = chromosomes[father][i];
                                }
                                
                            }
                            else
                            {
                                currentPos = i;
                                break;
                            }
                        }
                    }
                    break;
            }

            
        }

        /// <summary>
        /// An overriden version of "MutateAParent" in Binary GA.
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="childID"></param>
        /// <param name="mutatedFlag"></param>
        public override void MutateAParent(int parentID, int childID, bool[] mutatedFlag)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (mutatedFlag[i])
                {
                    if (chromosomes[parentID][i] == 1) chromosomes[childID][i] = 0;
                    else chromosomes[childID][i] = 1;
                }
                else
                {
                    chromosomes[childID][i] = chromosomes[parentID][i];
                }
            }
        }
    }
}
