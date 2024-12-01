using DapperExtensions.Mapper;
using System.Reflection;

namespace LocacaoMoto.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TMap> 
        where TMap : ClassMapper<TMap>
    {
        public RepositoryBase()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(TMap).Assembly });
        }
    }
}
