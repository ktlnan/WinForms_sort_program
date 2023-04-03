namespace oaip_laba10
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // ������������� ������ ��� ������� ���������� ����� ��� ������ ������ ��������� ������
            openFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // ������������� ������ ��� ������� �������� ����� ��� ������ ������ ��������� ������
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
        //����������
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
                MessageBox.Show("������! ������ ����, ���������� ����������!");
            }
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)  // ���������
        {
            if (Context.array == null)
            {
                SetGenerator setGenerator = new SetGenerator();
                SetGenerator.form1 = this;
                setGenerator.Show();

                buttonSort.Enabled = true;
            }
            else
            {
                MessageBox.Show("������! ������ ��� ������������. ���������� �������� ������ ����� � ��������� �������!");
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)  // �������� �����
        {
            IOFile.LoadData();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e) // ���������� ����� ����������
        {
           Analysis comparativeAnalysis = new Analysis();
            comparativeAnalysis.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e) //������ �������
        {
            buttonSort.Enabled = true; // �������� ������ "�����������"
            listBox1.Items.Clear(); // �������� ������ ���������
            labelCountComparison.Text = ""; // �������� ����� ���������
            labelTimeSort.Text = ""; // �������� ����� ������� ����������
            labelNumberOfPermutations.Text = ""; // �������� ����� ���������� ������������
            Analysis.NumberOfPermutations = 0; // �������� ���������� ������������
            Analysis.Comparison = 0; // �������� ���������� ���������
            Context.array = null;
            this.count = 0; // �������� �������
        }
    }
}