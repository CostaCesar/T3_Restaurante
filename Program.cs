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
                break;
            }
        } while (opção != 0);
    }
}