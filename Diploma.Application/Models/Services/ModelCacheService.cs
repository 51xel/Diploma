using Diploma.Application.Models.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Models.Services
{
    internal class ModelCacheService : IModelCacheService
    {
        private readonly IModelCacheRepository _modelsCacheRepository;
        private readonly IModelFileRepository _modelFileRepository;

        public ModelCacheService(
            IModelFileRepository modelFileRepository,
            IModelCacheRepository modelsCacheRepository)
        {
            _modelFileRepository = modelFileRepository;
            _modelsCacheRepository = modelsCacheRepository;
        }

        public async Task<MemoryStream?> GetOrCreateModelStreamAsync(Model model)
        {
            if (_modelsCacheRepository.TryGetModel(model.Id, out MemoryStream? modelStream))
            {
                return modelStream;
            }

            modelStream = await _modelFileRepository.GetModelAsync(model.Name);

            if (modelStream == null)
            {
                return null;
            }

            _modelsCacheRepository.CreateModel(model.Id, modelStream);

            return modelStream;
        }
    }
}
