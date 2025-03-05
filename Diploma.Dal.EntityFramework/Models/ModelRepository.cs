using Diploma.Application.Models.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Models
{
    internal class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _cosmosDbContext;

        public ModelRepository(ApplicationDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task<Model?> GetAsync(Guid modelId, CancellationToken cancellationToken)
        {
            return await _cosmosDbContext.Models.FirstOrDefaultAsync(x => x.Id == modelId, cancellationToken);
        }
    }
}
