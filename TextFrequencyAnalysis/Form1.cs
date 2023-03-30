using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TextFrequencyAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //button1.Click += button1_Click;
            //button2.Click += button2_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        outPut output = new outPut(); string answer = "";
        private void button2_Click(object sender, EventArgs e)//сохранение
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;  
            string WritePath = saveFileDialog1.FileName; // получаем выбранный файл
            using (StreamWriter stream1 = new StreamWriter(WritePath,false)) stream1.WriteLine(textBox1.Text);//из текст.поля в файл
            
        }

        private void button1_Click(object sender, EventArgs e)//открытие
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)//открой диалог.окно
                 return;
            string path = openFileDialog1.FileName;//путь к файлу
            using (StreamReader stream = new StreamReader(path)) textBox1.Text = stream.ReadToEnd();//открываем и считываем весь текст из файла в поле
       }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            try
            {
                //Преобразовать строку в массив слов
                string[] arrayWords = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '(', ')', '-' }, StringSplitOptions.RemoveEmptyEntries);
                var dict = new Dictionary<string, int>(); float elements = 0;
                foreach (var value in arrayWords)//подсчёт совпадений
                {
                    if (!double.TryParse(value,out double tail))//фильтр - скипает цифры
                    {
                        elements++;
                        dict.TryGetValue(value, out int count);
                        dict[value] = count + 1;
                    }
                }
                //вывод относительных частот
                
                foreach (var pair in dict) answer += pair.Key + "[" + pair.Value/elements + "]" + "\r\n";  
                    answer += $"Всего слов:{elements}";
                    output.textBox(answer); output.Show();textBox1.Clear();
               


            }
            catch (Exception er) { MessageBox.Show(er.Message + " Введите текст!");}
            
        }
    }
}
