using System;
public class Program
{
    public static void Main()
    {
         
        int opção , quantMaxMesa = 10 , quantMesa = 0;
        Restaurante restaurante = new Restaurante("Caio & Kaio" , "Coltec" , quantMaxMesa );
        Console.WriteLine("\t Bem vindo ao restaurante Caio & Kaio");
        do
        {
            Console.WriteLine("\t\t Digite a opção desejada: ");
            Console.WriteLine("\t\t\t Reservar mesa 1");
            Console.WriteLine("\t\t\t Fazer pedido 2");
            Console.WriteLine("\t\t\t Fechar conta 0");
            opção = int.Parse(Console.ReadLine()); 
            switch (opção)
            {
                case 1:
                    string data , nomeCliente , emailCliente;
                    Console.WriteLine("\t\t Digite a data desejada");
                    data = Console.ReadLine();
                    Console.WriteLine("\t\t Nome do cliente");
                    nomeCliente = Console.ReadLine();
                    Console.WriteLine("\t\t Email cliente");
                    emailCliente = Console.ReadLine();
                     Cliente cliente = new Cliente(nomeCliente , emailCliente);
                    restaurante.ReservarMesa(quantMesa , data , ref cliente);
                    quantMesa++;
                break;
                case 2:
                    int mesaE , quantidade , buffer , tipo;
                    string item  ;
                    double valor;
                    Console.WriteLine("\t\t Digite a mesa desejada");
                    mesaE = int.Parse(Console.ReadLine());
                    Console.WriteLine("\t\t Digite o item desejado");
                    item = Console.ReadLine();
                    Console.WriteLine("\t\t Digite o valor do item");
                    valor = double.Parse(Console.ReadLine());
                    Console.WriteLine("\t\t Digite a quantidade");
                    quantidade = int.Parse(Console.ReadLine());
                    Console.WriteLine("\t\t Digite o tipo desejado \n\t\t1 = comida\n\t\t0 = bebida");
                    tipo = int.Parse(Console.ReadLine());
                    if (tipo == 0)
                    {
                        restaurante.Mesas[mesaE].AdicionarNaComanda(ComandaTipo.Bebida, item, valor, quantidade);
                    }
                    else if (tipo == 1)
                    {
                        restaurante.Mesas[mesaE].AdicionarNaComanda(ComandaTipo.Comida, item, valor, quantidade);
                    }
                    else
                    {
                        Console.WriteLine("Item invalido");
                    }
                    break;
            }
        } while (opção != 0);
    }
}