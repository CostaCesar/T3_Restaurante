using System;
using System.Collections.Generic;

public class Mesa
{
    public int Numero
    { get; private set; }
    public bool PodeSerUsada
    { get; set; }
    public string[] DatasReservadas
    { get; private set; }
    public Cliente[] Usuarios
    { get; private set; }
    public Comanda Conta
    { get; private set; }
    
    public Mesa(int numero, bool podeUsar)
    {
        this.Numero = numero;
        this.PodeSerUsada = podeUsar;
        this.DatasReservadas = new string[0];
        Usuarios = new Cliente[0];
        Conta = new Comanda("");
        return;
    }

    public bool Reservar(string data)
    {
        // Testando disponibilidade da mesa
        if(this.PodeSerUsada == false)
        {
            Console.WriteLine("# ESTA MESA NAO ESTA DISPONIVEL PARA RESERVAS #");
            return false;
        }
        if(this.DatasReservadas.Contains(data))
        {
            Console.WriteLine("# ESTA MESA JA ESTA RESERVADA NA DATA " + data + " #");
            return false;
        }
        
        // Reservando...
        string[] novasDatas = new string[DatasReservadas.Length+1];
        DatasReservadas.CopyTo(novasDatas, 0);
        novasDatas[novasDatas.Length-1] = data;
        DatasReservadas = novasDatas;
        Console.WriteLine("$ MESA RESERVADA COM SUCESSO $");
        return true;
    }

    public void Liberar(string data)
    {
        if(this.DatasReservadas.Contains(data))
        {
            int removerEm = Array.IndexOf(this.DatasReservadas, data);
            string[] novasDatas = new string[DatasReservadas.Length-1];
            for(int i = 0; i < removerEm; i++)
                novasDatas[i] = DatasReservadas[i];
            for(int i = removerEm; i < novasDatas.Length; i++)
                novasDatas[i] = DatasReservadas[i+1];
        }
        Console.WriteLine("$ DATA " + data + "REMOVIDA $");
        return;
    }

    public void AdicionarNaComanda(string item, double valor)
    {
        this.Conta.Consumo = String.Concat(this.Conta.Consumo, "\n \t - ");
        this.Conta.Consumo = String.Concat(this.Conta.Consumo, item);
        this.Conta.Valor += valor;
        return;
    }

    public void AdicionarCliente(Cliente adicionado)
    {
        Cliente[] novosClientes = new Cliente[this.Usuarios.Length+1];
        this.Usuarios.CopyTo(novosClientes, 0);
        novosClientes[novosClientes.Length-1] = adicionado;
        Usuarios = novosClientes;
        Console.WriteLine("$ CLIENTE \"" + adicionado.Nome + "\" ADICIONADO COM SUCESSO");
        return;
    }

    public void Info(bool listarConsumo, bool listarClientes, bool listarDatas)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine(String.Format("<< Mesa {0}>>", this.Numero));
        Console.WriteLine("Status: " + (this.PodeSerUsada ? "Operacional" : "Inoperante"));
        if(listarDatas == true)
        {
            Console.WriteLine("Datas Reservadas:");
            foreach(string data in DatasReservadas)
                Console.WriteLine("\t - " + data);
        }
        if(listarClientes == true)
        {
            Console.WriteLine("Clientes na mesa:");
            foreach(Cliente atual in Usuarios)
            {
                Console.WriteLine("\t > Nome: " + atual.Nome);
                Console.WriteLine("\t   Email: " + atual.Email);
            }
        }
        if(listarConsumo == true)
        {
            Console.Write("Dados da comanda: ");
            this.Conta.ListarConsumo();
            Console.WriteLine("");
            Console.WriteLine(String.Format(">>> Valor Final: {0:C}", this.Conta.Valor));
        }
        Console.WriteLine("==============================================");
        return;
    }


}