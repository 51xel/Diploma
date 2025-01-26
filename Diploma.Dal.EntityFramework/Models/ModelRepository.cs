using Diploma.Application.Models.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Models
{
    internal class ModelRepository : IModelRepository
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public ModelRepository(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task<Model?> GetAsync(Guid modelId)
        {
            return await _cosmosDbContext.Models.FirstOrDefaultAsync(x => x.Id == modelId);
        }
    }
}
