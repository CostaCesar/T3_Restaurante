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

    public bool Reservar(string data, ref Cliente reservador)
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
        
        Console.WriteLine("$ MESA RESERVADA COM SUCESSO $");
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
        Console.WriteLine("$ DATA " + data + "REMOVIDA $");
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
            Console.WriteLine("# COMANDA NAO ESPECIFICADA #");
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
        Console.WriteLine("$ Comanda " + this.Numero + " zerada $");
        return;
    }

    public void AdicionarCliente(Cliente adicionado)
    {
        Cliente[] novosClientes = new Cliente[this.Usuarios.Length+1];  // Cria novo vetor 
        this.Usuarios.CopyTo(novosClientes, 0);                         // Copia
        novosClientes[novosClientes.Length-1] = adicionado;             // Adiciona
        Usuarios = novosClientes;                                       // Troca a referencia
        Console.WriteLine("$ CLIENTE \"" + adicionado.Nome + "\" ADICIONADO COM SUCESSO");
        return;
    }

    public void RemoverCliente(int indice)
    {
        if(indice < 0 || indice > Usuarios.Length)
        {
            Console.WriteLine("# CLIENTE INEXISTENTE #");;
            return;
        }
        Cliente[] novosClientes = new Cliente[this.Usuarios.Length-1];  // Cria novo vetor 
        for(int i = 0; i < indice; i++)                                 // Copia
            novosClientes[i] = Usuarios[i];
        for(int i = 0; i < indice; i++)                                 // Retira
            novosClientes[i] = Usuarios[i+1];
        Usuarios = novosClientes;                                       // Troca a referencia
        Console.WriteLine("$ CLIENTE REMOVIDO COM SUCESSO");
        return;
    }

    public double DividirConta()
    { return Comanda.DividirConta(this.Usuarios.Length, this.ContaBebida.Valor + this.ContaComida.Valor); }

    public double ValorFinal()
    { return Comanda.Calcular10pc(this.ContaComida.Valor + this.ContaBebida.Valor); }

    public double ValorFinal_Dividido()
    { return (this.ValorFinal() / this.Usuarios.Length);}

    public void InfoMesa(bool listarConsumo, bool listarClientes, bool listarDatas)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine(String.Format("<< Mesa {0}>>", this.Numero));
        Console.WriteLine("Status: " + (this.PodeSerUsada ? "Operacional" : "Inoperante"));
        if(listarDatas == true) // Mostrar Datas
        {
            Console.WriteLine("Datas Reservadas:");
            for(int i = 0; i < DatasReservadas.Length; i++)
            {
                Console.Write("\t - " + DatasReservadas[i]);
                Console.WriteLine(": " + UsuariosReservados[i].Nome + " (" + UsuariosReservados[i].Email + ")");
            }
        }
        if(listarClientes == true) // Mostrar Clientes
        {
            Console.WriteLine("Clientes na mesa:");
            foreach(Cliente atual in Usuarios)
            {
                Console.WriteLine("\t > Nome: " + atual.Nome);
                Console.WriteLine("\t   Email: " + atual.Email);
            }
        }
        if(listarConsumo == true) // Mostrar Comanda
        {
            Console.WriteLine("Dados da comanda: ");
            Console.Write("Comida: ");
            this.ContaComida.ListarConsumo();
            Console.WriteLine("");
            Console.Write("Bebida: ");
            this.ContaBebida.ListarConsumo();
            Console.WriteLine("");
            Console.WriteLine(String.Format(">>> Valor Total: {0:C}", this.ContaComida.Valor + this.ContaBebida.Valor));
            Console.WriteLine(String.Format(">>> + Taxa de 10%: {0:C}", this.ValorFinal()));
            Console.WriteLine(String.Format(">>> Dividindo por {0}: {1:C}", this.Usuarios.Length, this.ValorFinal_Dividido()));
        }
        Console.WriteLine("==============================================");
        return;
    }


}