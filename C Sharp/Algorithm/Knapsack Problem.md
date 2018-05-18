

# Knapsack Problem

The knapsack problem or rucksack problem is a problem in combinatorial optimization: 
Given a set of items, each with a weight and a value, determine the number of each 
item to include in a collection so that the total weight is less than or equal to 
a given limit and the total value is as large as possible.

The problem often arises in resource allocation where there are financial constraints and is studied in fields such as combinatorics, computer science, complexity theory, cryptography, applied mathematics, and daily fantasy sports.

[Read more for reference](https://en.wikipedia.org/wiki/Knapsack_problem)
``` csharp
void Main()
{
	int[] value = { 10, 50, 70 };
    int[] weight = { 10, 20, 30 };
    int capacity = 40;
    int itemsCount = 3;
 
    int result = KnapSack(capacity, weight, value, itemsCount);
    Console.WriteLine(result);
}

// KnapSack stack
public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
{
  int[,] K = new int[itemsCount + 1, capacity + 1];

  for (int i = 0; i <= itemsCount; ++i)
  {
      for (int w = 0; w <= capacity; ++w)
      {
          if (i == 0 || w == 0)
              K[i, w] = 0;
          else if (weight[i - 1] <= w)
              K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
          else
              K[i, w] = K[i - 1, w];
      }
  }

  return K[itemsCount, capacity];
}
```
