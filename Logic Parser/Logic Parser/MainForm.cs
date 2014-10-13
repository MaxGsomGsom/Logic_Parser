using System;
using System.Windows.Forms;

namespace Logic_Parser
{
    public partial class MainForm : Form
    {
        TreeMaker maker;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maker = new TreeMaker();
            try
            {
            maker.MakeTree(textBox1.Text);
            maker.DrawTree(pictureBox1.CreateGraphics());
            }
            catch
            {
                MessageBox.Show("Ошибка в выражении");
            }
            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = maker.Calculate(textBox1.Text, textBox2.Text).ToString();

            }
            catch
            {
                MessageBox.Show("Ошибка в выражении");
            }
        }
    }
}
