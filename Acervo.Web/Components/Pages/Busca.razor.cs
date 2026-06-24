using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Acervo.Web.Components.Pages
{
    public partial class Busca
    {
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        private string Query { get; set; } = string.Empty;
        private bool IsLoading { get; set; } = false;

        private record BookVm(long Id, string Title, string AuthorName, string CategoryName, decimal Price);

        private List<BookVm> AllBooks { get; } = new()
        {
            new(1, "Fundação",              "Isaac Asimov",              "Ficção Científica", 39.90m),
            new(2, "1984",                  "George Orwell",             "Ficção",            34.90m),
            new(3, "Duna",                  "Frank Herbert",             "Ficção Científica", 49.90m),
            new(4, "O Senhor dos Anéis",    "J.R.R. Tolkien",            "Fantasia",          89.90m),
            new(5, "Dom Casmurro",          "Machado de Assis",          "Literatura",        24.90m),
            new(6, "A Metamorfose",         "Franz Kafka",               "Literatura",        19.90m),
            new(7, "Cem Anos de Solidão",   "Gabriel García Márquez",    "Romance",           44.90m),
            new(8, "O Hobbit",              "J.R.R. Tolkien",            "Fantasia",          39.90m),
            new(9, "O Conto da Aia",        "Margaret Atwood",           "Ficção Científica", 42.90m),
        };

        private List<BookVm> Results { get; set; } = new();

        protected override void OnInitialized()
        {
            var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("q", out var q))
            {
                Query = q!;
                RunSearch();
            }
        }

        private void RunSearch()
        {
            if (string.IsNullOrWhiteSpace(Query))
            {
                Results.Clear();
                return;
            }

            var term = Query.Trim().ToLowerInvariant();
            Results = AllBooks
                .Where(b =>
                    b.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    b.AuthorName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    b.CategoryName.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
