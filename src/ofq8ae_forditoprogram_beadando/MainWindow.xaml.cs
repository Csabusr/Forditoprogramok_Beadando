using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ofq8ae_forditoprogram_beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static List<GridItem> syntax = new List<GridItem>();
        public static string[,] matrix = new string[12, 7];
        public static Stack stack;
        public static bool check = false;
        public static string input = "";
        public static string ruleNumber = "";
        public static string helper;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_tablazat.Items.Clear();
            tb_path.Text = "Syntax.csv";
            syntax = getData(tb_path.Text);
            foreach (GridItem item in syntax)
            {
                dg_tablazat.Items.Add(item);
            }
        }

        public List<GridItem> getData(string path)
        {
            List<GridItem> ret = new List<GridItem>();

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                AllowComments = false,
                Delimiter = ";",
                Quote = '"'
            };

            var streamReader = File.OpenText(path);
            var csvReader = new CsvReader(streamReader, csvConfig);
            while (csvReader.Read())
            {
                GridItem temp = new GridItem();
                temp.column1 = csvReader.GetField(0);
                temp.column2 = csvReader.GetField(1);
                temp.column3 = csvReader.GetField(2);
                temp.column4 = csvReader.GetField(3);
                temp.column5 = csvReader.GetField(4);
                temp.column6 = csvReader.GetField(5);
                temp.column7 = csvReader.GetField(6);
                ret.Add(temp);
            }
            return ret;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            input = tb_c_input.Text;
            dg_tablazat.Items.Clear();
            OpenFileDialog talloz = new OpenFileDialog();
            talloz.ShowDialog();
            tb_path.Text = talloz.FileName;
            syntax = getData(tb_path.Text);
            foreach (GridItem item in syntax)
            {
                dg_tablazat.Items.Add(item);
            }
        }

        public static string simple(string st)
        {
            return Regex.Replace(st, @"([0-9]+)", "i");
        }

        public static bool format(string matrixElem, TextBox tb_output)
        {
            if (matrixElem.Length == 0)
            {
                check = true;
                return true;
            }

            if (matrixElem.Trim() == "accept")
            {
                check = true;
                return true;
            }

            if (matrixElem.Trim() == "pop")
            {
                input = input.Substring(1);
                return false;
            }


            if (matrixElem.Contains('('))
            {
                string seged = matrixElem.Substring(1).Split(',')[0];

                for (int j = seged.Length - 1; j >= 0; j--)
                {
                    if (seged[j].Equals('e'))
                    {
                        continue;
                    }
                    stack.Push(seged[j].ToString());
                }
            }

            if (matrixElem.Contains(')'))
            {
                ruleNumber += matrixElem.Substring(0, matrixElem.Length - 1).Split(',')[1];
            }
            string stackContain = "";
            foreach (string element in stack)
            {
                stackContain += element;
            }

            tb_output.Text += "\n"+ input + ", "+ stackContain + ", "+ ruleNumber;

            return false;
        }

        public static void fillTheMatrix(DataGrid dg)
        {
            int matrixIndex = 0;
            foreach(GridItem item in syntax)
            {
                matrix[matrixIndex, 0] = item.column1;
                matrix[matrixIndex, 1] = item.column2;
                matrix[matrixIndex, 2] = item.column3;
                matrix[matrixIndex, 3] = item.column4;
                matrix[matrixIndex, 4] = item.column5;
                matrix[matrixIndex, 5] = item.column6;
                matrix[matrixIndex, 6] = item.column7;
                matrixIndex++;
            }
        }

        public static bool checkInput(string input, string[,] matrix)
        {
            string characters = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                characters += matrix[0, j];
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!characters.Contains(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb_output.Text = "";
            tb_output.Text +="("+ tb_o_input.Text+ ", E#, e []) initially "; 
            fillTheMatrix(dg_tablazat);
            string[] elements = new string[2]; 
            input = simple(tb_o_input.Text);
            stack = new Stack();
            stack.Push("#");
            stack.Push("E");
            if (checkInput(input, matrix))
            {
                do
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (input[0].ToString() == matrix[0, j])
                        {
                            helper = stack.Pop().ToString();
                            if (helper == "#" && input == "#")
                            {
                                lbl_correct.Foreground = Brushes.Green;
                                lbl_correct.Content = "Elfogadva";
                            }
                            for (int t = 0; t < matrix.GetLength(0); t++)
                            {
                                if (helper == matrix[t, 0])
                                {
                                    format(matrix[t, j],tb_output);
                                }
                            }
                        }
                    }
                } while (!check);
            }
            else
            {
                lbl_correct.Foreground = Brushes.Red;
                lbl_correct.Content = "Nem megfelelő Input";
            }
            tb_output.Text += " accept \nO.K.";
        }
    }
}
