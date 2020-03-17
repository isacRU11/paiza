using System;

// B011:名刺バインダー管理
public class Hello{
        public static void Main(){
            var line = Console.ReadLine().Split(' ');
            //バインダーのポケットの数
            int n = int.Parse(line[0]);
            //名刺の番号
            int m = int.Parse(line[1]);

            if (!CompOfInt(n, 1, 100000) || !CompOfInt(m, 1, 100000)) return;

            //番号のページ数
            int pageNo = n > m ? m : (int)Math.Round((double) m / n);
            
            //前・次ページの初カード番号
            int bnPage              = 1;
            if (pageNo > 1 ) bnPage = pageNo % 2 == 0 ? (n * (pageNo - 1)) - n : (n * (pageNo + 1)) - n;
            
            //前・次ページの差分
            int bnDiff = n > m ? Math.Abs((n * pageNo) + m) + 1 : Math.Abs((n * pageNo) - m) + 1;
           
            Console.WriteLine(bnPage + bnDiff);
        }
/*-------------  以下のメソッドは他の問題でも使うため、本来は共通化しているクラスにまとめているものである。-------*/
        public static bool CompOfInt(int value, int s, int e){
            return value >= s && value <= e;
        }
}