using APIAmbiental.Data.Contexts;
using APIAmbiental.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAmbiental.Data.Repository
{


    public class CondicoesAmbientaisRepository : ICondicoesAmbientaisRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CondicoesAmbientaisRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        
        public void Add(CondicoesAmbientaisModel condicoesAmbientaisModel)
        {
            _databaseContext.CondicoesAmbientais.Add(condicoesAmbientaisModel);
            _databaseContext.SaveChanges();
        }

        public void Delete(CondicoesAmbientaisModel condicoesAmbientaisModel)
        {
            _databaseContext.CondicoesAmbientais.Remove(condicoesAmbientaisModel);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<CondicoesAmbientaisModel> GetALL()
        {
            return _databaseContext.CondicoesAmbientais.ToList(); ;
        }
        public IEnumerable<CondicoesAmbientaisModel> GetAll(int page, int size)
        {
            return _databaseContext.CondicoesAmbientais
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }
        public CondicoesAmbientaisModel GetById(int id)
        {
            return _databaseContext.CondicoesAmbientais.Find(id);
        }

        public void Update(CondicoesAmbientaisModel condicoesAmbientaisModel)
        {
            _databaseContext.CondicoesAmbientais.Update(condicoesAmbientaisModel);
            _databaseContext.SaveChanges();
        }
    }
}
