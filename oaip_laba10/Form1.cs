namespace oaip_laba10
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // устанавливаем фильтр для диалога сохранения файла для выбора только текстовых файлов
            openFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // устанавливаем фильтр для диалога открытия файла для выбора только текстовых файлов
        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }
        //сортировка
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(new Obmen());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    //IOFile.SaveData();
                    buttonSort.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(new QuickSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    buttonSort.Enabled = false;
                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Ошибка! Массив пуст, сортировка невозможна!");
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)  // Генерация
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)  // Открытие файла
        {

        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e) // Происходит вывод статистики
        {

        }

        private void buttonClear_Click(object sender, EventArgs e) //кнопка очистки
        {

        }
    }
}