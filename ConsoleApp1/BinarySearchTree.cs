using System;

namespace ConsoleApp1;

public class BinarySearchTree : BinaryTree
{

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

    public virtual void Add(int value)
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

    public virtual void Remove(int value)
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
