﻿using System;

namespace fibnumbers
{
    static class Program
    {
        // https://www.codewars.com/kata/5541f58a944b85ce6d00006a

        // The Fibonacci numbers are the numbers in the following integer sequence (Fn):
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...
        // such as
        // F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.
        // Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying

        // F(n) * F(n+1) = prod.

        // Your function productFib takes an integer (prod) and returns an array:

        // [F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
        // depending on the language if F(n) * F(n+1) = prod.

        //If you don't find two consecutive F(m) verifying F(m) * F(m+1) = prod you will return

        // [F(m), F(m+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
        // F(m) being the smallest one such as F(m) * F(m+1) > prod.

        // Examples
        // productFib(714) # should return {21, 34, 1}, 
        //                 # since F(8) = 21, F(9) = 34 and 714 = 21 * 34

        // productFib(800) # should return {34, 55, 0}, 
        //                 # since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55

        // Notes: Not useful here but we can tell how to choose the number n up to which to go:
        // we can use the "golden ratio" phi which is (1 + sqrt(5))/2 knowing that F(n) is asymptotic to:
        // phi^n / sqrt(5). That gives a possible upper bound to n.
        static void Main(string[] args)
        {
            var x = ProductFib(4895); // 55, 89, 1
        }

        private static ulong[] ProductFib(ulong prod)
        {
            ulong f1 = 1; 
            ulong f2 = 0;
            ulong multiply = 0;
            while (multiply < prod)
            {
                var temp = f2;
                f2 = f1;
                f1 += temp;
                multiply = f1 * f2;
            }

            return new[] {f2, f1, (ulong) (multiply == prod ? 1 : 0)};
        }
    }
}