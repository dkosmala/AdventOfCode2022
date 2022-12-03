using System;

public class Day2
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day2/Day2-1 input.txt");

      int total = 0;

      for (int i = 0; i < lines.Length; i++) {
         lines[i] = lines[i].Replace("A", "1");
         lines[i] = lines[i].Replace("B", "2");
         lines[i] = lines[i].Replace("C", "3");
         lines[i] = lines[i].Replace("X", "1");
         lines[i] = lines[i].Replace("Y", "2");
         lines[i] = lines[i].Replace("Z", "3");
      }

      string debug;

      foreach (string line in lines) {
         string[] choices = line.Split(" ");
         int me = Int32.Parse(choices[1]);
         int him = Int32.Parse(choices[0]);

         if (me == him) {
            total += me + 3;
            debug = "TIE  " + me + " " + him + "  " + total;
         } else if (me == 3 && him == 1) {
            total += me;
            debug = "LOSS " + me + " " + him + "  " + total;
         } else if (me > him || (me == 1 && him == 3)) {
            total += me + 6;
            debug = "WIN  " + me + " " + him + "  " + total;
         } else {
            total += me;
            debug = "LOSS " + me + " " + him + "  " + total;
         }

         //Console.WriteLine(debug);
      }

      return total.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day2/Day2-1 input.txt");

      int total = 0;

      for (int i = 0; i < lines.Length; i++)
      {
         lines[i] = lines[i].Replace("A", "1");
         lines[i] = lines[i].Replace("B", "2");
         lines[i] = lines[i].Replace("C", "3");
      }

      foreach (string line in lines) {
         string[] choices = line.Split(" ");
         int him = Int32.Parse(choices[0]);
         int me = -1;

         switch (choices[1]) {
            case "X":
               me = him - 1;
               if (me == 0) me = 3;
               break;
            case "Y":
               me = him;
               break;
            case "Z":
               me = him % 3 + 1;
               break;
         }

         if (me == him) {
            total += me + 3;
         } else if (me == 3 && him == 1) {
            total += me;
         } else if (me > him || (me == 1 && him == 3)) {
            total += me + 6;
         } else {
            total += me;
         }
      }

      return total.ToString();
   }
}