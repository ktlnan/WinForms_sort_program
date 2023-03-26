using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oaip_laba10
{
    public class Obmen : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;
        public int[] Algorithm(int[] mas, bool flag = true)
        {
                //Если flag равен true, то выполняется сортировка пузырьком с выводом информации о каждой итерации 
                //и перестановке в файл и на форму.
                //Если flag равен false, то выполняется обычная сортировка пузырьком 
                //без вывода информации о каждой итерации и перестановке.
            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                { //Счетчик сравнений увеличивается при каждом сравнении двух элементов массива (mas[i] и mas[j]):
                    for (int j = i + 1; j < mas.Length; j++)
                    {   //Счетчик сравнений увеличивается при каждом сравнении двух элементов массива (mas[i] и mas[j]):
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                        Analysis.Comparison++;
                        //Счетчик перестановок увеличивается только в случае, если два элемента массива нужно поменять местами:
                        if (mas[i] > mas[j])
                        {
                            IOFile.InputInfoAboutTransposition(mas[i], mas[j]);
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            Analysis.NumberOfPermutations++;

                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[i], mas[j]);
                        }
                    }
                }
                    //После завершения сортировки, результаты замера времени и другие 
                    //статистические данные выводятся на форму. Наконец, отсортированный массив
                    //возвращается из метода.
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
                //В обеих ветвях условия используется объект Stopwatch для замера времени выполнения сортировки. 
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        Analysis.Comparison++;
                        if (mas[i] > mas[j])
                        {
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            Analysis.NumberOfPermutations++;
                        }
                    }
                }
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
