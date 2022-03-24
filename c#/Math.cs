using System.Text;

namespace Programe
{
    public class Math
    {
        #region 백준 2609번 : 최대공약수와 최소공배수
        public void Baekjoon_2609()
        {
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                string? ReadLine = Console.ReadLine();

                if (!String.IsNullOrEmpty(ReadLine))
                {
                    int n1 = int.Parse(ReadLine.Split()[0]);
                    int n2 = int.Parse(ReadLine.Split()[1]);

                    int gcd = getGcd(n1, n2);
                    sb.Append(gcd + "\n");
                    sb.Append(n1*n2/gcd);
                    Console.WriteLine(sb.ToString());
                }
                else return;
            }
        }

        public int getGcd(int a, int b)
        {
            //GCD(a,b) = GCD(b,r)
            //GCD(581, 322) = GCD(322, 259) = GCD(259, 63) =  GCD(63, 7) = GCD(7, 0) = 7
            
            if (b == 0) return a;
            return getGcd(b, a % b);
        }
        #endregion

        #region 백준 17425번 : 약수의 합
        public void Baekjoon_17425()
        {
            long[] fx = new long[1000001];
            long[] dp = new long[1000001];
            
            Array.Fill(fx, 1);

            for (int i = 2; i < fx.Length; i++)
            {
                for (int j = 1; i * j < fx.Length; j++)
                {
                    fx[i * j] += i;
                }
            }

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] += dp[i - 1] + fx[i];
            }

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                string? ReadLine = Console.ReadLine();

                if (!String.IsNullOrEmpty(ReadLine))
                {
                    int t = int.Parse(ReadLine);

                    for (int i = 0; i < t; i++)
                    {
                        int n = 0;
                        string? NumberLine = Console.ReadLine();
                        if (!String.IsNullOrEmpty(NumberLine)) n = int.Parse(NumberLine);
                        else return;
                        sb.Append(dp[n]).Append("\n");
                    }
                    Console.WriteLine(sb.ToString().Trim());
                }
                else return;
            }
        }
        #endregion
    }
}