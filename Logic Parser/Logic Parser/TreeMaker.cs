using System.Drawing;
using System;

namespace Logic_Parser
{
    class TreeMaker
    {
        char curSymb = ' ';
        string inputString = "";
        int curStringPos = 0;
        BinaryTree tree = new BinaryTree();
        Graphics g;

        public void MakeTree(string inputString0)
        {
            inputString = inputString0;

            NextSymb();
            OrFunc();
            tree.Normalize();
        }

        public void DrawTree(Graphics g0)
        {
            g = g0;
            g.Clear(Color.White);

            int startX = (int)(g.VisibleClipBounds.Width / 2);

            g.DrawString(Convert.ToString(tree.TreeRoot.Value), new Font(FontFamily.GenericSerif, 15), Brushes.Black, startX, 50);
            g.DrawEllipse(Pens.Black, startX - 4, 50 + 1, 25, 25);

            DrawNode(tree.TreeRoot, g, startX, 100, (int)(g.VisibleClipBounds.Height / 5), 50);
        }



        void DrawNode(BinaryNode node, Graphics g, int x, int y, int dx, int dy)
        {
            if (node.LeftSheet != null)
            {
                g.DrawString(Convert.ToString(node.LeftSheet.Value), new Font(FontFamily.GenericSerif, 15), Brushes.Black, x - dx, y);
                g.DrawEllipse(Pens.Black, x - dx - 4, y + 1, 25, 25);
                g.DrawLine(Pens.Black, x + 5, y-dy+25, x - dx + 5, y);
                DrawNode(node.LeftSheet, g, x - dx, y + dy, (int)(dx*0.8), dy);
            }

            if (node.RightSheet != null)
            {
                g.DrawString(Convert.ToString(node.RightSheet.Value), new Font(FontFamily.GenericSerif, 15), Brushes.Black, x + dx, y);
                g.DrawEllipse(Pens.Black, x + dx - 4, y + 1, 25, 25);  
                g.DrawLine(Pens.Black, x + 5, y - dy + 25, x + dx + 5, y);
                DrawNode(node.RightSheet, g, x + dx, y + dy, (int)(dx * 0.8), dy);
            }
        }


        void OperandFunc()
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
                    if (tree.CurNode.Value == '(') NextSymb();
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

        void NoFunc()
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

        void AndFunc()
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

        void OrFunc()
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


        void NextSymb()
        {
            if (curStringPos == inputString.Length) curSymb = '@';
            else
            {
                curSymb = inputString[curStringPos];
                curStringPos++;
            }
        }
    }
}
