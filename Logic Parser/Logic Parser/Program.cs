using System;

namespace Logic_Parser
{
    class Program
    {
        static char curSymb = ' ';
        static string inputString = "";
        static int curStringPos = 0;
        static BinaryTree tree = new BinaryTree();

        static void Main(string[] args)
        {
            inputString = Console.ReadLine();
            NextSymb();

            OrFunc();

            tree.Normalize();

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }


        static void OperandFunc()
        {
            while (true)
            {
                if (curSymb == '@') return;
                else if (curSymb == '|')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '&')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '!')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '(')
                {
                    tree.CurNode.Value = curSymb;
                    tree.AddNode();
                    NextSymb();
                    OrFunc();
                }
                else if (curSymb == ')')
                {
                    if (tree.CurNode.Value == '(')  NextSymb();
                    else
                    {
                        tree.GoBack();
                        return;
                    }

                }
                else 
                {
                    tree.CurNode.Value = curSymb;
                    NextSymb();
                }
            }

        }

        static void NoFunc()
        {
            while (true)
            {
                if (curSymb == '@') return;
                else if (curSymb == '|')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '&')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '!')
                {
                    tree.CurNode.Value = '!';
                    NextSymb();
                }
                else if (curSymb == ')')
                {     
                    tree.GoBack();
                    return;
                }
                else
                {
                    tree.AddNode();
                    OperandFunc();
                }
            }
        }

        static void AndFunc()
        {
            while (true)
            {
                if (curSymb == '@') return;
                else if (curSymb == '|')
                {
                    tree.GoBack();
                    return;
                }
                else if (curSymb == '&')
                {
                    tree.CurNode.Value = curSymb;
                    NextSymb();
                }
                else if (curSymb == '!')
                {
                    tree.AddNode();
                    NoFunc();
                }
                else if (curSymb == ')')
                {
                    tree.GoBack();
                    return;
                }
                else 
                {
                    tree.AddNode();
                    NoFunc();
                }
            }
        }

        static void OrFunc()
        {
            while (true)
            {
                if (curSymb == '@') return;
                else if (curSymb == '|')
                {
                    tree.CurNode.Value = curSymb;
                    NextSymb();
                }
                else if (curSymb == '&')
                {
                    tree.AddNode();
                    AndFunc();
                }
                else if (curSymb == '!')
                {
                    tree.AddNode();
                    AndFunc();
                }
                else if (curSymb == ')')
                {
                    tree.GoBack();
                    return;
                }
                else 
                {
                    tree.AddNode();
                    AndFunc();
                }
            }
        }


        static void NextSymb()
        {
            if (curStringPos == inputString.Length) curSymb = '@';
            else
            {
                curSymb = inputString[curStringPos];
                curStringPos++;
            }
        }

    }



    public class BinaryNode
    {
        BinaryNode root = null;
        BinaryNode leftSheet = null;
        BinaryNode rightSheet = null;
        char myValue = ' ';


        public BinaryNode(BinaryNode root0)
        {
            root = root0;
        }

        public char Value
        {
            set { myValue = value; }
            get { return myValue; }
        }

        public BinaryNode Root
        {
            set { root = value; }
            get { return root; }
        }

        public BinaryNode LeftSheet
        {
            set { leftSheet = value; }
            get { return leftSheet; }
        }

        public BinaryNode RightSheet
        {
            set { rightSheet = value; }
            get { return rightSheet; }
        }
    }

    public class BinaryTree
    {
        BinaryNode treeRoot;
        BinaryNode curNode;

        public BinaryTree()
        {
            treeRoot = new BinaryNode(null);
            curNode = treeRoot;
        }

        public void AddNode() 
        {
            if (curNode.LeftSheet == null)
            {
                BinaryNode nextNode = new BinaryNode(curNode);
                curNode.LeftSheet = nextNode;
                curNode = nextNode;
            }
            else if (curNode.RightSheet == null)
            {
                BinaryNode nextNode = new BinaryNode(curNode);
                curNode.RightSheet = nextNode;
                curNode = nextNode;
            }
        }

        public void GoBack()
        {
            if (curNode.Root != null) curNode = curNode.Root;
        }

        public void GoLeft()
        {
            if (curNode.LeftSheet != null) curNode = curNode.LeftSheet;
        }

        public void GoRight()
        {
            if (curNode.RightSheet != null) curNode = curNode.RightSheet;
        }

        public BinaryNode TreeRoot
        {
            get { return treeRoot; }
        }

        public BinaryNode CurNode
        {
            get { return curNode; }
        }


        public void Normalize() 
        {
            RecurNorm(treeRoot);
        }
        
        void RecurNorm(BinaryNode node, bool left=true)
        {
            if (node.LeftSheet != null) RecurNorm(node.LeftSheet, true);
            if (node.RightSheet != null) RecurNorm(node.RightSheet, false);

            if ((node.Value == ' ' || node.Value == '(') && node.Root!=null) 
            {
                if (node.LeftSheet != null)
                {
                    if (left) node.Root.LeftSheet = node.LeftSheet;
                    else node.Root.RightSheet = node.LeftSheet;
                    node.LeftSheet.Root = node.Root;
                }
                else
                {
                    if (left) node.Root.LeftSheet = node.RightSheet;
                    else node.Root.RightSheet = node.RightSheet;
                    node.RightSheet.Root = node.Root;
                }
            }
        }
    }
}
