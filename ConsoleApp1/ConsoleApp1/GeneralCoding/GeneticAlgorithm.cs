using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     Genetic Algorithms
Background
Genetic algorithms (GA) are a useful tool for machine learning. GA is a general algorithm paradigm that offers a way to find or approximate an answer to problems that may be otherwise intractible.

For an example problem, given the list [1,2,3,4,5,6,7,8,9,10], find a way to partition the list into two lists such that the sum of one list is 38 and the product of the other list is 210. A brute force solution can work by finding the divisors of 210. However, a this approach quickly becomes intractable on large lists.

Genetic algorithms are based on the idea that you can create a chromosome that represents a potential solution to the problem. One way of representing such a chromosome is with a binary string of digits. In our example problem above, we could represent one chromosome as 0101110000, and decide that 0 means that the corresponding number is in the "sum" pile and 1 means it is in the "product" pile. The 0101110000 chromosome gives us 1+3+7+8+9+10=38 and 2*4*5*6=240--a potential candidate solution with characteristics of our desired solution.

A population is a collection of chromosomes. The "genetic" part of the algorithm's name comes from the fact that the algorithm uses evolution-based concepts to improve the fitness (proximity to the target solution) of the chromosomes.

The first step in the algorithm is to generate a population of random chromosomes. Calculate the fitness of those chromosomes in whatever way fits the problem. In the problem at hand, the goal is to minimize the absolute difference of the sum from the ideal sum and likewise for the product. A fitness score for a chromosome can be the "distance" to the target solution:

sqrt((chromosome sum - ideal sum)^2 +
     (chromosome product - ideal product)^2)
The closer this score is to 0 (that is, the closer the chromosome is to ideal), the better the fitness. Let our fitness be a decimal in the range 0-1 given by the formula 1 / (score + 1). A fitness of 0 is competely incorrect and a fitness of 1 means an exact answer has been found.

The evolutionary step involves iteratively inspecting the population and selecting chromosomes by fitness which should live in the next generation. Each iteration proceeds as follows:

Select two chromosomes from the original population. This is not done purely randomly. This is done using roulette wheel selection, where the chances of picking a chromosome are proportional to its fitness.
With a probability probCrossover, a crossover occurs between these two new chromosomes. A crossover involves selecting a random cutoff index in two equal-length chromosomes and swapping their tails. For example, a crossover at the 3rd bit between 01011010 and 11110110 results in 010 10110 and 111 11010.
With a probability probMutation, a mutation can occur at any bit along each new chromosome; the mutation rate is typically very small. For the problem at hand, a mutation entails flipping a bit.
Add these two (potentially modified) chromosomes into the new population and repeat steps 1-3 until the new population is the same size as the original one.
After performing this evoltionary process iteratively, a point will be reached when a chromosome has attained the target fitness. For this challenge, terminate when a chromosome has a fitness of 1 and return this chromosome.

Your task
Your task for this challenge is to complete the function

findBinaryString(getFitness, chromosomeLength, 
                 probMutation, probCrossover)
The first parameter, getFitness is a provided function that computes the fitness of a chromosome.

chromosomeLength is a number of the bits in the target chromosome.

probMutation and probCrossover are provided floating point numbers that represent the chance of their respective modification occuring.

One internal parameter available to you is the size of your population. A number between 50 and 100 chromosomes is reasonable.

findBinaryGeneticString should return a binary string of '0' and '1' of chromosomeLength that has a fitness score of 1 as computed by getFitness
    */
    public class GeneticAlgorithm
    {
        private Random random = new Random();

        public string Generate(int length)
        {
            string ret = "";
            for (int i = 0; i < length; ++i)
            {
                if (random.Next(0, 2) == 1)
                {
                    ret += "1";
                }
                else
                {
                    ret += "0";
                }
            }
            return ret;
        }

        public string Select(IEnumerable<string> population, IEnumerable<double> fitnesses, double sum = 0.0)
        {
            // fitness proportionate selection.

            var fitArr = fitnesses.ToArray();
            if (sum == 0.0)
            {
                foreach (var fit in fitnesses)
                {
                    sum += fit;
                }
            }

            // normalize.
            for (int i = 0; i < fitArr.Length; ++i)
            {
                fitArr[i] /= sum;
            }

            var popArr = population.ToArray();

            Array.Sort(fitArr, popArr);

            sum = 0.0;

            var accumFitness = new double[fitArr.Length];

            // calculate accumulated normalized fitness values.
            for (int i = 0; i < accumFitness.Length; ++i)
            {
                sum += fitArr[i];
                accumFitness[i] = sum;
            }

            var val = random.NextDouble();

            for (int i = 0; i < accumFitness.Length; ++i)
            {
                if (accumFitness[i] > val)
                {
                    return popArr[i];
                }
            }
            return "";
        }

        public string Mutate(string chromosome, double probability)
        {
            string ret = "";
            double randomVariable = 0.0;
            foreach (char c in chromosome)
            {
                randomVariable = random.NextDouble();
                if (randomVariable < probability)
                {
                    if (c == '1')
                    {
                        ret += "0";
                    }
                    else
                    {
                        ret += "1";
                    }
                }
                else
                {
                    ret += c;
                }
            }
            return ret;
        }

        public IEnumerable<string> Crossover(string chromosome1, string chromosome2)
        {
            int randomPosition = random.Next(0, chromosome1.Length);
            string newChromosome1 = chromosome1.Substring(randomPosition) + chromosome2.Substring(0, randomPosition);
            string newChromosome2 = chromosome2.Substring(randomPosition) + chromosome1.Substring(0, randomPosition);
            return new string[] { newChromosome1, newChromosome2 };
        }

        public string Run(Func<string, double> fitness, int length, double crossoverProbability, double mutationProbability, int iterations = 100)
        {
            int populationSize = 500;
            // run population is population being generated.
            // test population is the population from which samples are taken.
            List<string> testPopulation = new List<string>(), runPopulation = new List<string>();
            string one = "", two = "";
            var randDouble = 0.0;

            // construct initial population.
            while (testPopulation.Count < populationSize)
            {
                testPopulation.Add(Generate(length));
            }

            var fitnesses = new double[testPopulation.Count];

            double sum = 0.0;

            // continuously generate populations until number of iterations is met.
            for (int iter = 0; iter < iterations; ++iter)
            {
                runPopulation = new List<string>();

                // calculate fitness for test population.
                sum = 0.0;
                fitnesses = new double[testPopulation.Count];
                for (int i = 0; i < fitnesses.Length; ++i)
                {
                    fitnesses[i] = fitness(testPopulation[i]);
                    sum += fitnesses[i];
                }

                // a population doesn't need to be generated for last iteration.
                // (using test population)
                if (iter == iterations - 1) break;

                while (runPopulation.Count < testPopulation.Count)
                {

                    one = Select(testPopulation, fitnesses, sum);
                    two = Select(testPopulation, fitnesses, sum);

                    // determine if crossover occurs.
                    randDouble = random.NextDouble();
                    if (randDouble <= crossoverProbability)
                    {
                        var stringArr = Crossover(one, two).ToList();
                        one = stringArr[0];
                        two = stringArr[1];
                    }

                    one = Mutate(one, mutationProbability);
                    two = Mutate(two, mutationProbability);

                    runPopulation.Add(one);
                    runPopulation.Add(two);
                }

                testPopulation = runPopulation;
            }

            // find best-fitting string.
            var testSort = testPopulation.ToArray();
            var fitSort = fitnesses.ToArray();

            Array.Sort(fitSort, testSort);

            return testSort[testSort.Length - 1];
        }

        private static Func<string, double> Fitness(string goal)
        {
            return new Func<string, double>(chromosome => {
                double total = 0;

                for (int i = 0; i < goal.Length; i++)
                {
                    if (goal[i] != chromosome[i])
                    {
                        total++;
                    }
                }

                return 1.0 / (total + 1);
            });
        }
        public static void Main(string[] args)
        {
            int length = 10;
            var random = new Random();
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
            }

            var goal = sb.ToString();
            Func<string, double> f = Fitness(goal);
            GeneticAlgorithm ql = new GeneticAlgorithm();
            string run=ql.Run(f, length, 0.6, 0.002);
            Console.WriteLine(run);
        }
    }
}