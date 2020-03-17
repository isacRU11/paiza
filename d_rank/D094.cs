using System;
using System.Linq;

// D094:犬派か猫派か
public class D094{
    public static void Main(){
            string[] resultArr = new string[3];
            for (int i = 0; i < 3; i++){
                var line = Console.ReadLine();
                if (line != "cat" && line != "dog") return;
                resultArr[i] = line;
            }
            Console.WriteLine(resultArr.Count(p => p == "dog") > resultArr.Count(p => p == "cat") ? "dog" : "cat");
    }
}