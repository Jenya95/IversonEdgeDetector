using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iverson_edge_detector
{
    public partial class Form2 : Form
    {
        //конструктор умолчания
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = Form1.Threshold.ToString();
        }
        //конструктор с параметром, задающим язык (рус. или англ.)
        public Form2(int id):this()
        {
            if (id > 0)//русский язык
            {
                this.Text = "Установить";
                groupBox1.Text = "Порог";
                button1.Text = "Принять";
                Error = "Ошибка";
                ErrorMessage = "Введите корректное значение порога!";
            }
            else //англ. язык
            {
                Error = "Error";
                ErrorMessage = "Set an acceptable threshold value!";
            }
        }
        string Error //заголовок MessageBox
        {get;set;}
        string ErrorMessage //сообщение MessageBox
        {get;set;}
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   
                //установка значения порога
                Form1.Threshold = double.Parse(textBox1.Text);
            }
            catch //в случае ввода неправильных данных
            {
                MessageBox.Show(ErrorMessage, Error, MessageBoxButtons.OK);
                return;
            }
            Close();
        }
    }
}
