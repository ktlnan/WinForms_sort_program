using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oaip_laba10
{
    internal class QuickSort : IStrategy
    {
        public int iterationCount = 0; // Счётчик итераций
        public static Form1 form1; // Ссылка на главную форму
        public void SortAnalysis(int[] array, int a, int b)  // Метод рекурсивной сортировки
        { // Инициализация переменных
            int i = a;
            int j = b;
            int middle = array[(a + b) / 2];
            // Сортировка элементов массива
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    i++;
                }
                while (array[j] > middle)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temporaryVariable = array[i];
                    array[i] = array[j];
                    array[j] = temporaryVariable;
                    i++;
                    j--;
                }
                // Подсчёт количества перестановок
                Analysis.NumberOfPermutations++;
            }
            // Подсчёт количества сравнений
            Analysis.Comparison++;
            // Рекурсивный вызов для левой и правой части массива
            if (a < j)
            {
                SortAnalysis(array, a, j);
            }
            if (i < b)
            {
                SortAnalysis(array, i, b);
            }
        }
        public void SortAnalysisFlag(int[] array, int a, int b) // Метод рекурсивной сортировки с флагом
        {  // Инициализация переменных
            int i = a;
            int j = b;
            int middle = array[(a + b) / 2];
            // Сортировка элементов массива
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    i++;
                }
                while (array[j] > middle)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temporaryVariable = array[i];
                    array[i] = array[j];
                    array[j] = temporaryVariable;
                    i++;
                    j--;
                }
                // Добавление информации о сравнении и перестановке в файл
                IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                IOFile.InputInfoAboutComparison(array[i], array[j]);
                IOFile.InputInfoAboutTransposition(array[i], array[j]);
                IOFile.FillContent();
                // Подсчёт количества перестановок
                Analysis.NumberOfPermutations++;
            }
            // Подсчёт количества итераций и сравнений
            this.iterationCount++;
            Analysis.Comparison++;
            // Добавление элемента в ListBox на главной форме
            form1.AddItemsListBox(array[i]);
            // Рекурсивный вызов для левой и правой части массива
            if (a < j)
            {
                SortAnalysisFlag(array, a, j);
            }
            if (i < b)
            {
                SortAnalysisFlag(array, i, b);
            }
        }
        public int[] Algorithm(int[] mas, bool flag = true) // Метод, реализующий алгоритм быстрой сортировки
        { // Если флаг true, то используется метод SortAnalysisFlag с добавлением информации в файл и ListBox
            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                SortAnalysisFlag(mas, 0, mas.Length - 1);
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                form1.labelCountComparison.Text = Convert.ToString(Analysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(Analysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
                return mas;
            }

            else
            {
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                SortAnalysis(mas, 0, mas.Length - 1);
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                    Analysis.timeSort = resultTime.Seconds * 1000 + resultTime.Milliseconds;
                    Analysis.elapsedTime = elapsedTime;
                return mas;
            }
        }
    }
}
