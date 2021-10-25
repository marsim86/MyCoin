using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Util
{

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

}