namespace PrimeiraApi.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new()
                {
                    new Pessoa(id: Guid.NewGuid(), nome: "Neymar"),
                    new Pessoa(id: Guid.NewGuid(), nome: "Cristiano"),
                    new Pessoa(id: Guid.NewGuid(), nome: "Messi")
                };

        public static void MapPessoasRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () => Pessoas);
            app.MapGet(pattern: "/pessoas/id/{id}", handler: (Guid id) => Pessoas.Find(x => x.Id == id));
            app.MapGet(pattern: "/pessoas/nome/{nome}", handler: (string nome) => Pessoas.Find(x => x.Nome == nome));

           
            app.MapPost(pattern: "/pessoas", handler: (Pessoa pessoa) =>
            {
                if (pessoa.Nome != "Lucas")
                {
                    return Results.BadRequest(error:new {  message = "Erro pq não é Lucas" });
                }
                Pessoas.Add(pessoa);
                return Results.Ok(pessoa);
            });


            app.MapPut(pattern: "/pessoas/{id}", handler: (Guid id, Pessoa pessoa) =>
            {
                var index = Pessoas.FindIndex(x => x.Id == id);
                if (index < 0)
                {
                    return Results.NotFound();
                }
                Pessoas[index] = pessoa;
                return Results.Ok(pessoa);
            });
            
        }
    }
    
}

