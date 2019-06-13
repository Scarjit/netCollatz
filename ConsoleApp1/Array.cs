using System;
using System.Text;

namespace ConsoleApp1 {
    static class Array {

        public static void Start() {

            const int number = 1000000;
            ulong longestSeqIndex = 0;
            int longestSeq = 0;

            _recArrayCache = new int[number+1];
            _recArrayCache[1] = 1;

            for (int i = 2; i <= number; i++)
            {
                var sequenceLength = GetArrayLength(i);

                if (sequenceLength > longestSeq) {
                    longestSeqIndex = (ulong) i;
                    longestSeq = sequenceLength;
                }
            }
            
            CollatzConjecture(longestSeqIndex);
        }

        private static int[] _recArrayCache;
        private static int GetArrayLength(long i) {
            int chainLength;
            if (i < _recArrayCache.Length && _recArrayCache[i] != 0) return _recArrayCache[i];

            if (i % 2 == 0) {
                chainLength = 1 + GetArrayLength(i / 2);
            } else {
                chainLength = 1 + GetArrayLength(3 * i + 1);
            }

            if (i < _recArrayCache.Length) _recArrayCache[i] = chainLength;
            return chainLength;
        }

        static void CollatzConjecture(ulong num)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{num},");
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num = 3 * num + 1;
                }

                sb.Append($"{num},");
            }
            
            Console.WriteLine(sb);
        }

    }
}