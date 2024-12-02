using System;

namespace ConsoleApp1;

public class BinarySearchTree
{
    public Node? RootNode { get; private set; } = null;

    public override string ToString()
    {
        return RootNode != null ? RootNode.ToString() : "";
    }

    public Node GetMin(Node? node = null)
    {
        if (node == null)
        {
            node = RootNode;
        }

        if (node == null)
        {
            throw new Exception("Empty RootNode");
        }

        Node currentNode = node;

        while (true)
        {
            if (currentNode.Left == null)
            {
                return currentNode;
            }
            else
            {
                currentNode = currentNode.Left;
            }
        }
    }

    public Node GetMax(Node? node = null)
    {
        if (node == null)
        {
            node = RootNode;
        }

        if (node == null)
        {
            throw new Exception("Empty RootNode!");
        }

        Node currentNode = node;

        while (true)
        {
            if (currentNode.Right == null)
            {
                return currentNode;
            }
            else
            {
                currentNode = currentNode.Right;
            }
        }
    }

    public void Add(int value)
    {
        if (RootNode == null)
        {
            RootNode = new Node(value);
            return;
        }

        Node currentNode = RootNode;
        while (true)
        {
            if (value < currentNode.Value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new Node(value);
                    return;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = new Node(value);
                    return;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
        }
    }

    public void AddRange(IEnumerable<int> values)
    {
        foreach (int value in values)
        {
            Add(value);
        }
    }

    public void Remove(int value)
    {
        if (RootNode == null)
        {
            return;
        }

        Node? currNode = RootNode;
        Node? parent = null;

        while (currNode != null)
        {
            if (currNode.Value > value)
            {
                parent = currNode;
                currNode = currNode.Left;
                continue;
            }
            else if (currNode.Value < value)
            {
                parent = currNode;
                currNode = currNode.Right;
                continue;
            }
            else
            {
                if (currNode.Left == null || currNode.Right == null)
                {
                    if (parent == null)
                    {
                        RootNode = (currNode.Left == null) ? currNode.Right : currNode.Left;
                    }
                    else if (parent.Left == currNode)
                    {
                        parent.Left = (currNode.Left == null) ? currNode.Right : currNode.Left;
                    }
                    else if (parent.Right == currNode)
                    {
                        parent.Right = (currNode.Left == null) ? currNode.Right : currNode.Left;
                    }
                }
                else
                {
                    Node maxInLeft = GetMax(currNode.Left);

                    int valueTemp = maxInLeft.Value;

                    Remove(valueTemp);

                    if (parent == null)
                    {
                        RootNode.Value = valueTemp;
                    }
                    else if (parent.Left == currNode)
                    {
                        parent.Left.Value = valueTemp;
                    }
                    else if (parent.Right == currNode)
                    {
                        parent.Right.Value = valueTemp;
                    }
                }

                break;
            }
        }

    }

    public List<int> ByPass(Node? node = null, bool first = true, List<int> list = null)
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

        ByPass(node?.Left, false, list);
        if (node != null) list.Add(node.Value);
        ByPass(node?.Right, false, list);

        return list;
    }

    public List<int> ByPassReverse(Node? node = null, bool first = true, List<int> list = null)
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

        ByPassReverse(node?.Left, false, list);
        ByPassReverse(node?.Right, false, list);
        if (node != null) list.Add(node.Value);

        return list;
    }

    public void PrintTree(Node? node = null, bool first = true)
    {
        foreach (var value in ByPass(node))
        {
            Console.WriteLine(value);
        }
    }
    public void PrintTreeReverse(Node? node = null, bool first = true)
    {
        foreach (var value in ByPassReverse(node))
        {
            Console.WriteLine(value);
        }
    }

    public void RemoveRecursive(int value)
    {
        if (RootNode == null)
        {
            return;
        }

        if (RootNode.Value == value)
        {
            RootNode = null;
            return;
        }

        Node currentNode = RootNode;

        while (true)
        {
            if (currentNode.Left?.Value == value)
            {
                currentNode.Left = null;
                return;
            }

            else if (currentNode.Right?.Value == value)
            {
                currentNode.Right = null;
                return;
            }

            else if (value < currentNode.Left?.Value)
            {
                currentNode = currentNode.Left;
            }
            else if (value > currentNode.Right?.Value)
            {
                currentNode = currentNode.Right;
            }
            else
            {
                return;
            }
        }
    }

    public Node? Search(int value)
    {
        if (RootNode == null)
        {
            return null;
        }

        Node curr = RootNode;

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
