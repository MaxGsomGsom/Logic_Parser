using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryNode treeRoot = new BinaryNode(null);

            string inputString = Console.ReadLine();

        }
    }

    public class BinaryNode
    {
        BinaryNode root = null;
        BinaryNode leftSheet = null;
        BinaryNode rightSheet = null;
        string value0 = "";
        
        
        public BinaryNode(BinaryNode root0)
        {
            root = root0;
        }

        string Value
        {
            set { value0 = value; }
            get { return value0; }
        }

        BinaryNode Root
        {
            get
            { return root; }
        }

        BinaryNode LeftSheet
        {
            set
            { if (leftSheet == null) leftSheet = value; }
            get
            { return leftSheet; }
        }

        BinaryNode RightSheet
        {
            set
            { if (rightSheet == null) rightSheet = value; }
            get
            { return rightSheet; }
        }
    }
}
