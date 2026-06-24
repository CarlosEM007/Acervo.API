using Microsoft.AspNetCore.Components;

namespace Acervo.Web.Components.Pages
{
    public partial class DetalhesLivro
    {
        [Parameter] public long Id { get; set; }
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        // ── Estado ─────────────────────────────────────────────────
        private bool IsLoading { get; set; } = true;
        private bool IsFavorite { get; set; } = false;
        private bool DescExpanded { get; set; } = false;
        private string? FeedbackMessage { get; set; }
        private bool FeedbackSuccess { get; set; }

        // ── Modelo de view ─────────────────────────────────────────
        private record BookDetailVm(
            long Id, string Title, string Description, int PagesNumber, DateTime Release,
            string? CoverImageUrl, string CategoryName, string CategorySlug,
            long AuthorId, string AuthorName, string PublisherName,
            decimal Price, decimal? OriginalPrice);

        private BookDetailVm? Book { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            IsLoading = true;
            await LoadBook();
            IsLoading = false;
        }

        private async Task LoadBook()
        {
            // Substituir pela chamada ao serviço real
            await Task.Delay(300);

            Book = Id switch
            {
                1 => new(1, "Fundação",
                    "Em Fundação, Isaac Asimov apresenta Hari Seldon, um matemático que usa a psico-história para prever o colapso do Império Galáctico e planeja uma enciclopédia para salvar o conhecimento humano. A série se desdobra em séculos de política, ciência e sobrevivência numa galáxia caótica. É uma das obras mais influentes da ficção científica, explorando como a humanidade pode planejar seu próprio destino em escala civilizacional.",
                    376, new DateTime(1951, 6, 1), null,
                    "Ficção Científica", "ficcao-cientifica",
                    1, "Isaac Asimov", "Aleph", 39.90m, null),

                2 => new(2, "1984",
                    "1984 é uma distopia sombria de George Orwell que retrata um futuro totalitário onde o Partido controla cada aspecto da vida humana. Winston Smith trabalha no Ministério da Verdade reescrevendo registros históricos e começa a questionar o sistema — uma decisão perigosa num mundo de vigilância constante e pensamento policiado.",
                    328, new DateTime(1949, 6, 8), null,
                    "Ficção", "ficcao",
                    2, "George Orwell", "Companhia das Letras", 34.90m, 44.90m),

                _ => null
            };
        }

        private async Task AddToCart()
        {
            if (Book is null) return;

            // Substituir pela chamada ao serviço de carrinho
            await Task.Delay(200);

            FeedbackMessage = $"«{Book.Title}» adicionado ao carrinho!";
            FeedbackSuccess = true;
            StateHasChanged();

            await Task.Delay(3000);
            FeedbackMessage = null;
            StateHasChanged();
        }

        private async Task ToggleFavorite()
        {
            if (Book is null) return;

            // Substituir pela chamada ao serviço de favoritos
            await Task.Delay(150);

            IsFavorite = !IsFavorite;
            FeedbackMessage = IsFavorite
                ? $"«{Book.Title}» adicionado aos favoritos!"
                : $"«{Book.Title}» removido dos favoritos.";
            FeedbackSuccess = IsFavorite;
            StateHasChanged();

            await Task.Delay(3000);
            FeedbackMessage = null;
            StateHasChanged();
        }
    }
}
