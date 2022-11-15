using System;

public class Comanda {
    private string _consumo;
    private double _valor;

    public string Consumo
    {
        get { return _consumo;} 
        set { this._consumo = value;}
    }
    public double Valor
    {
        get { return _valor;} 
        set { this._valor = value;}
    }

    public void ListarConsumo() {
        Console.WriteLine(Consumo);
    }
    public double calcular10porcento() {
        this._valor += this._valor * 0.1;
        return _valor;
    }
    public double dividirConta(int numPessoas) {
        double valorPorPessoas = 0;
        valorPorPessoas = this._valor / numPessoas;
        return valorPorPessoas;
    }

    public Comanda(string consumo, double valor)
    {
        this._consumo = consumo;
        this._valor = valor;
    }
}
