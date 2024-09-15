using APIAmbiental.Models;

namespace APIAmbiental.Data.Repository
{
    public interface ICondicoesAmbientaisRepository
    {
        IEnumerable<CondicoesAmbientaisModel> GetALL();

        IEnumerable<CondicoesAmbientaisModel> GetAll(int page, int size);
        CondicoesAmbientaisModel GetById(int id);

        void Add(CondicoesAmbientaisModel condicoesAmbientaisModel);
        void Update(CondicoesAmbientaisModel condicoesAmbientaisModel);
        void Delete(CondicoesAmbientaisModel condicoesAmbientaisModel);


    }
}
