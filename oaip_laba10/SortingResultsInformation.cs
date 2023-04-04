using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oaip_laba10
{
    public class SortingResultsInformation
    { // Переменные для хранения количества сравнений, перестановок, времени сортировки, объема выборки и времени
        public int Comparison = 0;
        public int NumberOfPermutations = 0;
        public int TimeSort = 0;
        public int Volume = 0;
        public string Time = "";
        public IStrategy Strategy; // Переменная для хранения стратегии сортировки
        public string NameSortingMethod; // Название метода сортировки
        // Конструктор, инициализирующий поля объекта
        public SortingResultsInformation(int Comparison, int NumberOfPermutations, string Time, IStrategy Strategy, int TimeSort, int Volume)
        {
            this.Comparison = Comparison;
            this.NumberOfPermutations = NumberOfPermutations;
            this.Time = Time;
            this.Strategy = Strategy;
            // Устанавливаем название метода сортировки в зависимости от типа стратегии
            if (Strategy.GetType() == (new Obmen()).GetType())
            {
                this.NameSortingMethod = "Метод Обмена";
            }
            else
            {
                this.NameSortingMethod = "Метод быстрой сортировки";
            }
            this.TimeSort = TimeSort;
            this.Volume = Volume;
        }
    }
}
