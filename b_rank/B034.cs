using System;

// B034:ロボットの歩行実験
public class B034{
        static int[] ConvertToIntArray(string[] strArr,int s,int e) {
            int[] intArr = new int[strArr.Length];
            for(int i = 0;i < strArr.Length;i++) {
                int j;
                if(int.TryParse(strArr[i], out j) && (j >= s && j <= e)) {
                    intArr[i] = j;
                } else {
                    intArr = null;
                }
            }
            return intArr;
        }
        static void Main(string[] args) {

            //スタート地点
            //条件：-1,000 ≦ s_x, s_y ≦ 1,000
            int[] s_xy = ConvertToIntArray(Console.ReadLine().Split(' '),-1000,1000);
            //条件：0 ≦ d_f, d_r, d_b, d_l ≦ 10
            int[] d_frbl = ConvertToIntArray(Console.ReadLine().Split(' '),0,10);
            //条件：0 ≦ N ≦ 1,000
            var N = Console.ReadLine();
            int n;
            if (int.TryParse(N, out n) && (n >= 0 && n <= 1000) && s_xy != null && d_frbl != null) {
                //ロボットが現在向いている方向(F,R,B,L)
                string plook = "F";
                //アクションリストを取得
                for (int i = 0; i < n; i++) {
                    string[] val = Console.ReadLine().Split(' ');
                    if (val[0] == "t") {
                        switch (plook) {
                            case "R": plook = val[1] == "R" ? "B" : val[1] == "B" ? "L" : val[1] == "L" ? "F" : plook; break;
                            case "B": plook = val[1] == "R" ? "L" : val[1] == "B" ? "F" : val[1] == "L" ? "R" : plook; break;
                            case "L": plook = val[1] == "R" ? "F" : val[1] == "B" ? "R" : val[1] == "L" ? "B" : plook; break;
                            case "F": plook = val[1]; break;
                        }
                    } else if (val[0] == "m") {
                        switch (plook) {
                            case "F":
                                if (val[1] == "F") s_xy[1] += d_frbl[0];
                                else if (val[1] == "R") s_xy[0] += d_frbl[1];
                                else if (val[1] == "B") s_xy[1] -= d_frbl[2];
                                else if (val[1] == "L") s_xy[0] -= d_frbl[3];
                                break;
                            case "R":
                                if (val[1] == "F") s_xy[0] += d_frbl[0];
                                else if (val[1] == "R") s_xy[1] -= d_frbl[1];
                                else if (val[1] == "B") s_xy[0] -= d_frbl[2];
                                else if (val[1] == "L") s_xy[1] += d_frbl[3];
                                break;
                            case "B":
                                if (val[1] == "F") s_xy[1] -= d_frbl[0];
                                else if (val[1] == "R") s_xy[0] -= d_frbl[1];
                                else if (val[1] == "B") s_xy[1] += d_frbl[2];
                                else if (val[1] == "L") s_xy[0] += d_frbl[3];
                                break;
                            case "L":
                                if (val[1] == "F") s_xy[0] -= d_frbl[0];
                                else if (val[1] == "R") s_xy[1] += d_frbl[1];
                                else if (val[1] == "B") s_xy[0] += d_frbl[2];
                                else if (val[1] == "L") s_xy[1] -= d_frbl[3];
                                break;
                        }
                    }
                    if (val[0] == "t") continue;
                }
                //結果
                Console.WriteLine(s_xy[0] + " " + s_xy[1]);
            }
        }
}