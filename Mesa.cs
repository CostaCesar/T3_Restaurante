using System;
using System.Collections.Generic;

public class Mesa
{
    public int Numero
    { get; private set; }
    public bool PodeSerUsada
    { get; set; }
    public bool Reservada
    { get; set; }
    public string[] DatasReservadas
    { get; private set; }
    public Cliente[] UsuariosReservados
    { get; private set; }
    public Cliente[] Usuarios
    { get; private set; }
    public Comanda ContaComida
    { get; private set; }
    public Comanda ContaBebida
    { get; private set; }
    public Mesa(int numero, bool podeUsar)
    {
        this.Numero = numero;
        this.PodeSerUsada = podeUsar;
        this.DatasReservadas = new string[0];
        this.UsuariosReservados = new Cliente[0];
        this.Usuarios = new Cliente[0];
        this.ContaComida = new Comanda();
        this.ContaBebida = new Comanda();
        return;
    }
    private const string T = "\t|\t";

    public bool Reservar(string data, ref Cliente reservador)
    {
        // Testando disponibilidade da mesa
        if(this.PodeSerUsada == false)
        {
            Console.WriteLine(T + " # ESTA MESA NAO ESTA DISPONIVEL PARA RESERVAS #");
            this.Reservada = true;
            return false;
        }
        if(this.DatasReservadas.Contains(data))
        {
            Console.WriteLine(T + " # ESTA MESA JA ESTA RESERVADA NA DATA " + data + " #");
            this.Reservada = true;
            return false;
        }
        
        // Reservando datas...
        string[] novasDatas = new string[DatasReservadas.Length+1];
        DatasReservadas.CopyTo(novasDatas, 0);
        novasDatas[novasDatas.Length-1] = data;
        DatasReservadas = novasDatas;
        
        // Reservando usuarios...
        Cliente[] novosUsuarios = new Cliente[UsuariosReservados.Length+1];
        UsuariosReservados.CopyTo(novosUsuarios, 0);
        novosUsuarios[novosUsuarios.Length-1] = reservador;
        UsuariosReservados = novosUsuarios;
        
        Console.WriteLine(T + " $ MESA RESERVADA COM SUCESSO $");
        this.Reservada = true;
        return true;
    }
    public void LiberarReserva(string data)
    {
        if(this.DatasReservadas.Contains(data))
        {
            int removerEm = Array.IndexOf(this.DatasReservadas, data);
            string[] novasDatas = new string[DatasReservadas.Length-1];
            Cliente[] novosUsuarios = new Cliente[UsuariosReservados.Length-1];
            for(int i = 0; i < removerEm; i++)
            {
                novasDatas[i] = DatasReservadas[i];
                novosUsuarios[i] = UsuariosReservados[i];
            }
            for(int i = removerEm; i < novasDatas.Length; i++)
            {
                novasDatas[i] = DatasReservadas[i+1];
                novosUsuarios[i] = UsuariosReservados[i+1];
            }
        }
        Console.WriteLine(T + " $ DATA " + data + " REMOVIDA $");
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

    public void InfoMesa(bool listarConsumo, bool listarClientes, bool listarDatas)
    {
        Console.WriteLine(T + String.Format(" << Mesa {0}>>", this.Numero + 1));
        Console.WriteLine(T + " Status: " + (this.PodeSerUsada ? "Operacional" : "Inoperante"));
        if(listarDatas == true) // Mostrar Datas
        {
            Console.WriteLine(T + " Datas Reservadas:");
            for(int i = 0; i < DatasReservadas.Length; i++)
            {
                Console.Write(T + " -" + DatasReservadas[i]);
                Console.WriteLine(
                    " : " + UsuariosReservados[i].Nome + " (" + UsuariosReservados[i].Email + ")");
            }
        }
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