using Microsoft.AspNetCore.Components;

namespace Acervo.Web.Components.Pages
{
    public partial class Autores
    {
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        private record AuthorVm(long Id, string Name, string? Biography, int BookCount);

        private string SearchQuery { get; set; } = string.Empty;
        private char? SelectedLetter { get; set; }

        private static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private List<AuthorVm> AllAuthors { get; } = new()
        {
            new(1,  "Isaac Asimov",           "Mestre da ficção científica, autor de Fundação e Eu, Robô.", 12),
            new(2,  "George Orwell",           "Escritor britânico conhecido por 1984 e A Revolução dos Bichos.", 6),
            new(3,  "Frank Herbert",           "Criador do universo épico de Duna.", 8),
            new(4,  "J.R.R. Tolkien",          "Pai da fantasia moderna, criador da Terra Média.", 5),
            new(5,  "Machado de Assis",        "Maior escritor brasileiro, fundador da Academia Brasileira de Letras.", 20),
            new(6,  "Franz Kafka",             "Escritor tcheco de obras sombrias e metafóricas.", 7),
            new(7,  "Gabriel García Márquez",  "Nobel de Literatura, pai do realismo mágico.", 10),
            new(8,  "Margaret Atwood",         "Autora canadense de O Conto da Aia.", 14),
            new(9,  "Clarice Lispector",       "Uma das mais importantes escritoras brasileiras do século XX.", 11),
            new(10, "Dostoiévski",             "Mestre da psicologia humana na literatura russa.", 9),
        };

        private List<AuthorVm> FilteredAuthors { get; set; } = new();

        protected override void OnInitialized() => FilterAuthors();

        private void FilterAuthors()
        {
            var q = SearchQuery.Trim().ToLowerInvariant();
            FilteredAuthors = AllAuthors
                .Where(a => (string.IsNullOrEmpty(q) || a.Name.Contains(q, StringComparison.OrdinalIgnoreCase))
                         && (SelectedLetter == null || char.ToUpperInvariant(a.Name[0]) == SelectedLetter))
                .OrderBy(a => a.Name)
                .ToList();
        }

        private void SetLetter(char? letter)
        {
            SelectedLetter = letter;
            FilterAuthors();
        }

        private static string GetInitials(string name)
        {
            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length >= 2
                ? $"{parts[0][0]}{parts[^1][0]}"
                : name[..1].ToUpperInvariant();
        }

        private static string TruncateBio(string? bio) =>
            string.IsNullOrWhiteSpace(bio) ? "Autor do acervo."
            : bio.Length > 80 ? bio[..80] + "…"
            : bio;
    }
}
