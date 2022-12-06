using System;
using System.Text.RegularExpressions;

public class Day5
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day5/Day5-1 input.txt");

      List<Stack<char>> list = new List<Stack<char>>();
      
      // bottom up
      for (int j = lines.Length-1; j >= 0; j--) {
         if (list.Count == 0) {
            foreach (char c in lines[j].ToCharArray()) {
               list.Add(new Stack<char>());
            }
         }

         char[] chars = lines[j].ToCharArray();

         for(int i = 0; i < chars.Length; i++) {
            if (!Char.IsWhiteSpace(chars[i])) {
               list.ElementAt(i).Push(chars[i]);
            }
         }
      }

      lines = System.IO.File.ReadAllLines(@"Day5/Day5-2 input.txt");

      Regex rx = new Regex(@"(\d+)");
      Stack<char> tempStack = new Stack<char>();
      char toMove;

      foreach (string line in lines) {
         var matches = rx.Matches(line);
         int num = int.Parse(matches[0].Value);
         int from = int.Parse(matches[1].Value);
         int to = int.Parse(matches[2].Value);

         for (int i = 0; i < num; i++) {
            toMove = list.ElementAt(from-1).Pop();
            tempStack.Push(toMove);
         }

         for (int i = 0; i < num; i++) {
            toMove = tempStack.Pop();
            list.ElementAt(to-1).Push(toMove);
         }

      }

      // foreach(Stack<char> stack in list) {
      //    foreach(char c in stack.ToArray()) {
      //       Console.Write(c);
      //    }
      //    Console.WriteLine();
      // }

      foreach(Stack<char> stack in list) {
         Console.Write(stack.Peek());
      }

      return "";
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day1/Day1-1 input.txt");

      return "";
   }
}