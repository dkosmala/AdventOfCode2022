using System.Text.RegularExpressions;

public class Day6
{
   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day6/Day6-1 input.txt");
      string line = lines[0];
      int i = 0;

      Queue<char> queue = new Queue<char>();

      foreach (char c in line.ToCharArray()) {
         i++;

         while (queue.Contains(c)) {
            queue.Dequeue();
         }

         queue.Enqueue(c);

         if (queue.Count == 4) {
            break;
         }
      }

      foreach (char c in queue) {
         Console.Write(c);
      }

      Console.WriteLine(" " + i);
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day6/Day6-1 input.txt");
      string line = lines[0];
      int i = 0;

      Queue<char> queue = new Queue<char>();

      foreach (char c in line.ToCharArray()) {
         i++;

         while (queue.Contains(c)) {
            queue.Dequeue();
         }

         queue.Enqueue(c);

         if (queue.Count == 14) {
            break;
         }
      }

      foreach (char c in queue) {
         Console.Write(c);
      }

      Console.WriteLine(" " + i);
   }
}