using System;

public class Day3
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day3/Day3-1 input.txt");

      List<char> dupes = new List<char>();

      foreach (string line in lines) {
         string left = line.Substring(0, line.Length / 2);
         string right = line.Substring(line.Length / 2);

         IEnumerable<char> found = left.ToCharArray().Intersect(right.ToCharArray());
         dupes.Add(found.First());
      }

      int score = 0;

      // a = 97, A = 65
      foreach (char c in dupes) {
         if ((byte)c < 97) {
            score += c - 64 + 26;
         } else {
            score += c - 96;
         }
      }

      return score.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day3/Day3-1 input.txt");

      List<char> dupes = new List<char>();

      for (int i = 0; i < lines.Length; i += 3)
      {
         IEnumerable<char> found = lines[i].ToCharArray().Intersect(lines[i+1].ToCharArray()).Intersect(lines[i+2]);
         dupes.Add(found.First());
      }

      int score = 0;

      // a = 97, A = 65
      foreach (char c in dupes)
      {
         if ((byte)c < 97)
         {
            score += c - 64 + 26;
         }
         else
         {
            score += c - 96;
         }
      }

      return score.ToString();
   }
}