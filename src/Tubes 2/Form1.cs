using System.IO;
using System.Linq.Expressions;
using System.Text;
using Tubes_2.algorithms;

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
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(settings1.mapfFile))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    int col = 0;
                    int row = 0;

                    // COunt rows and columns
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        col = line.Length;
                        row++;

                    }

                    dataGridView1.ColumnCount = col;
                    dataGridView1.RowCount = row;

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
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
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
            int i = 0, j = 0;
            Tuple<List<string>, List<int[]>> result = algo.bfsearch();

            
            try
            {
                foreach (var node in result.Item2)
                {
                    i = node[0];
                    j = node[1];
                    dataGridView1.Rows[node[0]].Cells[node[1]].Style.BackColor = Color.Green;
                }
            }
            catch(ArgumentOutOfRangeException err){
                String heh = i.ToString() + j.ToString(); ;
                MessageBox.Show(heh);
            }
        }

        private string[,] convertToStringArray(String filename)
        {
            String[] input = File.ReadAllLines(settings1.mapfFile);

            int i = 0, j = 0;
            string[,] result = new string[input.Length, input[0].Length];
            foreach (var row in input)
            {
                if(row != " ")
                {
                    j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        result[i, j] = col;
                        j++;
                    }
                    i++;
                }
                
            }

            return result;
        }
    }
}