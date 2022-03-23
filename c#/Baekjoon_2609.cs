using System.Text;

namespace Programe
{
    public class Programe
    {
        //백준 2609번 : 최대공약수와 최소공배수
        static void Main(string[] args)
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

        static int getGcd(int a, int b)
        {
            //GCD(a,b) = GCD(b,r)
            //GCD(581, 322) = GCD(322, 259) = GCD(259, 63) =  GCD(63, 7) = GCD(7, 0) = 7
            
            if (b == 0) return a;
            return getGcd(b, a % b);
        }
    }
}