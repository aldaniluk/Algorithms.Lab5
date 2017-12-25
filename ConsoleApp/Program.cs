using KunAlgorithm;
using StableMarriageProblem;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MarriageProblem
            Human[] men = new Human[]
                {
                new Human(new int[]{2,1,3,4}),
                new Human(new int[]{4,1,2,3}),
                new Human(new int[]{1,3,2,4}),
                new Human(new int[]{4,3,1,2})
                };
            Human[] women = new Human[]
            {
                new Human(new int[]{1,3,2,4}),
                new Human(new int[]{3,4,1,2}),
                new Human(new int[]{4,2,3,1}),
                new Human(new int[]{3,2,1,4})
            };

            Pair[] stablePairs = StableMarriage.Get(women, men);
            foreach (var p in stablePairs)
            {
                Console.WriteLine($"{p.Man} {p.Woman}");
            }
            #endregion

            Console.WriteLine("\n\n\n");

            #region Matchings
            int[,] arr1 = new int[,]
            {
                {0,0,0,1,1,0},
                {0,0,0,0,1,1},
                {0,0,0,1,1,0},
                {1,0,1,0,0,0},
                {1,1,1,0,0,0},
                {0,1,0,0,0,0}
            };
            Graph g1 = new Graph(arr1);

            List<Tuple<int,int>> matching1 = MaxMatching.Get(g1);

            for (int i = 0; i < matching1.Count; i++)
            {
                Console.Write($"{matching1[i].Item1} {matching1[i].Item2}   ");
            }
            Console.WriteLine();

            #endregion
        }
    }
}
