using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Comanda {
    private string consumo;
    private double valor;
    public string Consumo { get; set }
    public double Valor { get; set }

    public void ListarConsumo() {
        Console.WriteLine(getConsumo);
    }
    public double calcular10porcento() {
        this.valor += this.valor * 0.1;
        return valor;
    }
    public double dividirConta(int numPessoas) {
        double valorPorPessoas = 0;
        valorPorPessoas = this.valor / numPessoas;
        return valorPorPessoas;
    }

}