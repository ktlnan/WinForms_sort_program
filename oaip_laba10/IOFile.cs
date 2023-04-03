using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace oaip_laba10
{
    public class IOFile
    {
        public static Form1 form1 = new Form1();
        public static string content = "";
        public static string path = "";
        public static char[] listChar = new char[100];
        public static List<string> arrayList = new List<string>();
        public static void OpenSaveDialogForm() // метод открывает диалоговое окно сохранения файла
        { // если диалог закрыт без сохранения
            if (form1.saveFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // сохраняем путь к файлу
            path = form1.saveFileDialog2.FileName;
        }

        public static void OpenLoadDialogForm() // метод открывает диалоговое окно загрузки файла
        {  // если диалог закрыт без выбора файла
            if (form1.openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // сохраняем путь к выбранному файлу
            path = form1.openFileDialog2.FileName;
        }
        public static void FillContent()
        {
            foreach (var i in Context.array)
            {
                content += Convert.ToString(i) + ' ';
            }
            content += '\n';
        }
        public static string InputInfoAboutComparison(int first, int second)
        {
            content += "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static string InputInfoAboutTransposition(int first, int second)
        {
            content += "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        //Метод Separator(sr) отвечает за посимвольную обработку данных из
        //загружаемого файла и сохранения этих данных в массив из класса Context.
        private static void Separator(StreamReader streamReader)
        {
            int i = 0; //индекс в массиве vs, начиная с которого записываются считываемые символы
            int a = 0;// переменная для хранения текущего числа
            int a1 = 0; // переменная для хранения суммы всех чисел, составляющих текущее число
            int l = 0; // переменная для хранения количества цифр в текущем числе

            try
            {
                while (streamReader.Peek() != -1) // читаем текст до конца
                {
                    if (streamReader.Peek() == 32) // если следующий символ - пробел, значит текущее число закончилось
                    {
                        char[] vs = new char[2 * i];// создаем массив символов длиной в два раза больше, чем количество символов в текущем числе
                        streamReader.Read(vs, i, 1); // считываем пробел
                        i++;
                    }
                    else if (streamReader.Peek() >= 48 && streamReader.Peek() <= 57) // если следующий символ - цифра, значит мы находимся внутри числа
                    {
                        do
                        {
                            if (streamReader.Peek() == -1) // если конец файла, выходим из цикла
                            {
                                break;
                            }
                            streamReader.Read(listChar, i, 1); // считываем следующий символ
                            int.TryParse(Convert.ToString(listChar[i]), out a); // преобразуем символ в число
                            a *= Convert.ToInt32(Math.Pow(10.0, l)); // учитываем разрядность числа
                            a1 += a; // добавляем число к сумме всех чисел текущего числа
                            i++; // увеличиваем счетчик символов в текущем числе
                            l++; // увеличиваем количество цифр в текущем числе
                        }
                        while (streamReader.Peek() != 32); // повторяем, пока не встретим пробел (конец текущего числа)
                        string input = Convert.ToString(a1);
                        string output = new string(input.ToCharArray().Reverse().ToArray()); // переворачиваем число
                        int.TryParse(output, out a1);
                        arrayList.Add(Convert.ToString(a1)); // добавляем число в список
                        l = 0; // обнуляем количество цифр в текущем числе
                        a = 0; // обнуляем переменную для хранения текущего числа
                        a1 = 0;  // обнуляем переменную для хранения суммы всех чисел, составляющих текущее число
                    }
                    else // если следующий символ не пробел и не цифра, значит формат файла некорректный
                    {
                        MessageBox.Show("Некорректный формат загружаемого файла.");
                        break;
                    }
                }
                // создаем массив int из списка чисел
                Context.array = new int[arrayList.Count];
                for (int k = 0; k < arrayList.Count; k++)
                {
                    int.TryParse(arrayList[k], out Context.array[k]);
                }
                // добавляем содержимое массива в listBox
                foreach (int j in Context.array)
                {
                    content += Convert.ToString(j) + " ";
                }
                form1.listBox1.Items.Add(content);
                form1.listBox1.Items.Add("");
            }
            catch
            {
                MessageBox.Show("Некорректный формат загружаемого файла.");
            }
        }
        // Метод для загрузки данных из файла
        public static void LoadData()
        {
            OpenLoadDialogForm(); // открываем диалоговое окно для выбора файла
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr); // вызываем метод для разделения текста на числа и добавления их в список
                sr.Close();
            }
        }
        // Метод для сохранения данных в файл
        public static void SaveData(string text = "", bool flag = false)
        {
            content += text; // добавляем текст в переменную content

            if (flag == false)// если флаг равен false, значит нужно открыть диалоговое окно для выбора файла
            {
                OpenSaveDialogForm();
            }

            try
            {
                System.IO.File.WriteAllText(path, IOFile.content); // записываем содержимое переменной content в файл
            }
            catch (System.ArgumentException)
            {

            }
        }

    }
}
