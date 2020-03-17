using System;

// D057:プレゼント選び
public class D057{
    public static void Main(){
        	var line1 = Console.ReadLine ();
			var line2 = Console.ReadLine ();

			string[] strArr = line2.Split (' ');

			foreach (string str in strArr) {
				if (str.Length < 1 || str.Length > 20) {
					return;
				}
				foreach (char ch in str) {
				    //英小文字かチェック
					if (!char.IsLower (ch)) {
						return;
					}
				}
			}

			int seiseki;
			if (!int.TryParse (line1, out seiseki)) {
				return;
			}

			if (seiseki >= 1 && seiseki <= 3) {
				for(int i = 1;i <= strArr.Length;i++){
					if (seiseki == i) {
						Console.WriteLine (strArr [i - 1]);
					}
				}
			}
    }
}
