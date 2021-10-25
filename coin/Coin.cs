using PruebaTonta.clasess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


abstract class Coin
{
    protected string NAME = string.Empty;
    protected string PARVALUE = string.Empty;
    protected string URL_CHECK = string.Empty;
    protected string TAG_PRICE = string.Empty;
    private int MAX_VALUES = 1000;

    //
    private List<CoinValue> _values;
    public List<CoinValue> allValues { get { return _values; } }

    private Coin() {
        _values = new List<CoinValue>();
    }

    public Coin(string name) :this()
    {
        this.NAME = name;
        //_values = new List<CoinValue>();
    }

    public CoinValue getValue()
    {

        double res = 0.0;
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL_CHECK + PARVALUE);

            HttpResponseMessage response = new HttpClient().SendAsync(request).Result;
            string msg = response.Content.ReadAsStringAsync().Result;
            res = (double)Newtonsoft.Json.Linq.JObject.Parse(msg)[TAG_PRICE];
        }
        catch (Exception ex)
        {
            throw new Exception("Error recuperando valor '" + PARVALUE + "'", ex);
        }
        _values.Add( new CoinValue(res));
        if (_values.Count > MAX_VALUES) _values.RemoveAt(0);
        analizaDatos();
        return _values.Last();
    }


    protected abstract void analizaDatos();

}

