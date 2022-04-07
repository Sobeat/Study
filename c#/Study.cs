using System.Text;

namespace Programe
{
    public class Study
    {
        #region 백준 알고리즘 기초 1

        #region Chapter2
        #region 자료구조 1
        public void Baekjoon_9093()
        {
            //단어 뒤집기
            int t = Convert.ToInt32(Console.ReadLine());    
            int index = 0;

            while (index < t)
            {
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;
                
                string[] words = str.Split(' ');
                string output = "";
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = words[i].Length - 1; j >= 0; j--)
                    {
                        char[] word = words[i].ToCharArray();
                        output += word[j];
                    }
                    output += " ";
                }
                Console.WriteLine(output);
            }
            return;
        }
        
        public void Baekjoon_9012()
        {
            //괄호
            while(true) {
                string? t = Console.ReadLine();
                if (String.IsNullOrEmpty(t)) return;

                for (int i = 0; i < Convert.ToInt32(t); i++)
                {
                    string? str = Console.ReadLine();
                    if (String.IsNullOrEmpty(str)) return;

                    int cnt = 0;

                    foreach (char word in str)
                    {
                        if (word == '(') cnt += 1;
                        else if (cnt > 0) cnt -=1;
                        else
                        { 
                            cnt = -1;
                            break;
                        }
                    }

                    if (cnt == 0) Console.WriteLine("YES");
                    else Console.WriteLine("NO");
                }
            }
        }
        
        public void Baekjoon_10828()
        {
            //스택
            while(true)
            {
                string? n = Console.ReadLine();
                if (String.IsNullOrEmpty(n)) return;

                int[] data = new int[Convert.ToInt32(n)];
                int size = 0;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < Convert.ToInt32(n); i++)
                {
                    string? str = Console.ReadLine();
                    if (String.IsNullOrEmpty(str)) return;

                    switch (str.Split(' ')[0])
                    {
                        case "push":
                            data[size] = Convert.ToInt32(str.Split(' ')[1]);
                            size += 1;
                            break;
                        case "pop":
                            if (size == 0) {
                                sb.Append(-1);
                                sb.AppendLine();
                            }
                            else {
                                size -= 1;
                                sb.Append(data[size]);
                                sb.AppendLine();
                            }
                            break;
                        case "size":
                            sb.Append(size);
                            sb.AppendLine();
                            break;
                        case "empty":
                            if (size == 0) {
                                sb.Append(1);
                                sb.AppendLine();
                            }
                            else
                            {
                                sb.Append(0);
                                sb.AppendLine();
                            }
                            break;
                        case "top":
                            if (size == 0) {
                                sb.Append(-1);
                                sb.AppendLine();
                            }
                            else {
                                sb.Append(data[size - 1]);
                                sb.AppendLine();
                            }
                            break;
                    }
                }
                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_1874()
        {
            //스택 수열
            while (true)
            {
                string? n = Console.ReadLine();
                if (String.IsNullOrEmpty(n)) return;

                StringBuilder sb = new StringBuilder();
                Stack<int> stack = new Stack<int>();
                int size = 0;

                for (int i = 0; i < Convert.ToInt32(n); i++)
                {
                    int str = Convert.ToInt32(Console.ReadLine());

                    if (str > size)
                    {
                        while (str > size)
                        {
                            stack.Push(++size);
                            sb.Append("+\n");
                        }
                        stack.Pop();
                        sb.Append("-\n");
                    }
                    else
                    {
                        if (stack.Peek() != str)
                        {
                            sb.Clear();
                            sb.Append("NO\n");
                            break;
                        }
                        stack.Pop();
                        sb.Append("-\n");
                    }
                }
                Console.Write(sb);
            }
        }

        public void Baekjoon_1406()
        {
            //에디터
            while (true)
            {
                StringBuilder sb = new StringBuilder();

                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                int m = Convert.ToInt32(Console.ReadLine());

                Stack<string> right = new Stack<string>();
                Stack<string> left = new Stack<string>();

                for (int i = 0; i < str.Length; i++)
                {
                    left.Push(str[i].ToString());
                }

                for (int i = 0; i < m; i++)
                {
                    string? cmd = Console.ReadLine();
                    if (String.IsNullOrEmpty(cmd)) return;

                    string? result = null;

                    switch (cmd.Split(' ')[0].ToString())
                    {
                        case "L":
                            if (left.TryPop(out result)) {
                                if (!String.IsNullOrEmpty(result)) right.Push(result);
                            }
                            break;
                        case "D":
                            if (right.TryPop(out result)) {
                                if (!String.IsNullOrEmpty(result)) left.Push(result);
                            }
                            break;
                        case "B":
                            left.TryPop(out result);
                            break;
                        case "P":
                            left.Push(cmd.Split(' ')[1].ToString());
                            break;
                    }
                }

                string[] temp = new string[left.Count];
                int leftCount = left.Count;
                int rightCount = right.Count;

                for (int i = leftCount; i > 0; i--)
                {
                    left.TryPop(out string? result);
                    if (!String.IsNullOrEmpty(result)) temp[i - 1] = result;
                }

                for (int i = 0; i < temp.Length; i++)
                {
                    sb.Append(temp[i]);
                }

                for (int i = 0; i < rightCount; i++)
                {
                    right.TryPop(out string? result);
                    sb.Append(result);
                }

                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_10845()
        {
            //큐
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                StringBuilder sb = new StringBuilder();
                Queue<int> queue = new Queue<int>();

                for (int i = 0; i < n; i++)
                {
                    string? cmd = Console.ReadLine();
                    if (String.IsNullOrEmpty(cmd)) return;
                    
                    switch (cmd.Split(' ')[0])
                    {
                        case "push":
                            queue.Enqueue(Convert.ToInt32(cmd.Split(' ')[1]));
                            break;
                        case "pop":
                            if (queue.TryDequeue(out int pop)) sb.Append(pop + "\n");
                            else sb.Append(-1 + "\n");
                            break;
                        case "size":
                            sb.Append(queue.Count + "\n");
                            break;
                        case "empty":
                            if (queue.Count == 0) sb.Append(1 + "\n");
                            else sb.Append(0 + "\n");
                            break;
                        case "front":
                            if (queue.TryPeek(out int front)) sb.Append(front + "\n");
                            else sb.Append(-1 + "\n");
                            break;
                        case "back":
                            int back = 0;
                            try {
                                back = queue.Last();
                            }
                            catch {
                                back = -1;
                            }
                            sb.Append(back + "\n");
                            break;
                    }
                }
                Console.Write(sb);
            }
        }

        public void Baekjoon_1158()
        {
            //요세푸스 문제
            while (true)
            {
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                int n = Convert.ToInt32(str.Split(' ')[0]);
                int k = Convert.ToInt32(str.Split(' ')[1]);
                Queue<int> queue = new Queue<int>();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < n; i++)
                {
                    queue.Enqueue(i + 1);
                }

                while (queue.Count > 0)
                {
                    for (int i = 1; i < k; i++)
                    {
                        queue.TryDequeue(out int result);
                        queue.Enqueue(result);
                    }
                    queue.TryDequeue(out int value);
                    sb.Append(value + ", ");
                }
                Console.WriteLine("<" + sb.ToString().Substring(0, sb.Length - 2) + ">");
            }
        }

        public void Baekjoon_10886()
        {
            //덱
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                StringBuilder sb = new StringBuilder();
                int[] Deque = new int[10001];
                int size = 0;
                for (int i = 0; i < n; i++)
                {
                    string? cmd = Console.ReadLine();
                    if (String.IsNullOrEmpty(cmd)) return;

                    switch (cmd.Split(' ')[0])
                    {
                        case "push_front":
                            Deque[size] = Convert.ToInt32(cmd.Split(' ')[1]);
                            size += 1;
                            break;
                        case "push_back":
                            for (int j = size; j > 0 ; j--)
                            {
                                Deque[j] = Deque[j - 1];
                            }
                            Deque[0] = Convert.ToInt32(cmd.Split(' ')[1]);
                            size += 1;
                            break;
                        case "pop_front":
                            if (size > 0)
                            {
                                sb.AppendLine(Deque[size - 1].ToString());
                                size -= 1;
                            }
                            else sb.AppendLine("-1");
                            break;
                        case "pop_back":
                            if (size > 0)
                            {
                                sb.AppendLine(Deque[0].ToString());

                                for (int j = 0; j < size; j++)
                                {
                                    Deque[j] = Deque[j + 1];
                                }
                                size -= 1;
                            }
                            else sb.AppendLine("-1");
                            break;
                        case "size":
                            sb.AppendLine(size.ToString());
                            break;
                        case "empty":
                            if (size == 0) sb.AppendLine("1");
                            else sb.AppendLine("0");
                            break;
                        case "front":
                            if (size > 0)
                            {
                                sb.AppendLine(Deque[size - 1].ToString());
                            }
                            else sb.AppendLine("-1");
                            break;
                        case "back":
                            if (size > 0)
                            {
                                sb.AppendLine(Deque[0].ToString());
                            }
                            else sb.AppendLine("-1");
                            break;
                    }
                }
                Console.Write(sb);
            }
        }
        #endregion
        #region 자료구조 1 (연습)
        public void Baekjoon_17413()
        {
            //단어 뒤집기2
            while (true)
            {
                string? s = Console.ReadLine();
                if (String.IsNullOrEmpty(s)) return;

                StringBuilder sb = new StringBuilder();
                Stack<char> stack = new Stack<char>();
                bool tag = false;
                int size = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '<') {
                        size = stack.Count;
                        for (int j = 0; j < size; j++)
                        {
                            stack.TryPop(out char result);
                            sb.Append(result);
                        }
                        sb.Append(s[i]);
                        tag = true;
                    }
                    else if (s[i] == '>') {
                        sb.Append(s[i]);
                        tag = false;
                    }
                    else if (tag) {
                        sb.Append(s[i]);
                    }
                    else {
                        if (s[i] == ' ') {
                            size = stack.Count;
                            for (int j = 0; j < size ; j++)
                            {
                                stack.TryPop(out char result);
                                sb.Append(result);
                            }
                            sb.Append(s[i]);
                        }
                        else
                        {
                            stack.Push(s[i]);
                        }
                    }
                }
                size = stack.Count;
                for (int j = 0; j < size; j++)
                {
                    stack.TryPop(out char result);
                    sb.Append(result);
                }

                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_10799()
        {
            //쇠막대기
            while(true)
            {
                int retval = 0;
                Stack<int> stack = new Stack<int>();

                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                char[] stick = str.ToCharArray();
                for (int i = 0; i < stick.Length; i++)
                {
                    if (stick[i] == ')')
                    {
                        if (stack.Peek() == i-1) {
                            stack.Pop();
                            retval += stack.Count;
                        }
                        else {
                            stack.Pop();
                            retval += 1;
                        }
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
                Console.WriteLine(retval);
            }
        }

        public void Baekjoon_17298()    //*
        {
            //오큰수
            while(true)
            {
                #region 시간초과
                /*
                int n = Convert.ToInt32(Console.ReadLine());
                string? str = Console.ReadLine();

                if (String.IsNullOrEmpty(str)) return;
                StringBuilder sb = new StringBuilder();
                string[] a = str.Split(' ');
                Stack<int> stack = new Stack<int>();
                for (int i = 0; i < n; i++)
                {
                    if (i > 0) sb.Append(' ');
                    if (stack.Count == 0) stack.Push(Convert.ToInt32(a[i]));

                    for (int j = i + 1; j < a.Length; j++) {
                        if (stack.Peek() < Convert.ToInt32(a[j])) {
                            stack.Push(Convert.ToInt32(a[j]));
                            break;
                        }
                    }
                    if (stack.Peek() == Convert.ToInt32(a[i])) { 
                        sb.Append("-1");
                        stack.Pop();
                    }
                    else  {
                        sb.Append(stack.Peek());
                    }
                }
                Console.WriteLine(sb);
                */
                #endregion

                int n = Convert.ToInt32(Console.ReadLine());
                string? str = Console.ReadLine();

                if (String.IsNullOrEmpty(str)) return;
                StringBuilder sb = new StringBuilder();
                string[] a = str.Split(' ');
                int[] ans = new int[n];
                Stack<int> stack = new Stack<int>();
                stack.Push(0);
                for (int i = 1; i < n; i++)
                {
                    if (stack.Count == 0) stack.Push(i);

                    while (stack.Count > 0 && Convert.ToInt32(a[stack.Peek()]) < Convert.ToInt32(a[i]))
                    {
                        ans[stack.Peek()] = Convert.ToInt32(a[i]);
                        stack.Pop();
                    }
                    stack.Push(i);
                }

                while (stack.Count > 0)
                {
                    ans[stack.Peek()] = -1;
                    stack.Pop();
                }
                
                for (int i = 0; i < n; i++) {
                    sb.Append(ans[i] + " ");
                }

                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_17299()    //**
        {
            //오등큰수
            while(true)
            {
                int[] freq = new int[1000001];
                int n = Convert.ToInt32(Console.ReadLine());
                string? str = Console.ReadLine();

                if (String.IsNullOrEmpty(str)) return;
                StringBuilder sb = new StringBuilder();
                string[] a = str.Split(' ');
                int[] ans = new int[n];
                Stack<int> stack = new Stack<int>();
                stack.Push(0);
                for (int i = 0; i < n; i++)
                {
                    freq[Convert.ToInt32(a[i])] += 1;
                }

                for (int i = 1; i < n; i++)
                {
                    if (stack.Count == 0) stack.Push(i);

                    while (stack.Count > 0 && freq[Convert.ToInt32(a[stack.Peek()])] < freq[Convert.ToInt32(a[i])])
                    {
                        ans[stack.Peek()] = Convert.ToInt32(a[i]);
                        stack.Pop();
                    }
                    stack.Push(i);
                }

                while (stack.Count > 0)
                {
                    ans[stack.Peek()] = -1;
                    stack.Pop();
                }
                
                for (int i = 0; i < n; i++) {
                    sb.Append(ans[i] + " ");
                }

                Console.WriteLine(sb);
            }
        }
        #endregion
        #endregion

        #region Chapter3
        #region 수학 1
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
        #region 최소공배수
        public void Baekjoon_1934()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++) {
                string? str = Console.ReadLine();
                
                if (String.IsNullOrEmpty(str)) return;

                int a = Convert.ToInt32(str.Split(' ')[0]);
                int b = Convert.ToInt32(str.Split(' ')[1]);

                int g = 1;
                for (int j = 2; j <= Math.Min(a,b); j++)
                {
                    if (a % j == 0 && b % j == 0) {
                        g = j;
                    }
                }

                Console.WriteLine(a * b / g);
            }
        }
        #endregion 
        #region 팩토리얼
        public void Baekjoon_10872()
        {
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int retval = 1;
                for (int i = 1; i <= n; i++)
                {
                    retval=retval * i;
                }
                Console.WriteLine(retval);
            }
        }
        #endregion
        #region 팩토리얼 0의 갯수
        public void Baekjoon_1676()
        {
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int count = 0;
                for (int i = 1; i <= n; i++)
                {
                    int j = i;
                    
                    while (j % 5 == 0)
                    {
                        j = Convert.ToInt32(j / 5);
                        count++;
                    }
                }

                Console.WriteLine(count);
            }
        }
        #endregion
        #region 조합 0의 갯수
        //수학 공식을 모르겠음...
        public void Baekjoon_2004()
        {
            while (true)
            {
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;
                long n = Convert.ToInt64(str.Split(' ')[0]);
                long m = Convert.ToInt64(str.Split(' ')[1]);

                long xCount = 0;
                long jCount = 0;

                for (long i=2; i<=n; i*=2) {
                    xCount += n/i;
                }

                for (long i=2; i<=n-m; i*=2) {
                    xCount -= (n-m)/i;
                }

                for (long i=2; i<=m; i*=2) {
                    xCount -= m/i;
                }

                for (long i=5; i<=n; i*=5) {
                    jCount += n/i;
                }

                for (long i=5; i<=n-m; i*=5) {
                    jCount -= (n-m)/i;
                }

                for (long i=5; i<=m; i*=5) {
                    jCount -= m/i;
                }

                Console.WriteLine(Math.Min(xCount, jCount));
            }
        }
        #endregion
        #endregion
        #region 수학 1 (연습)
        public void Baekjoon_9613()
        {
            
        }
        #endregion
        #endregion

        #endregion

        #region Study

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

        #region 제일 작은 수 제거하기
        public int[] programmers_12935(int[] arr)
        {
            int[] answer;
            if (arr.Length > 1)
            {
                answer = new int[arr.Length - 1];
                int index = 0;
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min) min = arr[i];
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > min)
                    {
                        answer[index] = arr[i];
                        index += 1;
                    }
                }
            }
            else
            {
                answer = new int[1] { -1 };
            }

            return answer;
        }
        #endregion

        #region 정수 내림차순 정리하기
        public long programmers_12933(long n) 
        {
            long answer = 0;
            List<int> list = new List<int>();
            
            for (int i = 0; i < n.ToString().Length; i++)
            {
                list.Add(Convert.ToInt32(n.ToString().Substring(i,1)));
            }

            var descList = list.OrderByDescending(i => i);
            string temp = "";
            foreach (var i in descList)
            {
                temp += i.ToString();
            }
            answer = Convert.ToInt64(temp);
            return answer;
        }
        #endregion
        
        #endregion
    }
}