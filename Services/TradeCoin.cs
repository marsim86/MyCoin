// Crea un trade de una moneda
// Contiene el lector de una moneda
// y el tradding del mismo
class TradeCoin
{

    //ID IDENTIFICATIVO DE LA MONEDA
    private string ID = string.Empty;
    private bool SIMULADO = false;//msimon


    public TradeCoin(string id, int diasHistorico,bool simulado = false)
    {
        this.ID = id;
        this.SIMULADO = simulado;
    }

    public void start(){
        
    }
}
