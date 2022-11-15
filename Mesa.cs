using System;

public class Mesa
{
    public int Numero
    { get; private set; }
    public bool EstaReservada
    { get; private set; }
    public string? Data
    { 
        get {
            if(Data == null)
                return "00/00/0000";
            else return Data;
        }
        private set{ this.Data = value; }
    }
    public Cliente[] Usuarios
    { get; private set; }
    public Mesa(int numero, bool estaReservada, string data)
    {
        this.Numero = numero;
        this.EstaReservada = estaReservada;
        this.Data = null;
        Usuarios = new Cliente[0];
        return;
    }

    public bool Reservar(string data)
    {
        if(this.EstaReservada == true)
        {
            Console.WriteLine("# ESTA MESA JA ESTA RESERVADA #");
            return false;
        }
        this.EstaReservada = true;
        this.Data = data;
        Console.WriteLine("$ MESA RESERVADA COM SUCESSO $");
        return true;
    }
}