using System;

public class Day1
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day1/Day1-1 input.txt");

      int mostCalories = 0;
      int currentCalories = 0;

      for(int i = 0; i < lines.Length; i++) {
         if (lines[i].Length == 0) {
            if (currentCalories > mostCalories) {
               mostCalories = currentCalories;
            }

            currentCalories = 0;
         } else {
            currentCalories += Int32.Parse(lines[i]);
         }
      }

      return mostCalories.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day1/Day1-1 input.txt");

      int currentCalories = 0;
      List<int> elfSnacks = new List<int>();

      for (int i = 0; i < lines.Length; i++)
      {
         if (lines[i].Length == 0) {
            elfSnacks.Add(currentCalories);
            currentCalories = 0;
         }
         else {
            currentCalories += Int32.Parse(lines[i]);
         }
      }

      elfSnacks = elfSnacks.OrderDescending().ToList<int>();

      return (elfSnacks[0] + elfSnacks[1] + elfSnacks[2]).ToString();
   }
}