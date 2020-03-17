using System;

// D076:禁止ワード
public class D076{
    public static void Main(){
			var line1 = Console.ReadLine ();
			var line2 = Console.ReadLine ();

			string ngWord = line1?.ToString ()?.Trim ();
			string targetWord = line2?.ToString ()?.Trim ();


			string result = targetWord.IndexOf (ngWord) >= 0 ? "NG" : targetWord;

			Console.WriteLine (result);
    }
}