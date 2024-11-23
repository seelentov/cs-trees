using System;

namespace ConsoleApp1;

public class BinarySearchTree
{
    public static void Show()
    {
        Node binarySearchTree = new(8,
            new Node(4,
                new Node(2,
                    new Node(1),
                    new Node(3)
                ),
                new Node(6,
                    new Node(5),
                    new Node(7)
                )
            ),
            new Node(12,
                new Node(10,
                    new Node(9),
                    new Node(11)
                ),
                new Node(13,
                    new Node(14),
                    new Node(15)
                )
            )
        );

        Console.WriteLine("Tree:");
        Console.WriteLine(binarySearchTree);
        Console.WriteLine("Needed:");
        Console.WriteLine(binarySearchTree.Left?.Left?.Left);
        Console.WriteLine("Search result:");
        Node? finded = Search(binarySearchTree, 10);
        Console.WriteLine(finded);
    }

    public static Node? Search(Node node, int value)
    {
        Node curr = node;

        while (true)
        {
            if (curr.Value == value)
            {
                return curr;
            }

            if (curr.Value > value && curr.Left != null)
            {
                curr = curr.Left;
                continue;
            }

            if (curr.Value < value && curr.Right != null)
            {
                curr = curr.Right;
                continue;
            }

            return null;
        }
    }
}
