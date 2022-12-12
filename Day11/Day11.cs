using System;
using System.Text.RegularExpressions;

public class Day11
{
   public class Monkey {
      public int id;
      public Queue<int> items = new Queue<int>();
      public string operation = "";
      public int testDivisor;
      public int trueMonkey;
      public int falseMonkey;
      public int inspected = 0;

   }

      public class BigMonkey {
      public int id;
      public Queue<double> items = new Queue<double>();
      public string operation = "";
      public int testDivisor;
      public int trueMonkey;
      public int falseMonkey;
      public double inspected = 0;

   }

   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day11/input.txt");
      Regex rx;
      List<Monkey> monkeys = new List<Monkey>();
      Monkey current = new Monkey();

      foreach(string line in lines) {
         if (line.TrimStart().StartsWith("Monkey")) {
            rx = new Regex(@"\d");

            current = new Monkey();
            current.id = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("Starting")) {
            rx = new Regex(@"\s(\d+)");

            foreach (Match match in rx.Matches(line)) {
               current.items.Enqueue(int.Parse(match.Value));
            }
         } else if (line.TrimStart().StartsWith("Operation")) {
            rx = new Regex(@"[*+]\s\d+");
            current.operation = rx.Match(line).Value;
         } else if (line.TrimStart().StartsWith("Test")) {
            rx = new Regex(@"\d+");
            current.testDivisor = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("If true")) {
            rx = new Regex(@"\d");
            current.trueMonkey = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("If false")) {
            rx = new Regex(@"\d");
            current.falseMonkey = int.Parse(rx.Match(line).Value);
         } else if (line.Trim() == "") {
            monkeys.Add(current);
         }
      }

      monkeys = monkeys.OrderBy(m => m.id).ToList();

      int totalRounds = 20;

      for(int round = 1; round <= totalRounds; round++) {
         foreach (Monkey monkey in monkeys) {
            while (monkey.items.Count > 0) {
               monkey.inspected++;
               int item = monkey.items.Dequeue();
               item = DoOperation(monkey.operation, item);
               item = item / 3;

               if (item % monkey.testDivisor == 0) {
                  monkeys.First(m => m.id == monkey.trueMonkey).items.Enqueue(item);
               } else {
                  monkeys.First(m => m.id == monkey.falseMonkey).items.Enqueue(item);
               }
            }
         }
      }

      monkeys = monkeys.OrderByDescending(k => k.inspected).ToList();

      int monkeyBusiness = monkeys[0].inspected * monkeys[1].inspected;

      Console.WriteLine(monkeyBusiness);
   }

   private int DoOperation(string op, int worry) {
      string[] args = op.Split(" ");
      if (args[0] == "+") {
         return worry + int.Parse(args[1]);
      } else if (args[0] == "*") {
         return worry * int.Parse(args[1]);
      } else if (op.Length == 0) {
         // haaaaackish
         return worry * worry;
      }

      return worry;
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day11/input.txt");
      Regex rx;
      List<BigMonkey> monkeys = new List<BigMonkey>();
      BigMonkey current = new BigMonkey();

      foreach(string line in lines) {
         if (line.TrimStart().StartsWith("Monkey")) {
            rx = new Regex(@"\d");

            current = new BigMonkey();
            current.id = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("Starting")) {
            rx = new Regex(@"\s(\d+)");

            foreach (Match match in rx.Matches(line)) {
               current.items.Enqueue(int.Parse(match.Value));
            }
         } else if (line.TrimStart().StartsWith("Operation")) {
            rx = new Regex(@"[*+]\s\d+");
            current.operation = rx.Match(line).Value;
         } else if (line.TrimStart().StartsWith("Test")) {
            rx = new Regex(@"\d+");
            current.testDivisor = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("If true")) {
            rx = new Regex(@"\d");
            current.trueMonkey = int.Parse(rx.Match(line).Value);
         } else if (line.TrimStart().StartsWith("If false")) {
            rx = new Regex(@"\d");
            current.falseMonkey = int.Parse(rx.Match(line).Value);
         } else if (line.Trim() == "") {
            monkeys.Add(current);
         }
      }

      monkeys = monkeys.OrderBy(m => m.id).ToList();

      int primeProd = 1;
      monkeys.ForEach(d => primeProd = primeProd * d.testDivisor);

      int totalRounds = 10000;

      for(int round = 1; round <= totalRounds; round++) {
         foreach (BigMonkey monkey in monkeys) {
            while (monkey.items.Count > 0) {
               monkey.inspected++;
               double item = monkey.items.Dequeue();
               item = DoBigOperation(monkey.operation, item);
               item = item % primeProd;

               if (item % monkey.testDivisor == 0) {
                  monkeys.First(m => m.id == monkey.trueMonkey).items.Enqueue(item);
               } else {
                  monkeys.First(m => m.id == monkey.falseMonkey).items.Enqueue(item);
               }
            }
         }

         if (round == 1 || round == 20 || round == 1000) {
            Console.WriteLine("Round " + round + ": " + monkeys[0].inspected + ' ' + monkeys[1].inspected + ' ' + monkeys[2].inspected + ' ' + monkeys[3].inspected + ' ');
         }
      }

      monkeys = monkeys.OrderByDescending(k => k.inspected).ToList();

      double monkeyBusiness = monkeys[0].inspected * monkeys[1].inspected;

      Console.WriteLine(monkeyBusiness);
   }

   private double DoBigOperation(string op, double worry) {
      string[] args = op.Split(" ");
      if (args[0] == "+") {
         return worry + double.Parse(args[1]);
      } else if (args[0] == "*") {
         return worry * double.Parse(args[1]);
      } else if (op.Length == 0) {
         // haaaaackish
         return worry * worry;
      }

      return worry;
   }
}