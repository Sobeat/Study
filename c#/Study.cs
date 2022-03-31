using System.Text;

namespace Programe
{
    public class Study
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

        #region 백준 17427번 : 약수의 합2
        public void Baekjoon_17427()
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
                string? ReadLine = Console.ReadLine();

                if (!String.IsNullOrEmpty(ReadLine))
                {
                    int n = int.Parse(ReadLine);
                    Console.WriteLine(dp[n]);
                }
                else return;
            }
        }
        #endregion

        #region 프로그래머스 행렬 테두리 회전하기
        public int[] WebBackEnd_2021_Lv2(int rows, int columns, int[,] queries)
        {
            int[] answer = new int[queries.GetLength(0)];
            int[,] board = new int[rows, columns];

            int cnt = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] += cnt;
                    cnt++;
                }
            }

            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                x1 = queries[i, 0] - 1;
                x2 = queries[i, 1] - 1;
                y1 = queries[i, 2] - 1;
                y2 = queries[i, 3] - 1;

                int start = board[x1, x2];
                int min = start;


                for (int j = x1 + 1; j <= y1; j++)
                {
                    min = Math.Min(min, board[j, x2]);
                    board[j - 1, x2] = board[j, x2];
                    Console.WriteLine(board[j, x2]);
                    //14,20,26
                }

                for (int j = x2 + 1; j <= y2; j++)
                {
                    min = Math.Min(min, board[y1, j]);
                    board[y1, j - 1] = board[y1, j];
                    Console.WriteLine(board[y1, j]);
                    //27,28
                }

                for (int j = y1 - 1; j >= x1; j--)
                {
                    min = Math.Min(min, board[j, y2]);
                    board[j + 1, y2] = board[j, y2];
                    Console.WriteLine(board[j, y2]);
                    //Console.WriteLine(board[j + 1, y2]);
                    //22,16,10
                }

                for (int j = y2 - 1; j >= x2; j--)
                {
                    min = Math.Min(min, board[x1, j]);
                    board[x1, j + 1] = board[x1, j];
                    Console.WriteLine(board[x1, j]);
                    //9,8
                }

                board[x1,x2+1] = start;
                answer[i] = min;
            }

            return answer;
        }
        #endregion
        
        #region 다단계 칫솔 판매
        public int[] WebBackEnd_2021_Lv3(string[] enroll, string[] referral, string[] seller, int[] amount) {
            //seller 판매원
            //amount 판매수량
            int[] answer = new int[enroll.Length];

            Dictionary<string, int> result = new Dictionary<string, int>();
            Dictionary<string, string> referer = new Dictionary<string, string>();

            for (int i = 0; i < answer.Length; i++) {
                result.Add(enroll[i], 0);
                referer.Add(enroll[i], referral[i]);
            }
            
            for (int i = 0; i < seller.Length; i++) {
                //이익금
                int sumFund = amount[i] * 100;
                
                int fund = result[seller[i]];
                string prevSeller = referer[seller[i]];
                
                int profit = sumFund / 10;
                result[seller[i]] += sumFund - profit;
                result = fundDivision(enroll, referer, prevSeller, (int)(sumFund / 10), result);
            }

            for (int i = 0; i < result.Count; i++) {
                answer[i] = result.Values.ElementAt(i);
            }

            return answer;
        }

        public Dictionary<string, int> fundDivision(string[] enroll, Dictionary<string, string> referral, string prevSeller, int fund, Dictionary<string, int> result)
        {
            if (fund < 1) return result;
            if (prevSeller == "-") return result;
            
            int profit = fund / 10;
            result[prevSeller] += fund - profit;

            prevSeller = referral[prevSeller];
            return fundDivision(enroll, referral, prevSeller, (int)(fund / 10), result);
        }
        #endregion
    }
}