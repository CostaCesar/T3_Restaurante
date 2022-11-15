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
    public Comanda Conta
    { get; private set; }
    
    public Mesa(int numero, bool podeUsar)
    {
        this.Numero = numero;
        this.PodeSerUsada = podeUsar;
        this.DatasReservadas = new string[0];
        this.UsuariosReservados = new Cliente[0];
        this.Usuarios = new Cliente[0];
        this.Conta = new Comanda("");
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

    public double DividirConta()
    { return this.Conta.DividirConta(this.Usuarios.Length); }

    public double Calcular10pc()
    { return this.Conta.Calcular10pc(); }
    public void Liberar(string data)
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

    public void AdicionarNaComanda(string item, double valor)
    {
        this.Conta.Consumo = String.Concat(this.Conta.Consumo, "\n \t - ");
        this.Conta.Consumo = String.Concat(this.Conta.Consumo, item);
        this.Conta.Valor += valor;
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
            Console.Write("Dados da comanda: ");
            this.Conta.ListarConsumo();
            Console.WriteLine("");
            Console.WriteLine(String.Format(">>> Valor Final: {0:C}", this.Conta.Valor));
        }
        Console.WriteLine("==============================================");
        return;
    }


}