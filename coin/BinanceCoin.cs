using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTonta.clasess
{
    class BinanceCoin : Coin
    {
        public BinanceCoin(string name)
            : base(name)
        {
            this.PARVALUE = "1INCHUSDT";
            this.URL_CHECK = @"https://api.binance.com/api/v3/ticker/price?symbol=";
            this.TAG_PRICE = "price";
        }

        protected override void analizaDatos()
        {
            if (base.allValues.Count < 5) return;
            double max = base.allValues[0].value;
            double min = base.allValues[0].value;
            List<int> tendencias = new List<int>();
            int ten = 0;
            int contaTen = 0;

            for (int i = base.allValues.Count - 1; i > 0; i--)
            {
                double value = base.allValues[i].value;
                double value_1 = base.allValues[i - 1].value;
                min = Math.Min(min, value);
                max = Math.Max(max, value);
                if (ten == 0)//sin tendencia
                {
                    if (value_1 > value) ten = -1;
                    else if (value_1 < value) ten = 1;
                }
                else if (ten > 0)//tendencia positiva
                {
                    if (value_1 > value)
                    {
                        ten = -1;
                        tendencias.Add(contaTen);
                        contaTen = 0;
                    }
                    else if (value_1 < value) contaTen++;
                }
                else //tendencia negativa
                {
                    if (value_1 > value) contaTen++;
                    else if (value_1 < value)
                    {
                        ten = 0;
                        tendencias.Add(-1*contaTen);
                        contaTen = 0;
                    }
                }
            }

            Console.WriteLine ("min=" + min + ";max=" + max);
        }

    }
}
