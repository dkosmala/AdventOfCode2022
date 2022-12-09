using System;
using System.Linq;

public class Day8
{
   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day8/Day8-1 input.txt");
      //lines = lines.Take(1).ToArray();

      HashSet<(int,int)> trees = new HashSet<(int, int)>();
      int highest = 0;
      int highestHPos = 0;
      int highestVPos = 0;
      char[] line;

      for(int v = 0; v < lines.Length; v++) {
         highestHPos = 0;
         highest = 0;
         line = lines[v].ToCharArray();

         // to the right
         for(int h = 0; h < line.Length; h++) {
            
            if ((int)line[h] > highest) {
               highest = line[h];
               highestHPos = h;
               trees.Add((v, h));
            }

            if (highest == 9) { break; }
         }

         // to the left
         highest = 0;
         for(int h = line.Length - 1; h > highestHPos; h--) {
            if ((int)line[h] > highest) {
               highest = line[h];
               trees.Add((v, h));
            }
         }
      }

      for (int h = 0; h < 99; h++) {
         highestVPos = 0;
         highest = 0;

         for (int v = 0; v < lines.Length; v++) {
            if ((int)lines[v][h] > highest) {
               highest = lines[v][h];
               highestVPos = v;
               trees.Add((v, h));

               if (highest == 9) { break; }
            }
         }

         highest = 0;
         for (int v = 98; v > highestVPos; v--) {
            if ((int)lines[v][h] > highest) {
               highest = lines[v][h];
               trees.Add((v, h));
            }            
         }
      }

      // foreach((int a, int b) in trees) {
      //    Console.Write("(" + a + "," + b + "), ");
      // }
      Console.WriteLine(trees.Count);
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day8/Day8-1 input.txt");

      int[,] treeGrid = new int[99,99];
      HashSet<(int,int)> trees = new HashSet<(int, int)>();

      for(int v = 0; v < lines.Length; v++) {
         for (int h = 0; h < lines[v].Length; h++) {
            treeGrid[v,h] = (int)char.GetNumericValue(lines[v][h]);

            if (v != 0 && h != 0 && v != lines.Length - 1 && h != lines.Length - 1) {
               trees.Add((v,h));
            }
         }
      }

      int highScore = 0;
      int score = 0;
      foreach((int,int) tree in trees) {
         score = CalcScore(treeGrid, tree);

         if (score > highScore) highScore = score;
      }
      
      //Console.Write(CalcScore(treeGrid, (3,2)));
      Console.WriteLine(highScore);
   }

   private int CalcScore(int[,] treeGrid, (int,int) tree) {
      int score = 0;
      int count = 0;
      int current = treeGrid[tree.Item1, tree.Item2];

      int h = tree.Item2 - 1;
      while (h >= 0 && current > treeGrid[tree.Item1, h]) {
         count++;
         h--;
      }

      score = (h < 0 ? count : count + 1);

      h = tree.Item2 + 1;
      count = 0;
      while (h <= 98 && current > treeGrid[tree.Item1, h]) {
         count++;
         h++;
      }

      score = score * (h > 98 ? count : count + 1);

      int v = tree.Item1 - 1;
      count = 0;
      while (v >= 0 && current > treeGrid[v, tree.Item2]) {
         v--;
         count++;
      }

      score = score * (v < 0 ? count : count + 1);

      v = tree.Item1 + 1;
      count = 0;
      while (v <= 98 && current > treeGrid[v, tree.Item2]) {
         v++;
         count++;
      }

      score = score * (v > 98 ? count : count + 1);   
      return score;
   }
}