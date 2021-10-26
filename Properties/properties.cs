using System.Collections.Generic;
public class Properties
{
    public string status { get; set; }
    public int frecuency { get; set; }
}

public class Item
{
    public string coinid { get; set; }
    public string par { get; set; }
    public string history { get; set; }
    public int previous_days { get; set; }
    public int wallet { get; set; }
    public int record { get; set; }
    public int trade { get; set; }
    public int simulate { get; set; }
    public int active { get; set; }
}

public class Wallet
{
    public int id { get; set; }
    public string coin { get; set; }
    public double value { get; set; }
}

public class Root
{
    public Properties properties { get; set; }
    public List<Item> items { get; set; }
    public List<Wallet> wallets { get; set; }
}