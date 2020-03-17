using System;
using System.Collections.Generic;

// D059:トランプ占い
public class D059{
    public static void Main(){
			var line = Console.ReadLine ();
			string[] strArr = line.Split (' ');

			List<string> colArr = new List<string> (){ "J", "Q", "K" };

			if (!colArr.Contains (strArr ?[0]) || !colArr.Contains (strArr ?[1])) {
				return;
			}

			if (strArr [0].Equals ("J") && strArr [1].Equals ("J")) {
				Console.WriteLine (strArr [0] + " Q");
			} else {
				Console.WriteLine (strArr [0] + " " + strArr [1]);
			}
    }
}
