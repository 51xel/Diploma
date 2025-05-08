using Diploma.Application.Models.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Models
{
    class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ModelRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Model?> GetAsync(Guid modelId, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Models.FirstOrDefaultAsync(x => x.Id == modelId, cancellationToken);
        }
    }
}
