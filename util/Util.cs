using System;
using System.IO;
using Newtonsoft.Json;

public static class Util
{

    public static string getValueFile(string file, string key)
    {
        string res = string.Empty;
        try
        {
            string strFile = File.ReadAllText(file);
            res =  getValueString(strFile, key);
        }
        catch (Exception ex)
        {
            Logger.e("No se ha podido recuperar la propiedad  " + key  + " del fichero" + file);
            Logger.e("Error:" + ex.Message, ex);
        }
        return res;
    }
    public static string getValueString(string str, string key)
    {
        
        if (key.StartsWith ("1")) return "OFF";
        else return "ON";
    }

}