namespace APIAmbiental.ViewModel
{
    public class CondicoesAmbientaisPaginacaoViewModel
    {
        public IEnumerable<CondicoesAmbientaisViewModel> CondicoesAmbientais { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CondicoesAmbientais.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/api/Ambiental?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/api/Ambiental?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}
