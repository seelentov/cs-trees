﻿using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        BinarySearchTree tree = new();

        int[] test = [1, 2, 3, 4, 5, 6, 7];
        int[] test2 = [4, 6, 2, 3, 1, 7, 5];

        tree.AddRange(test);

        Console.WriteLine(tree);

        tree.PrintTree();
    }

}