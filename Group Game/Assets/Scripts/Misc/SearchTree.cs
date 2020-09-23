using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SearchTree : MonoBehaviour
{
    public BinarySearchTree searchTree = new BinarySearchTree();
    public int potentialPrices = 15;
    public int maxPrice = 100;

    public int currentPrice = 0;

    private void Start()
    {
        for(int i = 0; i < potentialPrices; i++)
        {
            int random = UnityEngine.Random.Range(0, maxPrice);
            searchTree.AddValue(random);
        }
        searchTree.TraverseInOrder(searchTree.root);
    }
}
[System.Serializable]
public class BinarySearchTree
{
    public BinaryNode root;

    public bool AddValue(int value)
    {
        BinaryNode before = null;
        BinaryNode after = root;

        while (after != null)
        {
            before = after;
            if (value < after.index)
            {
                after = after.left; // new left node in tree
            }
            else if (value > after.index) //new right node
            {
                after = after.right;
            }
            else
            {
                //value already exists
                return false;
            }
        }

        BinaryNode newNode = new BinaryNode();
        newNode.index = value;

        if (root == null)
        {
            //tree is empty create global root node
            root = newNode;
        }
        else
        {
            if (value < before.index)
            {
                before.left = newNode;
            }
            else
            {
                before.right = newNode;
            }
        }
        return true;
    }

    public bool AddNode(BinaryNode node)
    {
        if (Find(node.index) == null)
        {
            BinaryNode before = null;
            BinaryNode after = root;

            while (after != null)
            {
                before = after;
                if (node.index < after.index)
                {
                    after = after.left; // new left node in tree
                }
                else if (node.index > after.index) //new right node
                {
                    after = after.right;
                }
                else
                {
                    //value already exists
                    return false;
                }
            }

            BinaryNode newNode = new BinaryNode();
            newNode.index = node.index;

            if (root == null)
            {
                //tree is empty create global root node
                root = newNode;
            }
            else
            {
                if (node.index < before.index)
                {
                    before.left = newNode;
                }
                else
                {
                    before.right = newNode;
                }
            }
            return true;
        }
        return false;
    }

    public BinaryNode Find(int value)
    {
        return Find(value, root);
    }

    private BinaryNode Find(int value, BinaryNode parent)
    {
        if (parent != null)
        {
            if (value == parent.index)
            {
                return parent;
            }
            else if (value < parent.index)
            {
                return Find(value, parent.left);
            }
            else
            {
                return Find(value, parent.right);
            }
        }
        return null;
    }

    public void RemoveValue(int value)
    {
        root = RemoveValue(root, value);
    }

    private BinaryNode RemoveValue(BinaryNode parent, int key)
    {
        if (parent == null)
        {
            return parent;
        }

        if (key < parent.index)
        {
            parent.left = RemoveValue(parent.left, key);
        }
        else if (key > parent.index)
        {
            parent.right = RemoveValue(parent.right, key);
        }
        else
        {
            //delete this node

            //detects if node only has one child
            if (parent.left == null)
            {
                return parent.right;
            }
            else if (parent.right == null)
            {
                return parent.left;
            }


            parent.index = MinValue(parent.right);
            parent.right = RemoveValue(parent.right, parent.index);
        }
        return parent;
    }

    private int MinValue(BinaryNode node)
    {
        int minV = node.index;

        while (node.left != null)
        {
            minV = node.left.index;
            node = node.left;
        }
        return minV;
    }

    public int GetTreeDepth()
    {
        return GetTreeDepth(root);
    }

    public int GetTreeDepth(BinaryNode parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.left), GetTreeDepth(parent.right));

    }

    public void TraversePreOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            Debug.Log(parent.index + " ");
            TraversePreOrder(parent.left);
            TraversePreOrder(parent.right);
        }
    }
    public void TraversePostOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.left);
            TraversePostOrder(parent.right);
            Debug.Log(parent.index + " ");
        }
    }
    public void TraverseInOrder(BinaryNode parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.left);
            Debug.Log(parent.index + " ");
            TraverseInOrder(parent.right);
        }
    }
}

public class BinaryNode
{
    public int index;
    public BinaryNode left;
    public BinaryNode right;
    public class BinaryNode_Item : BinaryNode
    {
        public Equipment data;

        public BinaryNode_Item(Equipment i, int n)
        {
            index = n;
            data = i;
        }
    }
}
