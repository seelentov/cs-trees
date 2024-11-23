using System;

namespace ConsoleApp1;

public class Node
{
    public int Value { get; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString()
    {
        return ToString(this, "");
    }

    private string ToString(Node? node, string indent)
    {
        if (node == null) return "";

        string result = indent + node.Value + "\n";
        result += ToString(node.Left, indent + "\t");
        result += ToString(node.Right, indent + "\t");
        return result;
    }
}