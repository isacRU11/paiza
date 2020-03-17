using System;

// D056:かまくらづくり
public class D056{
    public static void Main(){
			var line = Console.ReadLine ();

			string[] strArr = line.Split (' ');

			int[] iArr = new int[strArr.Length];
			for (int i = 0; i < strArr.Length; i++) {
				int temp;
				if (int.TryParse (strArr [i], out temp)) {
					if (temp < 1 || temp > 20) {
						return;
					}
					iArr [i] = temp;
				} else {
					return;
				}
			}

			int r_1 = iArr [0];
			int r_2 = iArr [1];

			Console.WriteLine (RtnVal(r_1) - RtnVal(r_2));
    }
    		public static int RtnVal(int val){
			int rtnVal = 0;
			int temp = val;
			for (int i = 0; i < 2; i++) {
				rtnVal = temp * val;
				temp = rtnVal;
			}

			return rtnVal;
		}
}
