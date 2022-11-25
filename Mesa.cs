using System;
using System.Collections.Generic;

public class Mesa
{
    public int Numero
    { get; private set; }
    public string Data
    { get; private set;}
    public bool Reservada
    { get; set; }
    public Cliente[] Usuarios
    { get; private set; }
    public Comanda ContaComida
    { get; private set; }
    public Comanda ContaBebida
    { get; private set; }
    public Mesa(int numero)
    {
        this.Numero = numero;
        this.Data = "";
        this.Usuarios = new Cliente[0];
        this.ContaComida = new Comanda();
        this.ContaBebida = new Comanda();
        return;
    }
    private const string T = "\t|\t";

    public bool Reservar(string data, ref Cliente reservador)
    {
        // Testando disponibilidade da mesa
        if(this.Reservada == true)
        {
            Console.WriteLine(T + " # ESTA MESA JA ESTA RESERVADA #");
            this.Reservada = true;
            return false;
        }
        
        Console.WriteLine(T + " $ MESA RESERVADA COM SUCESSO $");
        this.Reservada = true;
        this.Data = data;
        return true;
    }
    public void LiberarReserva()
    {
        if(this.Reservada == true)
        {
            this.Reservada = false;
            this.ZerarComanda();
            Console.WriteLine(T + " $ DATA REMOVIDA $");
        }
        return;
    }

    public void AdicionarNaComanda(ComandaTipo comanda, string item, double valor, int quantidade)
    {
        Comanda interno;
        if(comanda == ComandaTipo.Comida)
            interno = ContaComida;
        else if(comanda == ComandaTipo.Bebida)
            interno = ContaBebida;
        else
        {
            Console.WriteLine("T +  # COMANDA NAO ESPECIFICADA #");
            return;
        }
        interno.Consumo = String.Concat(interno.Consumo, "\n \t - ");
        interno.Consumo = String.Concat(interno.Consumo, quantidade);
        interno.Consumo = String.Concat(interno.Consumo, " ");
        interno.Consumo = String.Concat(interno.Consumo, item);
        interno.Valor += (valor * quantidade);
        return;
    }
    public void ZerarComanda()
    {
        this.ContaBebida.Consumo = "";
        this.ContaBebida.Valor = 0.0;
        this.ContaComida.Consumo = "";
        this.ContaComida.Valor = 0.0;
        Console.WriteLine(T + " $ Comanda " + this.Numero + " zerada $");
        return;
    }

    public void AdicionarCliente(Cliente adicionado)
    {
        Cliente[] novosClientes = new Cliente[this.Usuarios.Length+1];  // Cria novo vetor 
        this.Usuarios.CopyTo(novosClientes, 0);                         // Copia
        novosClientes[novosClientes.Length-1] = adicionado;             // Adiciona
        Usuarios = novosClientes;                                       // Troca a referencia
        Console.WriteLine(T + " $ CLIENTE \"" + adicionado.Nome + "\" ADICIONADO COM SUCESSO");
        return;
    }

    public void RemoverCliente(int indice)
    {
        if(indice < 0 || indice > Usuarios.Length)
        {
            Console.WriteLine(T + " # CLIENTE INEXISTENTE #");;
            return;
        }
        Cliente[] novosClientes = new Cliente[this.Usuarios.Length-1];  // Cria novo vetor 
        for(int i = 0; i < indice; i++)                                 // Copia
            novosClientes[i] = Usuarios[i];
        for(int i = indice; i < novosClientes.Length; i++)              // Retira
            novosClientes[i] = Usuarios[i+1];
        Usuarios = novosClientes;                                       // Troca a referencia
        Console.WriteLine(T + " $ CLIENTE REMOVIDO COM SUCESSO");
        return;
    }
    public void ListarClientes() {
        for (int i = 0; i < Usuarios.Length; i++)
        {
            Console.WriteLine(T + " Nome:" + Usuarios[i].Nome);
            Console.WriteLine(T + " Email:" + Usuarios[i].Email);
            Console.WriteLine(T + " Indice = " + i );

        }

    }
    public double DividirConta()
    { return Comanda.DividirConta(this.Usuarios.Length, this.ContaBebida.Valor + this.ContaComida.Valor); }

    public double ValorFinal()
    { return Comanda.Totalcom10pc(this.ContaComida.Valor + this.ContaBebida.Valor); }
    public double Imprimir10pc() {
        double valor10;
        valor10 = this.ContaComida.Valor + this.ContaBebida.Valor;
        valor10 = valor10 * 0.1;
        return valor10;
        
    }
    public double ValorFinal_Dividido()
    { return (this.ValorFinal() / this.Usuarios.Length);}

    public void InfoMesa(bool listarConsumo, bool listarClientes)
    {
        Console.WriteLine(T + String.Format(" << Mesa {0}>>", this.Numero + 1));
        Console.WriteLine(T + " Reservada: " + (this.Reservada ? "Sim, " + this.Data : "Nao"));

        if(listarClientes == true) // Mostrar Clientes
        {
            Console.WriteLine(T + " Clientes na mesa:");
            foreach(Cliente atual in Usuarios)
            {
                Console.WriteLine(T + "  > Nome: " + atual.Nome);
                Console.WriteLine(T + "  > Email: " + atual.Email);
            }
        }
        if(listarConsumo == true) // Mostrar Comanda
        {
            Console.WriteLine(T + " Dados da comanda: ");
            Console.Write(T + " Comida: ");
            Console.Write(T);
            this.ContaComida.ListarConsumo();
            Console.WriteLine("");
            Console.Write(T + " Bebida: ");
            Console.Write(T);
            this.ContaBebida.ListarConsumo();
            Console.WriteLine("");
            Console.WriteLine(String.Format(T + " >>> Valor Total: {0:C}", this.ContaComida.Valor + this.ContaBebida.Valor));
            Console.WriteLine(String.Format(T + " >>> Taxa de 10%: {0:C}", this.Imprimir10pc()));
            Console.WriteLine(String.Format(T + " >>> Valor total + Taxa de 10%: {0:C}", this.ValorFinal()));
            Console.WriteLine(String.Format(T + " >>> Dividindo por {0}: {1:C}", this.Usuarios.Length, this.ValorFinal_Dividido()));
        }
        return;
    }


}