using Microsoft.AspNetCore.Components;

namespace Acervo.Web.Components.Pages
{
    public partial class Categorias
    {
        [Inject] private NavigationManager Navigation { get; set; } = default!;

        private record CategoryVm(string Name, string Icon, string Slug, string Description, int Count);

        private List<CategoryVm> Categories { get; } = new()
        {
            new("Ficção Científica", "🚀", "ficcao-cientifica", "Universos distantes, tecnologia e o futuro da humanidade.", 312),
            new("Fantasia",          "🧙", "fantasia",          "Mundos mágicos, criaturas extraordinárias e heróis épicos.", 278),
            new("Romance",           "💛", "romance",           "Histórias de amor, relacionamentos e emoções humanas.", 445),
            new("Suspense",          "🔍", "suspense",          "Mistérios, thrillers e narrativas de arrepiar.", 189),
            new("Biografia",         "📜", "biografia",         "Vidas reais que inspiraram o mundo.", 134),
            new("Autoajuda",         "✨", "autoajuda",         "Desenvolvimento pessoal, produtividade e bem-estar.", 221),
            new("História",          "🏛️", "historia",          "Do passado ao presente, eventos que moldaram o mundo.", 156),
            new("Literatura",        "📚", "literatura",        "Clássicos e obras fundamentais da escrita universal.", 398),
            new("Psicologia",        "🧠", "psicologia",        "Comportamento humano, mente e saúde mental.", 112),
            new("Filosofia",         "🤔", "filosofia",         "Grandes questões da existência, ética e pensamento.", 98),
            new("Infantil",          "🎈", "infantil",          "Histórias encantadoras para os leitores mais jovens.", 267),
            new("Culinária",         "🍳", "culinaria",         "Receitas, técnicas e a arte da gastronomia.", 143),
        };
    }
}
