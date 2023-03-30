using System;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TextFrequencyAnalysis
{
    public partial class outPut : Form
    {
        public outPut()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number != 8)
            {
                e.Handled = true;
            }
        }
        public void textBox(string answer) 
        { textBox1.Text += answer; }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, new Font("Times New Roman", 14), Brushes.Black, 0, 0);
        }
        private void button1_Click(object sender, EventArgs e)//print
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем
        }

        private void button2_Click(object sender, EventArgs e)//save
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string pathfile = saveFileDialog1.FileName;
            try { using (StreamWriter str = new StreamWriter(pathfile, false)) str.WriteLine(textBox1.Text); } 
            catch (Exception err) { MessageBox.Show(err.Message);}
        }
    }
}
