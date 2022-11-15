using System;

public class Comanda {

    public string Consumo
    { get; set; }
    public double Valor
    { get; set; }

    public Comanda(string consumo, double valor = 0.0)
    {
        this.Consumo = consumo;
        this.Valor = valor;
    }

    public void ListarConsumo() {
        Console.Write(Consumo);
    }
    public double Calcular10pc() {
        this.Valor += this.Valor * 0.1;
        return Valor;
    }
    public double DividirConta(int numPessoas) {
        if(numPessoas == 0)
        {
            Console.WriteLine("# NUMERO DE PESSOAS INVALIDO #");
            return 0.0;
        }
        double valorPorPessoas = this.Valor / numPessoas;
        return valorPorPessoas;
    }
}
