namespace Programe
{
    public static class Programe
    {
        static void Main(string[] args)
        {
            Study study = new Study();
            //math.Baekjoon_2609();
            //math.Baekjoon_17425();
            
            //math.Baekjoon_17427();
            string[] enroll = {"john", "mary", "edward", "sam", "emily", "jaimie", "tod", "young"};
            string[] referral = {"-", "-", "mary", "edward", "mary", "mary", "jaimie", "edward"};
            string[] seller = {"young", "john", "tod", "emily", "mary"};
            int[] amount = {12, 4, 2, 5, 10};
            study.WebBackEnd_2021_Lv3(enroll, referral, seller, amount);
            //[360, 958, 108, 0, 450, 18, 180, 1080]
        }
    }
}