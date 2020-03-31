using System;
using System.Linq;

namespace snake
{
    public class Generation
    {
        /**
         * The array containing all the bots of the population
         */
        private Bot[] generation;

        /**
         * Create a new random Generation of the size given in parameter,
         * all playing on a 8 * 8 Grid
         */
        public Generation(int size)
        {
            generation = new Bot[size];
            for (int i = 0; i < size; ++i)
                generation[i] = new Bot(8, 8);
        }

        /**
         * Sort bots by decreasing order of fitness
         * FIXME
         */
        
        static int Partition(int[] array, int low,
            int high)
        {
            int pivot = array[high];

            int lowIndex = (low - 1);
            
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        static void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }
        public static void switchy(Bot[] arr, int a, int b)
        {
            Bot backup = arr[b];
            arr[b] = arr[a];
            arr[a] = backup;
        }
        public void Sort()
        {
            for (int i = 1; i < generation.Length; i++)
            {
                for (int i1 = i; i1 > 0; i1--)
                {
                    if (generation[i1 - 1].Score <= generation[i1].Score)
                    {
                        switchy(generation, i1, i1-1);
                    }
                }
            }
        }

        /**
         * HINT: Return an array of the n best bots of the generation
         * FIXME
         */
        public Bot[] GetBestBots(int n)
        {
            Sort();
            Bot[] arr = new Bot[n];
            if (generation.Length <= n)
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i] = generation[i];
                }   
            }
            return arr;
        }

        /**
         * HINT: Bot selection for the next generation,
         * the fitness parameter represents the sum of the scores
         * of every bot of the generation
         * FIXME
         */
        public Bot SelectBot(long fitness_sum)
        {
            throw new NotImplementedException();
        }

        /**
         * HINT: Bot selection for the next generation, no parameter,
         * naive implementation
         * FIXME
         */
        public Bot SelectBot()
        {
            throw new NotImplementedException();
        }

        /**
         * HINT: Copy, crossover and mutate the previous generation bots into
         * the gen array in parameter
         * FIXME
         */
        public void Duplicate(Bot[] gen)
        {
            throw new NotImplementedException();
        }

        /**
         * Create a new generation, if the parameter is true,
         * the best bot of the previous generation must play a new game and be
         * displayed on stdout
         * FIXME
         */
        public void NewGen(bool display_best = true)
        {
            Sort();
            Bot[] bestbots = GetBestBots(generation.Length / 10);
            Bot[] newgen = new Bot[generation.Length];
            Random random = new Random();
            for (int i = 0; i < generation.Length; i++)
            {
                int a = random.Next(bestbots.Length);
                newgen[i] = bestbots[a];
            }
            
            generation = newgen;
        }

        /**
         * Each bot of the population play a game
         */
        public void Play(bool display = true)
        {
            for (int i = 0; i < generation.Length; ++i)
                generation[i].Play(display);
        }

        /**
         * Train a population for nbGen generations
         * FIXME
         */
        public void Train(int nbGen)
        {
            for (int i = 0; i < nbGen; i++)
            {
                Play();
                NewGen();
            }
        }

        /**
         * Create a generation with 'size' Bots all restores from the file
         * given in parameter
         */
        public Generation(int size, string path)
        {
            generation = new Bot[size];
            Bot saved = new Bot(path);
            for (int i = 0; i < size; i++)
                generation[i] = new Bot(saved, false);
        }
    }
}
