# Permutations

In mathematics, the notion of permutation relates to the act of arranging all the members of a set into some sequence or order, or if the set is already ordered, rearranging (reordering) its elements, a process called permuting. These differ from combinations, which are selections of some members of a set where order is disregarded. For example, written as tuples, there are six permutations of the set {1,2,3}, namely: (1,2,3), (1,3,2), (2,1,3), (2,3,1), (3,1,2), and (3,2,1). These are all the possible orderings of this three element set. As another example, an anagram of a word, all of whose letters are different, is a permutation of its letters. In this example, the letters are already ordered in the original word and the anagram is a reordering of the letters.

[Read more for reference](https://en.wikipedia.org/wiki/Permutation)
 
``` csharp
// Permutations & Combinations
void Main()
{	 
	String str = "ABC@";
	int n = str.Length;
    permutation(str, 0, n-1);
}

// Define other methods and classes here
/**
* permutation function
* @param str string to calculate permutation for
* @param l starting index
* @param r end index
*/
private void permutation(String str, int l, int r)
{		
	if (l == r)
	{
		Console.WriteLine(str);
	}
	else
	{
	    for (int i = l; i <= r; i++)
	    {
		str = swap(str,l,i);
		permutation(str, l+1, r);
		str = swap(str,l,i);
	    }
	}
}
 
/**
 * Swap Characters at position
 * @param a string value
 * @param i position 1
 * @param j position 2
 * @return swapped string
 */
public String swap(String a, int i, int j)
{
	char temp;
	char[] charArray = a.ToCharArray();
	temp = charArray[i] ;
	charArray[i] = charArray[j];
	charArray[j] = temp;
	return new string(charArray);
}
```
