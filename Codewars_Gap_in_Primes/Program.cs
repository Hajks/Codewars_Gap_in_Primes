using System;
using System.Collections.Generic;
using System.Linq;

//##TASK DESCRIPTION##
//    The prime numbers are not regularly spaced. For example from 2 to 3 the gap is 1. From 3 to 5 the gap is 2. From 7 to 11 it is 4. Between 2 and 50 we have the following pairs of 2-gaps primes: 3-5, 5-7, 11-13, 17-19, 29-31, 41-43

//    A prime gap of length n is a run of n-1 consecutive composite numbers between two successive primes (see: http://mathworld.wolfram.com/PrimeGaps.html).

//    We will write a function gap with parameters:

//    g (integer >= 2) which indicates the gap we are looking for

//    m (integer > 2) which gives the start of the search (m inclusive)

//    n (integer >= m) which gives the end of the search (n inclusive)

//    In the example above gap(2, 3, 50) will return [3, 5] or (3, 5) or {3, 5} which is the first pair between 3 and 50 with a 2-gap.

//So this function should return the first pair of two prime numbers spaced with a gap of g between the limits m, n if these numbers exist otherwise nil or null or None or Nothing (depending on the language).

//In C++ return in such a case {0, 0}. In F# return [||]. In Kotlin return []

//#Examples: gap(2, 5, 7) --> [5, 7] or (5, 7) or {5, 7}

//gap(2, 5, 5) --> nil. In C++ {0, 0}. In F# [||]. In Kotlin return[]`

//gap(4, 130, 200) --> [163, 167] or (163, 167) or {163, 167}

//([193, 197] is also such a 4-gap primes between 130 and 200 but it's not the first pair)

//gap(6,100,110) --> nil or {0, 0} : between 100 and 110 we have 101, 103, 107, 109 but 101-107is not a 6-gap because there is 103in between and 103-109is not a 6-gap because there is 107in between.

//Note for Go
//For Go: nil slice is expected when there are no gap between m and n. Example: gap(11,30000,100000) --> nil

namespace Codewars_Gap_in_Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            //MySolution
            long[] Gap(int g, long m, long n)
            {
                List<long> GapNumbers = new List<long>();

                for (int i = (int)m; i < n; i++)
                {
                    if(IsPrime(i))
                        GapNumbers.Add(i);
                    if (GapNumbers.Count == 2)
                    {
                        if (GapNumbers.ElementAt(1) - GapNumbers.ElementAt(0) == g)
                            break;
                        else
                            GapNumbers.RemoveAt(0);
                    }
                }
                
                bool IsPrime(int num)
                {
                    for (int i = 2; i <= num/2; i++)
                    {
                        if (num % i == 0)
                            return false;
                    }

                    return true;
                }
                if (GapNumbers.Count == 2)
                return GapNumbers.ToArray();
                else
                    return null;
            }

            Gap(4, 100, 110);
        }
        //Codewars solution + code review for myself
        public static long[] Gap2(int g, long m, long n) 
        {
            long[] p = { 0, 0 };
            for (long i = m; i < n; i++)
            {
                if (IsPrime(i))
                {
                    p[0] = p[1];
                    p[1] = i;
                    if (p[1] - p[0] == g) return p; //If our numbers are correct we return them. Otherwise we return null. Solution simillar to mine.
                }
            }
            return null;
        }
    
        private static bool IsPrime(long n) // We define if number is prime or not. 
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            for(int i = 5; i * i <= n; i += 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            return true;
        }
    }
}
