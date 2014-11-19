namespace _02.FindMinimumCost
{
    using System;

    public class FindCost
    {
        private const double CostReplace = 1;
        private const double CostDelete = 0.9;
        private const double CostInsert = 0.8;

        private static double[,] costs;

        public static void Main ()
        {
            Console.WriteLine("Enter first word: ");
            var firstWord = Console.ReadLine();

            Console.WriteLine("Second word: ");
            var secWord = Console.ReadLine();

            var minCost = Compute(firstWord, secWord);
            Console.WriteLine();
            PrintTable();
            Console.WriteLine("Minimum cost for changing the words: " + minCost);
        }

        private static double Compute (string firstWord, string secondWord)
        {
            var firstLength = firstWord.Length;
            var secondLength = secondWord.Length;
            costs = new double[firstLength + 1, secondLength + 1];

            for (int row = 0; row <= firstLength; row++)
            {
                costs[row, 0] = row * CostDelete;
            }

            for (int col = 0; col <= secondLength; col++)
            {
                costs[0, col] = col * CostInsert;
            }

            for (int row = 1; row <= firstLength; row++)
            {
                for (int col = 1; col <= secondLength; col++)
                {
                    var replaceCost = (secondWord[col - 1] == firstWord[row - 1]) ? 0 : CostReplace;

                    var delete = costs[row - 1, col] + CostDelete;
                    var replace = costs[row - 1, col - 1] + replaceCost;
                    var insert = costs[row, col - 1] + CostInsert;

                    costs[row, col] = Math.Min(Math.Min(insert, delete), replace);
                }
            }

            return costs[firstLength, secondLength];
        }

        static void PrintTable ()
        {
            for (int row = 0; row < costs.GetLength(0); row++)
            {
                for (int col = 0; col < costs.GetLength(1); col++)
                {
                    Console.Write("{0, 4}  |", costs[row, col]);
                }

                Console.WriteLine();
                Console.WriteLine(new string('_', costs.GetLength(1) * 7));
            }

            Console.WriteLine();
        }
    }
}
