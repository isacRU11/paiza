using System;
using System.Linq;
using System.Collections.Generic;

// B008:地下アイドルの夢
namespace ConsoleProject {
	class B008 {
		
		public static void Main (string[] args) {

			var NMLine = Console.ReadLine ();
			string[] nmArr = NMLine.Split (' ');

			//会員数 
			int n;
			//イベント回数
			int m;

			//各ライブの各会員の損益
			List<string[]> profitAndLossList = new List<string[]> (); 

			if (int.TryParse (nmArr? [0], out n) && int.TryParse (nmArr? [1], out m)) {
				//境界チェック： 0 ≦ N ≦ 1000,0 ≦ M ≦ 1000
				if ((n >= 1 && n <= 1000) && (m >= 1 && m <= 1000)) {
					for (int i = 0; i < m; i++) {
						if (n == 0 || m == 0) {
							break;
						}
						var line = Console.ReadLine ();

						string[] strArr = line.Split (' ');
						profitAndLossList.Add (strArr);
					}
				}
			}
			
			List<int> totalList = new List<int> ();

			//会員数、またはイベント回数の値が0だった場合、0を結果として表示
			if (profitAndLossList?.Count == 0) {
				Console.WriteLine (0);
			}
			if (profitAndLossList?.Count > 0) {
				foreach (string[] arr in profitAndLossList) {
					int total = 0;
					foreach (string str in arr) {
						int tempi;
						if (int.TryParse (str, out tempi)) {
							//境界チェック：　-100 ≦ e_{i,j} ≦ 100
							if (tempi >= -100 && tempi <= 100) {
								total += tempi;
							} else {
								//境界外だった場合、処理を中断し、0を結果として表示
								Console.WriteLine (0);
								return;
							}
						}
					}
					totalList.Add (total);
				}

				int temp = 0;
				foreach (int j in totalList) {
					if (j > 0) {
						temp += j;
					}
				}
				Console.WriteLine (temp);
			}
		}

	}
}

