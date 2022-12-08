using System;

public class Day7
{
   public int _count = 0;
   public int _toDelete = 70000000;

   private class Node {
      public Node? parent { get; set; }
      public List<Node> childs { get; set; }

      public string? name { get; set; }
      public int fileSize { get; set; }

      public Node() {
         childs = new List<Node>();
      }
   }

   public void first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day7/Day7-1 input.txt");

      Node root = new Node() { name = "/", fileSize = 0, parent = null };
      Node current = root;

      foreach (string line in lines) {
         string[] args = line.Split(" ");

         if (args[0] == "$") {
            if (args[1] == "cd") {
               switch (args[2]) {
                  case "/":
                     current = root;
                     break;
                  case "..":
                     current = current.parent;
                     break;
                  default:
                     current = current.childs.First(n => n.name == args[2]);
                     break;
               }
            } else if (args[1] == "ls") {
               // skip to next line
               continue;
            }
         } else {
            // no $ so should be a file
            if (args[0] == "dir") {
               current.childs.Add(new Node() { name = args[1], fileSize = 0, parent = current });
            } else {
               current.fileSize += int.Parse(args[0]);
            }
         }
      }

      Traverse(root);

      Console.WriteLine(_count);
   }

   private int Traverse(Node node) {
      foreach (Node n in node.childs) {
         node.fileSize += Traverse(n);
      }

      if (node.fileSize <= 100000) {
         _count += node.fileSize;
      }

      return node.fileSize;
   }

   public void second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day7/Day7-1 input.txt");

      Node root = new Node() { name = "/", fileSize = 0, parent = null };
      Node current = root;

      foreach (string line in lines) {
         string[] args = line.Split(" ");

         if (args[0] == "$") {
            if (args[1] == "cd") {
               switch (args[2]) {
                  case "/":
                     current = root;
                     break;
                  case "..":
                     current = current.parent;
                     break;
                  default:
                     current = current.childs.First(n => n.name == args[2]);
                     break;
               }
            } else if (args[1] == "ls") {
               // skip to next line
               continue;
            }
         } else {
            // no $ so should be a file
            if (args[0] == "dir") {
               current.childs.Add(new Node() { name = args[1], fileSize = 0, parent = current });
            } else {
               current.fileSize += int.Parse(args[0]);
            }
         }
      }

      Traverse(root);
      int limit = 30000000 - (70000000 - root.fileSize);

      TraverseForDelete(root, limit);

      Console.WriteLine(_toDelete);
   }

   private void TraverseForDelete(Node node, int limit) {
      if (node.fileSize > limit && node.fileSize < _toDelete) {
         _toDelete = node.fileSize;
      }

      foreach (Node n in node.childs) {
         TraverseForDelete(n, limit);
      }
   }
}