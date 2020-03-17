using System;

// D072:データのバックアップ
public class D072{
    public static void Main(){
			var line = Console.ReadLine ().Split (' ');
			//バックアップをしたいデータの容量
			int X;
			//外部記憶装置 1 つあたりの容量
			int Y;
			//外部記憶装置 1 つあたりの価格
			int P;

			if (!int.TryParse (line? [0], out X) || 
				!int.TryParse (line? [1], out Y) || 
				!int.TryParse (line? [2], out P)) {
				return;
			}

			if ((X >= 1 && X <= 1000) && (Y >= 1 && Y <= 1000) && (P >= 1 && P <= 10000)) {
				if (Y >= X) {
					Console.WriteLine (P);
				} else {
					while (X > Y) {
						Y *= Y;
						P *= 2;
						if (Y >= X) {
							Console.WriteLine (P);
							return;
						}
					}
				}
			}
    }
}
