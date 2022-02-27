namespace Minesweeper
{
    partial class Minesweep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

    

        private void InitializeComponent()
        {
            this.tilesGrid = new Minesweeper.Minesweep.TilesGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flagCounter = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip_Game_Beginner = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Normal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Expert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip_Game_Exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tilesGrid
            // 
            this.tilesGrid.Location = new System.Drawing.Point(12, 128);
            this.tilesGrid.Name = "tilesGrid";
            this.tilesGrid.Size = new System.Drawing.Size(200, 100);
            this.tilesGrid.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Minesweeper.MineRes.sun;
            this.pictureBox1.Location = new System.Drawing.Point(39, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 95);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.LoadGame);
            // 
            // flagCounter
            // 
            this.flagCounter.AutoSize = true;
            this.flagCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagCounter.Location = new System.Drawing.Point(176, 38);
            this.flagCounter.Name = "flagCounter";
            this.flagCounter.Size = new System.Drawing.Size(0, 24);
            this.flagCounter.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_Game});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip_Game
            // 
            this.menuStrip_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_Game_New,
            this.toolStripMenuItem1,
            this.menuStrip_Game_Beginner,
            this.menuStrip_Game_Normal,
            this.menuStrip_Game_Expert,
            this.toolStripMenuItem2,
            this.menuStrip_Game_Exit});
            this.menuStrip_Game.Name = "menuStrip_Game";
            this.menuStrip_Game.Size = new System.Drawing.Size(50, 20);
            this.menuStrip_Game.Text = "Game";
            // 
            // menuStrip_Game_New
            // 
            this.menuStrip_Game_New.Name = "menuStrip_Game_New";
            this.menuStrip_Game_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuStrip_Game_New.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_Game_New.Text = "New";
            this.menuStrip_Game_New.Click += new System.EventHandler(this.MenuStrip_New_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuStrip_Game_Beginner
            // 
            this.menuStrip_Game_Beginner.Name = "menuStrip_Game_Beginner";
            this.menuStrip_Game_Beginner.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_Game_Beginner.Tag = "Beginner";
            this.menuStrip_Game_Beginner.Text = "Beginner";
            this.menuStrip_Game_Beginner.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // menuStrip_Game_Normal
            // 
            this.menuStrip_Game_Normal.Name = "menuStrip_Game_Normal";
            this.menuStrip_Game_Normal.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_Game_Normal.Tag = "Normal";
            this.menuStrip_Game_Normal.Text = "Normal";
            this.menuStrip_Game_Normal.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // menuStrip_Game_Expert
            // 
            this.menuStrip_Game_Expert.Name = "menuStrip_Game_Expert";
            this.menuStrip_Game_Expert.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_Game_Expert.Tag = "Expert";
            this.menuStrip_Game_Expert.Text = "Expert";
            this.menuStrip_Game_Expert.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // menuStrip_Game_Exit
            // 
            this.menuStrip_Game_Exit.Name = "menuStrip_Game_Exit";
            this.menuStrip_Game_Exit.Size = new System.Drawing.Size(180, 22);
            this.menuStrip_Game_Exit.Text = "Exit";
            this.menuStrip_Game_Exit.Click += new System.EventHandler(this.MenuStrip_Exit_Click);
            // 
            // Minesweep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 667);
            this.Controls.Add(this.flagCounter);
            this.Controls.Add(this.tilesGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Minesweep";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TilesGrid tilesGrid;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label flagCounter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_New;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Beginner;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Normal;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Expert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Exit;
    }
}

