public class Cliente {
    private string _nome;
    private string _email;

    public Cliente(string nome, string email)
    {
        this._nome = nome;
        this._email = email;
    }

    public string Nome
    { 
        get {return _nome;}
        set {this._nome = value; }
    }
    public string Email
    { 
        get {return _email;}
        set {this._email = value; }
    }
}