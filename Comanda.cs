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

    public Comanda(string consumo, double valor = 0.0)
    {
        this._consumo = consumo;
        this._valor = valor;
    }

    public void ListarConsumo() {
        Console.Write(Consumo);
    }
    public double Calcular10pc() {
        this._valor += this._valor * 0.1;
        return _valor;
    }
    public double DividirConta(int numPessoas) {
        double valorPorPessoas = 0;
        valorPorPessoas = this._valor / numPessoas;
        return valorPorPessoas;
    }
}
