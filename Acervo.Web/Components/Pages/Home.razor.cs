using Microsoft.AspNetCore.Components;

namespace Acervo.Web.Components.Pages
{
    public partial class Home
    {
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        private record BookVm(long Id, string Title, string AuthorName, string CategoryName,
            decimal Price, decimal? OriginalPrice, string? CoverImageUrl);

        private record CategoryVm(string Name, string Icon, string Slug, int Count);

        private List<CategoryVm> FeaturedCategories { get; set; } = new()
        {
            new("Ficção Científica", "fa-solid fa-rocket",       "ficcao-cientifica", 312),
            new("Fantasia",          "fa-solid fa-hat-wizard",   "fantasia",          278),
            new("Romance",           "fa-solid fa-heart",        "romance",           445),
            new("Suspense",          "fa-solid fa-magnifying-glass", "suspense",      189),
            new("Biografia",         "fa-solid fa-scroll",       "biografia",         134),
            new("Autoajuda",         "fa-solid fa-star",         "autoajuda",         221),
            new("História",          "fa-solid fa-landmark",     "historia",          156),
            new("Literatura",        "fa-solid fa-book",         "literatura",        398),
        };

        private List<BookVm> NewReleases { get; set; } = new()
        {
            new(1, "Fundação", "Isaac Asimov", "Ficção Científica", 39.90m, null, null),
            new(2, "1984", "George Orwell", "Ficção", 34.90m, 44.90m, null),
            new(3, "Duna", "Frank Herbert", "Ficção Científica", 49.90m, null, null),
            new(4, "O Senhor dos Anéis", "J.R.R. Tolkien", "Fantasia", 89.90m, 109.90m, null),
        };

        private List<BookVm> BestSellers { get; set; } = new()
        {
            new(5, "Dom Casmurro", "Machado de Assis", "Literatura", 24.90m, null, null),
            new(6, "A Metamorfose", "Franz Kafka", "Literatura", 19.90m, 29.90m, null),
            new(7, "Cem Anos de Solidão", "Gabriel García Márquez", "Romance", 44.90m, null, null),
            new(8, "O Hobbit", "J.R.R. Tolkien", "Fantasia", 39.90m, 49.90m, null),
        };
    }
}
