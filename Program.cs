using System;
using System.Security.Cryptography;

public class Program
{
    private const string Line = "\t|--------------------------------------------------";
    private const string T = "\t|\t" ;
    public static void Main()
    {
        int opção,quantMaxMesa , mesa , indice ,quantidade, tipo;
        string data,nomeCliente,emailCliente;
        Console.WriteLine(Line);
        Console.WriteLine("\t| Bem Vindo ao sistema do Restaurante Caio & Kaio: ");
        Console.Write(T + " Digite a data de hoje: ");
        data = Console.ReadLine();
        Console.Write(T + " Digite a quantidade de mesas do dia: ");
        quantMaxMesa = int.Parse(Console.ReadLine());
        Restaurante restaurante = new Restaurante("Caio & Kaio" , "Coltec" , quantMaxMesa );
        Console.WriteLine(Line);
        Console.WriteLine("\t| Bem vindo ao restaurante Caio & Kaio");
        do
        {
            Console.WriteLine(T + " Digite a opção desejada:     ");
            Console.WriteLine(T + " Reservar mesa            -> 1");
            Console.WriteLine(T + " Mesa disponives          -> 2");
            Console.WriteLine(T + " Adicionar cliente a mesa -> 3");
            Console.WriteLine(T + " Remover cliente          -> 4");
            Console.WriteLine(T + " Fazer pedido             -> 5");
            Console.WriteLine(T + " 10% garçom com total     -> 6");
            Console.WriteLine(T + " Dividir conta            -> 7");
            Console.WriteLine(T + " Imformação geral mesa    -> 8");
            Console.WriteLine(T + " Fechar conta             -> 9");
            Console.WriteLine(T + " Fechar sistema           -> 0");
            Console.Write(T + " Digite a opção: ");
            opção = int.Parse(Console.ReadLine());
            Console.WriteLine(Line);
            switch (opção)
            {
                case 1:
                    {
                        Console.Write(T + " Nome do cliente: ");
                        nomeCliente = Console.ReadLine();
                        Console.Write(T + " Email cliente: ");
                        emailCliente = Console.ReadLine();
                        Console.Write(T + " Digite a mesa que sera reservada: ");
                        mesa = int.Parse(Console.ReadLine());
                        Cliente cliente = new Cliente(nomeCliente, emailCliente);
                        if (restaurante.ReservarMesa(mesa - 1, data, ref cliente) == true) { 
                            restaurante.Mesas[mesa - 1].AdicionarCliente(cliente);
                        }
                        Console.WriteLine(Line);
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < quantMaxMesa ; i++) 
                        {
                            if (restaurante.Mesas[i].Reservada == false)
                            {

                                Console.WriteLine(T + " Mesa {0} disponivel" , i + 1);
                            }
                            else 
                            {
                                Console.WriteLine(T + " Mesa {0} indisponivel" , i + 1);
                            }
                        
                        }
                        Console.WriteLine(Line);    
                        break; 
                    }
                case 3:
                    {
                        Console.Write(T + " Nome do cliente: ");
                        nomeCliente = Console.ReadLine();
                        Console.Write(T + " Email cliente: ");
                        emailCliente = Console.ReadLine();
                        Console.Write(T + " Digite a mesa que adicionado: ");
                        mesa = int.Parse(Console.ReadLine());
                        Cliente cliente = new Cliente(nomeCliente, emailCliente);
                        if (restaurante.Mesas[mesa - 1].Reservada != true)
                        {
                            Console.WriteLine(T + " Mesa não reservada ");
                        }
                        else
                        {
                            restaurante.Mesas[mesa - 1].AdicionarCliente(cliente);
                        }
                        Console.WriteLine(Line);
                        break;
                }
                case 4: 
                    {
                        Console.Write(T + " Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        restaurante.Mesas[mesa - 1].ListarClientes();
                        Console.Write(T + " O indice do cliente desejado: ");
                        indice = int.Parse(Console.ReadLine());
                        restaurante.Mesas[mesa - 1].RemoverCliente(indice);
                        break; 
                    }
                case 5:
                    {
                        string item;
                        double valor;
                        Console.Write(T + " Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        Console.Write(T + " Digite o item desejado: ");
                        item = Console.ReadLine();
                        Console.Write(T + " Digite o valor do item: $");
                        valor = double.Parse(Console.ReadLine());
                        Console.Write(T + " Digite a quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                        Console.Write(T + " Digite o tipo desejado\n" + T + " 1 = comida:\n" + T + " 0 = bebida:\n" + T + " Digite: ");
                        tipo = int.Parse(Console.ReadLine());
                        if (tipo == 0)
                        {
                            restaurante.Mesas[mesa - 1 ].AdicionarNaComanda(ComandaTipo.Bebida, item, valor, quantidade);
                        }
                        else if (tipo == 1)
                        {
                            restaurante.Mesas[mesa - 1].AdicionarNaComanda(ComandaTipo.Comida, item, valor, quantidade);
                        }
                        else
                        {
                            Console.WriteLine(T + " Item invalido ");
                        }
                        Console.WriteLine(Line);
                        break;
                    }
                case 6: 
                    {
                        Console.Write(T + " Digite a mesa: ");
                        mesa = int.Parse(Console.ReadLine());
                        Console.WriteLine(T + " O valor dos 10% é : $" + restaurante.Mesas[mesa - 1].Imprimir10pc());
                        Console.WriteLine(T + " Valor total c/10% : $" + restaurante.Mesas[mesa - 1].ValorFinal());
                        Console.WriteLine(T + " Valor total s/10% : ${0}" , restaurante.Mesas[mesa - 1].ValorFinal() - restaurante.Mesas[mesa - 1].Imprimir10pc());
                        break;
                    }
                case 7:
                    {
                        Console.Write(T + " Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        Console.WriteLine(T + " O valor ficou em por pessoa: $" + restaurante.Mesas[mesa - 1].ValorFinal_Dividido());
                        break;
                    }
                case 8: 
                    {
                        Console.Write(T + " Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        if (restaurante.Mesas[mesa - 1].Reservada == false)
                        {
                            Console.WriteLine(T + " Mesa vazia");
                        }
                        else if (restaurante.Mesas[mesa - 1].Reservada == true)
                        {
                            restaurante.Mesas[mesa - 1].InfoMesa(true , true ,true);
                        }
                        Console.WriteLine(Line);
                        break;
                    }
                case 9:
                    {
                        Console.Write(T + " Digite a mesa desejada: ");
                        mesa = int.Parse(Console.ReadLine());
                        if (restaurante.Mesas[mesa - 1].Reservada == false)
                        {
                            Console.WriteLine(T + " Mesa vazia");
                        }
                        else if (restaurante.Mesas[mesa - 1].Reservada == true)
                        {
                            restaurante.Mesas[mesa - 1].InfoMesa(true, true, true);
                        }
                        restaurante.Mesas[mesa - 1].ZerarComanda();
                        restaurante.Mesas[mesa - 1].LiberarReserva(data);
                        break; 
                    }
                case 0: 
                    {
                        Console.WriteLine(T + " Bom fim de espediente");
                        Console.WriteLine(Line);
                        break;
                    }
            }
        } while (opção != 0);
    }
}