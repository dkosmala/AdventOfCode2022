using System;
using System.Numerics;

public class Day9
{
   private class RopePart {
      public int x { get; set; }
      public int y { get; set; }

      public RopePart() {
         x = 0;
         y = 0;
      }
   }

   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day9/Day9-1 input.txt");

      RopePart head = new RopePart();
      RopePart tail = new RopePart();
      HashSet<(int,int)> positions = new HashSet<(int, int)>();

      foreach(string line in lines) {
         string[] cmds = line.Split(" ");
         string dir = cmds[0];

         for(int i = 0; i < int.Parse(cmds[1]); i++) {

            if (dir == "R") {
               head.x++;
            } else if (dir == "L") {
               head.x--;
            } else if (dir == "U") {
               head.y++;
            } else if (dir == "D") {
               head.y--;
            }

            tail = ComputeTail(head, tail);
            positions.Add((tail.x, tail.y));
         }
      }

      Console.WriteLine(positions.Count);
   }

   private RopePart ComputeTail(RopePart head, RopePart tail) {
      int diffX = head.x - tail.x;
      int diffY = head.y - tail.y;

      if (tail.y == head.y) {
         if (diffX >= 2) {
            tail.x++;
         } else if (diffX <= -2) {
            tail.x--;
         } else {
            // tail doesn't move
         }
      } else if (tail.x == head.x) {
         if (diffY >= 2) {
            tail.y++;
         } else if (diffY <= -2) {
            tail.y--;
         } else {
            // tail doesn't move
         }
      } else {
         // head and tail not in same column and row, potential diagonal
         if (Math.Abs(diffX) < 2 && Math.Abs(diffY) < 2) {
            // within distance 1 of head, don't need to move
         } else {
            if (diffX > 0) {
               tail.x++;
            } else if (diffX < 0) {
               tail.x--;
            }

            if (diffY > 0) {
               tail.y++;
            } else if (diffY < 0) {
               tail.y--;
            }
         }
      }

      return tail;
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day9/Day9-1 input.txt");

      List<RopePart> knots = new List<RopePart>();
      HashSet<(int,int)> positions = new HashSet<(int, int)>();
      RopePart head, tail;

      for(int i = 0; i < 10; i++) {
         knots.Add(new RopePart());
      }

      foreach(string line in lines) {
         string[] cmds = line.Split(" ");
         string dir = cmds[0];

         for(int i = 0; i < int.Parse(cmds[1]); i++) {

            for(int k = 0; k < knots.Count - 1; k++) {
               head = knots[k];
               tail = knots[k+1];

               if (k == 0) {
                  if (dir == "R")
                  {
                     head.x++;
                  }
                  else if (dir == "L")
                  {
                     head.x--;
                  }
                  else if (dir == "U")
                  {
                     head.y++;
                  }
                  else if (dir == "D")
                  {
                     head.y--;
                  }
               }

               tail = ComputeTail(head, tail);

               if (k == 8) {
                  positions.Add((tail.x, tail.y));
               }

               knots[k] = head;
               knots[k+1] = tail;
            }
         }
      }

      Console.WriteLine(positions.Count);
   }
}