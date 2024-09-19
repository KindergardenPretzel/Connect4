using System.Runtime.Intrinsics.X86;

namespace Connect4
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap mappy;
        Box box;
        public Form1()
        {
            InitializeComponent();
            box = new Box(ClientSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mappy = new Bitmap(canvas.Width, canvas.Height);
            gfx = Graphics.FromImage(mappy);
            EndGamePanel.Visible = false;
            WinTextBox.ReadOnly = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            box.Draw(gfx);
            canvas.Image = mappy;
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Focused)
            {
                canvas.Size = ClientSize;
                mappy = new Bitmap(canvas.Width, canvas.Height);
                gfx = Graphics.FromImage(mappy);
                box.ScreenSize = ClientSize;
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!box.IsGameOver)
            {
                box.DropCorcle(e.Location);
            }
            box.winDetection();
            if (box.winDetection() == "red")
            {
                EndGamePanel.Visible = true;
                WinTextBox.Text = "Red Won!";
                WinTextBox.ReadOnly = true;
            }
            if (box.winDetection() == "blue")
            {
                EndGamePanel.Visible = true;
                WinTextBox.Text = "Blue Won!";
                WinTextBox.ReadOnly = true;
            }
            if (box.winDetection() == "")
            {
                EndGamePanel.Visible = false;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            box.MoveSelection(e.Location);
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            box.IsGameOver = false;
            EndGamePanel.Visible = false;
            this.Controls.Clear();
            WinTextBox.ReadOnly = true;
            Size temp = ClientSize;
            InitializeComponent();
            Focus();
            ClientSize = temp;
            box = new Box(ClientSize);
            canvas.Size = ClientSize;
            mappy = new Bitmap(canvas.Width, canvas.Height);
            gfx = Graphics.FromImage(mappy);
            box.ScreenSize = ClientSize;
            box.IsGameOver = false;
            EndGamePanel.Visible = false;
        }
    }
}