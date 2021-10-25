using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace PRUEBA3
{
    class Program
    {
        private static string folder = string.Empty;
        private static string propsFile = string.Empty;
        static void Main(string[] args)
        {
            procesaArgs(args);

            if (string.IsNullOrEmpty(folder)) folder = System.IO.Directory.GetCurrentDirectory();
            if (string.IsNullOrEmpty(propsFile)) propsFile = System.AppDomain.CurrentDomain.FriendlyName + ".json";

            string pFile = folder + "\\" + propsFile;

            if (!File.Exists(pFile))
            {
                Console.WriteLine("NO Existe fichero");
                Environment.Exit(-1);
            }
            Util.pathRoot(pFile);
            string strJson = File.ReadAllText(pFile);

            Root r = (Root)Newtonsoft.Json.JsonConvert.DeserializeObject(strJson, typeof(Root));
            //aqui lee los ficheros a cargar


            //int segFrecuency = 5;

            //Util.waitToExactSecond(segFrecuency);
            //Console.WriteLine("oleeee");


            //for (int i = 0; i < 2; i++)
            //{
            //    DateTime dt = DateTime.Now;
            //    Console.WriteLine("dt=" + dt.ToString("HH:mm:ss.fff"));
            //    System.Threading.Thread.Sleep(segFrecuency * 1000);
            //}
            Environment.Exit (0);

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
}
