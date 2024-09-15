using APIAmbiental.Models;

namespace APIAmbiental.Services
{
    public interface ICondicoesAmbientaisService
    {

        IEnumerable<CondicoesAmbientaisModel> ListarCondicoesAmbientais();

        IEnumerable<CondicoesAmbientaisModel> ListarCondicoesAmbientais(int pagina = 0, int tamanho = 10);

        CondicoesAmbientaisModel ObterCondicoesAmbientaisPorID(int id);

        void CadastrarCondicoesAmbientais(CondicoesAmbientaisModel condicoesAmbientaisModel);
        void AtualizarCondicoesAmbientais(CondicoesAmbientaisModel condicoesAmbientaisModel);
        void DeletarCondicoesAmbientais(int id);
    }
}
