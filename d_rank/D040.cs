using System;
using System.Collections.Generic;
using System.Linq;

// D040:連休の天気
public class D040{
    public static void Main(){
			List<int> dayList = new List<int> ();

			for (int i = 1; i <= 7; i++) {
				var line = Console.ReadLine ();
				int num;
				if (int.TryParse (line.Trim (), out num) && num >= 0 && num <= 100) {
						dayList.Add (num);
				} else {
					return;
				}
			}


			var result = dayList.Where (p => p <= 30).Count();

			Console.WriteLine (result);
    }
}