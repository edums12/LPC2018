namespace ContaBancaria
{
    public class Cliente
    {
        public int codigo {get; set;}
        public string nome {get; set;}

        public Cliente(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }

        public string exibir()
        {
            return 
                string.Format(
                    "//CLIENTE//\nCódigo: {0}\nNome: {1}\n", 
                    this.codigo.ToString(), 
                    this.nome
                );
        }
    }
}