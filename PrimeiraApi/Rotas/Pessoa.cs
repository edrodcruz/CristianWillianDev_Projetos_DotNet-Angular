using PrimeiraApi.Rotas;

namespace PrimeiraApi.Rotas
{
    public class Pessoa
    { 
        public Guid Id { get; init; }
        public string Nome { get; init; }

        public Pessoa(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    };
    
}