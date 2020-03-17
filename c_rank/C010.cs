using System;
using System.Linq;
using System.Collections.Generic;

// C010:安息の地を求めて
namespace ConsoleProject {
	class C010 {

		public struct Vector2 {
			public int x;
			public int y;

			public Vector2 (int x, int y) {
				this.x = x;
				this.y = y;
			}
		}

		public static void Main (string[] args) {

			/*
			   a:20 b:10 R:10
			   N:3
               x_i:25 y_i:10
               x_i:20 y_i:15
               x_i:70 y_i:70
			 */


			var line1 = Console.ReadLine ();
			var line2 = Console.ReadLine ();


			//string line1 = "20 10 10";
			//string line2 = "3";

			//0 ≦ a ≦ 100
			int a;
			//0 ≦ b ≦ 100
			int b;
			//1 ≦ R ≦ 100
			int R;
			//1 ≦ N ≦ 1000
			int N;


			string[] line1Arr = line1.Split (' ');

			if (int.TryParse (line1Arr ?[0], out a) &&
			    int.TryParse (line1Arr ?[1], out b) &&
			    int.TryParse (line1Arr ?[2], out R) &&
			    int.TryParse (line2.ToString ().Trim (), out N)) {

				if (IsWithin (a, 100) && IsWithin (b, 100) && IsWithin (R, 100) && IsWithin (N, 1000)) {

					List<string> strList = new List<string> ();
					List<Vector2> vec2List = new List<Vector2> ();
					for (int i = 0; i < N; i++) {
						var l = Console.ReadLine ();

						string[] arr = l.Split (' ');

							int x_i;
							int y_i;

							if (int.TryParse (arr ?[0], out x_i) && int.TryParse (arr ?[1], out y_i)) {
							    
								if (IsWithin (x_i, 100) && IsWithin (y_i, 100)) {
									vec2List.Add (new Vector2 (x_i, y_i));
								}
							}
							arr [0] = "";
							arr [1] = "";

					}

					foreach (Vector2 vec in vec2List) {
					    int ax = 0;
					    int by = 0;
					    if(vec.x > a){
					        ax = vec.x - a;
					    }else{
					        ax = a - vec.x;
					    }
					    
					    if(vec.y > b){
					        by = vec.y - b;
					    }else{
					        by = b - vec.y;
					    }
						if ((ax + by) >= R){
							strList.Add ("silent");
						} else {
							strList.Add ("noisy");
						}
					}
					foreach (string str in strList) {
						Console.WriteLine (str);
					}
				}
			}
		}

		public static bool IsWithin (int val, int range) {
			return val >= 0 && val <= range;
		}
	}
}
