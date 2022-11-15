using System;

public class Restaurante
{
    public string Nome
    { get; set; }
    public string Enderec
    { get; set; }
    public Mesa[] Mesas
    { get; private set; }

    public Restaurante(string nome, string enderec, int nMesas)
    {
        this.Nome = nome;
        this.Enderec = enderec;
        if(nMesas < 1)
            Mesas = new Mesa[1];
        else Mesas = new Mesa[nMesas];
        for(int i = 0; i < nMesas; i++)
            Mesas[i] = new Mesa(i, true);
    }
    
    public bool ReservarMesa(int nMesa, string data, ref Cliente reservando)
    {
        if(nMesa < 0 || nMesa >= Mesas.Length)
        {
            Console.WriteLine("# NUMERO DA MESA INEXISTENTE #");
            return false;
        }
        if(reservando == null)
        {
            Console.WriteLine("# CLIENTE NAO EXISTENTE #");
            return false;
        }
        return Mesas[nMesa].Reservar(data, ref reservando);
    }
}