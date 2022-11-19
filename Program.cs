using System;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        int opção,quantMaxMesa,quantMesa , mesa , indice;
        string data,nomeCliente,emailCliente;
        Console.WriteLine("\t|--------------------------------------------------");
        Console.WriteLine("\t| Bem Vindo ao sistema do Restaurante Caio & Kaio: ");
        Console.Write("\t|\t Digite a data de hoje: ");
        data = Console.ReadLine();
        Console.Write("\t|\t Digite a quantidade de mesas do dia: ");
        quantMaxMesa = int.Parse(Console.ReadLine());
        Restaurante restaurante = new Restaurante("Caio & Kaio" , "Coltec" , quantMaxMesa );
        Console.WriteLine("\t|--------------------------------------------------");
        Console.WriteLine("\t| Bem vindo ao restaurante Caio & Kaio");
        do
        {
            Console.WriteLine("\t|\t Digite a opção desejada:     ");
            Console.WriteLine("\t|\t Reservar mesa            -> 1");
            Console.WriteLine("\t|\t Adicionar cliente a mesa -> 2");
            Console.WriteLine("\t|\t Remover cliente          -> 3");
            Console.WriteLine("\t|\t Fazer pedido             -> 4");
            Console.WriteLine("\t|\t 10% garçom com total     -> 5");
            Console.WriteLine("\t|\t Fechar conta             -> 0");
            Console.Write("\t|\t\t Digite a opção: ");
            opção = int.Parse(Console.ReadLine());
            Console.WriteLine("\t|--------------------------------------------------");
            switch (opção)
            {
                case 1:
                    {
                        Console.Write("\t|\t Nome do cliente: ");
                        nomeCliente = Console.ReadLine();
                        Console.Write("\t|\t Email cliente: ");
                        emailCliente = Console.ReadLine();
                        Console.Write("\t|\t Digite a mesa que sera reservada: ");
                        mesa = int.Parse(Console.ReadLine());
                        Cliente cliente = new Cliente(nomeCliente, emailCliente);
                        if (restaurante.ReservarMesa(mesa - 1, data, ref cliente) == true) { 
                            restaurante.Mesas[mesa - 1].AdicionarCliente(cliente);
                        }
                        Console.WriteLine("\t|--------------------------------------------------");
                        break;
                    }
                case 2:
                    {
                        Console.Write("\t|\t Nome do cliente: ");
                        nomeCliente = Console.ReadLine();
                        Console.Write("\t|\t Email cliente: ");
                        emailCliente = Console.ReadLine();
                        Console.Write("\t|\t Digite a mesa que adicionado: ");
                        mesa = int.Parse(Console.ReadLine());
                        Cliente cliente = new Cliente(nomeCliente, emailCliente);
                        if (restaurante.Mesas[mesa - 1].Reservada != true)
                        {
                            Console.WriteLine("\t|\t Mesa não reservada ");
                        }
                        else
                        {
                            restaurante.Mesas[mesa - 1].AdicionarCliente(cliente);
                        }
                        Console.WriteLine("\t|--------------------------------------------------");
                        break;
                }
                case 3: 
                    {
                        Console.Write("\t|\t Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        restaurante.Mesas[mesa - 1].ListarClientes();
                        Console.Write("\t|\t O indice do cliente desejado: ");
                        indice = int.Parse(Console.ReadLine());
                        restaurante.Mesas[mesa - 1].RemoverCliente(indice);
                        break; 
                    }
                case 4:
                    {
                        int mesaE, quantidade, buffer, tipo;
                        string item;
                        double valor;
                        Console.Write("\t|\t Digite a mesa desejada: ");
                        mesaE = int.Parse(Console.ReadLine());
                        Console.Write("\t|\t Digite o item desejado: ");
                        item = Console.ReadLine();
                        Console.Write("\t|\t Digite o valor do item: ");
                        valor = double.Parse(Console.ReadLine());
                        Console.Write("\t|\t Digite a quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                        Console.Write("\t|\t Digite o tipo desejado \n\t\t1 = comida: \n\t\t0 = bebida: ");
                        tipo = int.Parse(Console.ReadLine());
                        if (tipo == 0)
                        {
                            restaurante.Mesas[mesaE - 1 ].AdicionarNaComanda(ComandaTipo.Bebida, item, valor, quantidade);
                        }
                        else if (tipo == 1)
                        {
                            restaurante.Mesas[mesaE - 1].AdicionarNaComanda(ComandaTipo.Comida, item, valor, quantidade);
                        }
                        else
                        {
                            Console.WriteLine("Item invalido");
                        }
                        Console.WriteLine("\t|--------------------------------------------------");
                        break;
                    }
                case 5: 
                    {
                        double valorc10 , valors10 , valor;
                        Console.Write("\t|\t Digite a mesa: ");
                        mesa = int.Parse(Console.ReadLine());
                        Console.WriteLine("\t|\t O valor dos 10% é " + restaurante.Mesas[mesa - 1].Imprimir10pc());
                        Console.WriteLine("\t|\t Valor total: " + restaurante.Mesas[mesa - 1].ValorFinal());
                        break;
                    }
            }
        } while (opção != 0);
    }
}