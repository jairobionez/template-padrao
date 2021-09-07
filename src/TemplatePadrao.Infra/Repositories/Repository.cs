using Ecrednet.Infra.Data.Context;
using TemplatePadrao.Core.Entities;

namespace TemplatePadrao.Infra.Repositories
{
    public class Repository<TEntity> where TEntity: EntityBase
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
    }
}
