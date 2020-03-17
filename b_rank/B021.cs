using System;
using System.Linq;

// B021:複数形への変換
public class Hello{
    public static void Main(){
            //入力数
            var line1 = Console.ReadLine();
            int n;
            //1 ≦ N ≦ 10
            if (!int.TryParse(line1, out n) || !CompOfInt(n, 1, 10)) return;

            string[] resultArr = new string[n];
            for (int i = 0; i < n; i++){
                string line2 = Console.ReadLine();
                if (!CompOfString(line2,2,20) || line2.ToCharArray().Any(p => char.IsUpper(p))) break;
                int len = line2.Length - 1;
                
                //末尾が s, sh, ch, o, x のいずれかである英単語の末尾に es を付ける
                bool[] conditionsArr1 = new bool[]{
                    line2.Substring(len).Equals("s"),
                    line2.Substring(len - 1).Equals("sh"),
                    line2.Substring(len - 1).Equals("ch"),
                    line2.Substring(len).Equals("o"),
                    line2.Substring(len).Equals("x")
                };
                
                //末尾が f, fe のいずれかである英単語の末尾の f, fe を除き、末尾に ves を付ける
                bool[] conditionsArr2 = new bool[]{
                    line2.Substring(len).Equals("f"),
                    line2.Substring(len - 1).Equals("fe")
                };
                
                //末尾の1文字が y で、末尾から2文字目が a, i, u, e, o のいずれでもない英単語の末尾の y を除き、末尾に ies を付ける
                bool[] conditionsArr3 = new bool[]{
                    !line2.Substring(len - 1, 1).Equals("a"),
                    !line2.Substring(len - 1, 1).Equals("i"),
                    !line2.Substring(len - 1, 1).Equals("u"),
                    !line2.Substring(len - 1, 1).Equals("e"),
                    !line2.Substring(len - 1, 1).Equals("o")
                };

                if (conditionsArr1.Any(p => p))
                    line2 += "es";
                else if (conditionsArr2.Any(p => p))
                    line2 = line2.Substring(len).Equals("f") ? 
                        line2.Substring(0,len) + line2.Substring(len).Replace("f", "ves") :
                        line2.Substring(0,len - 1) + line2.Substring(len - 1).Replace("fe", "ves");
                else if (line2.Substring(len).Equals("y") && conditionsArr3.All(p => p))
                    line2 = line2.Substring(0,len) + line2.Substring(len).Replace("y", "ies");
                else
                    line2 += "s";

                resultArr[i] = line2;
            }
            
            resultArr.ToList().ForEach(p => {Console.WriteLine(p);});
    }

/*-------------  以下のメソッドは他の問題でも使うため、本来は共通化しているクラスにまとめているものである。-------*/
        public static bool CompOfInt(int value, int s, int e) {
            return value >= s && value <= e;
        }

        public static bool CompOfString(string value, int s, int e){
            return value.Length >= s && value.Length <= e;
        }
}