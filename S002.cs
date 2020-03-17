using System;
using System.Collections.Generic;

// S002:最短距離を測る
namespace Paiza {
	public class AppMain {
		struct Location {
			internal int X, Y;
			internal int Count;
		}

		struct Vector2 {
			public int X{ get; set; }

			public int Y{ get; set; }

			public Vector2 (int x, int y) {
				this.X = x;
				this.Y = y;
			}
		}

		public static void Main (string[] args) {
			/*
			List<string> Map1 = new List<string> { 
				"0s01",
				"0010",
				"0110",
				"001g",
				"0000"
			};
			*/

			var MNLine = Console.ReadLine ();
			string[] mnArr = MNLine.Split (' ');

			//行の数 
			int n;
			//列の数
			int m;

			//「スタート」は's',「ゴール」は'g',「道」は'0',「壁」は'1'
			List<string> map = new List<string>();

			if (int.TryParse (mnArr? [0], out n) && int.TryParse (mnArr? [1], out m)) {
				//境界チェック： 0 ≦ N ≦ 1000,0 ≦ M ≦ 1000
				if ((n >= 1 && n <= 1000) && (m >= 1 && m <= 1000)) {
					for (int i = 0; i < m; i++) {
						if (n == 0 || m == 0) {
							break;
						}
						var line = Console.ReadLine ();

						string[] strArr = line.Split (' ');
						string temp = string.Empty;
						foreach (string s in strArr) {
							temp += s;
						}
						map.Add (temp);
					}
				}
			}

			foreach (string s in map) {
				if (s.Length != n) {
					return;
				}
			}

			if (map.Count == 0) {
				return;
			}

			map.Insert (0, AddStr("1",n));
			map.Insert (map.Count, AddStr("1",n));

			for (int i = 0; i < map.Count; i++) {
				map [i] = "1" + map [i];
				
				map [i] += "1";
			}

			string[] Map = map.ToArray ();

			var que = new Queue<Location> ();

			Location start;

			bool IsExistGoal = false;

			for (int i = 0; i < Map.Length; i++) {
				for (int j = 0; j < Map [i].Length; j++) {
					if (Map [i] [j] == 's') {
						char c = Map [i] [j];
						start.X = j;
						start.Y = i;
						start.Count = 1;
						que.Enqueue (start);
					}

					if (Map [i] [j] == 'g') {
						IsExistGoal = true;
						if (j > 0 && j < Map [0].Length - 1 && i > 0 && i < Map.GetUpperBound (0)) {
							if (Map [i - 1] [j] == '1' &&
							   Map [i + 1] [j] == '1' &&
							   Map [i] [j - 1] == '1' &&
							   Map [i] [j + 1] == '1') {
								IsExistGoal = false;
							}
						}
					}
				}
			}

			do {
				if (!IsExistGoal || que?.Count == 0) {
					Console.WriteLine ("Fail");
					break;
				}
				Location lo = que.Dequeue ();
				Vector2[] pArgs = new Vector2[] { new Vector2 (lo.X - 1, lo.Y), 
					new Vector2 (lo.X + 1, lo.Y), 
					new Vector2 (lo.X, lo.Y - 1), 
					new Vector2 (lo.X, lo.Y + 1)
				};

				foreach (Vector2 point in pArgs) {
					if (point.X > 0 && point.X < Map [0].Length - 1 && point.Y > 0 && point.Y < Map.GetUpperBound (0)) {
						char ch = Map [point.Y] [point.X];
						if (ch == '0') {
							start.X = point.X;
							start.Y = point.Y;
							start.Count = lo.Count + 1;
							que.Enqueue (start);
						} else if (ch == 'g') {
							Console.WriteLine (lo.Count);
							return;
						}

					}
				}
			} while(que.Count > 0);
		}

		private static string AddStr(string val , int cnt){
			string strVal = string.Empty;
			for (int i = 0; i < cnt; i++) {
				strVal += val;
			}
			return strVal;
		}
	}
}

