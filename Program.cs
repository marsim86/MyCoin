using System;
using System.IO;

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

            Console.WriteLine(pFile);
            do
            {
                Console.WriteLine("llamada");
                System.Threading.Thread.Sleep(1500);
            } while ("ON".Equals(Util.getValueFile(pFile, "properties.status")));

        }

        //para poder cargar propiedades
        private static void procesaArgs(string[] args)
        {
            if (args == null || args.Length == 0) return;

        }
    }
}
