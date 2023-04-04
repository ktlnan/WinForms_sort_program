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
        public static List<SortingResultsInformation> sortingResults = new List<SortingResultsInformation>(); //статический список объектов типа SortingResultsInformation для хранения результатов сортировки.
        private Context context = new Context(); //объявляет объект типа Context, который будет использоваться для передачи данных между различными формами приложения.
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
        // Метод сортировки по заданному размеру массива
        private void Sort(int n, int number)
        {
            this.context = new Context(new Obmen()); // Использование метода сортировки "Обмен"
            Context.array = new int[n];
            FillArray(Context.array); // Заполнение массива случайными числами
            context.ExecuteAlgorithm(false); // Запуск алгоритма сортировки
            // Вывод результатов сортировки в таблицу
            dataGridView1.Rows[number].Cells[1].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Время: " + Convert.ToString(elapsedTime);
            // Добавление информации о сортировке в список результатов
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new Obmen(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;
            // Использование метода сортировки "Быстрая сортировка"
            this.context = new Context(new QuickSort());
            Context.array = new int[n];
            FillArray(Context.array);
            context.ExecuteAlgorithm(false);
            // Вывод результатов сортировки в таблицу
            dataGridView1.Rows[number].Cells[2].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Время: " + Convert.ToString(elapsedTime);
            // Добавление информации о сортировке в список результатов
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new QuickSort(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }

            Sort(10, 0);
            Sort(100, 1);
            Sort(1000, 2);
            Sort(10000, 3);

            sortingResults.Clear();
        }
    }
}
