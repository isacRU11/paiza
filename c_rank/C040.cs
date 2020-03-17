using System;
using System.Collections.Generic;

// C040:【ロジサマコラボ問題】背比べ
public class C040{
    public static void Main(){
			var line = Console.ReadLine ();

			Dictionary<float,string> dc = new Dictionary<float, string> ();
			int len;
			if (!int.TryParse (line, out len)) {
				return;
			}

			if (len < 2 || len > 100) {
				return;
			}

			for (int i = 0; i < len; i++) {
				var line2 = Console.ReadLine ().Split (' ');
				float f;
				if (float.TryParse (line2 [1], out f)) {
					if (f < 100 || f > 200) {
						return;
					}
					dc.Add (f, line2? [0]);
				} else {
					return;
				}
			}

			//以上
			List<float> le_List = new List<float> ();
			//以下
			List<float> ge_List = new List<float> ();

			foreach (var v in dc) {
				if (v.Value == "le") {
					le_List.Add (v.Key);
				}
				if (v.Value == "ge") {
					ge_List.Add (v.Key);
				}
			}

			le_List.Sort ();
			ge_List.Sort ();

			Console.WriteLine (ge_List? [ge_List.Count - 1] + " " + le_List? [0]);
		
    }
}
