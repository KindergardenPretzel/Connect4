namespace Connect4
{
    internal class Box
    {
        public Size ScreenSize;

        private Corcle[,] grid;
        private Corcle corcle;
        private Color[] color = new Color[2];
        private int yOffset => ScreenSize.Height / 7;
        private int currentPlayer = 0;
        private bool isGameOver = false;

        public bool IsGameOver
        {
            set
            {
                isGameOver = value;
            }
            get
            {
                return isGameOver;
            }
        }

        private int horizontalCorcles = 7;
        private int corcleWidth => ScreenSize.Width / 10;
        private int corcleHeight => (ScreenSize.Height - yOffset) / 7;
        private int spacing => (ScreenSize.Width - (corcleWidth * 7)) / 8;
        private int ColumnWidth => ((ScreenSize.Width - spacing) / 7);
        private int horizontalSpacing => (ScreenSize.Width - (corcleWidth * 7)) / 8;
        private int verticalSpacing => (ScreenSize.Height - yOffset - (corcleHeight * 6)) / 7;

        public Box(Size screensize)
        {
            ScreenSize = screensize;
            color[0] = Color.Red;
            color[1] = Color.Blue;
            grid = new Corcle[7, 6];

            corcle = new Corcle(new Rectangle(0, 0, corcleWidth, corcleHeight), color[0]);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Corcle(new Rectangle((i * corcleWidth) + ((i + 1) * horizontalSpacing), (j * (corcleHeight + verticalSpacing)) + yOffset, corcleWidth, corcleHeight), Color.Wheat);
                }
            }
        }

        public void MoveSelection(Point position)
        {
            //figure out which column position is in
            //get the x coordinate of that column
            //done


            int columnNum = position.X / ColumnWidth;
            int ColumnX = spacing + (ColumnWidth * columnNum);
            corcle.Rect.X = ColumnX;
        }
        public void DropCorcle(Point position)
        {
            int columnNum = position.X / ColumnWidth;
            int ColumnX = spacing + (ColumnWidth * columnNum);
            drop();          
            corcle.color = color[currentPlayer];
           // color[currentPlayer] = color[1];
            void drop()
            {
                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    if (grid[columnNum, i].color != Color.Wheat)
                    {
                        if (i != 0)
                        {
                            if (grid[columnNum, 0].color == Color.Wheat)
                            {
                                grid[columnNum, i - 1].color = color[currentPlayer];
                                if (currentPlayer == 0)
                                {
                                    currentPlayer = 1;
                                }
                                 else if(currentPlayer == 1)
                                 {
                                    currentPlayer = 0;
                                 }
                                return;
                            }
                            
                        }

                    }

                }
                if (grid[columnNum, 5].color == Color.Wheat)
                {
                    grid[columnNum, 5].color = color[currentPlayer];
                    if (currentPlayer == 0)
                    {
                        currentPlayer = 1;
                    }
                    else if (currentPlayer == 1)
                    {
                        currentPlayer = 0;
                    }
                }
            }
        }

        public void Draw(Graphics gfx)
        {

            DrawBox(gfx);
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    grid[i, j].Rect = new Rectangle((i * corcleWidth) + ((i + 1) * horizontalSpacing), (j * (corcleHeight + verticalSpacing)) + yOffset, corcleWidth, corcleHeight);
                    grid[i, j].Draw(gfx);
                }
            }
            corcle.Rect.Size = new Size(corcleWidth, corcleHeight);
            corcle.Draw(gfx);
        }

        private void DrawBox(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Peru, new Rectangle(0, 0, ScreenSize.Width, ScreenSize.Height));

        }
        public string winDetection()
        {
            int redScore = 0;
            int blueScore = 0;
            for(int j = 0;j < grid.GetLength(1); j ++)
            {
                for(int i = 0; i < grid.GetLength(0); i ++)
                {
                    if(grid[i,j].color == Color.Red)
                    {
                        blueScore = 0;
                        redScore++;                        
                    }
                    if (redScore == 4)
                    {
                        this.IsGameOver = true;
                        return "red";                      
                    }
                    if (grid[i,j].color == Color.Blue)
                    {
                        redScore = 0;
                        blueScore++;
                    }
                    if (blueScore == 4)
                    {
                        this.IsGameOver = true;
                        return "blue";                       
                    }
                    if(grid[i, j].color == Color.Wheat)
                    {
                        blueScore = 0;
                        redScore = 0;
                    }
                }
                ;
            }
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].color == Color.Red)
                    {
                        blueScore = 0;
                        redScore++;
                    }
                    if (redScore == 4)
                    {
                        this.IsGameOver = true;
                        redScore = 0;
                        return "red";
                    }
                    if (grid[i, j].color == Color.Blue)
                    {
                        redScore = 0;
                        blueScore++;
                    }
                    if (blueScore == 4)
                    {
                        this.IsGameOver = true;
                        blueScore = 0;
                        return "blue";
                    }
                    if (grid[i, j].color == Color.Wheat)
                    {
                        blueScore = 0;
                        redScore = 0;
                    }
                }
                ;
            }
            int sy = grid.GetLength(1)-1;
            int curry = 0;
            int currr = 3;
            for (int j = 3; j < grid.GetLength(0)+2; j++)
            {
                currr = j;
                curry = sy;
                while (currr >= 0 && curry >= 0)
                {
                    if(currr < grid.GetLength(0) && curry < grid.GetLength(1))
                    {
                        if (grid[currr, curry].color == Color.Red)
                        {
                            blueScore = 0;
                            redScore++;
                    
                        }
                        if (redScore == 4)
                        {
                            this.IsGameOver = true;
                            redScore = 0;
                            return "red";
                        }
                        if (grid[currr, curry].color == Color.Blue)
                        {
                            redScore = 0;
                            blueScore++;

                        }
                        if (blueScore == 4)
                        {
                            this.IsGameOver = true;
                            blueScore = 0;
                            return "blue";
                        }
                    }
                    currr--;
                    curry--;
                }
                blueScore = 0;
                redScore = 0;
                
            }
            for(int i = 3;i >= -2; i--)
            {
                currr = i;
                curry = sy;
                while (currr <= grid.GetLength(0) -1 && curry <= grid.GetLength(1) - 1)
                {
                    if (currr >= 0 && curry >= 0)
                    {
                        if (grid[currr, curry].color == Color.Red)
                        {
                            blueScore = 0;
                            redScore++;

                        }
                        if (redScore == 4)
                        {
                            this.IsGameOver = true;
                            redScore = 0;
                            return "red";
                        }
                        if (grid[currr, curry].color == Color.Blue)
                        {
                            redScore = 0;
                            blueScore++;

                        }
                        if (blueScore == 4)
                        {
                            this.IsGameOver = true;
                            blueScore = 0;
                            return "blue";
                        }
                    }
                    currr++;
                    curry--;
                }
                blueScore = 0;
                redScore = 0;
            }
            return "";
        }
    }
}
