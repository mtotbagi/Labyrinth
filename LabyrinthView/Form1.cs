using Labyrinth.Persistence;
using Labyrinth.Model;
using System.Drawing;
using System.Windows.Forms;

namespace LabyrinthView
{
    public partial class GameForm : Form
    {
        private LabyrinthGame model = null!;
        private System.Windows.Forms.Timer timer;
        private Panel[,] cells = null!;

        private const int CellSize = 40;
        private int gameTime;
        private bool gamePaused;

        public GameForm()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(KeyPressed);

            DataManager manager = new DataManager();

            model = new LabyrinthGame(manager);
            model.MovePerformed += new EventHandler(UpdateLabyrinth);
            model.GameOver += new EventHandler(GameOver);
            model.TimePassed += new EventHandler(TimeUpdate);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
        }

        private void TimeUpdate(object? sender, EventArgs e)
        {
            gameTimeLabel.Text = TimeSpan.FromSeconds(model.GameTime).ToString("g");
        }

        private void GameOver(object? sender, EventArgs e)
        {
            timer.Stop();
            pauseMenu.Enabled = false;
            MessageBox.Show("Congratulations, you won!" + Environment.NewLine,
                                "Labyrinth",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
        }

        private void KeyPressed(object? sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;

            switch (keyPressed)
            {
                case ' ':
                    PauseGame(); break;

                case 'a':
                case 'A':
                    model.Move(Direction.Left); break;

                case 'd':
                case 'D':
                    model.Move(Direction.Right); break;

                case 'w':
                case 'W':
                    model.Move(Direction.Up); break;

                case 's':
                case 'S':
                    model.Move(Direction.Down); break;

            }
        }

        private void smallGameStart_Click(object sender, EventArgs e)
        {
            StartNewGame(7);
        }

        private void mediumGameStart_Click(object sender, EventArgs e)
        {
            StartNewGame(11);

        }

        private void largeGameStart_Click(object sender, EventArgs e)
        {
            StartNewGame(15);

        }

        private void pauseMenu_Click(object sender, EventArgs e)
        {
            PauseGame();
        }
        private void exitMenu_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (MessageBox.Show("Are you sure you want to quit?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }

            if(!model.GamePaused) { timer.Start(); }
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            model.AdvanceTime();
        }
        private void ResetGameTime()
        {
            gameTimeLabel.Text = "";
            gameTime = 0;
            gamePaused = false;
            timer.Start();
        }
        private void PauseGame()
        {
            if (model.GamePaused)
            {
                timer.Start();
                pauseMenu.Text = "Pause game";
                model.GamePaused = false;
            }
            else
            {
                timer.Stop();
                pauseMenu.Text = "Resume game";

                model.GamePaused = true;
            }
        }
        private void UpdateLabyrinth(object? sender, EventArgs e)
        {
            DrawField();
        }
        private void StartNewGame(int mapId)
        {
            if (cells != null)
            {
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        cells[i, j].Dispose();
                    }
                }
            }

            model.Load(mapId);

            int size = model.Data.Size;

            cells = new Panel[size, size];
            this.Size = new Size(size * CellSize + 60, size * CellSize + 100);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Panel cell = new Panel
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(j * CellSize + 20, (size - 1 - i) * CellSize + 25),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Controls.Add(cell);
                    cells[i, j] = cell;
                }
            }

            DrawField();

            ResetGameTime();

            pauseMenu.Enabled = true;
            pauseMenu.Text = "Pause game";
            timeTextLabel.Text = "Time elapsed:";
        }
        private void DrawField()
        {
            int size = model.Data.Size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Panel cell = cells[i, j];
                    Color c;
                    if (!model.Data.Visible[i, j])
                    {
                        c = Color.Black;
                    }
                    else if (model.Data.Value[i, j] == 0) c = Color.White;
                    else c = Color.Gray;
                    cell.BackColor = c;
                    cell.CreateGraphics().Clear(c);
                    Controls.Add(cell);
                    cells[i, j] = cell;
                }
            }
            Graphics g = cells[model.Data.XPos, model.Data.YPos].CreateGraphics();
            g.FillEllipse(Brushes.Black, 5, 5, CellSize - 10, CellSize - 10);
        }
    }
}
