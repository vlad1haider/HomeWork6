using System.Collections.Generic;
using System.Threading;

public class NumberGenerator
{
    public IEnumerable<int> GenerateNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Thread.Sleep(500); 
            yield return i; 
        }
    }
}