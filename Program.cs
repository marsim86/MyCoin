using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Coins;


class Program
{
    private static string folder = string.Empty;
    private static string propsFile = string.Empty;
    static void Main(string[] args)
    {
        //Procesa los parámetros de entrada
        procesaArgs(args);
        //Si no se indica otro, se indica el fichero inicial de configuracion (mycoin.json)
        if (string.IsNullOrEmpty(folder)) folder = System.IO.Directory.GetCurrentDirectory();
        if (string.IsNullOrEmpty(propsFile)) propsFile = System.AppDomain.CurrentDomain.FriendlyName + ".json";
        string pFile = folder + "\\" + propsFile;

        if (!File.Exists(pFile))
        {
            Logger.e("NO Existe fichero " + pFile);

            Environment.Exit(-1);
        }
        Util.pathRoot(pFile);
        string strJson = File.ReadAllText(pFile);

        //Monedas a procesar
        Dictionary<string,Coin> d = new Dictionary<string, Coin>();

        Root r = (Root)Newtonsoft.Json.JsonConvert.DeserializeObject(strJson, typeof(Root));

        foreach (Item item in r.items){
            if (item.active == 0) return;
            Coin c = new BinanceCoin (item.coinid);
            voy por aqui
            d.Add (item.coinid,c);
            c.start ();
        }
        //aqui lee los ficheros a cargar

        Coins.Coin bc = new Coins.BinanceCoin("1INCH");

        for (int i = 0; i < 10; i++)
        {
            bc.getValue();
            System.Threading.Thread.Sleep(5000);
        }

        //int segFrecuency = 5;

        //  
        //Console.WriteLine("oleeee");


        //for (int i = 0; i < 2; i++)
        //{
        //    DateTime dt = DateTime.Now;
        //    Console.WriteLine("dt=" + dt.ToString("HH:mm:ss.fff"));
        //    System.Threading.Thread.Sleep(segFrecuency * 1000);
        //}
        Environment.Exit(0);

        //var obj = JObject.Parse(strJson);
        //var res = Newtonsoft.Json.JsonConvert<Root>(strJson);
        //Environment.Exit(0);
        Console.WriteLine(pFile);
        do
        {
            Console.WriteLine("llamada " + DateTime.Now);
            System.Threading.Thread.Sleep(1500);
        } while (Util.appRunning());
        Console.WriteLine("Fuera " + DateTime.Now);
    }

    //para poder cargar propiedades
    private static void procesaArgs(string[] args)
    {
        //TODO
        if (args == null || args.Length == 0) return;

    }
}

