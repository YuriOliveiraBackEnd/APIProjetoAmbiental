using APIAmbiental.Data.Contexts;
using APIAmbiental.Data.Repository;
using APIAmbiental.Models;

namespace APIAmbiental.Services
{
    public class CondicoesAmbientaisService : ICondicoesAmbientaisService
    {
        private readonly ICondicoesAmbientaisRepository _repository;

        public CondicoesAmbientaisService(ICondicoesAmbientaisRepository repository)
        {
            _repository = repository;
        }

        public void CadastrarCondicoesAmbientais(CondicoesAmbientaisModel condicoesAmbientaisModel) => _repository.Add(condicoesAmbientaisModel);
        public void AtualizarCondicoesAmbientais(CondicoesAmbientaisModel condicoesAmbientaisModel) => _repository.Update(condicoesAmbientaisModel);
        public void DeletarCondicoesAmbientais(int id)
        {
            var condicoesambientais = _repository.GetById(id);
            if (condicoesambientais != null)
            {
                _repository.Delete(condicoesambientais);
            }
        }

        public IEnumerable<CondicoesAmbientaisModel> ListarCondicoesAmbientais() => _repository.GetALL();

        public IEnumerable<CondicoesAmbientaisModel> ListarCondicoesAmbientais(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public CondicoesAmbientaisModel ObterCondicoesAmbientaisPorID(int id) => _repository.GetById(id);
    }
}
