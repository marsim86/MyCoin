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

            Root r = null;
            r = (Root)Newtonsoft.Json.JsonConvert.DeserializeObject(strJson, typeof(Root));
            string status2 = r.properties.status;
            //var obj = JObject.Parse(strJson);
            //var res = Newtonsoft.Json.JsonConvert<Root>(strJson);
            //Environment.Exit(0);
            Console.WriteLine(pFile);
            do
            {
                Console.WriteLine("llamada " +  DateTime.Now);
                System.Threading.Thread.Sleep(1500);
            } while (Util.appRunning());
Console.WriteLine("Fuera " +  DateTime.Now);
        }

        //para poder cargar propiedades
        private static void procesaArgs(string[] args)
        {
            if (args == null || args.Length == 0) return;

        }
    }
}
