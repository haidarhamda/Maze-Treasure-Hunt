using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tubes_2;
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

        private async void searchButton_Click(object sender, EventArgs e)
        {
            // Clear output
            output1.route = "None";
            output1.nodes = "None";
            output1.steps = "None";
            output1.execTime = "None";

            start_map_visual(sender, EventArgs.Empty);

            //Clear cell color
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if(dataGridView1.Rows[i].Cells[j].Style.BackColor != Color.Black)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }


            // Initialize map
            Map defaultMap = null;
            try
            {
                defaultMap = new Map(convertToStringArray(settings1.mapfFile));
             
            }catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            Tuple<List<int[]>, List<int[]>, bool> result = null;

            if (settings1.algoChoice == 0)
            {
                //MessageBox.Show(settings1.algoChoice.ToString());
                if (!resizeOnce2)
                {
                    panel1.Height += 120;
                    this.Height += 120;
                    resizeOnce2 = true;
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();

                Bfs algo = new Bfs(defaultMap);
                result = algo.bfsearch();

                watch.Stop();
                var task = startVisualizeAsync(result);
                await task; 
                double elapsed = (double)watch.ElapsedMilliseconds / 1000;
                output1.execTime = elapsed.ToString();
                string test = "Nodes: ";
                List<int[]> testing = result.Item2.Distinct().ToList();
                for (int i = 0; i < result.Item2.Count; i++)
                {
                    test = test + "(" + testing[i][0].ToString() + ", " + testing[i][1].ToString() + ")";
                }
                MessageBox.Show(test);
                output1.nodes = result.Item2.Distinct().ToList().Count.ToString();
                output1.steps = (result.Item1.Count - 1).ToString();
            }
            else if(settings1.algoChoice == 1)
            {
                if (!resizeOnce2)
                {
                    panel1.Height += 120;
                    this.Height += 120;
                    resizeOnce2 = true;
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Dfs algo = new Dfs(defaultMap);
                result = algo.dfsearch();
                watch.Stop();
                var task = startVisualizeAsync(result);
                await task;
                double elapsed = (double)watch.ElapsedMilliseconds / 1000;
                output1.execTime = elapsed.ToString();
                //string test = "";
                //for (int i = 0; i < result.Item2.Count; i++)
                //{
                //    test = test + "(" + result.Item2[i][0].ToString() + ", " + result.Item2[i][1].ToString() + ")";
                //}
                //MessageBox.Show(test);
                output1.nodes = result.Item2.Distinct().ToList().Count.ToString();
                output1.steps = (result.Item1.Count - 1).ToString();
            }
            else
            {
                MessageBox.Show("Pilih algoritma pencarian yang ingin digunakan terlebih dahulu!");
            }
        }

        private async Task startVisualizeAsync(Tuple<List<int[]>, List<int[]>,bool> result)
        {

            // Show search route
            bool repeatedNode;

            for (int i = 0; i < result.Item2.Count; i++)
            {
                repeatedNode = false;

                if (dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor == Color.Yellow || dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor == Color.Orange)
                {
                    repeatedNode = true;
                }

                dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Blue;

                //// check left
                //if ((result.Item2[i][1] - 2) >= 0 && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 2].Style.BackColor != Color.Green && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 2].Style.BackColor != Color.DarkGreen && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 2].Style.BackColor != Color.Black && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 2].Style.BackColor != Color.Green)
                //{
                //    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 2].Style.BackColor = Color.Yellow;
                //}
                //// check right
                //if ((result.Item2[i][1]) < dataGridView1.ColumnCount && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1]].Style.BackColor != Color.Green && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1]].Style.BackColor != Color.DarkGreen && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1]].Style.BackColor != Color.Black && dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1]].Style.BackColor != Color.Green)
                //{
                //    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1]].Style.BackColor = Color.Yellow;
                //}
                //// check up
                //if ((result.Item2[i][0] - 2) >= 0 && dataGridView1.Rows[result.Item2[i][0] - 2].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Green && dataGridView1.Rows[result.Item2[i][0] - 2].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.DarkGreen && dataGridView1.Rows[result.Item2[i][0] - 2].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Black && dataGridView1.Rows[result.Item2[i][0] - 2].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Green)
                //{
                //    dataGridView1.Rows[result.Item2[i][0] - 2].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Yellow;
                //}
                //// check down
                //if ((result.Item2[i][0]) < dataGridView1.RowCount && dataGridView1.Rows[result.Item2[i][0]].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Green && dataGridView1.Rows[result.Item2[i][0]].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.DarkGreen && dataGridView1.Rows[result.Item2[i][0]].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Black && dataGridView1.Rows[result.Item2[i][0]].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.Green)
                //{
                //    dataGridView1.Rows[result.Item2[i][0]].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Yellow;
                //}
                await Task.Delay((int)(settings1.delaySettings * 1000));

                if (repeatedNode)
                {
                    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Orange;
                }
                else
                {
                    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Yellow;
                }

            }


            //Clear yellow
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.Yellow)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }

            // Show solution
            string routeDir = "";
            for (int i = 0; i < result.Item1.Count; i++)
            {
                dataGridView1.Rows[result.Item1[i][0] - 1].Cells[result.Item1[i][1] - 1].Style.BackColor = Color.IndianRed;
                if(i != (result.Item1.Count - 1))
                {
                    // Down
                    if(result.Item1[i + 1][0] - 1 > result.Item1[i][0] - 1)
                    {
                        routeDir += "D ";
                    }
                    // Up
                    else if(result.Item1[i + 1][0] - 1 < result.Item1[i][0] - 1)
                    {
                        routeDir += "U ";
                    }
                    // Left
                    else if (result.Item1[i + 1][1] - 1 < result.Item1[i][1] - 1)
                    {
                        routeDir += "L ";
                    }
                    // Right
                    else
                    {
                        routeDir += "R ";
                    }

                }
                await Task.Delay((int)(settings1.delaySettings * 1000));
            }

            output1.route = routeDir;
            //output1.nodes = result.Item2.Distinct().ToList().Count.ToString();
            //output1.steps = result.Item1.Count.ToString();
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