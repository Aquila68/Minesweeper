using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweep : Form
    {
        private Difficulty difficulty=Difficulty.Beginner;
        public Minesweep()                                          //this method runs when you execute the program
        {
            InitializeComponent();
            this.LoadGame(null, null);
            this.tilesGrid.tileflagcountchange += TileFlagCountChanged;
        }

        private enum Difficulty { Beginner, Normal ,Expert}
        private void LoadGame(object sender, EventArgs e)           //loads the game
        {
            int x, y, mines;
            switch (this.difficulty)
            {
                case Difficulty.Beginner:
                    x = y = 9;
                    mines = 10;
                    break;
                case Difficulty.Normal:
                    x = y = 16;
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    x = 30;
                    y = 16;
                    mines = 99;
                    break;
                default:
                    throw new InvalidOperationException("Invalid difficulty");
            }

            this.tilesGrid.LoadGrid(new Size(x, y), mines);
            this.MaximumSize = this.MinimumSize = new Size(this.tilesGrid.Width + 36, this.tilesGrid.Height + 175);
            this.flagCounter.Text = mines.ToString();
            this.flagCounter.ForeColor = Color.Black;
        }

        private class TilesGrid : Panel //class containing the tiles and the flag count
        {

            private static readonly Random random = new Random();
            private static readonly HashSet<Tile> gridSearchBlacklist = new HashSet<Tile>();
            private Size gridSize;
            private int mines, flags;
            private bool minesGenerated;
            private Tile this[Point point] => (Tile)Controls[$"Tile_{point.X}_{point.Y}"];
            
            public event EventHandler<TileFlagCountChangedEventArgs> tileflagcountchange = delegate { };
            private void Tile_MouseDown(object sender, MouseEventArgs e)
            {
                Tile t = (Tile)sender;
                if (!t.Opened)
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left when !t.Flagged:
                            if (!this.minesGenerated)
                            {
                                this.GenerateMines(t);
                            }
                            if (t.Mined)
                            {
                                this.DisableTiles(true);
                            }
                            else
                            {
                                t.TestAdjacentTiles();
                                gridSearchBlacklist.Clear();
                                
                            }
                            break;
                        case MouseButtons.Right when this.flags > 0:
                            if (t.Flagged)
                            {
                                t.Flagged = false;
                                this.flags++;
                            }
                            else
                            {
                                t.Flagged = true;
                                this.flags--;
                            }
                            tileflagcountchange(this,
                                new TileFlagCountChangedEventArgs(this.flags, 
                                this.flags < this.mines * 0.25 ? Color.Red : Color.Black));
                            break;
                    }
                    CheckForWin();
                }
                
            }

            public void LoadGrid(Size gridSize, int mines)  //loads the grid/panel with tiles and mines
            {
                this.minesGenerated = false;
                this.Controls.Clear();
                this.gridSize = gridSize;
                this.mines = this.flags = mines;
                this.Size = new Size(gridSize.Width * Tile.LENGTH, gridSize.Height * Tile.LENGTH);
                for (int x = 0; x < gridSize.Width; x++)
                {
                    for (int y = 0; y < gridSize.Height; y++)
                    {
                        Tile t = new Tile(x, y);
                        t.MouseDown += Tile_MouseDown;
                        this.Controls.Add(t);
                    }
                }

                foreach (Tile tile in this.Controls)
                {
                    tile.SetAdjacentTiles();
                }
            }

            private void GenerateMines(Tile safeTile)   //randomly spreads the mines among the tiles
            {
                int safeTileCount = safeTile.AdjacentTiles.Length + 1;
                Point[] usedPositions = new Point[this.mines + safeTileCount];
                usedPositions[0] = safeTile.GridPosition;
                for (int i = 1; i < safeTileCount; i++)
                {
                    usedPositions[i] = safeTile.AdjacentTiles[i - 1].GridPosition;
                }

                for (int i = safeTileCount; i < usedPositions.Length; i++)
                {
                    Point point = new Point(random.Next(this.gridSize.Width), random.Next(this.gridSize.Height));
                    if (!usedPositions.Contains(point))
                    {
                        this[point].Mine();
                        usedPositions[i] = point;
                    }
                    else
                    {
                        i--;
                    }
                    this.minesGenerated = true;

                }
            }

            private void DisableTiles(bool gameLost) //disables interaction with tiles when you win/lose game
            {
                if (gameLost)
                {
                    MessageBox.Show("You stepped on mine", "Game Lost", MessageBoxButtons.OK);
                }
                foreach (Tile tile in this.Controls)
                {
                    tile.MouseDown -= this.Tile_MouseDown;
                    if (gameLost)
                    {
                        tile.Image = !tile.Opened && tile.Mined && !tile.Flagged ? MineRes.bomb :
                            tile.Flagged && !tile.Mined ? MineRes.question : tile.Image;

                    }
                        
                }
            }

            private void CheckForWin()      //checks whether player has won
            {
                if (this.flags != 0 && this.Controls.OfType<Tile>().Count(tile => tile.Opened || tile.Flagged) !=
                    this.gridSize.Width * this.gridSize.Height)
                {
                    return;
                }
                if (flags == 0 && Controls.OfType<Tile>().Count(tile => tile.Mined && tile.Flagged) == mines) {//checks for win when all flags have been used
                    MessageBox.Show("Hooray!!!You solved the game", "Game Solved", MessageBoxButtons.OK);
                    this.DisableTiles(false);
                }
                if ((gridSize.Width * gridSize.Height) - Controls.OfType<Tile>().Count(tile => tile.Opened ) == mines){
                    MessageBox.Show("Hooray!!!You solved the game", "Game Solved", MessageBoxButtons.OK);
                    this.DisableTiles(false);
                }
            }

            private class Tile : PictureBox         //class for each tile and its properties
            {

                public const int LENGTH = 25;
                private bool flagged;
                private static readonly int[][] adjacentCoords =                //matrix of surrounding tiles
                {
                    new int[]{-1,-1 },new int[]{0,-1 },new int[]{1,-1 },
                    new int[]{-1,0 },                   new int[]{1,0 },
                    new int[]{-1,1 },new int[]{0,1 },new int[]{1,1 }
                };

                private int AdjacentMines => this.AdjacentTiles.Count(tile => tile.Mined); //count of mines around the tile
                public Tile[] AdjacentTiles { get; private set; }
                public Point GridPosition { get; }
                public bool Opened { get; private set; }                              //true when tile has been left-clicked
                public bool Mined { get; private set; }                               //is true when the tile has mine under it
                public bool Flagged
                {
                    get => this.flagged;
                    set
                    {
                        this.flagged = value;
                        this.Image = value ? MineRes.flagged : MineRes.facingDown;
                    }
                }

                public Tile(int x, int y)
                {
                    this.Name = $"Tile_{x}_{y}";
                    this.Location = new Point(x * LENGTH, y * LENGTH);
                    this.GridPosition = new Point(x, y);
                    this.Size = new Size(LENGTH, LENGTH);
                    this.Image = MineRes.facingDown;
                    this.SizeMode = PictureBoxSizeMode.Zoom;
                }

                public void SetAdjacentTiles()          //creates a list of adjacent tiles for each tile
                {
                    TilesGrid tilesgrid = (TilesGrid)this.Parent;
                    List<Tile> listtiles = new List<Tile>(8);
                    foreach (int[] adjacentCoord in adjacentCoords)
                    {
                        Tile tile = tilesgrid[
                            new Point(GridPosition.X + adjacentCoord[0], GridPosition.Y + adjacentCoord[1])];
                        if (tile != null)
                        {
                            listtiles.Add(tile);
                        }
                    }
                    this.AdjacentTiles = listtiles.ToArray();
                }

                public void TestAdjacentTiles()     //check whether the tile has mines around it
                {
                    if (this.flagged || gridSearchBlacklist.Contains(this)) { return; }

                    TilesGrid.gridSearchBlacklist.Add(this);
                    if (this.AdjacentMines == 0)
                    {
                        foreach (Tile tile in this.AdjacentTiles)
                        {
                            tile.TestAdjacentTiles();
                        }
                    }
                    this.Open();
                }

                public void Mine()
                {
                    this.Mined = true;
                }

                public void Open()
                {
                    this.Opened = true;
                    //this.Image = (Image)Resources.ResourceManager.GetObject($"Empty_{this.AdjacentMines}");
                    switch (this.AdjacentMines) {
                        case 0:
                            this.Image = MineRes.Empty_0;
                            break;
                        case 1:
                            this.Image = MineRes.Empty_1;
                            break;
                        case 2:
                            this.Image = MineRes.Empty_2;
                            break;
                        case 3:
                            this.Image = MineRes.Empty_3;
                            break;
                        case 4:
                            this.Image = MineRes.Empty_4;
                            break;
                        case 5:
                            this.Image = MineRes.Empty_5;
                            break;
                        case 6:
                            this.Image = MineRes.Empty_6;
                            break;
                        case 7:
                            this.Image = MineRes.Empty_7;
                            break;
                        case 8:
                            this.Image = MineRes.Empty_8;
                            break;
                        default:
                            throw new InvalidConstraintException("Invalid number of mines");
                    }
                }
            }

            public class TileFlagCountChangedEventArgs : EventArgs
            {
                public int flags { get; }
                public Color labelColor { get; }

                public TileFlagCountChangedEventArgs(int flags, Color labelColour)
                {
                    this.flags = flags;
                    this.labelColor = labelColor;
                }
            }
        }
        private void TileFlagCountChanged(object sender, TilesGrid.TileFlagCountChangedEventArgs e) //for flag count upndation
        {
            this.flagCounter.Text = e.flags.ToString();
            this.flagCounter.ForeColor = e.labelColor;
        }

        private void MenuStrip_New_Click(object sender, EventArgs e)
        {
            this.LoadGame(null, null);
        }

        private void MenuStrip_Game_DifficultyChanged(object sender, EventArgs e)//runs when difficulty is changed
        {
            this.difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), (string)((ToolStripMenuItem)sender).Tag);
            this.LoadGame(null, null);
        }

        private void MenuStrip_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
