namespace Connect4
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            canvas = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            EndGamePanel = new Panel();
            WinTextBox = new TextBox();
            NewGame = new Button();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            EndGamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.Location = new Point(1, 1);
            canvas.Margin = new Padding(2, 2, 2, 2);
            canvas.Name = "canvas";
            canvas.Size = new Size(559, 270);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.MouseClick += canvas_MouseClick;
            canvas.MouseMove += canvas_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 17;
            timer1.Tick += timer1_Tick;
            // 
            // EndGamePanel
            // 
            EndGamePanel.Controls.Add(WinTextBox);
            EndGamePanel.Controls.Add(NewGame);
            EndGamePanel.Location = new Point(146, 79);
            EndGamePanel.Margin = new Padding(2, 2, 2, 2);
            EndGamePanel.Name = "EndGamePanel";
            EndGamePanel.Size = new Size(251, 112);
            EndGamePanel.TabIndex = 1;
            // 
            // WinTextBox
            // 
            WinTextBox.Location = new Point(59, 14);
            WinTextBox.Margin = new Padding(2, 2, 2, 2);
            WinTextBox.Name = "WinTextBox";
            WinTextBox.Size = new Size(125, 23);
            WinTextBox.TabIndex = 2;
            WinTextBox.Text = "Tie";
            // 
            // NewGame
            // 
            NewGame.Location = new Point(82, 71);
            NewGame.Margin = new Padding(2, 2, 2, 2);
            NewGame.Name = "NewGame";
            NewGame.Size = new Size(78, 20);
            NewGame.TabIndex = 0;
            NewGame.Text = "New Game";
            NewGame.UseVisualStyleBackColor = true;
            NewGame.Click += NewGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(EndGamePanel);
            Controls.Add(canvas);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            EndGamePanel.ResumeLayout(false);
            EndGamePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox canvas;
        private System.Windows.Forms.Timer timer1;
        private Panel EndGamePanel;
        private TextBox WinTextBox;
        private Button NewGame;
    }
}
