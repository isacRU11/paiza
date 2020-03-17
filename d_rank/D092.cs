using System;

// D092:花見の準備
public class D092{
        private static int[] ConvertToIntArray(string[] strArr) {
            int[] intArr = new int[strArr.Length];
            for (int i = 0; i < strArr.Length; i++) {
                int j;
                intArr[i] = int.TryParse(strArr[i], out j) ? j : 0;
            }
            return intArr;
        }

        private static bool CompOfInt(int value, int s, int e) {
            return value >= s && value <= e;
        }
    public static void Main(){
             var line1 = Console.ReadLine();
            var line2 = Console.ReadLine();

            int[] arr1 = ConvertToIntArray(line1.Split(' '));
            int[] arr2 = ConvertToIntArray(line2.Split(' '));

            if (CompOfInt(arr1[2], 1000, 50000) &&
                CompOfInt(arr2[2], 1000, 50000) &&
                CompOfInt(arr1[0], 1, 30) &&
                CompOfInt(arr1[1], 1, 30) &&
                CompOfInt(arr2[0], 1, 30) &&
                CompOfInt(arr2[1], 1, 30)) {

                int tmp = 0;
                if (arr1[2] < arr2[2]) {
                    tmp = (arr1[2] / (arr1[0] * arr1[1])) * (arr2[0] * arr2[1]);
                    if (tmp < arr2[2]) Console.WriteLine(line1);
                    else if (tmp == arr2[2]) Console.WriteLine("DRAW");
                } else {
                    tmp = (arr2[2] / (arr2[0] * arr2[1])) * (arr1[0] * arr1[1]);
                    if (tmp < arr1[2]) Console.WriteLine(line2);
                    else if (tmp == arr1[2]) Console.WriteLine("DRAW");
                }
            }
    }
}