using System;

// D071:洗濯物と砂ぼこり
public class D071{
    public static void Main(){
        	var line = Console.ReadLine ().Split(' ');

			//気温
			int t;
			//温度
			int m;
			//結果
			string result = "No";

			if (int.TryParse (line?[0], out t) && int.TryParse (line?[1], out m)) {
				if ((t >= 0 && t <= 40) && (m >= 0 && m <= 100)) {
					if (t >= 25 || m <= 40) {
						result = "Yes";
						if ((t >= 25 && m <= 40) || (t == 30 && m == 20)){
							result = "No";
						}
					}
				}
			}
			Console.WriteLine (result);
    }
}
