using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Acervo.Web.Components.Shared
{
    public class AppButtonBase : ComponentBase
    {
        // ── Identificação ──────────────────────────────────────────────
        [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8];

        // ── Conteúdo ───────────────────────────────────────────────────
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public RenderFragment? LeadingIcon { get; set; }
        [Parameter] public RenderFragment? TrailingIcon { get; set; }

        // ── Tipo HTML ─────────────────────────────────────────────────
        /// <summary>button | submit | reset</summary>
        [Parameter] public string Type { get; set; } = "button";

        // ── Variante visual ───────────────────────────────────────────
        /// <summary>primary | secondary | outline | ghost | danger</summary>
        [Parameter] public string Variant { get; set; } = "primary";

        // ── Tamanho ───────────────────────────────────────────────────
        /// <summary>sm | md | lg</summary>
        [Parameter] public string Size { get; set; } = "md";

        // ── Dimensões personalizadas ──────────────────────────────────
        /// <summary>Largura customizada. Ex: "200px", "100%", "12rem"</summary>
        [Parameter] public string? Width { get; set; }

        /// <summary>Altura customizada. Ex: "48px", "3rem"</summary>
        [Parameter] public string? Height { get; set; }

        // ── Flags de estado ───────────────────────────────────────────
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool FullWidth { get; set; }
        [Parameter] public bool Loading { get; set; }

        /// <summary>Texto exibido enquanto Loading = true</summary>
        [Parameter] public string? LoadingText { get; set; }

        // ── Callback ──────────────────────────────────────────────────
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        // ── Estilo computado ──────────────────────────────────────────
        protected string ButtonStyle
        {
            get
            {
                var parts = new List<string>();
                if (!string.IsNullOrWhiteSpace(Width)) parts.Add($"width:{Width}");
                if (!string.IsNullOrWhiteSpace(Height)) parts.Add($"height:{Height}");
                return parts.Count > 0 ? string.Join(";", parts) + ";" : string.Empty;
            }
        }

        // ── Handler ───────────────────────────────────────────────────
        protected async Task HandleClick(MouseEventArgs e)
        {
            if (Disabled || Loading) return;
            if (OnClick.HasDelegate)
                await OnClick.InvokeAsync(e);
        }
    }
}
