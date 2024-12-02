using System;

namespace ConsoleApp1;

public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }


    public Node(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return ToString(this);
    }

    enum Side
    {
        Left,
        Right
    }

    private string ToString(Node? node, string indent = "", Side? side = null)
    {
        if (node == null) return "";

        string result = indent + (side == Side.Right ? "R:" : side == Side.Left ? "L:" : " ") + node.Value + "\n";
        result += ToString(node.Right, indent + "\t", Side.Right);
        result += ToString(node.Left, indent + "\t", Side.Left);
        return result;
    }
}