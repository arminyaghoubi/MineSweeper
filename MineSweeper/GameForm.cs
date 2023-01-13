using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace MineSweeper
{


    public partial class MineSweeperForm : Form
    {
        public List<MineButton> ListMineButton;
        public List<Classes.Player> WinnerList;
        public MineSweeperForm()
        {
            InitializeComponent();
            WinnerList = new List<Classes.Player>();
        }

        private List<int> MakeMine(int sumMine, int maxNumber)
        {
            List<int> mineNumber = new List<int>();
            Random rnd = new Random();
            while (mineNumber.Count < sumMine)
            {
                int number = rnd.Next(0, maxNumber);
                if (mineNumber.IndexOf(number) < 0)
                    mineNumber.Add(number);
            }
            return mineNumber;
        }

        public void GameOver(MineButton sender)
        {
            if (sender.EndGame == false)
            {
                foreach (var item in ListMineButton)
                    item.EndGame = true;

                NewStartButton.Image = MineSweeper.Properties.Resources.facedevilish32;
                GameTimer.Enabled = false;
                MessageBox.Show("بازی رو باختی!!!", "متاسفم", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                foreach (var item in ListMineButton)
                {
                    if (item.Mine == true)
                    {
                        item.Image = MineSweeper.Properties.Resources.pop;
                        item.Status = MineButton.ButtonMood.Open;
                        item.BackColor = Color.White;
                    }
                    Thread.Sleep(7);
                    Application.DoEvents();
                }
            }
        }

        public void BombAroundMethod(MineButton sender)
        {
            if (GameTimer.Enabled == false)
                GameTimer.Enabled = true;
            Thread.Sleep(1);
            Application.DoEvents();

            if (sender.EndGame == false && sender.Status == MineButton.ButtonMood.Close)
            {
                sender.BackColor = Color.White;
                sender.Status = MineButton.ButtonMood.Open;
                if (sender.RowNumber < 9 && ListMineButton[sender.Number + 1].MineAround == 0 && ListMineButton[sender.Number + 1].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number + 1]);

                if (sender.RowNumber < 9 && ListMineButton[sender.Number + 1].MineAround != 0)
                {
                    ListMineButton[sender.Number + 1].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number + 1].BackColor = Color.White;
                    ListMineButton[sender.Number + 1].Text = ListMineButton[sender.Number + 1].MineAround.ToString();
                }
                if (sender.RowNumber > 1 && ListMineButton[sender.Number - 1].MineAround == 0 && ListMineButton[sender.Number - 1].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number - 1]);

                if (sender.RowNumber > 1 && ListMineButton[sender.Number - 1].MineAround != 0)
                {
                    ListMineButton[sender.Number - 1].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number - 1].BackColor = Color.White;
                    ListMineButton[sender.Number - 1].Text = ListMineButton[sender.Number - 1].MineAround.ToString();
                }
                if (sender.ColumnNumber < 9 && ListMineButton[sender.Number + 9].MineAround == 0 && ListMineButton[sender.Number + 9].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number + 9]);

                if (sender.ColumnNumber < 9 && ListMineButton[sender.Number + 9].MineAround != 0)
                {
                    ListMineButton[sender.Number + 9].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number + 9].BackColor = Color.White;
                    ListMineButton[sender.Number + 9].Text = ListMineButton[sender.Number + 9].MineAround.ToString();
                }
                if (sender.ColumnNumber > 1 && ListMineButton[sender.Number - 9].MineAround == 0 && ListMineButton[sender.Number - 9].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number - 9]);

                if (sender.ColumnNumber > 1 && ListMineButton[sender.Number - 9].MineAround != 0)
                {
                    ListMineButton[sender.Number - 9].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number - 9].BackColor = Color.White;
                    ListMineButton[sender.Number - 9].Text = ListMineButton[sender.Number - 9].MineAround.ToString();
                }
                if (sender.RowNumber < 9 && sender.ColumnNumber > 1 && ListMineButton[sender.Number - 8].MineAround == 0 && ListMineButton[sender.Number - 1].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number - 8]);

                if (sender.RowNumber < 9 && sender.ColumnNumber > 1 && ListMineButton[sender.Number - 8].MineAround != 0)
                {
                    ListMineButton[sender.Number - 8].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number - 8].BackColor = Color.White;
                    ListMineButton[sender.Number - 8].Text = ListMineButton[sender.Number - 8].MineAround.ToString();
                }
                if (sender.RowNumber < 9 && sender.ColumnNumber < 9 && ListMineButton[sender.Number + 10].MineAround == 0 && ListMineButton[sender.Number + 10].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number + 10]);

                if (sender.RowNumber < 9 && sender.ColumnNumber < 9 && ListMineButton[sender.Number + 10].MineAround != 0)
                {
                    ListMineButton[sender.Number + 10].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number + 10].BackColor = Color.White;
                    ListMineButton[sender.Number + 10].Text = ListMineButton[sender.Number + 10].MineAround.ToString();
                }
                if (sender.RowNumber > 1 && sender.ColumnNumber > 1 && ListMineButton[sender.Number - 10].MineAround == 0 && ListMineButton[sender.Number - 10].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number - 10]);

                if (sender.RowNumber > 1 && sender.ColumnNumber > 1 && ListMineButton[sender.Number - 10].MineAround != 0)
                {
                    ListMineButton[sender.Number - 10].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number - 10].BackColor = Color.White;
                    ListMineButton[sender.Number - 10].Text = ListMineButton[sender.Number - 10].MineAround.ToString();
                }
                if (sender.RowNumber > 1 && sender.ColumnNumber < 9 && (ListMineButton[sender.Number + 8].MineAround == 0) && ListMineButton[sender.Number + 8].Mine == false)
                    BombAroundMethod(ListMineButton[sender.Number + 8]);

                if (sender.RowNumber > 1 && sender.ColumnNumber < 9 && (ListMineButton[sender.Number + 8].MineAround != 0))
                {
                    ListMineButton[sender.Number + 8].Status = MineButton.ButtonMood.Open;
                    ListMineButton[sender.Number + 8].BackColor = Color.White;
                    ListMineButton[sender.Number + 8].Text = ListMineButton[sender.Number + 8].MineAround.ToString();
                }
            }
        }

        public int FlagNumber
        {
            get { return int.Parse(FlagLabel.Text); }
            set { FlagLabel.Text = value.ToString(); }
        }

        public void FlagAndUnFlagMethod(MineButton sender)
        {

            if (sender.EndGame == false)
            {
                if (GameTimer.Enabled == false)
                    GameTimer.Enabled = true;
                if (sender.Status == MineButton.ButtonMood.Flag)
                    --FlagNumber;
                if (sender.Status == MineButton.ButtonMood.Close)
                    ++FlagNumber;
            }
            if (FlagNumber == 0)
            {
                int i = 0;
                foreach (var item in ListMineButton)
                {
                    if (item.Status == MineButton.ButtonMood.Flag && item.Mine == true)
                        i++;
                }
                if (i == 10)
                {
                    NewStartButton.Image = MineSweeper.Properties.Resources.facegrin32;
                    GameTimer.Enabled = false;
                    MessageBox.Show("شما بردید", "تبریک", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    WinnerForm frm1 = new WinnerForm();
                    if (frm1.ShowDialog() == DialogResult.OK)
                    {
                        Classes.Player ply = new Classes.Player()
                        {
                            Name = frm1.Name,
                            Record = Time
                        };
                        WinnerList.Add(ply);
                    }

                    BestTimeForm frm2 = new BestTimeForm()
                    {
                        WinnerListBestForm = WinnerList
                    };
                    frm2.Show();
                }
            }
        }

        private void MakeGame(int columnLevel, int rowLevel, int speed, int heightSize, int widthSize, int sumMine)
        {
            NewStartButton.Image = MineSweeper.Properties.Resources.facesmile32;
            Time = 0;
            FlagNumber = 10;
            ListMineButton = new List<MineButton>();
            List<int> mineNumber = MakeMine(sumMine, rowLevel * columnLevel);
            gamePanel.Controls.Clear();
            this.Height = heightSize;
            this.Width = widthSize;
            for (int i = 0; i < columnLevel; i++)
            {
                for (int j = 0; j < rowLevel; j++)
                {
                    MineButton btn = new MineButton();
                    btn.Height = 25;
                    btn.Width = 25;
                    btn.Top = j * 24;
                    btn.Left = i * 24;
                    btn.Number = (i * 9) + (j);
                    btn.RowNumber = j + 1;
                    btn.ColumnNumber = i + 1;
                    if (mineNumber.IndexOf(btn.Number) >= 0)
                        btn.Mine = true;
                    btn.EndGameEvent += GameOver;
                    btn.Click += StartGame;
                    btn.BombAroundEvent += BombAroundMethod;
                    btn.FlagAndUnFlagEvent += FlagAndUnFlagMethod;
                    btn.ClickDownEvent += Btn_ClickDownEvent;
                    btn.MouseUp += Btn_MouseUp;
                    ListMineButton.Add(btn);
                    gamePanel.Controls.Add(btn);
                    Application.DoEvents();
                    Thread.Sleep(speed);
                }
            }


            foreach (var item in ListMineButton)
            {
                if (item.RowNumber < 9 && ListMineButton[item.Number + 1].Mine == true)
                    item.MineAround++;

                if (item.RowNumber > 1 && ListMineButton[item.Number - 1].Mine == true)
                    item.MineAround++;

                if (item.ColumnNumber < 9 && ListMineButton[item.Number + 9].Mine == true)
                    item.MineAround++;

                if (item.ColumnNumber > 1 && ListMineButton[item.Number - 9].Mine == true)
                    item.MineAround++;

                if (item.RowNumber < 9 && item.ColumnNumber > 1 && ListMineButton[item.Number - 8].Mine == true)
                    item.MineAround++;

                if (item.RowNumber < 9 && item.ColumnNumber < 9 && ListMineButton[item.Number + 10].Mine == true)
                    item.MineAround++;

                if (item.RowNumber > 1 && item.ColumnNumber > 1 && ListMineButton[item.Number - 10].Mine == true)
                    item.MineAround++;

                if (item.RowNumber > 1 && item.ColumnNumber < 9 && (ListMineButton[item.Number + 8].Mine == true))
                    item.MineAround++;
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            NewStartButton.Image = MineSweeper.Properties.Resources.facesmile32;
        }

        private void StartGame(object sender, EventArgs e)
        {
            if (Time == 0 && GameTimer.Enabled == false)
                GameTimer.Enabled = true;
        }

        private void Btn_ClickDownEvent()
        {
            NewStartButton.Image = MineSweeper.Properties.Resources.facesurprise32;
        }

        private void MineSweeperForm_Shown(object sender, EventArgs e)
        {
            NewStartButton.Image = MineSweeper.Properties.Resources.facesmile32;
            NewStartButton.BackColor = Color.Silver;
            MakeGame(9, 9, 10, 383, 266, 10);
        }

        private void HowPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPlayGame frm = new AboutPlayGame();
            frm.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutGameForm frm = new AboutGameForm();
            frm.Show();
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeGame(9, 9, 10, 383, 266, 10);
        }

        private void easyLevelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MakeGame(9, 9, 10, 383, 266, 10);
        }

        private void mediumLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeGame(16, 16, 7, 551, 435, 40);
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeGame(30, 16, 5, 551, 771, 99);
        }

        private void bestRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BestTimeForm frm = new BestTimeForm();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void MonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

        public int Time
        {
            get { return int.Parse(TimeLabel.Text); }
            set { TimeLabel.Text = value.ToString(); }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Time++;
        }

        private void NewStartButton_Click(object sender, EventArgs e)
        {
            NewStartButton.Image = MineSweeper.Properties.Resources.facesmile32;
            MakeGame(9, 9, 10, 383, 266, 10);
        }
    }
}
