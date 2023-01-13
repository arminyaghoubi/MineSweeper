using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MineSweeper
{


    public partial class MineButton : Button
    {
        #region NestedType
        public enum ButtonMood
        {
            Close,
            Open,
            Flag
        }

        public MineButton()
        {
            InitializeComponent();
            _mine = false;
        }
        #endregion

        #region Property

        private bool _mine;
        public bool Mine
        {
            get { return _mine; }
            set { _mine = value; }
        }

        private byte _mineAround;
        public byte MineAround
        {
            get { return _mineAround; }
            set { _mineAround = value; }
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private ButtonMood _status;
        public ButtonMood Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _rowNumber;

        public int RowNumber
        {
            get { return _rowNumber; }
            set { _rowNumber = value; }
        }

        private int _columnNumber;

        public int ColumnNumber
        {
            get { return _columnNumber; }
            set { _columnNumber = value; }
        }

        private bool _endGame;

        public bool EndGame
        {
            get { return _endGame; }
            set { _endGame = value; }
        }


        #endregion

        #region Method
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            this.BackColor = Color.DarkRed;
            this.FlatStyle = FlatStyle.Flat;
            this.MouseEnter += MouseEnter_Method;
            this.MouseLeave += MouseLeave_Method;
            this.MouseUp += RightClick_Method;
            this.MouseDown += MouseDown_Method;
            this._mineAround = 0;
            this._status = ButtonMood.Close;
            this.Cursor = Cursors.Hand;
            this._endGame = false;
        }

        private void MouseDown_Method(object sender, MouseEventArgs e)
        {
            if (_endGame == false)
            {
                ClickDownEvent();
            }
        }

        internal void RightClick_Method(object sender, MouseEventArgs e)
        {
            if (_endGame == false)
            {
                if (e.Button == MouseButtons.Right)
                {
                    switch (_status)
                    {
                        case ButtonMood.Close:
                            this.Image = MineSweeper.Properties.Resources.flag;
                            this._status = ButtonMood.Flag;
                            FlagAndUnFlagEvent((MineButton)sender);
                            break;
                        case ButtonMood.Flag:
                            this.Image = null;
                            this._status = ButtonMood.Close;
                            FlagAndUnFlagEvent((MineButton)sender);
                            break;
                    }
                }

                if (e.Button == MouseButtons.Left)
                {
                    this.BackColor = Color.White;
                    if (this.Mine == true)
                    {
                        if (EndGameEvent != null)
                            EndGameEvent((MineButton)sender);
                    }
                    else
                    {
                        if (this._status == ButtonMood.Close)
                            if (this._mineAround > 0)
                                this.Text = _mineAround.ToString();
                        if (this._mineAround == 0)
                            BombAroundEvent((MineButton)sender);
                            
                    }
                    this._status = ButtonMood.Open;
                }
            }
        }
        private void MouseEnter_Method(object sender, EventArgs e)
        {
            if (this._status != ButtonMood.Open)
                this.BackColor = Color.Red;
        }
        private void MouseLeave_Method(object sender, EventArgs e)
        {
            if (this._status != ButtonMood.Open)
                this.BackColor = Color.DarkRed;
        }
        #endregion
        #region Event
        public delegate void EndGameHandler(MineButton sender);
        public event EndGameHandler EndGameEvent;

        public delegate void BombAroundHandler(MineButton sender);
        public event BombAroundHandler BombAroundEvent;

        public delegate void FlagAndUnFlagHandler(MineButton sender);
        public event FlagAndUnFlagHandler FlagAndUnFlagEvent;

        public delegate void ClickDownHandler();
        public event ClickDownHandler ClickDownEvent;
        #endregion

    }
}
