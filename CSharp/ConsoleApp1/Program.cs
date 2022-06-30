using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public static class Program
{
    static void Main()
    {
        //var inputLinks = new HashSet<string>();
        //var inputTests = new HashSet<string>();
        //using StreamReader reader = new StreamReader(Console.OpenStandardInput());
        //while (!reader.EndOfStream)
        //{
        //    string line = reader.ReadLine();
        //    if (line.Contains("->"))
        //        inputLinks.Add(line);
        //    else if (line.Contains(","))
        //        inputTests.Add(line);

        //    if (string.IsNullOrWhiteSpace(line))
        //    {
        //        break;
        //    }
        //}

        var inputLinks = new HashSet<string>()
        {
            "a->a",
            "a->b",
            "r->s",
            "b->c",
            "x->c",
            "q->r",
            "y->x",
            "w->z",
        };

        var inputTests = new HashSet<string>()
        {
            "a,q,w",
            "a,c,r",
            "y,z,a,r",
            "a,w"
        };

        var nodes = new HashSet<MyLinkedListNode>();
        foreach (var link in inputLinks)
        {
            var nodeNames = link.Split("->");
            MyLinkedListNode startNode = nodes.AddNodeIfNotExist(nodeNames[0]);
            MyLinkedListNode endNode = nodes.AddNodeIfNotExist(nodeNames[1]);
            startNode.LinkToNode(endNode);
        }

        foreach (var test in inputTests)
        {
            Console.WriteLine(nodes.DoLinkedListsIntersect(test));
        }
    }

    static MyLinkedListNode AddNodeIfNotExist(this HashSet<MyLinkedListNode> nodes, string nodeName)
    {
        var node = nodes.SingleOrDefault(x => x.Name == nodeName);
        if (node == null)
        {
            node = new MyLinkedListNode(nodeName);
            nodes.Add(node);
        }

        return node;
    }

    static bool DoLinkedListsIntersect(this HashSet<MyLinkedListNode> nodes, string test)
    {
        var usedNodes = new HashSet<MyLinkedListNode>();
        foreach (var startNodeName in test.Split(","))
        {
            var node = nodes.SingleOrDefault(x => x.Name == startNodeName);
            while (node != null)
            {
                if (!usedNodes.Contains(node))
                {
                    usedNodes.Add(node);
                    node = node.NextNode;
                }
                else
                    return true;
            }
        }

        return false;
    }
}

internal class MyLinkedListNode
{
    internal MyLinkedListNode(string name)
    {
        Name = name;
    }

    internal MyLinkedListNode(string name, MyLinkedListNode? nextNode)
    {
        Name = name;
        NextNode = nextNode;
    }

    public string Name { get; set; }
    public MyLinkedListNode? NextNode { get; set; } = default;

    public void LinkToNode(MyLinkedListNode nextNode)
    {
        if (!IsCircleLink(nextNode))
        {
            NextNode = nextNode; 
        }
    }

    private bool IsCircleLink(MyLinkedListNode nextNode)
    {
        var node = nextNode;
        while (node != null)
        {
            if (node == this)
            {
                return true;
            }
            node = node.NextNode;
        }

        return false;
    }
}