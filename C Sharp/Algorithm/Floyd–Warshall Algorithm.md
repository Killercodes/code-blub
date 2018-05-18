# Floyd–Warshall Algorithm
> Determines the shortest paths in a weighted graph with positive or negative edge weights

The Floyd–Warshall algorithm is an algorithm for finding shortest paths in a weighted graph with positive or negative edge weights (but with no negative cycles).[1][2] A single execution of the algorithm will find the lengths (summed weights) of the shortest paths between all pairs of vertices. Although it does not return details of the paths themselves, it is possible to reconstruct the paths with simple modifications to the algorithm. Versions of the algorithm can also be used for finding the transitive closure of a relation {\displaystyle R} **R**, or (in connection with the Schulze voting system) widest paths between all pairs of vertices in a weighted graph
``` csharp
class FloydWarshallAlgo
    {
 
        public const int cst = 9999;
 
        private static void Print(int[,] distance, int verticesCount)
        {
            Console.WriteLine("Shortest distances between every pair of vertices:");
 
            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == cst)
                        Console.Write("cst".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7));
                }
 
                Console.WriteLine();
            }
        }
 
        public static void FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];
 
            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                    distance[i, j] = graph[i, j];
 
            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }
 
            Print(distance, verticesCount);
        }
        static void Main(string[] args)
        {
            int[,] graph = {
                         { 0,   6,  cst, 11 },
                         { cst, 0,   4, cst },
                         { cst, cst, 0,   2 },
                         { cst, cst, cst, 0 }
                           };
 
            FloydWarshall(graph, 4);
        }
    }
```
