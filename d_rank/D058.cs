using System;

// D058:初詣で
public class D058{
    public static void Main(){
        	var line = Console.ReadLine ();

			string[] arr = line.Split (' ');

			string result = string.Empty;

			int[] iarr = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++) {
				int val;
				if (int.TryParse (arr [i], out val)) {
					iarr [i] = val;
				} else {
					return;
				}
			}

			int L = iarr[0];
			int M = iarr[1];
			int N = iarr[2];

			for (int i = 1; i <= L + M + N; i++) {
				if (i <= L) {
					result += "A";
				}
				if (i > L && i <= M + L) {
					result += "B";
				}

				if (i > M + L) {
					result += "A";
				}
			}
			Console.WriteLine (result);
    }
}
