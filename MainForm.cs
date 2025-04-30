using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LifeGame
{
    public partial class MainForm : Form
    {
        Game game;
        int height;
        int width;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Tick += timerTick;
            SetStart();
        }

        void Draw()
        {
            Controls.Clear();
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    Panel panel = new Panel
                    {
                        Size = new Size(20, 20),
                        Location = new Point(j * 20, i * 20),
                        BackColor = game.Matrix[i, j] ? Color.WhiteSmoke : Color.Black
                    };
                    Controls.Add(panel);
                }
        }

        void Redraw()
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    Controls[i * width + j].BackColor = game.Matrix[i, j] ? Color.WhiteSmoke : Color.Black;
                }
        }

        Timer timer = new Timer { Interval = 300 };
        bool paused = false;
        private void MainForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetStart();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (!paused)
                {
                    timer.Stop();
                    paused = true;
                }
                else
                {
                    timer.Start();
                    paused = false;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (timer.Interval >= 100)
                    timer.Interval -= 50;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (timer.Interval <= 1400)
                    timer.Interval += 50;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        void timerTick(object sender, EventArgs e)
        {
            try
            {
                game.NextLayout();
                Redraw();
            }
            catch
            {
                timer.Stop();
                paused = true;
            }
        }

        List<Point> points = new List<Point>();
        bool pressed = false;
        void SetStart()
        {
            this.KeyUp -= MainForm_KeyUp;
            timer.Stop();
            paused = true;
            Controls.Clear();
            points.Clear();
            pressed = false;


            height = 900 / 20;
            width = 1550 / 20;

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    Panel panel = new Panel
                    {
                        Size = new Size(20, 20),
                        Location = new Point(j * 20, i * 20),
                        BackColor = Color.DarkGray,
                        Tag = new Point(i, j)
                    };
                    panel.MouseDown += (s2, e2) => { pressed = !pressed; };
                    panel.MouseEnter += (s2, e2) =>
                    {
                        if (pressed)
                        {
                            (s2 as Panel).BackColor = Color.WhiteSmoke;
                            points.Add((Point)(s2 as Panel).Tag);
                        }
                    };

                    Controls.Add(panel);
                }

            void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Point[] layout = points.ToArray();

                    Controls.Clear();
                    this.KeyUp -= KeyDown;
                    this.KeyUp += MainForm_KeyUp;
                    game = new Game(height, width, layout);
                    Draw();
                    timer.Start();
                    paused = false;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }
            }
            this.KeyUp += KeyDown;
        }

    }
}

