using System;

public class Day4
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day4/Day4-1 input.txt");

      int overlaps = 0;

      foreach(string line in lines) {
         int[] a = Array.ConvertAll(line.Split(",")[0].Split("-"), s => int.Parse(s));
         int[] b = Array.ConvertAll(line.Split(",")[1].Split("-"), s => int.Parse(s));

         if ((a[0] <= b[0] && a[1] >= b[1]) || (b[0] <= a[0] && b[1] >= a[1])) {
            overlaps++;
         }
      }

      return overlaps.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day4/Day4-1 input.txt");

      int overlaps = 0;

      foreach(string line in lines) {
         int[] a = Array.ConvertAll(line.Split(",")[0].Split("-"), s => int.Parse(s));
         int[] b = Array.ConvertAll(line.Split(",")[1].Split("-"), s => int.Parse(s));

         if (!(a[1] < b[0] || b[1] < a[0])) {
            overlaps++;
         }
      }

      return overlaps.ToString();
   }
}