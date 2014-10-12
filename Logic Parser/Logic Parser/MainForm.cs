using System;
using System.Windows.Forms;

namespace Logic_Parser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeMaker maker = new TreeMaker();
            try
            {
            maker.MakeTree(textBox1.Text);
            maker.DrawTree(pictureBox1.CreateGraphics());
            }
            catch
            {
                MessageBox.Show("Ошибка в выражении");
            }
        }
    }
}
