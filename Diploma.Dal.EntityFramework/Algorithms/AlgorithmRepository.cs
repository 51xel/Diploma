using Diploma.Application.Algotihms.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Algorithms;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Algorithms
{
    class AlgorithmRepository : IAlgorithmRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AlgorithmRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Algorithm>> GetAlgorithmsAsync()
        {
            return await _applicationDbContext.Algorithms.ToListAsync();
        }
    }
}
