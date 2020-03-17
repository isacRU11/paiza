using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleProject {
	class C016 {
		public static void Main (string[] args) {

			var line = Console.ReadLine ();

			//インターネットスラングリスト登録
			Dictionary<int,char> LeetList = new Dictionary<int, char> ();
			LeetList.Add(0,'O');	
			LeetList.Add(1,'I');
			LeetList.Add(2,'Z');
			LeetList.Add(3,'E');
			LeetList.Add(4,'A');
			LeetList.Add(5,'S');
			LeetList.Add(6,'G');


			//1 ≦ (s の長さ) ≦ 100
			if (line.Length >= 1 && line.Length <= 100) {
				bool isUpperCase = true;
				foreach (char ch in line.ToCharArray()) {
					//s はアルファベット大文字のみからなる
					if (!char.IsUpper (ch)) {
						isUpperCase = false;
					}
				}
				//総合結果
				string result = string.Empty;
				string leet = "";
				string romaji = "";

				if (isUpperCase) {
					foreach (char ch in line.ToCharArray()) {
						foreach (KeyValuePair<int,char> kv in LeetList) {
							if (kv.Value.Equals(ch)) {
								leet = kv.Key.ToString();
							} else if(!kv.Value.Equals(ch)){
								romaji = ch.ToString();
							}
						}
						if (leet != string.Empty) {
							result += leet;
						}
						if (romaji != string.Empty && leet == string.Empty) {
							result += romaji;
						}
						leet = "";
						romaji = "";
					}
					Console.WriteLine (result);
				}
			}
		}
	}
}

