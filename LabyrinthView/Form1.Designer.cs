namespace LabyrinthView
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            gameMenu = new ToolStripMenuItem();
            newGameMenu = new ToolStripMenuItem();
            smallGameStart = new ToolStripMenuItem();
            mediumGameStart = new ToolStripMenuItem();
            largeGameStart = new ToolStripMenuItem();
            pauseMenu = new ToolStripMenuItem();
            exitMenu = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            timeTextLabel = new ToolStripStatusLabel();
            gameTimeLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameMenu
            // 
            gameMenu.DropDownItems.AddRange(new ToolStripItem[] { newGameMenu, pauseMenu, exitMenu });
            gameMenu.Name = "gameMenu";
            gameMenu.Size = new Size(50, 20);
            gameMenu.Text = "Menu";
            // 
            // newGameMenu
            // 
            newGameMenu.DropDownItems.AddRange(new ToolStripItem[] { smallGameStart, mediumGameStart, largeGameStart });
            newGameMenu.Name = "newGameMenu";
            newGameMenu.Size = new Size(180, 22);
            newGameMenu.Text = "New game";
            // 
            // smallGameStart
            // 
            smallGameStart.Name = "smallGameStart";
            smallGameStart.Size = new Size(119, 22);
            smallGameStart.Text = "Small";
            smallGameStart.Click += smallGameStart_Click;
            // 
            // mediumGameStart
            // 
            mediumGameStart.Name = "mediumGameStart";
            mediumGameStart.Size = new Size(119, 22);
            mediumGameStart.Text = "Medium";
            mediumGameStart.Click += mediumGameStart_Click;
            // 
            // largeGameStart
            // 
            largeGameStart.Name = "largeGameStart";
            largeGameStart.Size = new Size(119, 22);
            largeGameStart.Text = "Large";
            largeGameStart.Click += largeGameStart_Click;
            // 
            // pauseMenu
            // 
            pauseMenu.Enabled = false;
            pauseMenu.Name = "pauseMenu";
            pauseMenu.Size = new Size(180, 22);
            pauseMenu.Text = "Pause game";
            pauseMenu.Click += pauseMenu_Click;
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.Size = new Size(180, 22);
            exitMenu.Text = "Exit";
            exitMenu.Click += exitMenu_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { timeTextLabel, gameTimeLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // timeTextLabel
            // 
            timeTextLabel.Name = "timeTextLabel";
            timeTextLabel.Size = new Size(0, 17);
            // 
            // gameTimeLabel
            // 
            gameTimeLabel.Name = "gameTimeLabel";
            gameTimeLabel.Size = new Size(0, 17);
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Name = "GameForm";
            Text = "Labyrinth";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameMenu;
        private ToolStripMenuItem newGameMenu;
        private ToolStripMenuItem pauseMenu;
        private ToolStripMenuItem exitMenu;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel timeTextLabel;
        private ToolStripMenuItem smallGameStart;
        private ToolStripMenuItem mediumGameStart;
        private ToolStripMenuItem largeGameStart;
        private ToolStripStatusLabel gameTimeLabel;
    }
}
