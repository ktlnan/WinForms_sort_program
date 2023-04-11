﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oaip_laba10
{
    public partial class SetGenerator : Form
    {
        private Random random = new Random();
        public static Form1 form1;
        public SetGenerator()
        {
            InitializeComponent();
            label2.Text = "";
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxCountElements.Text = Convert.ToString(trackBar1.Value); // Отображаем значение трекбара в текстовом поле
        }

        private void textBoxCountElements_TextChanged(object sender, EventArgs e)
        {
            int flag = 0;
            if (!(int.TryParse(textBoxCountElements.Text, out flag)))
            {
                label2.Text = "Ошибка! Введенно некорректное значение!!";
                this.Height = 240; // закрывается до таких размеров, когда ввели буквы
            }
            else if (!(int.Parse(textBoxCountElements.Text) > trackBar1.Maximum))
            { // Если введенное значение меньше или равно максимальному значению трекбара, обновляем значение трекбара и скрываем сообщение об ошибке
                label2.Text = "";
                this.Height = 320; // нормальный ввод цифр 1-10
                trackBar1.Value = int.Parse(textBoxCountElements.Text);
            }
            else if ((int.Parse(textBoxCountElements.Text) > trackBar1.Maximum) || (int.Parse(textBoxCountElements.Text) < trackBar1.Minimum))
                {
                    label2.Text = "Ошибка! Введенное значение вышло \nза допустимый интервал!!";
                    this.Height = 240; //  закрывается до таких размеров, когда ввели больше положенного
            }
            }
        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            Context.array = new int[trackBar1.Value]; // Создаем массив нужной длины и заполняем его случайными числами
            for (int i = 0; i < Context.array.Length; i++)
            {
                Context.array[i] = random.Next(0, 1000);
            }

            form1.listBox1.Items.Add(""); // Добавляем элементы массива в ListBox на главной форме Form1
            foreach (var item in Context.array)
            {
                form1.listBox1.Items[form1.count] += Convert.ToString(item) + " ";
            }
            form1.count++;

            this.Close(); // Закрываем форму SetGenerator
        }

        private void SetGenerator_Load(object sender, EventArgs e)
        {

        }
    }
}
