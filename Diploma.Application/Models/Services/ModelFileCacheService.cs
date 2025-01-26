using Diploma.Application.Models.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Models.Services
{
    internal class ModelFileCacheService : IModelFileCacheService
    {
        private readonly IModelFileCacheRepository _modelFileCacheRepository;
        private readonly IModelFileRepository _modelFileRepository;

        public ModelFileCacheService(
            IModelFileRepository modelFileRepository,
            IModelFileCacheRepository modelsCacheRepository)
        {
            _modelFileRepository = modelFileRepository;
            _modelFileCacheRepository = modelsCacheRepository;
        }

        public async Task<MemoryStream?> GetOrAddAsync(Model model)
        {
            var modelFile = await _modelFileCacheRepository.GetAsync(model.Id);

            if (modelFile is not null)
            {
                return modelFile;
            }

            modelFile = await _modelFileRepository.GetAsync(model.Name);

            if (modelFile is null)
            {
                return null;
            }

            //TODO speed up?
            await _modelFileCacheRepository.SaveAsync(model.Id, modelFile);

            return modelFile;
        }
    }
}
