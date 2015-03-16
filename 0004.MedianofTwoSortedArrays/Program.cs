using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0004.MedianofTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 2,3,4 };
            int[] B = new int[] { 1 };
            System.Console.WriteLine(FindMedianSortedArrays(A, B));
            /*
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 1));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 2));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 3));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 4));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 5));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 6));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 7));
            System.Console.WriteLine(FindKthLowestInTwoSortedArrays(A, B, 8));
             */

        }

        //Find k-th lowest
        //k is based on 1, [1,m+n]
        static public int FindKthLowestInTwoSortedArrays(int[] A, int[] B,int k)
        {
            if ((A == null && k > B.Count()) || (B == null && k > A.Count()) || (k > A.Count() + B.Count()))
            {
                throw new Exception("Error Kth");
            }
            if (A == null || A.Count() == 0)
            {
                return B[k - 1];
            }
            else if (B == null || B.Count() == 0)
            {
                return A[k - 1];
            }

            int s1 = 0, e1 = A.Count() - 1;
            int s2 = 0, e2 = B.Count() - 1;
            int m1 = 0, m2 = 0, len = 0;
            while (s1 <= e1 && s2 <= e2)
            {
                //A: smallpart [s1,m1], bigpart [m1+1,e1]
                //B: smallpart [s2,m2], bigpart [m2+1,e2]
                m1 = (s1 + e1) / 2;
                m2 = (s2 + e2) / 2;
                len = (m1 - s1 + 1) + (m2 - s2 + 1);

                if (k >= len)
                {
                    //Drop one small part
                    if (A[m1] <= B[m2])
                    {
                        k -= (m1 - s1 + 1);
                        s1 = m1 + 1;
                    }
                    else
                    {
                        k -= (m2 - s2 + 1);
                        s2 = m2 + 1;
                    }
                }
                else
                {
                    //Drop one big part
                    if (A[m1] <= B[m2])
                    {
                        e2 = m2 - 1;
                    }
                    else
                    {
                        e1 = m1 - 1;
                    }
                }
            }

            if (s1 > e1)
            {
                return B[s2 + k - 1];
            }
            else
            {
                return A[s1 + k - 1];
            }
        }
        static public double FindMedianSortedArrays(int[] A, int[] B)
        {
            var n = A.Count();
            var m = B.Count();
            if ((n + m) % 2 == 1)
            {
                return FindKthLowestInTwoSortedArrays(A, B, (n + m) / 2 + 1) * 1.0;
            }
            else
            {
                return FindKthLowestInTwoSortedArrays(A, B, (n + m) / 2) * 0.5 + FindKthLowestInTwoSortedArrays(A, B, (n + m) / 2 + 1) * 0.5;
            }
        }
    }
}
