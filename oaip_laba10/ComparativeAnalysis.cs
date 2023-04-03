using System;
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
    public partial class Analysis : Form
    {
        public static int Comparison = 0; // Переменная Comparison будет хранить количество сравнений элементов при сортировке
        private Random random = new Random(); // Создаем новый объект класса Random для генерации случайных чисел
        public static int NumberOfPermutations = 0; // Переменная NumberOfPermutations будет хранить количество перестановок элементов при сортировке
        public static string elapsedTime = ""; // Переменная elapsedTime будет хранить время, затраченное на сортировку
        public static int timeSort = 0; // Переменная timeSort будет хранить время сортировки в миллисекундах

        public Analysis()
        {
            InitializeComponent();
            // Добавление колонок в объект dataGridView1
            dataGridView1.Columns.Add("Volume", "Объем выборки");
            dataGridView1.Columns.Add("ViborSort", "Метод выбора");
            dataGridView1.Columns.Add("QuickSort", "Метод б-ой сортировки");
            // Добавление строк в объект dataGridView1
            dataGridView1.Rows.Add("10");
            dataGridView1.Rows.Add("100");
            dataGridView1.Rows.Add("1000");
            dataGridView1.Rows.Add("10000");
            // Делаем первую колонку каждой строки доступной только для чтения
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }
        }
        private void FillArray(int[] vs) // Метод для заполнения массива случайными числами
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = random.Next(0, 100000);
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {

        }
    }
}
