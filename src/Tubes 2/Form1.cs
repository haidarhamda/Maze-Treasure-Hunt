using System.Drawing.Design;
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
        private bool resizeOnce = false;
        private bool resizeOnce2 = false;
        public Form1()
        {
            InitializeComponent();
        }

        // Menghitung node unik pada array
        private static int countUnique(List<int[]> nodes)
        {
            List<int[]> result = new List<int[]>();
            foreach (int[] node in nodes)
            {
                if (!util.countDistinct(result, node))
                {
                    result.Add(node);
                }
            }
            return result.Count;
        }

        // Visualize map
        private void start_map_visual(object sender, EventArgs e)
        {
            // Clear selection
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;

            // Menampilkan map
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(settings1.mapfFile))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    int row = 0;
                    int col = 0;

                    // Count rows and columns without whitespace
                    while ((line = streamReader.ReadLine()) != null)
                    {
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

                    // Menginisialisasi ukuran grid
                    dataGridView1.ColumnCount = col;
                    dataGridView1.RowCount = row;
                }
            }


            // Memasukkan detail map
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

                    // Menghilangkan header grid
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersVisible = false;
                }
            }

            // Mensetting dimensi grid
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
            
            // Resize app
            resize(ref resizeOnce, 30);

            // Clear selection
            dataGridView1.ClearSelection();
        }

        // Resize app
        private void resize(ref bool flag, int delta)
        {
            if (!flag)
            {
                panel1.Height += delta;
                this.Height += delta;
                flag = true;
            }
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            // Clear output
            output1.route = "None";
            output1.nodes = "None";
            output1.steps = "None";
            output1.execTime = "None";

            // Menampilkan maze
            start_map_visual(sender, EventArgs.Empty);

            // Clear cell color
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
            

            
            Map defaultMap = null;
            try
            {
                // Initialize map
                defaultMap = new Map(convertToStringArray(settings1.mapfFile));
                Tuple<List<int[]>, List<int[]>, bool> result = null;
                
                // Pencarian solusi sesuai dengan algoritma yang dipilih
                if(settings1.algoChoice == 0 || settings1.algoChoice == 1 || settings1.algoChoice == 3 || settings1.algoChoice == 4)
                {
                    // Resize app
                    resize(ref resizeOnce2, 170);
                    
                    // Start execution time counter
                    var watch = new System.Diagnostics.Stopwatch();
                    watch.Start();

                    // Get solution
                    if(settings1.algoChoice == 0)
                    {
                        Bfs algo = new Bfs(defaultMap);
                        result = algo.bfsearch();
                    }else if(settings1.algoChoice == 1)
                    {
                        Dfs algo = new Dfs(defaultMap);
                        result = algo.dfsearch();
                    }else if(settings1.algoChoice == 3)
                    {
                        Tsp algo = new Tsp(defaultMap);
                        result = algo.tspWithBfs();
                    }
                    else
                    {
                        Tsp algo = new Tsp(defaultMap);
                        result = algo.tspWithDfs();
                    }

                    // Stop counter
                    watch.Stop();

                    // Visualisasi hasil
                    var task = startVisualizeAsync(result);
                    await task;

                    // Menampilkan output
                    TimeSpan elapsed = watch.Elapsed;
                    output1.execTime = elapsed.TotalMilliseconds.ToString() + " ms";
                    output1.nodes = countUnique(result.Item2).ToString();
                    output1.steps = (result.Item1.Count - 1).ToString();

                    // Reset counter
                    watch.Reset();

                }else
                {
                    // Pilihan algoritma tidak valid
                    MessageBox.Show("Pilih algoritma pencarian yang ingin digunakan terlebih dahulu!");
                }

            }
            catch(Exception err)
            {
                // Format map tidak valid
                MessageBox.Show(err.Message);
            }

            
        }

        // Menentukan apakah sebuah point berada disampingnya atau tidak
        private bool isBeside(int[] current, int[] next)
        {
            if (current[0] == next[0])
            {
                if (Math.Abs(current[1] - next[1]) == 1)
                {
                    return true;
                }
            }
            else if (current[1] == next[1])
            {
                if (Math.Abs(current[0] - next[0]) == 1)
                {
                    return true;
                }
            }
            return false;
        } 

        // Visualize rute
        private async Task startVisualizeAsync(Tuple<List<int[]>, List<int[]>,bool> result)
        {
            // Inisialisasi flag kunjungan
            bool repeatedNode;

            // Show search route
            for (int i = 0; i < result.Item2.Count; i++)
            {
                repeatedNode = false;
                Color oldColor = dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor;

                // Flag jika node sudah pernah dikunjungi
                if (dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor != Color.White)
                {
                    repeatedNode = true;
                }

                // Menunjukkan current node
                dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Blue;

                // Delay untuk animasi
                await Task.Delay((int)(settings1.delaySettings * 1000));

                // Jika node sudah pernah dikunjungi ubah menjadi warna Orange, jika tidak ubah menjadi Yellow
                if (repeatedNode)
                {
                    Color newColor = ControlPaint.Dark(oldColor, 0.1f);
                    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = newColor;
                }
                else
                {
                    dataGridView1.Rows[result.Item2[i][0] - 1].Cells[result.Item2[i][1] - 1].Style.BackColor = Color.Yellow;
                }

            }

            // Show solution route
            string routeDir = "";
            for (int i = 0; i < result.Item1.Count; i++)
            {
                // Ubah warna cell
                //MessageBox.Show(dataGridView1.Rows[result.Item1[i][0] - 1].Cells[result.Item1[i][1] - 1].Style.BackColor.ToString());
                if(dataGridView1.Rows[result.Item1[i][0] - 1].Cells[result.Item1[i][1] - 1].Style.BackColor == Color.IndianRed)
                {
                    Color newColor = ControlPaint.Dark(Color.IndianRed, 0.2f);
                    dataGridView1.Rows[result.Item1[i][0] - 1].Cells[result.Item1[i][1] - 1].Style.BackColor = newColor;
                }
                else
                {  
                    dataGridView1.Rows[result.Item1[i][0] - 1].Cells[result.Item1[i][1] - 1].Style.BackColor = Color.IndianRed;
                }
                
                
                // Menentukan arah gerak solusi
                if(i != (result.Item1.Count - 1))
                {
                    if (isBeside(result.Item1[i + 1], result.Item1[i]))
                    {
                        // Down
                        if (result.Item1[i + 1][0] - 1 > result.Item1[i][0] - 1)
                        {
                            routeDir += "D ";
                        }
                        // Up
                        else if (result.Item1[i + 1][0] - 1 < result.Item1[i][0] - 1)
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
                    else routeDir += "T";
                    

                }

                // Delay untuk animasi
                await Task.Delay((int)(settings1.delaySettings * 1000));
            }

            //Menampilkan output arah rute solusi
            output1.route = routeDir;
        }

        // Ubah isi text file menjadi array string 2 dimensi
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