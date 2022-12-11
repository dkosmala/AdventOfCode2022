using System;

public class Day10
{
   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day10/Day10-1 input.txt");

      int cycle = 1;
      int register = 1;
      int strength = 0;

      foreach (string line in lines) {
         string[] cmds = line.Split(" ");

         if (cmds[0].StartsWith("noop")) {
            strength = CalcStrength(cycle, register, strength);
            Console.WriteLine("Mid cycle " + cycle + " reg: " + register + " str: " + strength);
            cycle++;
         } else if (cmds[0].StartsWith("addx")) {
            strength = CalcStrength(cycle, register, strength);
            Console.WriteLine("Mid cycle " + cycle + " reg: " + register + " str: " + strength);
            cycle++;
            strength = CalcStrength(cycle, register, strength);
            Console.WriteLine("Mid cycle " + cycle + " reg: " + register + " str: " + strength);
            cycle++;

            register += int.Parse(cmds[1]);
         }

      }

      Console.WriteLine(strength);
   }

   private int CalcStrength(int cycle, int reg, int str) {
      if (cycle % 40 == 20) {
         str = str + (cycle * reg);
      }

      return str;
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day10/Day10-1 input.txt");

      int cycle = 1;
      int register = 1;

      foreach (string line in lines) {
         string[] cmds = line.Split(" ");

         if (cmds[0].StartsWith("noop")) {
            //Console.WriteLine("Cycle " + cycle + ", Reg " + register);
            DrawPixel(cycle, register);
            cycle++;
         }
         else if (cmds[0].StartsWith("addx")) {
            //Console.WriteLine("Cycle " + cycle + ", Reg " + register);
            DrawPixel(cycle, register);
            cycle++;
            //Console.WriteLine("Cycle " + cycle + ", Reg " + register);
            DrawPixel(cycle, register);
            cycle++;

            register += int.Parse(cmds[1]);
         }

      }

      Console.WriteLine("");
   }

   private void DrawPixel(int cycle, int register) {
      cycle = cycle % 40;
      cycle--;

      if (cycle >= register - 1 && cycle <= register + 1) {
         Console.Write("#");
      } else {
         Console.Write(".");
      }

      // janktastic
      if ((cycle + 1) == 0) {
         Console.WriteLine();
      }
   }
}