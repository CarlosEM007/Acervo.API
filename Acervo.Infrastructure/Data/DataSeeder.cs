using Acervo.Domain.Entities;
using Acervo.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!await context.Authors.AnyAsync())
            {

            // --- Authors ---
            var machado  = new Author("Machado de Assis",  "Considerado o maior nome da literatura brasileira, fundador da Academia Brasileira de Letras.", new DateTime(1839, 6, 21, 0, 0, 0, DateTimeKind.Utc));
            var clarice  = new Author("Clarice Lispector",  "Uma das escritoras mais importantes do Brasil, conhecida por sua prosa introspectiva e experimental.", new DateTime(1920, 12, 10, 0, 0, 0, DateTimeKind.Utc));
            var jorge    = new Author("Jorge Amado",        "Autor baiano, um dos mais lidos da literatura brasileira, com obras que retratam a cultura do Nordeste.", new DateTime(1912, 8, 10, 0, 0, 0, DateTimeKind.Utc));
            var paulo    = new Author("Paulo Coelho",       "Escritor carioca, um dos autores brasileiros mais vendidos no mundo, conhecido por O Alquimista.", new DateTime(1947, 8, 24, 0, 0, 0, DateTimeKind.Utc));
            var saramago = new Author("José Saramago",      "Escritor português, vencedor do Prêmio Nobel de Literatura de 1998, conhecido por seu estilo narrativo único.", new DateTime(1922, 11, 16, 0, 0, 0, DateTimeKind.Utc));

            await context.Authors.AddRangeAsync(machado, clarice, jorge, paulo, saramago);
            await context.SaveChangesAsync();

            // --- Categories ---
            var romance     = new Category("Romance");
            var ficcao      = new Category("Ficção");
            var litBrasileira = new Category("Literatura Brasileira");
            var fantasia    = new Category("Fantasia");
            var autoAjuda   = new Category("Autoajuda");

            await context.Categories.AddRangeAsync(romance, ficcao, litBrasileira, fantasia, autoAjuda);
            await context.SaveChangesAsync();

            // --- Publishers ---
            var companhia = new Publisher("Companhia das Letras", "Brasil",    "www.companhiadasletras.com.br");
            var record    = new Publisher("Editora Record",        "Brasil",    "www.record.com.br");
            var rocco     = new Publisher("Editora Rocco",         "Brasil",    "www.rocco.com.br");

            await context.Publishers.AddRangeAsync(companhia, record, rocco);
            await context.SaveChangesAsync();

            // --- Users ---
            var admin = new User("Admin", "admin@acervo.com", BCrypt.Net.BCrypt.HashPassword("Admin@123"));
            var joao  = new User("João Silva", "joao@acervo.com", BCrypt.Net.BCrypt.HashPassword("Joao@123"));

            await context.Users.AddRangeAsync(admin, joao);
            await context.SaveChangesAsync();

            // --- Sellers ---
            var livrariaCultura = new Seller("Livraria Cultura",    "contato@livrariacultura.com.br",  "12.345.678/0001-90", "(11) 3170-4033");
            var saraiva         = new Seller("Saraiva Livraria",    "contato@saraiva.com.br",          "98.765.432/0001-11", "(11) 4003-8000");

            await context.Sellers.AddRangeAsync(livrariaCultura, saraiva);
            await context.SaveChangesAsync();

            // --- Books ---
            var domCasmurro     = new Book("Dom Casmurro",             "Narrado por Bentinho, o romance questiona a fidelidade de Capitu em uma das histórias mais debatidas da literatura brasileira.",  new DateTime(1899, 1, 1, 0, 0, 0, DateTimeKind.Utc),  256, litBrasileira.Id, machado.Id,  companhia.Id);
            var memorias        = new Book("Memórias Póstumas de Brás Cubas", "O defunto autor Brás Cubas narra sua própria vida em um romance inovador e cheio de ironia.",                           new DateTime(1881, 1, 1, 0, 0, 0, DateTimeKind.Utc),  208, romance.Id,       machado.Id,  companhia.Id);
            var apaixao         = new Book("A Paixão Segundo G.H.",    "Uma intensa narrativa de transformação existencial de uma mulher após um episódio perturbador.",                                 new DateTime(1964, 1, 1, 0, 0, 0, DateTimeKind.Utc),  176, ficcao.Id,        clarice.Id,  rocco.Id);
            var horaDaEstrela   = new Book("A Hora da Estrela",        "A trágica história de Macabéa, uma nordestina que tenta sobreviver no Rio de Janeiro.",                                         new DateTime(1977, 1, 1, 0, 0, 0, DateTimeKind.Utc),  88,  litBrasileira.Id, clarice.Id,  rocco.Id);
            var gabriela        = new Book("Gabriela, Cravo e Canela", "Romance que se passa na cidade de Ilhéus, retratando conflitos sociais e culturais do interior baiano.",                         new DateTime(1958, 1, 1, 0, 0, 0, DateTimeKind.Utc),  336, romance.Id,       jorge.Id,    record.Id);
            var capitaes        = new Book("Capitães da Areia",        "A história de meninos abandonados que vivem nas ruas de Salvador e se unem em uma gangue.",                                       new DateTime(1937, 1, 1, 0, 0, 0, DateTimeKind.Utc),  288, litBrasileira.Id, jorge.Id,    record.Id);
            var alquimista      = new Book("O Alquimista",             "A jornada de Santiago, um jovem pastor que parte em busca de um tesouro e descobre o sentido da vida.",                          new DateTime(1988, 1, 1, 0, 0, 0, DateTimeKind.Utc),  208, fantasia.Id,      paulo.Id,    rocco.Id);
            var ensaioSobre     = new Book("Ensaio sobre a Cegueira",  "Uma epidemia de cegueira branca assola uma cidade anônima, expondo o lado mais primitivo da humanidade.",                        new DateTime(1995, 1, 1, 0, 0, 0, DateTimeKind.Utc),  352, ficcao.Id,        saramago.Id, companhia.Id);

            await context.Books.AddRangeAsync(domCasmurro, memorias, apaixao, horaDaEstrela, gabriela, capitaes, alquimista, ensaioSobre);
            await context.SaveChangesAsync();

            // --- Stocks ---
            var stockCultura = new Stock(livrariaCultura.Id);
            var stockSaraiva = new Stock(saraiva.Id);

            await context.Stocks.AddRangeAsync(stockCultura, stockSaraiva);
            await context.SaveChangesAsync();

            // --- StockItems ---
            var stockItems = new List<StockItem>
            {
                new StockItem(stockCultura.Id, domCasmurro.Id,   50, 39.90m),
                new StockItem(stockCultura.Id, memorias.Id,      40, 34.90m),
                new StockItem(stockCultura.Id, apaixao.Id,       30, 44.90m),
                new StockItem(stockCultura.Id, gabriela.Id,      35, 49.90m),
                new StockItem(stockCultura.Id, alquimista.Id,    80, 42.90m),
                new StockItem(stockSaraiva.Id, horaDaEstrela.Id, 25, 29.90m),
                new StockItem(stockSaraiva.Id, capitaes.Id,      20, 37.90m),
                new StockItem(stockSaraiva.Id, ensaioSobre.Id,   15, 54.90m),
                new StockItem(stockSaraiva.Id, alquimista.Id,    60, 42.90m),
                new StockItem(stockSaraiva.Id, gabriela.Id,      18, 49.90m),
            };

            await context.StockItems.AddRangeAsync(stockItems);
            await context.SaveChangesAsync();

            // --- Cart, Favorites, Library (per user) ---
            var cartAdmin  = new Cart(admin.Id);
            var cartJoao   = new Cart(joao.Id);

            await context.Carts.AddRangeAsync(cartAdmin, cartJoao);
            await context.SaveChangesAsync();

            var cartItemAdmin1 = new CartItem(cartAdmin.Id, alquimista.Id,    42.90m, 1);
            var cartItemAdmin2 = new CartItem(cartAdmin.Id, ensaioSobre.Id,   54.90m, 2);
            var cartItemJoao1  = new CartItem(cartJoao.Id,  domCasmurro.Id,   39.90m, 1);
            var cartItemJoao2  = new CartItem(cartJoao.Id,  gabriela.Id,      49.90m, 1);

            await context.CartItems.AddRangeAsync(cartItemAdmin1, cartItemAdmin2, cartItemJoao1, cartItemJoao2);
            await context.SaveChangesAsync();

            var favAdmin = new Favorites(admin.Id);
            var favJoao  = new Favorites(joao.Id);

            await context.Favorites.AddRangeAsync(favAdmin, favJoao);
            await context.SaveChangesAsync();

            var favItemAdmin1 = new FavoritesItem(favAdmin.Id, domCasmurro.Id);
            var favItemAdmin2 = new FavoritesItem(favAdmin.Id, gabriela.Id);
            var favItemAdmin3 = new FavoritesItem(favAdmin.Id, alquimista.Id);
            var favItemJoao1  = new FavoritesItem(favJoao.Id,  memorias.Id);
            var favItemJoao2  = new FavoritesItem(favJoao.Id,  apaixao.Id);

            await context.FavoritesItems.AddRangeAsync(favItemAdmin1, favItemAdmin2, favItemAdmin3, favItemJoao1, favItemJoao2);
            await context.SaveChangesAsync();

            var libAdmin = new Library(admin.Id);
            var libJoao  = new Library(joao.Id);

            await context.Libraries.AddRangeAsync(libAdmin, libJoao);
            await context.SaveChangesAsync();

            var libItemAdmin1 = new LibraryItem(libAdmin.Id, domCasmurro.Id);
            var libItemAdmin2 = new LibraryItem(libAdmin.Id, alquimista.Id);
            var libItemJoao1  = new LibraryItem(libJoao.Id,  gabriela.Id);
            var libItemJoao2  = new LibraryItem(libJoao.Id,  capitaes.Id);
            var libItemJoao3  = new LibraryItem(libJoao.Id,  memorias.Id);

            await context.LibraryItems.AddRangeAsync(libItemAdmin1, libItemAdmin2, libItemJoao1, libItemJoao2, libItemJoao3);
            await context.SaveChangesAsync();

            // --- Sales ---
            var saleCompleted = new Sale(joao.Id, livrariaCultura.Id);
            await context.Sales.AddAsync(saleCompleted);
            await context.SaveChangesAsync();

            var saleItem1 = new SaleItem(saleCompleted.Id, domCasmurro.Id, 1, 39.90m);
            var saleItem2 = new SaleItem(saleCompleted.Id, alquimista.Id,  2, 42.90m);

            await context.SaleItems.AddRangeAsync(saleItem1, saleItem2);
            await context.SaveChangesAsync();

            var salePending = new Sale(admin.Id, saraiva.Id);
            await context.Sales.AddAsync(salePending);
            await context.SaveChangesAsync();

            var saleItem3 = new SaleItem(salePending.Id, ensaioSobre.Id,   1, 54.90m);
            var saleItem4 = new SaleItem(salePending.Id, horaDaEstrela.Id, 1, 29.90m);

            await context.SaleItems.AddRangeAsync(saleItem3, saleItem4);
            await context.SaveChangesAsync();
            }

            await SeedNewGenresAsync(context);
        }

        private static async Task SeedNewGenresAsync(AppDbContext context)
        {
            if (await context.Categories.AnyAsync(c => c.Description == "Terror"))
                return;

            // --- New Categories ---
            var terror      = new Category("Terror");
            var investigacao = new Category("Investigação");
            var ficcao      = new Category("Ficção Científica");

            await context.Categories.AddRangeAsync(terror, investigacao, ficcao);
            await context.SaveChangesAsync();

            // --- New Authors ---
            var king    = new Author("Stephen King",      "Mestre do terror moderno, com mais de 60 romances publicados. Um dos autores mais vendidos de todos os tempos.",              new DateTime(1947, 9, 21, 0, 0, 0, DateTimeKind.Utc));
            var christie = new Author("Agatha Christie",  "Rainha do Crime. Autora britânica criadora de Hercule Poirot e Miss Marple, com mais de 60 romances policiais.",             new DateTime(1890, 9, 15, 0, 0, 0, DateTimeKind.Utc));
            var doyle   = new Author("Arthur Conan Doyle","Escritor escocês criador do detetive Sherlock Holmes, um dos personagens mais famosos da literatura universal.",              new DateTime(1859, 5, 22, 0, 0, 0, DateTimeKind.Utc));
            var orwell  = new Author("George Orwell",     "Escritor britânico autor de obras distópicas que denunciam o totalitarismo e a manipulação da linguagem pelo poder.",         new DateTime(1903, 6, 25, 0, 0, 0, DateTimeKind.Utc));
            var huxley  = new Author("Aldous Huxley",     "Escritor britânico, autor de Admirável Mundo Novo, uma das distopias mais influentes do século XX.",                         new DateTime(1894, 7, 26, 0, 0, 0, DateTimeKind.Utc));
            var stoker  = new Author("Bram Stoker",       "Escritor irlandês autor de Drácula, obra que definiu o arquétipo do vampiro na cultura popular.",                            new DateTime(1847, 11, 8, 0, 0, 0, DateTimeKind.Utc));
            var shelley = new Author("Mary Shelley",      "Escritora britânica autora de Frankenstein, considerada a mãe da ficção científica moderna.",                                new DateTime(1797, 8, 30, 0, 0, 0, DateTimeKind.Utc));
            var eco     = new Author("Umberto Eco",       "Filósofo e escritor italiano. Seu O Nome da Rosa combina investigação policial com erudição histórica medieval.",            new DateTime(1932, 1,  5, 0, 0, 0, DateTimeKind.Utc));

            await context.Authors.AddRangeAsync(king, christie, doyle, orwell, huxley, stoker, shelley, eco);
            await context.SaveChangesAsync();

            // --- New Publishers ---
            var darkside     = new Publisher("Darkside Books",     "Brasil", "www.darksidebooks.com.br");
            var lpm          = new Publisher("L&PM Editores",      "Brasil", "www.lpm.com.br");
            var harperCollins = new Publisher("HarperCollins Brasil", "Brasil", "www.harpercollins.com.br");

            // Reusar editoras existentes onde aplicável
            var companhia = await context.Publishers.FirstAsync(p => p.Name == "Companhia das Letras");
            var record    = await context.Publishers.FirstAsync(p => p.Name == "Editora Record");

            await context.Publishers.AddRangeAsync(darkside, lpm, harperCollins);
            await context.SaveChangesAsync();

            // --- Ficção ---
            var mil984           = new Book("1984",                           "Em um futuro distópico, o Grande Irmão controla tudo e todos. Winston Smith ousa questionar o sistema em uma das mais importantes ficções políticas já escritas.",         new DateTime(1949, 6,  8, 0, 0, 0, DateTimeKind.Utc), 336, ficcao.Id,       orwell.Id,   companhia.Id);
            var revolucao        = new Book("A Revolução dos Bichos",         "Alegoria política sobre a corrupção do poder, narrada por animais de uma fazenda que tomam o controle da propriedade de seus donos.",                                       new DateTime(1945, 8, 17, 0, 0, 0, DateTimeKind.Utc), 120, ficcao.Id,       orwell.Id,   companhia.Id);
            var admiravel        = new Book("Admirável Mundo Novo",           "Sociedade futurista controlada pelo prazer e pela engenharia genética, onde a liberdade individual foi abolida em prol da estabilidade coletiva.",                          new DateTime(1932, 1,  1, 0, 0, 0, DateTimeKind.Utc), 311, ficcao.Id,       huxley.Id,   companhia.Id);

            // --- Terror ---
            var it               = new Book("It — A Coisa",                   "Sete crianças de Derry são aterrorizadas por uma entidade maligna que assume a forma dos piores medos de cada um. Décadas depois, o mal retorna.",                          new DateTime(1986, 9, 15, 0, 0, 0, DateTimeKind.Utc), 1104, terror.Id,      king.Id,     darkside.Id);
            var oIluminado       = new Book("O Iluminado",                    "Jack Torrance leva a família para passar o inverno no isolado Hotel Overlook. A loucura e as forças sobrenaturais do local transformam o que deveria ser um retiro em pesadelo.", new DateTime(1977, 1, 28, 0, 0, 0, DateTimeKind.Utc), 464, terror.Id,      king.Id,     darkside.Id);
            var misery           = new Book("Misery",                         "O escritor Paul Sheldon é resgatado de um acidente de carro por Annie Wilkes, sua fã mais obcecada, que o mantém prisioneiro e exige que ele ressuscite sua personagem favorita.", new DateTime(1987, 6,  8, 0, 0, 0, DateTimeKind.Utc), 340, terror.Id,      king.Id,     darkside.Id);
            var dracula          = new Book("Drácula",                        "O Conde Drácula, vampiro da Transilvânia, planeja se mudar para a Inglaterra. Jonathan Harker e seus amigos enfrentam a criatura imortal em uma batalha entre o bem e o mal.", new DateTime(1897, 5, 26, 0, 0, 0, DateTimeKind.Utc), 453, terror.Id,      stoker.Id,   lpm.Id);
            var frankenstein     = new Book("Frankenstein",                   "O Dr. Victor Frankenstein cria vida a partir de partes de cadáveres. O monstro abandondado pelo criador busca vingança em um clássico sobre os limites da ciência.",          new DateTime(1818, 1,  1, 0, 0, 0, DateTimeKind.Utc), 280, terror.Id,      shelley.Id,  lpm.Id);

            // --- Investigação ---
            var expressoOriente  = new Book("Assassinato no Expresso do Oriente", "Hercule Poirot está a bordo do lendário trem quando um passageiro é encontrado morto. Todos são suspeitos neste enigma com uma reviravolta inesquecível.",              new DateTime(1934, 1,  1, 0, 0, 0, DateTimeKind.Utc), 256, investigacao.Id, christie.Id, harperCollins.Id);
            var naoSobrouNenhum  = new Book("E Não Sobrou Nenhum",            "Dez desconhecidos são convidados para uma ilha isolada. Um a um começam a morrer, sem deixar pistas sobre quem é o assassino — talvez um deles próprios.",                  new DateTime(1939, 11, 6, 0, 0, 0, DateTimeKind.Utc), 248, investigacao.Id, christie.Id, harperCollins.Id);
            var caoDeBaskerville = new Book("O Cão dos Baskervilles",         "Sherlock Holmes e Dr. Watson investigam uma maldição ancestral sobre a família Baskerville e uma criatura sobrenatural que assombra os pântanos de Dartmoor.",               new DateTime(1902, 4,  1, 0, 0, 0, DateTimeKind.Utc), 192, investigacao.Id, doyle.Id,    lpm.Id);
            var estudoEmVermelho = new Book("Um Estudo em Vermelho",          "O primeiro encontro entre Sherlock Holmes e o Dr. Watson. Juntos investigam um assassinato misterioso sem nenhuma causa aparente nas ruas de Londres.",                       new DateTime(1887, 11, 1, 0, 0, 0, DateTimeKind.Utc), 152, investigacao.Id, doyle.Id,    lpm.Id);
            var nomeRosa         = new Book("O Nome da Rosa",                 "O frade Guilherme de Baskerville chega a uma abadia medieval onde monges estão sendo assassinados. Uma investigação que une lógica, teologia e mistério.",                    new DateTime(1980, 1,  1, 0, 0, 0, DateTimeKind.Utc), 592, investigacao.Id, eco.Id,      record.Id);

            await context.Books.AddRangeAsync(
                mil984, revolucao, admiravel,
                it, oIluminado, misery, dracula, frankenstein,
                expressoOriente, naoSobrouNenhum, caoDeBaskerville, estudoEmVermelho, nomeRosa);
            await context.SaveChangesAsync();

            // --- Stock dos novos livros nas lojas existentes ---
            var stockCultura = await context.Stocks
                .Include(s => s.Seller)
                .FirstAsync(s => s.Seller.Name == "Livraria Cultura");

            var stockSaraiva = await context.Stocks
                .Include(s => s.Seller)
                .FirstAsync(s => s.Seller.Name == "Saraiva Livraria");

            var newStockItems = new List<StockItem>
            {
                // Livraria Cultura — ficção e terror
                new StockItem(stockCultura.Id, mil984.Id,           45, 44.90m),
                new StockItem(stockCultura.Id, revolucao.Id,        60, 29.90m),
                new StockItem(stockCultura.Id, it.Id,               20, 89.90m),
                new StockItem(stockCultura.Id, oIluminado.Id,       25, 54.90m),
                new StockItem(stockCultura.Id, misery.Id,           30, 49.90m),
                new StockItem(stockCultura.Id, dracula.Id,          35, 39.90m),
                new StockItem(stockCultura.Id, frankenstein.Id,     40, 34.90m),
                new StockItem(stockCultura.Id, expressoOriente.Id,  50, 44.90m),
                new StockItem(stockCultura.Id, naoSobrouNenhum.Id,  45, 42.90m),

                // Saraiva — investigação e terror
                new StockItem(stockSaraiva.Id, admiravel.Id,        30, 47.90m),
                new StockItem(stockSaraiva.Id, it.Id,               15, 89.90m),
                new StockItem(stockSaraiva.Id, oIluminado.Id,       20, 54.90m),
                new StockItem(stockSaraiva.Id, caoDeBaskerville.Id, 35, 34.90m),
                new StockItem(stockSaraiva.Id, estudoEmVermelho.Id, 40, 29.90m),
                new StockItem(stockSaraiva.Id, nomeRosa.Id,         18, 59.90m),
                new StockItem(stockSaraiva.Id, dracula.Id,          22, 39.90m),
                new StockItem(stockSaraiva.Id, frankenstein.Id,     28, 34.90m),
            };

            await context.StockItems.AddRangeAsync(newStockItems);
            await context.SaveChangesAsync();
        }
    }
}
