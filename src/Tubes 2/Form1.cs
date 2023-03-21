using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Tubes_2.algorithms;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private String mapFile;
        private bool resizeOnce = false;
        private bool resizeOnce2 = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void settings1_Load(object sender, EventArgs e)
        {
            
        }


        private void start_map_visual(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Transparent;
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(settings1.mapfFile))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    int row = 0;
                    int col = 0;

                    // COunt rows and columns
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //MessageBox.Show(line);
                        col = 0;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] != ' ')
                            {
                                col++;
                            }
                        }
                        row++;

                    }

                    dataGridView1.ColumnCount = col;
                    dataGridView1.RowCount = row;
                    //MessageBox.Show(col.ToString() + row.ToString());

                }
            }


            // Input values
            using (var fileStream = File.OpenRead(settings1.mapfFile))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    int col = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // Remove space
                        line = line.Replace(" ", "");

                        for (int i = 0; i < line.Length; i++)
                        {
                            DataGridViewColumn column = dataGridView1.Columns[i];
                            column.Width = 55;
                            if (line[i] == 'K')
                            {
                                dataGridView1.Rows[col].Cells[i].Value = "Start";
                                dataGridView1.Rows[col].Cells[i].Style.BackColor = Color.White;
                                dataGridView1.Rows[col].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else if (line[i] == 'R')
                            {
                                dataGridView1.Rows[col].Cells[i].Value = "";
                                dataGridView1.Rows[col].Cells[i].Style.BackColor = Color.White;
                                dataGridView1.Rows[col].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else if (line[i] == 'T')
                            {
                                dataGridView1.Rows[col].Cells[i].Value = "Treasure";
                                dataGridView1.Rows[col].Cells[i].Style.BackColor = Color.White;
                                dataGridView1.Rows[col].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                dataGridView1.Rows[col].Cells[i].Value = "";
                                dataGridView1.Rows[col].Cells[i].Style.BackColor = Color.Black;
                                dataGridView1.Rows[col].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }

                        col++;

                    }
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersVisible = false;
                }
            }


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int colAuto = dataGridView1.Size.Width / dataGridView1.ColumnCount;
            int rowAuto = dataGridView1.Size.Height / dataGridView1.RowCount;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colAuto;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = rowAuto;
            }

            if (!resizeOnce)
            {
                panel1.Height += 30;
                this.Height += 30;
                resizeOnce = true;
            }

            dataGridView1.ClearSelection();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
            if(settings1.algoChoice == 0)
            {
                //MessageBox.Show(settings1.algoChoice.ToString());
                if (!resizeOnce2)
                {
                    panel1.Height += 120;
                    this.Height += 120;
                    resizeOnce2 = true;
                }
                startBFS();
            }
        }

        private void startBFS()
        {
            Map defaultMap = new Map(convertToStringArray(settings1.mapfFile));
            Bfs algo = new Bfs(defaultMap);
            Tuple<List<string>, List<int[]>> result = algo.bfsearch();

            int row = 0; int col = 0;
            int[] startPoint = defaultMap.getStartingPoint();
            startPoint[0] -= 1;
            startPoint[1] -= 1;

            dataGridView1.Rows[startPoint[0]].Cells[startPoint[1]].Style.BackColor = Color.Green;
            for (int i = 0; i < result.Item1.Count; i++)
            {
                Thread.Sleep(1000);
                if()
            }

        }

        private string[,] convertToStringArray(string filename)
        {
            string[] lines = File.ReadAllLines(settings1.mapfFile);

            string[,] _map = new string[lines.GetLength(0), lines.ElementAt(0).Split(" ").Length];
            for (int r = 0; r < lines.GetLength(0); r++)
            {
                for (int c = 0; c < lines.ElementAt(r).Split(" ").Length; c++)
                {
                    _map[r, c] = lines.ElementAt(r).Split(" ").ElementAt(c);
                }
            }
            return _map;
        }
    }
}