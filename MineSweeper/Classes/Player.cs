using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Classes
{
    public class Player
    {
        public Player()
        {
            _recordDate = DateTime.Now;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _record;
        public int Record
        {
            get { return _record; }
            set { _record = value; }
        }
        private DateTime _recordDate;
        public DateTime RecordDate
        {
            get { return _recordDate; }
        }
    }
}
