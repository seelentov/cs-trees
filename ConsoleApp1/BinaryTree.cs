using System;

namespace ConsoleApp1;

public class BinaryTree
{
    public Node? RootNode { get; protected set; } = null;

    public override string ToString()
    {
        return RootNode != null ? RootNode.ToString() : "";
    }

    public List<int> InOrder(Node? node = null, bool first = true, List<int>? list = null)
    {
        if (RootNode == null)
        {
            return [];
        }

        if (node == null && first)
        {
            node = RootNode;
        }

        else if (node == null)
        {
            return [];
        }

        if (list == null)
        {
            list = [];
        }

        InOrder(node?.Left, false, list);
        if (node != null) list.Add(node.Value);
        InOrder(node?.Right, false, list);

        return list;
    }

    public List<int> PreOrder(Node? node = null, bool first = true, List<int>? list = null)
    {
        if (RootNode == null)
        {
            return [];
        }

        if (node == null && first)
        {
            node = RootNode;
        }

        else if (node == null)
        {
            return [];
        }

        if (list == null)
        {
            list = [];
        }

        if (node != null) list.Add(node.Value);
        PreOrder(node?.Left, false, list);
        PreOrder(node?.Right, false, list);

        return list;
    }

    public List<int> PostOrder(Node? node = null, bool first = true, List<int>? list = null)
    {
        if (RootNode == null)
        {
            return [];
        }

        if (node == null && first)
        {
            node = RootNode;
        }

        else if (node == null)
        {
            return [];
        }

        if (list == null)
        {
            list = [];
        }

        PostOrder(node?.Left, false, list);
        PostOrder(node?.Right, false, list);
        if (node != null) list.Add(node.Value);

        return list;
    }


    public void PrintTree(Node? node = null, bool first = true)
    {
        foreach (var value in InOrder(node))
        {
            Console.WriteLine(value);
        }
    }

    public void BFS(Action<Node> dlg, Node? node = null)
    {
        if (node == null)
        {
            node = RootNode;
        }

        if (node == null)
        {
            throw new Exception("Empty RootNode");
        }

        Queue<Node> queue = [];

        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node currNode = queue.Dequeue();

            dlg(currNode);

            if (currNode.Left != null)
            {
                queue.Enqueue(currNode.Left);
            }


            if (currNode.Right != null)
            {
                queue.Enqueue(currNode.Right);
            }
        }
    }

    public void DFS(Action<Node> dlg, Node? node = null)
    {
        if (node == null)
        {
            node = RootNode;
        }

        if (node == null)
        {
            throw new Exception("Empty RootNode");
        }

        Stack<Node> stack = new();
        stack.Push(node);

        while (stack.Count > 0)
        {
            Node currNode = stack.Pop();

            dlg(currNode);

            if (currNode.Left != null)
            {
                stack.Push(currNode.Left);
            }


            if (currNode.Right != null)
            {
                stack.Push(currNode.Right);
            }
        }
    }
}
