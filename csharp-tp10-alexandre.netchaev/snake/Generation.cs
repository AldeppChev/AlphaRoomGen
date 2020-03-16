using System;

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
        public void Sort()
        {
            throw new NotImplementedException();
        }
        
        /**
         * HINT: Return an array of the n best bots of the generation
         * FIXME
         */
        public Bot[] GetBestBots(int n)
        {
            throw new NotImplementedException();
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
        public void NewGen(bool display_best = false)
        {
            throw new NotImplementedException();
        }

        /**
         * Each bot of the population play a game
         */
        public void Play(bool display = false)
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
            throw new NotImplementedException();
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
