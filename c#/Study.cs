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
            //GCD의 합
            int t = Convert.ToInt32(Console.ReadLine());
            //int t = 3;
            while (t-- > 0)
            {
                string? str = Console.ReadLine();
                //string str = "4 10 20 30 40";
                if (String.IsNullOrEmpty(str)) return;

                int[] a = new int[str.Split(' ').Length];
                for (int i = 0; i < str.Split(' ').Length; i++)
                {
                    a[i] = Convert.ToInt32(str.Split(' ')[i]);
                }

                long ans = 0;
                for (int i = 1; i < a.Length - 1; i++)
                {
                    for (int j = i+1; j < a.Length; j++)
                    {
                        ans += getGcd(a[i], a[j]);
                    }
                }

                Console.WriteLine(ans);
            }
                
        }

        public void Baekjoon_17087()
        {
            //숨바꼭질6
            while (true)
            {
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                int n = Convert.ToInt32(str.Split(' ')[0]);
                int s = Convert.ToInt32(str.Split(' ')[1]);

                str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;
                string[] a = str.Split(' ');
                int[] ans = new int[a.Length];

                for (int i = 0; i < a.Length; i++)
                {
                    //ans[i] = Convert.ToInt32(a[i]);
                    ans[i] = Math.Abs(Convert.ToInt32(a[i]) - s);
                }

                int maxD = ans[0];
                for (int i = 1; i < n; i++)
                {
                    maxD = getGcd(maxD, ans[i]);
                }

                Console.WriteLine(maxD);
            }
        }

        public void Baekjoon_1373()
        {
            //2진수 8진수
            while (true)
            {
                string? s = Console.ReadLine();
                if (String.IsNullOrEmpty(s)) return;

                StringBuilder sb = new StringBuilder();

                int n = s.Length;
                if (n%3 == 1) {
                    sb.Append(s[0]);
                } else if (n%3 == 2) {
                    sb.Append((s[0]-'0')*2 + s[1]-'0');
                }
                for (int i = n%3; i<n; i+=3) {
                    sb.Append((s[i]-'0')*4 + (s[i+1]-'0')*2 + (s[i+2]-'0'));
                }

                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_1212()
        {
            //8진수 2진수
            while (true)
            {
                string[] eight = {"000","001","010","011","100","101","110","111"};
                string? s = Console.ReadLine();
                if (String.IsNullOrEmpty(s)) return;
                StringBuilder sb = new StringBuilder();
                bool start = true;
                if (s.Length == 1 && s[0] == '0') {
                    sb.Append(0);
                }
                for (int i=0; i<s.Length; i++) {
                    int n = s[i] - '0';
                    if (start == true && n < 4) {
                        if (n == 0) {
                            continue;
                        } else if (n == 1) {
                            sb.Append("1");
                        } else if (n == 2) {
                            sb.Append("10");
                        } else if (n == 3) {
                            sb.Append("11");
                        }
                        start = false;
                    }
                    else {
                        sb.Append(eight[n]);
                        start = false;
                    }
                }

                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_2089()
        {
            while(true)
            {
                //-2진수
                int n = Convert.ToInt32(Console.ReadLine());
                StringBuilder sb = new StringBuilder();
                if (n == 0) sb.Append(0);
                else {
                    go(n, sb);
                }
                Console.WriteLine(sb);
            }
        }

        public void go(int n, StringBuilder sb)
        {
            if (n == 0) {
                return;
            }
            if (n%2 == 0) {
                go(-(n/2), sb);
                sb.Append(0);
            } else {
                if (n > 0) {
                    go(-(n/2), sb);
                } else {
                    go((-n+1)/2, sb);
                }
                sb.Append(1);
            }
        }
        
        public void Beakjoon_17103()
        {
            //골드바흐 파티션
            int t = Convert.ToInt32(Console.ReadLine());
            List<int> primes = new List<int>();
            bool[] check = new bool[1000001];

            for (int i=2; i <=1000000;i++)
            {
                if (check[i] == false) {
                    primes.Add(i);
                    for (int j = i+i; j<=1000000;j+=i) {
                        check[j] = true;
                    }
                }
            }

            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int ans = 0;
                foreach (int p in primes)
                {
                    if (n-p >= 2 && p <= n-p) {
                        if (check[n-p] == false) {
                            ans += 1;
                        }
                    }
                    else {
                        break;
                    }
                }
                Console.WriteLine(ans);
            }
        }
        #endregion
        #endregion

        #region Chapter4
        public int[] d = new int[1000001];
        public void Baekjoon_1463()
        {
            //1로 만들기
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Baekjoon_1463_go(n));
            }
        }

        public int Baekjoon_1463_go(int n)
        {
            if (n == 1) return 0;
            if (d[n] > 0) return d[n];
            d[n] = Baekjoon_1463_go(n-1) + 1;
            if (n%2 == 0) {
                int temp = Baekjoon_1463_go(n/2) + 1;
                if (d[n] > temp) d[n] = temp;
            }

            if (n%3 == 0) {
                int temp = Baekjoon_1463_go(n/3) + 1;
                if (d[n] > temp) d[n] = temp;
            }
            return d[n];
        }
        
        public void Baekjoon_11726()
        {
            //2*n 타일링
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] d = new int[1001];
                d[0] = d[1] = 1;
                for (int i=2; i<=n; i++) {
                    d[i] = d[i-1] + d[i-2];
                    d[i] %= 10007;
                }

                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_11727()
        {
            //2*n 타일링2
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] d = new int[1001];
                d[0] = d[1] = 1;
                for (int i=2; i<=n; i++)
                {
                    d[i] = 2*d[i-2] + d[i-1];
                    d[i] %= 10007;
                }

                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_9095()
        {
            //1,2,3 더하기
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] d = new int[1000];
                d[0] = d[1] = 1;
                d[2] = 2;
                for (int i=3; i<=n; i++)
                {
                    d[i] = d[i-1] + d[i-2] + d[i-3];
                }

                Console.WriteLine(d[n]);
            }
        }
        
        public void Baekjoon_11052()
        {
            //카드 구매하기
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                int[] d = new int[n+1];
                int[] a = new int[n+1];
                for (int i = 1; i <= n; i++)
                {
                    a[i] = Convert.ToInt32(str.Split(' ')[i - 1]);
                }

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (d[i] < d[i-j] + a[j]) {
                            d[i] = d[i-j] + a[j];
                        }
                    }
                }

                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_16194()
        {
            //카드 구매하기2
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;

                int[] d = new int[n+1];
                int[] a = new int[n+1];
                for (int i = 1; i <= n; i++)
                {
                    a[i] = Convert.ToInt32(str.Split(' ')[i - 1]);
                } 

                for (int i = 1; i <= n; i++)
                { 
                    d[i] = -1;
                }

                d[0] = 0;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (d[i] == -1 || d[i] > d[i-j]+a[j])
                        d[i] = d[i-j] + a[j];
                    }
                }

                Console.WriteLine(d[n]);
            }
        }
        

        public void Baekjoon_15990()
        {
            //1,2,3 더하기 5번째
            while (true)
            {
                long[,] d = new long[100001, 4];
                for (int i = 1; i <= 100000; i++)
                {
                    if (i - 1 >= 0)
                    {
                        d[i, 1] = d[i - 1, 2] + d[i - 1, 3];
                        if (i == 1)
                        {
                            d[i, 1] = 1;
                        }
                    }

                    if (i - 2 >= 0)
                    {
                        d[i, 2] = d[i - 2, 1] + d[i - 2, 3];
                        if (i == 2)
                        {
                            d[i, 2] = 1;
                        }
                    }

                    if (i - 3 >= 0)
                    {
                        d[i, 3] = d[i - 3, 1] + d[i - 3, 2];
                        if (i == 3)
                        {
                            d[i, 3] = 1;
                        }
                    }

                    d[i, 1] %= 1000000009L;
                    d[i, 2] %= 1000000009L;
                    d[i, 3] %= 1000000009L;
                }

                int t = Convert.ToInt32(Console.ReadLine());
                while (t-- > 0)
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine((d[n,1] + d[n,2] + d[n,3])%1000000009);
                }
            }
        }

        public void Baekjoon_10844()
        {
            //쉬운 계단 수
            while (true)
            {
                long mod = 1000000000;
                int n = Convert.ToInt32(Console.ReadLine());

                long[,] d = new long[n+1,10];
                for (int i=1; i<=9; i++) d[1,i] = 1;
                for (int i=2; i<=n; i++) {
                    for (int j=0; j<=9; j++) {
                        d[i,j] = 0;
                        if (j-1 >= 0) d[i,j] += d[i-1,j-1];
                        if (j+1 <= 9) d[i,j] += d[i-1,j+1];
                        d[i,j] %= mod;
                    }
                }

                long ans = 0;
                for (int i=0; i<=9; i++) {
                    ans += d[n,i];
                }
                ans %= mod;
                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_2193()
        {
            //이친수
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                long[] d = new long[n+1];
                d[1] = 1;
                if (n >= 2) {
                    d[2] = 1;
                }
                for (int i=3; i<=n; i++) {
                    d[i] = d[i-1] + d[i-2];
                }
                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_11053()
        {
            //가장 긴 증가하는 부분 수열(LIS)
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] d = new int[n];
                for (int i=0; i<n; i++) {
                    d[i] = 1;
                    for (int j=0; j<i; j++) {
                        if (a[j] < a[i] && d[i] < d[j]+1) {
                            d[i] = d[j]+1;
                        }
                    }
                }
                int ans = d[0];
                for (int i=0; i<n; i++) {
                    if (ans < d[i]) {
                        ans = d[i];
                    }
                }

                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_14002()
        {
            //가장 긴 증가하는 부분 수열 4
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] d = new int[n];
                int[] v = new int[n];

                for (int i=0; i<n; i++) {
                    d[i] = 1;
                    v[i] = -1;
                    for (int j=0; j<i; j++) {
                        if (a[j] < a[i] && d[i] < d[j]+1) {
                            d[i] = d[j]+1;
                            v[i] = j;
                        }
                    }
                }
                int ans = d[0];
                int p = 0;
                for (int i=0; i<n; i++) {
                    if (ans < d[i]) {
                        ans = d[i];
                        p = i;
                    }
                }

                sb.AppendLine(ans.ToString());
                Baekjoon_14002_go(p, a, d, v, sb);
                Console.WriteLine(sb);
            }
        }

        public void Baekjoon_14002_go(int p, int[] a, int[] d, int[] v, StringBuilder sb)
        {
            if (p == -1) return;
            Baekjoon_14002_go(v[p], a, d, v, sb);
            sb.Append(a[p] + " ");
        }

        public void Baekjoon_1912()
        {
            //연속합
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                int[] d = new int[n];

                for (int i = 0; i < n; i++)
                {
                    d[i] = a[i];
                    if (i == 0) continue;
                    if (d[i] < d[i - 1] + a[i]) d[i] = d[i - 1] + a[i];
                }
                int ans = d[0];
                for (int i=0; i<n; i++) {
                    if (ans < d[i]) ans = d[i];
                }
                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_2225()
        {
            //합분해
            long mod = 1_000_000_000;
            while(true) {
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) return;
                
                int n = Convert.ToInt32(str.Split(' ')[0]);
                int k = Convert.ToInt32(str.Split(' ')[1]);
                long[,] d = new long[k+1,n+1];
                d[0,0] = 1;
                for (int i=1; i<=k; i++) {
                    for (int j=0; j<=n; j++) {
                        for (int l=0; l<=j; l++) {
                            d[i,j] += d[i-1,j-l];
                            d[i,j] %= mod;
                        }
                    }
                }

                Console.WriteLine(d[k,n]);
            }
        }

        public void Baekjoon_1699()
        {
            //제곱수의 합
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] d = new int[n+1];

                for (int i=1; i<=n; i++) {
                    d[i] = i;
                    for (int j=1; j*j<=i; j++) {
                        if (d[i] > d[i-j*j]+1) {
                            d[i] = d[i-j*j]+1;
                        }
                    }
                }

                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_15998()
        {
            //1,2,3 더하기 3
            long mod = 1_000_000_009;
            long[] d = new long[1_000_001];
            d[0] = d[1] = 1;
            d[2] = 2;

            for (long i = 3; i <= 1_000_000; i++) {
                d[i] = (d[i - 1] + d[i - 2] + d[i - 3]) % mod;
            }

            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0) {
                long n = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_1149()
        {
            //RGB거리
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] house = new int[n+1,3];
                int[,] d = new int[n+1,3];

                for (int i = 1; i <= n; i++)
                {
                    int[] price = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                    for (int j = 0; j < price.Length; j++)
                    {
                        house[i,j] = price[j];
                    }
                }
                for (int i = 1; i<=n; i++)
                {
                    d[i,0] = Math.Min(d[i-1,1], d[i-1,2]) + house[i,0];
                    d[i,1] = Math.Min(d[i-1,0], d[i-1,2]) + house[i,1];
                    d[i,2] = Math.Min(d[i-1,0], d[i-1,1]) + house[i,2];
                }
                Console.WriteLine(Math.Min(Math.Min(d[n,0], d[n,1]), d[n,2]));
            }
        }

        public void Baekjoon_1309()
        {
            //동물원
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] d = new int[n+1,3];
                d[0,0] = 1;
                for (int i = 1; i <= n; i++)
                {
                    d[i,0] = d[i-1,0] + d[i-1,1] + d[i-1,2];
                    d[i,1] = d[i-1,0] + d[i-1,2];
                    d[i,2] = d[i-1,0] + d[i-1,1];
                    for (int j = 0; j < 3; j++)
                    {
                        d[i,j] %= 9901;
                    }
                }

                 Console.WriteLine((d[n,0] + d[n,1] + d[n,2]) % 9901);
            }
        }

        public void Baekjoon_11057()
        {
            //오르막 수
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] d = new int[n+1,10];

                for (int i = 0; i <= 9; i++) d[1,i] = 1;
                for (int i = 2; i <= n; i++) {
                    for (int j = 0; j <= 9; j++) {
                        for (int k = 0; k <= j; k++) {
                            d[i,j] += d[i-1,k];
                            d[i,j] %= 10007;
                        }
                    }
                }
                long ans = 0;
                for (int i = 0; i < 10; i++) ans += d[n,i];
                ans %= 10007;

                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_9465()
        {
            //스티커
            while (true)
            {
                int t = Convert.ToInt32(Console.ReadLine());
                while (t-- > 0)
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    int[,] b = new int[3,n];
                    int[,] d = new int[3,n+1];

                    for (int i = 1; i <= 2; i++) {
                        int[] a = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                        for (int j = 0; j < a.Length; j++) {
                            b[i,j] = a[j];
                        }
                    }

                    for (int i = 1; i <= n; i++) {
                        d[0,i] = Math.Max(Math.Max(d[0,i-1], d[1,i-1]), d[2,i-1]) + b[0,i-1];
                        d[1,i] = Math.Max(d[0,i-1], d[2,i-1]) + b[1,i-1];
                        d[2,i] = Math.Max(d[0,i-1], d[1,i-1]) + b[2,i-1];
                    }

                    Console.WriteLine(Math.Max(Math.Max(d[0,n], d[1,n]), d[2,n]));
                }
            }
        }

        public void Baekjoon_2156()
        {
            //포도주 시식
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[n+1];
                int[] d = new int[n+1];
                for (int i = 1; i <= n; i++) a[i] = Convert.ToInt32(Console.ReadLine());

                d[1] = a[1];
                if (n > 1)
                {
                    d[2] = a[1] + a[2];
                    for (int i = 3; i <= n; i++) {
                        d[i] = d[i-1];
                        d[i] = Math.Max(d[i], d[i-2] + a[i]);
                        d[i] = Math.Max(d[i], d[i-3] + a[i] + a[i-1]);
                    }
                }
                Console.WriteLine(d[n]);
            }
        }

        public void Baekjoon_1932()
        {
            //정수 삼각형
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] a = new int[n,n];
                int[,] d = new int[n,n];
                for (int i = 0; i < n; i++)
                {
                    int[] b = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                    for (int j = 0; j < b.Length; j++)
                    {
                        a[i,j] = b[j];
                    }
                }

                d[0,0] = a[0,0];
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        d[i,j] = d[i-1,j] + a[i,j];
                        if (j-1 >= 0)
                        {
                            d[i,j] = Math.Max(d[i-1,j-1] + a[i,j], d[i-1,j] + a[i,j]);
                        }
                    }
                }
                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    ans = Math.Max(ans, d[n-1,i]);
                }

                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_11055()
        {
            //가장 큰 증가하는 부분 수열
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                int[] d = new int[n];
                int ans = 0;
                
                for (int i = 0; i < n; i++)
                {
                    d[i] = a[i];
                    for (int j = 0; j < i; j++)
                    {
                        if (a[j] < a[i] && d[i] < d[j] + a[i])
                        {
                            d[i] = d[j] + a[i];
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    ans = Math.Max(ans, d[i]);
                }

                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_11722()
        {
            //가장 긴 감소하는 부분 수열
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] t = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                int[] a = new int[n+1];
                int[] d = new int[n+1];

                for (int i = 1; i <= n; i++)
                {
                    a[i] = t[i-1];
                }

                for (int i=n; i>=0; i--)
                {
                    d[i] = 1;
                    for (int j=i+1; j<=n; j++)
                    {
                        if (a[i] > a[j] && d[i] < d[j]+1)
                        {
                            d[i] = d[j] + 1;
                        }
                    }
                }

                int ans = d[1];
                for (int i=2; i<=n; i++)
                {
                    if (ans < d[i])
                    {
                        ans = d[i];
                    }
                }
                Console.WriteLine(ans);
            }
        }

        public void Baekjoon_11054()
        {
            //가장 긴 바이토닉 부분 수열
            while(true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                int[] d = new int[n];
                int[] d2 = new int[n];
                
                for (int i = 0; i < n; i++)
                {
                    d[i] = 1;
                    for (int j = 0; j < i; j++)
                    {
                        if (a[j] < a[i] && d[i] < d[j] + 1)
                        {
                            d[i] = d[j] + 1;
                        }
                    }
                }

                for (int i=n-1; i>=0; i--)
                {
                    d2[i] = 1;
                    for (int j=i+1; j<n; j++)
                    {
                        if (a[i] > a[j] && d2[i] < d2[j]+1)
                        {
                            d2[i] = d2[j] + 1;
                        }
                    }
                }

                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    if (ans < d[i]+d2[i]-1)
                    {
                        ans = d[i]+d2[i]-1;
                    }
                }

                Console.WriteLine(ans);
            }
        }

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