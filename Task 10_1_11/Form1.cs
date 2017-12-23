using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utils;
using BL;
using System.IO;

/* 11. Задача 8, только применительно к набору окружностей (кругов).
 * 8. Для набора прямоугольников, стороны которых параллельны OX и OY,
 *  заданных координатами 2-х диагональных вершин, найти все прямоугольники,
 *   которые не перекрываются никакими другими прямоугольниками 
 *   (т.е. если вырезать прямоугольники нужного размера и раскладывать по координатам на листе бумаги,
 *    то нужные прямоугольники не буду накладываться на другие прямоугольники, но могут касаться сторонами).
*/
namespace Task_10_1_11
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void GetResult_Click(object sender, EventArgs e)
        {
            errorTextBox.Text = "";
            try
            { 
                CircleUtility arrCircles = new CircleUtility(DataGridViewUtils.GridToArray2<double>(CircleDataGridView));
                arrCircles.Init();
                if (arrCircles.CheckingThatRadiusMoreThan0(arrCircles.Circles)) // радиус должен быть больше 0
                {
                    DataGridViewUtils.Array2ToGrid(resultDataGridView , arrCircles.CircleListToArr(arrCircles.FindAllAloneCircles()));
                }
                else
                {
                    errorTextBox.Text = "Радиусы должны быть больше 0";
                }
            }
            catch
            {
                errorTextBox.Text = "Таблица заполнена неправильно";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewUtils.InitGridForArr(CircleDataGridView, 40, false, true, false, true, false);
            DataGridViewUtils.InitGridForArr(resultDataGridView, 40, true , false, false, false, false);
            CircleDataGridView.ColumnHeadersVisible = true;
            CircleDataGridView.ColumnCount = 3;
            CircleDataGridView.Columns[0].Name = "X";
            CircleDataGridView.Columns[1].Name = "Y";
            CircleDataGridView.Columns[2].Name = "R";
            resultDataGridView.ColumnHeadersVisible = true;
            resultDataGridView.ColumnCount = 3;
            resultDataGridView.Columns[0].Name = "X";
            resultDataGridView.Columns[1].Name = "Y";
            resultDataGridView.Columns[2].Name = "R";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingAndReadingUtils myOpen = new SavingAndReadingUtils();

            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openDialog.FileName;
            string[] arr1 = new string[myOpen.ReadStrArrFromFile(filename).Length];
            arr1 = myOpen.ReadStrArrFromFile(filename);
            for (int n = 0; n < arr1.Length;n++)
            {
                try
                {
                    var numbers = arr1[n].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    CircleDataGridView.Rows[n].Cells[0].Value = numbers[0];
                    CircleDataGridView.Rows[n].Cells[1].Value = numbers[1];
                    CircleDataGridView.Rows[n].Cells[2].Value = numbers[2];
                    CircleDataGridView.RowCount++;
                }
                catch { }
            }


            /*Stream mystr = null;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myreader = new StreamReader(mystr);
                    string[] str;
                    int num = 0;
                    try
                    {

                        string[] str1 = myreader.ReadToEnd().Split('\n');
                        num = str1.Count();
                        CircleDataGridView.RowCount = num; 
                        for (int i = 0; i < num; i++)
                        {

                            str = str1[i].Split(' ');
                            for (int k = 0; k < CircleDataGridView.ColumnCount; k++)
                            {
                                try
                                {
                                    CircleDataGridView.Rows[i].Cells[k].Value = str[k];
                                }
                                catch { }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в чтении файла");
                    }
                    finally
                    {
                        myreader.Close();
                    }
                }
            }*/
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingAndReadingUtils mySave = new SavingAndReadingUtils();

            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveDialog.FileName;
            string[] arr = new string[CircleDataGridView.RowCount];
            for (int i = 0; i < CircleDataGridView.RowCount; i++)
            {
                for (int k = 0; k < CircleDataGridView.ColumnCount; k++)
                {
                    arr[i] += CircleDataGridView.Rows[i].Cells[k].Value.ToString() + " ";
                }
            }
            mySave.WriteArrInFile(filename, arr);
        }
    }
}