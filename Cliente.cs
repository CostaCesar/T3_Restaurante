public class Cliente {
    public string Email
    { get; set; }
    public string Nome
    { get; set; }

    public Cliente(string nome, string email)
    {
        this.Nome = nome;
        this.Email = email;
    }
}