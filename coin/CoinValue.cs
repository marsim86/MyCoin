using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTonta.clasess
{
    class CoinValue
    {
        private DateTime _date;
        private double _value;
        public CoinValue(double value)
        {
            this._value = value;
            this._date = DateTime.Now;
        }
        public DateTime date { get { return _date; } }
        public double value { get { return _value; } }

        public override string ToString()
        {
            return String.Format("{0:[yyyy-MM-dd HH:mm:ss]}{1:0.0000######}", _date, _value);
        }
    }
}
