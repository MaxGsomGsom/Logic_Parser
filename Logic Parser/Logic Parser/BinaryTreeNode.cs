
namespace Logic_Parser
{

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

        void RecurNorm(BinaryNode node, bool left = true)
        {
            if (node.LeftSheet != null) RecurNorm(node.LeftSheet, true);
            if (node.RightSheet != null) RecurNorm(node.RightSheet, false);

            if ((node.Value == ' ' || node.Value == '(') && node.Root != null)
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
