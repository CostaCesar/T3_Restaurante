using System;

public enum ComandaTipo
{
    Bebida,
    Comida
}
public class Comanda {

    public string Consumo
    { get; set; }
    public double Valor
    { get; set; }

    public Comanda( double valor = 0.0)
    {
        this.Consumo = "";
        this.Valor = valor;
    }

    public void ListarConsumo() {
        Console.Write(Consumo);
    }
    public static double Totalcom10pc(double valor) {
        valor += valor * 0.1;
        return valor;
    }
    public static double DividirConta(int numPessoas, double valor) {
        if(numPessoas == 0)
        {
            Console.WriteLine("\t|\t # NUMERO DE PESSOAS INVALIDO #");
            return 0.0;
        }
        double valorPorPessoas = valor / numPessoas;
        return valorPorPessoas;
    }
}
