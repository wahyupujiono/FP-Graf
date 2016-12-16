using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Prim
{
    public partial class MainForm : Form
    {
        private const int PAINTED = 0, UNPAINTED = 1;
        private int index, n, x, y, x1, x2, y1, y2;
        private int[] u, v;
        private Color[] color;
        private List<Node> graph;

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void supportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Support by :" + Environment.NewLine + "MOHAMMAD FIKRI          5115100049" + Environment.NewLine + "GLENN LUCAS                    5115100148" + Environment.NewLine + "WAHYU PUJIONO              5115100151" + Environment.NewLine + "UNGGUL WIDODO W         5115100706");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private PriorityQueue queue;

        private void petaITSToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new System.Drawing.Size(815, 490);
            form.Show();

            PictureBox button3 = new PictureBox();
            button3.Image = Properties.Resources.MAP_ITS;
            button3.Size = new System.Drawing.Size(815, 490);

            form.Controls.Add(button3);
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index++;

            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index--;

            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = -2;
            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }

        public MainForm()
        {
            InitializeComponent();
            CreateGraph();
            index = -1;
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void CreateGraph()
        {
            graph = new List<Node>();
            Node a = new Node(0, 0);
            Node b = new Node(1, Node.INFINITY);
            Node c = new Node(2, Node.INFINITY);
            Node d = new Node(3, Node.INFINITY);
            Node e = new Node(4, Node.INFINITY);
            Node f = new Node(5, Node.INFINITY);
            Node g = new Node(6, Node.INFINITY);

            List<Node> adjA = a.Adjacency;
            List<Node> adjB = b.Adjacency;
            List<Node> adjC = c.Adjacency;
            List<Node> adjD = d.Adjacency;
            List<Node> adjE = e.Adjacency;
            List<Node> adjF = f.Adjacency;
            List<Node> adjG = g.Adjacency;

            List<int> weightA = a.Weight;
            List<int> weightB = b.Weight;
            List<int> weightC = c.Weight;
            List<int> weightD = d.Weight;
            List<int> weightE = e.Weight;
            List<int> weightF = f.Weight;
            List<int> weightG = g.Weight;  
            
            adjA.Add(b);
            adjA.Add(d);
            adjA.Add(e);
            adjA.Add(f);
            adjA.Add(g);
            weightA.Add(5);
            weightA.Add(25);
            weightA.Add(10);
            weightA.Add(20);
            weightA.Add(15);
            adjB.Add(c);
            adjB.Add(d);
            adjB.Add(a);
            weightB.Add(22);
            weightB.Add(13);
            weightB.Add(5);
            adjC.Add(d);
            adjC.Add(b);
            weightC.Add(30);
            weightC.Add(22);
            adjD.Add(e);
            adjD.Add(a);
            adjD.Add(b);
            weightD.Add(17);
            weightD.Add(25);
            weightD.Add(13);
            adjE.Add(f);
            adjE.Add(a);
            adjE.Add(d);
            weightE.Add(7);
            weightE.Add(10);
            weightE.Add(17);
            adjF.Add(g);
            adjF.Add(a);
            adjF.Add(e);
            weightF.Add(3);
            weightF.Add(20);
            weightF.Add(7);
            adjG.Add(a);
            adjG.Add(f);
            weightG.Add(15);
            weightG.Add(3);

            graph.Add(a);
            graph.Add(b);
            graph.Add(c);
            graph.Add(d);
            graph.Add(e);
            graph.Add(f);
            graph.Add(g);
            n = graph.Count;
            color = new Color[n];

            for (int m = 0; m < n; m++)

                color[m] = Color.Red;

            u = new int[n];
            v = new int[n];

            MST();
        }



        void MST()
        {
            bool[] output = new bool[n];
            int[] pi = new int[n];
            List<Node> copy = new List<Node>();

            for (int i = 0; i < graph.Count; i++)
                copy.Add(graph[i]);

            queue = new PriorityQueue(copy);
            queue.buildHeap();

            for (int i = 0; i < queue.NodeList.Count; i++)
            {
                Node node = queue.extractMin();

                output[node.Id] = true;
                for (int j = 0; j < node.Adjacency.Count; j++)
                {
                    Node next = node.Adjacency[j];
                    int weight = node.Weight[j];

                    if (!output[next.Id] && weight <= next.Key)
                    {
                        pi[next.Id] = node.Id;
                        node.Adjacency[j].Key = weight;
                    }
                }

            }

            pi[0] = -1;

            for (int i = 0; i < n; i++)
            {
                u[i] = i;
                v[i] = pi[i];
            }

            // reorder the edges in the minimum spanning tree
            
            for (int i = 0; i <= n - 1; i++)
          {
                for (int j = i + 1; j < n; j++)
                {
                    Node nodeI = graph[u[i]];
                    Node nodeJ = graph[u[j]];

                    if (v[i] >= v[j] && nodeI.Key > nodeJ.Key)
                    {
                        int t = u[i];

                        u[i] = u[j];
                        u[j] = t;
                        t = v[i];
                        v[i] = v[j];
                        v[j] = t;
                    }
                }
            }
        }

        private void calculateXY(int id)
        {
            int Width = panel1.Width;
            int Height = panel1.Height;

            x = Width / 2 + (int)(Width * Math.Cos(2 * id * Math.PI / n) / 4.0);
            y = Height / 2 + (int)(Width * Math.Sin(2 * id * Math.PI / n) / 4.0);
        }

        private void draw(Graphics g)
        {

            if (index != -1)
            {
                int Width = panel1.Width;
                int Height = panel1.Height;
                Font font = new Font("Courier New", 12f, FontStyle.Bold);
                List<Node> nodeList = queue.NodeList;
                Pen pen = new Pen(Color.Black);
                SolidBrush textBrush = new SolidBrush(Color.White);
                //SolidBrush weightBrush = new SolidBrush(Color.Black);

                for (int i = 0; i <= index; i++)
                {
                    if (v[i] != -1)
                    {

                        calculateXY(u[i]);
                        x1 = x + (Width / 2) / n / 2;
                        y1 = y + (Width / 2) / n / 2;
                        calculateXY(v[i]);
                        x2 = x + (Width / 2) / n / 2;
                        y2 = y + (Width / 2) / n / 2;
                        g.DrawLine(pen, x1, y1, x2, y2);                        
                    }


                    SolidBrush brush = new SolidBrush(color[u[index]]);

                    char[] c = new char[1];

                    c[0] = (char)('a' + u[i]);

                    string str = new string(c);

                    calculateXY(u[i]);
                    g.FillEllipse(brush, x, y, (Width / 2) / n, (Width / 2) / n);
                    g.DrawString(str, font,
                        textBrush, (float)(x + (Width / 2) / n / 2) - 12f,
                        (float)(y + (Width / 2) / n / 2) - 12f);


                    if (v[i] != -1)
                    {
                        c = new char[1];
                        c[0] = (char)('a' + v[i]);
                        str = new string(c);
                        calculateXY(v[i]);
                        g.FillEllipse(brush, x, y, (Width / 2) / n, (Width / 2) / n);
                        g.DrawString(str, font,
                            textBrush, (float)(x + (Width / 2) / n / 2) - 12f,
                            (float)(y + (Width / 2) / n / 2) - 12f);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
            draw(pea.Graphics);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index++;

            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index--;

            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = -2;
            if (index < n)
                panel1.Invalidate();

            else
                index = -1;
        }
    }
}