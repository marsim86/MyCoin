using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Util
{

    private static string _pathRoot;
    public static void pathRoot(string pr) { _pathRoot = pr;}
    
    private static Root _root;
    private static DateTime _lastRoot = DateTime.MinValue;

    public static Root getProperties()
    {
        if (_root == null || _lastRoot.AddSeconds(5) < DateTime.Now)
            _root = (Root)Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(_pathRoot), typeof(Root));
        return _root;
    } 

    public static bool appRunning(){
        return "ON".Equals (getProperties().properties.status);
        //return true;
    }

    public static string getValueFile(string file, string key)
    {
        string res = string.Empty;
        try
        {
            string strFile = File.ReadAllText(file);
            res = getValueString(strFile, key);
        }
        catch (Exception ex)
        {
            Logger.e("No se ha podido recuperar la propiedad  " + key + " del fichero" + file);
            Logger.e("Error:" + ex.Message, ex);
        }
        return res;
    }
    public static string getValueString(string str, string key)
    {
        string res = string.Empty;
        try
        {
            if (key.Contains("."))
            {
                JToken jsonT = null;
                string[] keys = key.Split('.');
                JObject json = JObject.Parse(str);
                for (int i = 0; i <= keys.Length - 2; i++)
                {
                    if (i == 0) jsonT = json[keys[keys.Length - 2]];
                    else jsonT = jsonT[keys[keys.Length - 2]];
                }
                res = jsonT[keys[keys.Length - 1]].Value<string>();
            }
            else res = (string)JObject.Parse(str)[key];
        }
        catch { res = string.Empty; }
        return res;
    }

    public static void PrintValues(IEnumerable myCollection)
    {
        foreach (Object obj in myCollection)
            Console.Write("    {0}", obj);
        Console.WriteLine();
    }

    public static void waitToExactSecond(int iSecond){
         while (DateTime.Now.Second % iSecond != 0) System.Threading.Thread.Sleep(100);
    }

}