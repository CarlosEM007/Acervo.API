using Microsoft.AspNetCore.Components;

namespace Acervo.Web.Components.Pages
{
    public partial class Catalogo
    {
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        // ── Estado de UI ───────────────────────────────────────────
        private bool IsLoading { get; set; } = false;
        private bool FiltersOpen { get; set; } = false;
        private string ViewMode { get; set; } = "grid";

        // ── Filtros ────────────────────────────────────────────────
        private string SearchQuery { get; set; } = string.Empty;
        private List<long> SelectedCategories { get; set; } = new();
        private string? PriceMin { get; set; }
        private string? PriceMax { get; set; }
        private string SelectedSort { get; set; } = "lancamento";

        // ── Paginação ──────────────────────────────────────────────
        private int CurrentPage { get; set; } = 1;
        private int PageSize { get; set; } = 16;
        private int TotalPages => (int)Math.Ceiling((double)TotalBooks / PageSize);
        private int TotalBooks { get; set; } = 0;

        // ── Opções de ordenação ────────────────────────────────────
        private List<(string value, string label)> SortOptions { get; } = new()
        {
            ("lancamento",  "Lançamento"),
            ("titulo",      "Título (A–Z)"),
            ("titulo-desc", "Título (Z–A)"),
            ("preco-asc",   "Menor preço"),
            ("preco-desc",  "Maior preço"),
        };

        // ── Modelos de view ────────────────────────────────────────
        private record BookVm(long Id, string Title, string AuthorName, string CategoryName,
            string Description, decimal Price, string? CoverImageUrl);

        private record CategoryFilterVm(long Id, string Description, int Count);

        // ── Dados ──────────────────────────────────────────────────
        private List<CategoryFilterVm> AvailableCategories { get; set; } = new()
        {
            new(1, "Ficção Científica", 312),
            new(2, "Fantasia",          278),
            new(3, "Romance",           445),
            new(4, "Suspense",          189),
            new(5, "Biografia",         134),
            new(6, "Autoajuda",         221),
        };

        private List<BookVm> AllBooks { get; set; } = new()
        {
            new(1, "Fundação", "Isaac Asimov", "Ficção Científica",
                "A história de uma galáxia à beira do colapso e o homem que tentou salvar a civilização.", 39.90m, null),
            new(2, "1984", "George Orwell", "Ficção",
                "Uma distopia sombria sobre vigilância total, controle e resistência humana.", 34.90m, null),
            new(3, "Duna", "Frank Herbert", "Ficção Científica",
                "Uma saga épica em um planeta desértico onde especiaria é o recurso mais valioso do universo.", 49.90m, null),
            new(4, "O Senhor dos Anéis", "J.R.R. Tolkien", "Fantasia",
                "A jornada épica de Frodo para destruir o Um Anel e salvar a Terra Média.", 89.90m, null),
            new(5, "Dom Casmurro", "Machado de Assis", "Literatura",
                "A clássica história de Bentinho e Capitu, marcada pela dúvida e ciúme.", 24.90m, null),
            new(6, "A Metamorfose", "Franz Kafka", "Literatura",
                "Gregor Samsa acorda transformado em um inseto monstruoso — e sua família reage.", 19.90m, null),
            new(7, "Cem Anos de Solidão", "Gabriel García Márquez", "Romance",
                "A saga da família Buendía ao longo de sete gerações em Macondo.", 44.90m, null),
            new(8, "O Hobbit", "J.R.R. Tolkien", "Fantasia",
                "Bilbo Bolseiro parte em uma aventura inesperada com um grupo de anões.", 39.90m, null),
        };

        private List<BookVm> FilteredBooks { get; set; } = new();

        protected override void OnInitialized()
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var q = SearchQuery?.Trim().ToLowerInvariant() ?? "";

            var result = AllBooks.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(q))
                result = result.Where(b =>
                    b.Title.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    b.AuthorName.Contains(q, StringComparison.OrdinalIgnoreCase));

            if (decimal.TryParse(PriceMin, out var min))
                result = result.Where(b => b.Price >= min);

            if (decimal.TryParse(PriceMax, out var max))
                result = result.Where(b => b.Price <= max);

            result = SelectedSort switch
            {
                "titulo"      => result.OrderBy(b => b.Title),
                "titulo-desc" => result.OrderByDescending(b => b.Title),
                "preco-asc"   => result.OrderBy(b => b.Price),
                "preco-desc"  => result.OrderByDescending(b => b.Price),
                _             => result
            };

            var list = result.ToList();
            TotalBooks = list.Count;
            CurrentPage = 1;
            FilteredBooks = list.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }

        private void GoToPage(int page)
        {
            if (page < 1 || page > TotalPages) return;
            CurrentPage = page;
            FilteredBooks = AllBooks
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        private void ToggleCategory(long id, bool selected)
        {
            if (selected) SelectedCategories.Add(id);
            else SelectedCategories.Remove(id);
        }

        private void ClearFilters()
        {
            SearchQuery = string.Empty;
            SelectedCategories.Clear();
            PriceMin = null;
            PriceMax = null;
            SelectedSort = "lancamento";
            ApplyFilters();
        }
    }
}
