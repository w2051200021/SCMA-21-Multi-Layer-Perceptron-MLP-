using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEChangGALibrary
{
    public class PermutationGA: GenericGASolver<int>
    {

        #region DATAFIELDS
        int[] m;
        int[] pos;
        int[] subtour1;
        int[] subtour2;
        PermutationCrossoverOperator crossoverMode = PermutationCrossoverOperator.PartialMappedX;
        PermutationMutationOperator mutationMode = PermutationMutationOperator.Inversion;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="optimizationType"></param>
        /// <param name="objectiveFunction"></param>
        /// <param name="hostPanelForGAMonitor"></param>
        public PermutationGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> objectiveFunction, Panel hostPanelForGAMonitor = null) :
            base(numberOfVariables, optimizationType, objectiveFunction, hostPanelForGAMonitor)
        {
            m = new int[numberOfVariables];
            pos = new int[numberOfVariables];
            subtour1 = new int[numberOfVariables];
            subtour2 = new int[numberOfVariables];
        }

        #region PROPERTIES
        [
            Category("Operation Mode"),
            Description("The crossover operations for permutation-encoded GA.")
        ]
        public PermutationCrossoverOperator CrossoverOperator
        {
            set
            {
                crossoverMode = value;
                OnParameterChanged();
            }
            get => crossoverMode;
        }

        [
            Category("Operation Mode"),
            Description("The mutation operations for permutation-encoded GA.")
        ]   
        public PermutationMutationOperator MutationOperator
        {
            set
            {
                mutationMode = value;
                OnParameterChanged();
            }
            get => mutationMode;
        }
        #endregion

        #region OVERRIDE
        public override void InitializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                    chromosomes[r][c] = c;

                ShuffleAnArray(chromosomes[r], numberOfGenes);
            }
               
                
        }

        public override void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            int i1 = randomizer.Next(numberOfGenes);
            int i2 = randomizer.Next(numberOfGenes + 1);
            int temp;
            if(i1 > i2)
            {
                temp = i1;
                i1 = i2;
                i2 = temp;
            }

            switch(CrossoverOperator)
            {
                case PermutationCrossoverOperator.PartialMappedX:
                    for(int i = 0; i < numberOfGenes; i++) m[i] = -1;
                    // Construct the partial map
                    for(int i = i1; i < i2; i++)
                    {
                        if (chromosomes[father][i] == chromosomes[mother][i]) continue; // no mapping
                        if(m[chromosomes[father][i]] == -1 & m[chromosomes[mother][i]] == -1)
                        {
                            m[chromosomes[father][i]] = chromosomes[mother][i];
                            m[chromosomes[mother][i]] = chromosomes[father][i];
                        }
                        else if(m[chromosomes[father][i]] == -1)
                        {
                            m[chromosomes[father][i]] = m[chromosomes[mother][i]];
                            m[m[chromosomes[mother][i]]] = chromosomes[father][i];
                            m[chromosomes[mother][i]] = -2;
                        }
                        else if (m[chromosomes[mother][i]] == -1)
                        {
                            m[chromosomes[mother][i]] = m[chromosomes[father][i]];
                            m[m[chromosomes[father][i]]] = chromosomes[mother][i];
                            m[chromosomes[father][i]] = -2;
                        }
                        else
                        {
                            m[m[chromosomes[mother][i]]] = m[chromosomes[father][i]];
                            m[m[chromosomes[father][i]]] = m[chromosomes[mother][i]];
                            m[chromosomes[father][i]] = -3;
                            m[chromosomes[mother][i]] = -3;
                        }
                    }
                    // Assign the gene to children
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(i >= i1 & i < i2)
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                            chromosomes[child2][i] = chromosomes[father][i];
                        }
                        else
                        {
                            if (m[chromosomes[father][i]] < 0)
                                chromosomes[child1][i] = chromosomes[father][i];
                            else
                                chromosomes[child1][i] = m[chromosomes[father][i]];
                            if (m[chromosomes[mother][i]] < 0)
                                chromosomes[child2][i] = chromosomes[mother][i];
                            else
                                chromosomes[child2][i] = m[chromosomes[mother][i]];
                        }
                    }

                    break;

                case PermutationCrossoverOperator.OrderX:
                    // Initialize the map
                    for(int i = 0; i < numberOfGenes; i++) m[i] = chromosomes[mother][i]; 
                    // Mark out the same selected parent 1 genes in the parent 2 
                    for (int i = i1; i < i2; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[father][i]);
                        m[markOutIndex] = -1;
                    }
                    // Assign the gene to children
                    int orderIndex = 0;
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(i >= i1 & i < i2)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                        }
                        else
                        {
                            while (m[orderIndex] == -1) orderIndex++;
                            chromosomes[child1][i] = m[orderIndex];
                            orderIndex++;
                        }
                    }

                    // Repeat the same steps starting from parent 2 and against parent 1 (using the same selected position)
                    for (int i = 0; i < numberOfGenes; i++) m[i] = chromosomes[father][i];
                    for (int i = i1; i < i2; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[mother][i]);
                        m[markOutIndex] = -1;
                    }
                    orderIndex = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i >= i1 & i < i2)
                        {
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else
                        {
                            while (m[orderIndex] == -1) orderIndex++;
                            chromosomes[child2][i] = m[orderIndex];
                            orderIndex++;
                        }
                    }

                    break;

                case PermutationCrossoverOperator.PositionBasedX:
                    // Randomly select a set of positions (genes)
                    int numberOfSelectedGenes = randomizer.Next(1, numberOfGenes);
                    // Initialize the map
                    for (int i = 0; i < numberOfGenes; i++) 
                    {
                        m[i] = chromosomes[mother][i];
                        pos[i] = i;
                    }
                    ShuffleAnArray(pos, numberOfGenes);
                    Array.Sort(pos, 0, numberOfSelectedGenes);
                    // mark out the same selected parent 1 genes in the parent 2 
                    for (int i = 0; i < numberOfSelectedGenes; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[father][pos[i]]);
                        m[markOutIndex] = -1;
                    }
                    // Assign the gene to children
                    orderIndex = 0;
                    int positionIndex = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i == pos[positionIndex] & positionIndex < numberOfSelectedGenes)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            positionIndex++;
                        }
                        else
                        {
                            while (m[orderIndex] == -1) orderIndex++;
                            chromosomes[child1][i] = m[orderIndex];
                            orderIndex++;
                        }
                    }

                    // Repeat the same steps starting from parent 2 and against parent 1
                    // (using the same selected positions)

                    // Initialize the map
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        m[i] = chromosomes[father][i];
                    }
                    // mark out the same selected parent 1 genes in the parent 2 
                    for (int i = 0; i < numberOfSelectedGenes; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[mother][pos[i]]);
                        m[markOutIndex] = -1;
                    }
                    // Assign the gene to children
                    orderIndex = 0;
                    positionIndex = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i == pos[positionIndex] & positionIndex < numberOfSelectedGenes)
                        {
                            chromosomes[child2][i] = chromosomes[mother][i];
                            positionIndex++;
                        }
                        else
                        {
                            while (m[orderIndex] == -1) orderIndex++;
                            chromosomes[child2][i] = m[orderIndex];
                            orderIndex++;
                        }
                    }

                    break;

                case PermutationCrossoverOperator.OrderBasedX:
                    // Randomly select a set of positions (genes)
                    numberOfSelectedGenes = randomizer.Next(1, numberOfGenes);
                    // Initialize the map
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        m[i] = chromosomes[mother][i];
                        pos[i] = i;
                    }
                    ShuffleAnArray(pos, numberOfGenes);
                    Array.Sort(pos, 0, numberOfSelectedGenes);
                    // mark out the same selected parent 1 genes in the parent 2 
                    for (int i = 0; i < numberOfSelectedGenes; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[father][pos[i]]);
                        m[markOutIndex] = -1;
                    }
                    // Assign the gene to children
                    positionIndex = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if(m[i] == -1)
                        {
                            chromosomes[child1][i] = chromosomes[father][pos[positionIndex]];
                            positionIndex++;
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                        }
                    }

                    // Repeat the same steps starting from parent 2 and against parent 1
                    // (using the same selected positions)

                    // Initialize the map
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        m[i] = chromosomes[father][i];
                    }
                    // mark out the same selected parent 1 genes in the parent 2 
                    for (int i = 0; i < numberOfSelectedGenes; i++)
                    {
                        int markOutIndex = Array.IndexOf(m, chromosomes[mother][pos[i]]);
                        m[markOutIndex] = -1;
                    }
                    // Assign the gene to children
                    positionIndex = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (m[i] == -1)
                        {
                            chromosomes[child2][i] = chromosomes[mother][pos[positionIndex]];
                            positionIndex++;
                        }
                        else
                        {
                            chromosomes[child2][i] = chromosomes[father][i];
                        }
                    }

                    break;

                case PermutationCrossoverOperator.CycleX:
                    int cycleIndex = 0;
                    bool searchCycle = true;
                    for (int i = 0; i < numberOfGenes; i++) pos[i] = 0;
                    while(searchCycle)
                    {
                        for (int i = 0; i < numberOfGenes; i++)
                        {
                            if (chromosomes[father][i] == chromosomes[mother][pos[cycleIndex]])
                            {
                                cycleIndex++;
                                pos[cycleIndex] = i;

                                if (chromosomes[mother][i] == chromosomes[father][0])
                                    searchCycle = false;

                                break;
                            }
                        }
                    }
                    
                    Array.Sort(pos, 0, cycleIndex + 1);
                    positionIndex = 0;
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(i == pos[positionIndex] & positionIndex <= cycleIndex)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                            positionIndex++;
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                            chromosomes[child2][i] = chromosomes[father][i];
                        }

                    }
                    break;

                case PermutationCrossoverOperator.SubtourExchange:
                    int subtourLength = numberOfGenes / 2;
                    bool searchSubtour = true;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        pos[i] = 0;
                    }
                    while (searchSubtour)
                    {
                        for (int i = 0; i <= numberOfGenes - subtourLength; i++)
                        {
                            for (int k = 0; k < numberOfGenes; k++)
                            {
                                subtour1[k] = 0;
                                subtour2[k] = 0;
                            }
                            for (int k = i; k < i + subtourLength; k++)
                            {
                                subtour1[k - i] = chromosomes[father][k];
                            }
                            Array.Sort(subtour1, 0, subtourLength);
                            for (int j = 0; j <= numberOfGenes - subtourLength; j++)
                            {
                                for (int k = j; k < j + subtourLength; k++)
                                {
                                    subtour2[k - j] = chromosomes[mother][k];
                                }
                                Array.Sort(subtour2, 0, subtourLength);
                                if (subtour1.SequenceEqual(subtour2))
                                {
                                    pos[0] = i; // start point of subtour 1
                                    pos[1] = j; // start point of subtour 2
                                    break;
                                }
                            }
                            if (subtour1.SequenceEqual(subtour2))
                            {
                                searchSubtour = false;
                                break;
                            }
                        }
                        if (!subtour1.SequenceEqual(subtour2))
                        {
                            subtourLength--;
                        }
                    }

                    int positionIndex1 = 0;
                    int positionIndex2 = 0;
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if (i >= pos[0] & i < pos[0] + subtourLength)
                        {
                            chromosomes[child1][i] = chromosomes[mother][pos[1] + positionIndex1];
                            positionIndex1++;
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                        }

                        if (i >= pos[1] & i < pos[1] + subtourLength)
                        {
                            chromosomes[child2][i] = chromosomes[father][pos[0] + positionIndex2];
                            positionIndex2++;
                        }
                        else
                        {
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                    }

                    break;
            }
        }

        public override void MutateAParent(int parentID, int childID, bool[] mutatedFlag)
        {
            int i1 = randomizer.Next(numberOfGenes);
            int i2 = randomizer.Next(numberOfGenes);
            int temp;
            if (i1 > i2)
            {
                temp = i1;
                i1 = i2;
                i2 = temp;
            }

            switch (MutationOperator)
            {
                case PermutationMutationOperator.Inversion:
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(i >= i1 & i <= i2)
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i1 + (i2 - i)];
                        }
                        else
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i];
                        }
                    }
                    break;

                case PermutationMutationOperator.Insersion:
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if (i >= i1 & i < i2)
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i + 1];
                        }
                        else if (i == i2)
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i1];
                        }
                        else
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i];
                        }
                    }
                    break;

                case PermutationMutationOperator.Displacement:
                    int insertPosition = randomizer.Next(numberOfGenes - (i2 - i1));
                    int positionIndex1 = 0;
                    int positionIndex2 = 0;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (insertPosition <= i1)
                        {
                            if (i >= insertPosition & i <= insertPosition + i2 - i1)
                            {
                                chromosomes[childID][i] = chromosomes[parentID][i1 + positionIndex1];
                                positionIndex1++;
                            }
                            else if (i > insertPosition + i2 - i1 & i <= i2)
                            {
                                chromosomes[childID][i] = chromosomes[parentID][insertPosition + positionIndex2];
                                positionIndex2++;
                            }
                            else
                            {
                                chromosomes[childID][i] = chromosomes[parentID][i];
                            }
                        }
                        else
                        {
                            if (i >= insertPosition & i <= insertPosition + i2 - i1)
                            {
                                chromosomes[childID][i] = chromosomes[parentID][i1 + positionIndex1];
                                positionIndex1++;
                            }
                            else if (i >= i1 & i < insertPosition)
                            {
                                chromosomes[childID][i] = chromosomes[parentID][i2 + 1 + positionIndex2];
                                positionIndex2++;
                            }
                            else
                            {
                                chromosomes[childID][i] = chromosomes[parentID][i];
                            }
                        }

                    }
                    break;

                case PermutationMutationOperator.ReciprocalExchange:
                    for(int i = 0; i < numberOfGenes; i++)
                    {
                        if (i == i1)
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i2];
                        }
                        else if (i == i2)
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i1];
                        }
                        else
                        {
                            chromosomes[childID][i] = chromosomes[parentID][i];
                        }
                    }
                    break;
            }
        }
        #endregion




        /// <summary>
        /// Canonical crossover operators,
        /// </summary>
        public enum PermutationCrossoverOperator
        {
            PartialMappedX, OrderX, PositionBasedX, OrderBasedX, CycleX, SubtourExchange
        }

        public enum PermutationMutationOperator
        {
            Inversion, Insersion, Displacement, ReciprocalExchange
        }
    }
}
