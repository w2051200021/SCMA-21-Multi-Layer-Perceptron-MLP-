using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEChangGALibrary
{
    public delegate double CostFunction(int[] aSolution);
    public class BrutalForceMethod
    {
        protected int numberOfJobs;
        protected int numberOfCombinations;
        protected int solutionID = 0;
        protected int[] solution;
        protected int[] bestSolution;
        protected double shortestTime;
        protected CostFunction costFunction;
        protected OptimizationType optimizationType;
        protected BFMonitor theMonitor = null;
        protected StringBuilder sb;

        public int NumberOfJobs
        {
            get => numberOfJobs;
        }

        public BrutalForceMethod(int numberOfJobs, OptimizationType optimizationType, CostFunction costFunction, Panel hostPanelForBFMonitor = null)
        {
            this.numberOfJobs = numberOfJobs;
            this.costFunction = costFunction;
            numberOfCombinations = factorial(numberOfJobs);

            solution = new int[numberOfJobs];
            bestSolution = new int[numberOfJobs];
            

            for(int i = 0; i < numberOfJobs; i++)
            {
                solution[i] = i;
                bestSolution[i] = i;
            }
            shortestTime = costFunction(bestSolution);

            if (hostPanelForBFMonitor != null)
            {
                // create monitor object and add it to the host panel
                theMonitor = new BFMonitor(this);
                hostPanelForBFMonitor.Controls.Clear();
                hostPanelForBFMonitor.Controls.Add(theMonitor);
                theMonitor.Dock = DockStyle.Fill;
                theMonitor.lsb_BrutalForce.Items.Clear();
                if(numberOfCombinations > 0) theMonitor.lb_numberOfCombinations.Text = $"Total Number of Combinations:  {numberOfCombinations}";
                else theMonitor.lb_numberOfCombinations.Text = $"Total Number of Combinations:  Overflow ...";
                theMonitor.lb_bestSolution.Text = $"The Best Solution ( job i assign to machine j ):  ";
                theMonitor.lb_shortestTime.Text = $"The Shortest Setup Time:  ";
                sb = new StringBuilder();
            }
        }

        public int factorial(int n)
        {
            int result = 1;
            for(int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public void ShowAllCombinations()
        {
            solutionID = 0;
            Permutation(solution, 0, solution.Length - 1);

            sb.Clear();
            for (int i = 0; i < numberOfJobs; i++) sb.Append($"{bestSolution[i] + 1} ");
            theMonitor.lb_bestSolution.Text = $"The Best Solution ( job i assign to machine j ):  {sb.ToString()}";
            theMonitor.lb_shortestTime.Text = $"The Shortest Setup Time:  {shortestTime}";
        }

        public void Permutation(int[] ASolution, int pos1, int pos2)
        {
            if(pos1 == pos2)
            {
                sb.Clear();
                sb.Append($"No.{solutionID.ToString("0000000")}  ");
                sb.Append($"Solution:  ");
                for(int i = 0; i < numberOfJobs; i++)
                {
                    sb.Append($"{solution[i] + 1} ");
                }
                sb.Append($"  Total Setup Time: {costFunction(ASolution):0.000}");
                theMonitor.lsb_BrutalForce.Items.Add(sb.ToString());

                if(costFunction(solution) < shortestTime)
                {
                    shortestTime = costFunction(solution);
                    for(int i = 0; i < numberOfJobs; i++)
                    {
                        bestSolution[i] = solution[i];
                    }
                }

                solutionID++;
            }
            else
            {
                for(int i = pos1; i <= pos2; i++)
                {
                    swap(ASolution, pos1, i);
                    Permutation(ASolution, pos1 + 1, pos2);
                    swap(ASolution, pos1, i);
                }
            }
        }
        
        public void swap(int[] ASolution, int pos1, int pos2)
        {
            int temp;
            temp = ASolution[pos1];
            ASolution[pos1] = ASolution[pos2];
            ASolution[pos2] = temp;
        }
    }
}
